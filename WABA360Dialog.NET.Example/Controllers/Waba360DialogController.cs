using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using WABA360Dialog.ApiClient.Interfaces;
using WABA360Dialog.ApiClient.Payloads;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.LocationObjects;
using WABA360Dialog.Common.Enums;

namespace WABA360Dialog.NET.Example.Controllers
{
    [ApiController]
    [Route("/waba/360dialog/[action]")]
    public class Waba360DialogController : ControllerBase
    {
        private readonly ILogger<Waba360DialogController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWABA360DialogApiClient _client;

        public Waba360DialogController(ILogger<Waba360DialogController> logger, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _configuration = configuration;

            var headerWabaApiKey = contextAccessor.HttpContext?.Request.Headers["360DialogChannelApiKey"];
            _client = new WABA360DialogApiClient(!string.IsNullOrWhiteSpace(headerWabaApiKey) ? headerWabaApiKey : _configuration["WABA360Dialog:ChannelApiKey"]);
        }

        [HttpPost]
        public async Task<ActionResult> Webhook()
        {
            var stream = new MemoryStream();
            await HttpContext.Request.Body.CopyToAsync(stream);
            var byteArr = stream.ToArray();

            var payloadString = Encoding.UTF8.GetString(byteArr, 0, byteArr.Length);

            Log.Information($"Webhook:{payloadString}");
            var payload = JsonConvert.DeserializeObject<WABA360DialogWebhookPayload>(payloadString);
            Log.Information($"Contacts: {payload?.Contacts?.Count() ?? 0}, Messages: {payload?.Messages?.Count() ?? 0}.");

            return Ok(payload);
        }
        
        [HttpPost]
        public ActionResult WebhookObject([FromBody] WABA360DialogWebhookPayload webhookPayload)
        {
            return Ok(webhookPayload);
        }

        public record CheckContactRequest(string PhoneNumber);

        [HttpPost]
        public async Task<CheckContactsResponse> CheckContact([FromBody] CheckContactRequest request)
        {
            return await _client.CheckContactsAsync(new[] { request.PhoneNumber }, Blocking.wait);
        }

        public record SendMessageRequest(string WhatsappId, string TextMessage);

        [HttpPost]
        public async Task<SendMessageResponse> SendText([FromBody] SendMessageRequest request)
        {
            return await _client.SendMessageAsync(MessageObjectFactory.CreateTextMessage(request.WhatsappId, request.TextMessage));
        }

        public record SendMediaMessageRequest(string WhatsappId, string Link, string Caption);

        [HttpPost]
        public async Task<SendMessageResponse> SendImage([FromBody] SendMediaMessageRequest request)
        {
            return await _client.SendMessageAsync(MessageObjectFactory.CreateImageMessageByLink(request.WhatsappId, request.Link, request.Caption));
        }

        public record SendDocumentMessageRequest(string WhatsappId, string Link, string Filename, string Caption);

        [HttpPost]
        public async Task<SendMessageResponse> SendDocument([FromBody] SendDocumentMessageRequest request)
        {
            return await _client.SendMessageAsync(MessageObjectFactory.CreateDocumentMessageByLink(request.WhatsappId, request.Filename, request.Link, request.Caption));
        }

        public record SendNoCaptionMediaMessageRequest(string WhatsappId, string Link);

        [HttpPost]
        public async Task<SendMessageResponse> SendSticker([FromBody] SendNoCaptionMediaMessageRequest request)
        {
            return await _client.SendMessageAsync(MessageObjectFactory.CreateStickerMessageByLink(request.WhatsappId, request.Link));
        }

        public record SendTemplateMessageRequest(string WhatsappId, string TemplateNamespace, string TemplateName, WhatsAppLanguage Language, List<TemplateMessageComponentObject> Components);

        [HttpPost]
        public async Task<SendMessageResponse> SendTemplate([FromBody] SendTemplateMessageRequest request)
        {
            return await _client.SendMessageAsync(MessageObjectFactory.CreateTemplateMessage(request.WhatsappId, request.TemplateNamespace, request.TemplateName, request.Language, request.Components));
        }

        public record SendInteractiveMessageRequest(string WhatsappId, InteractiveObject InteractiveObject);

        [HttpPost]
        public async Task<SendMessageResponse> SendInteractive([FromBody] SendInteractiveMessageRequest request)
        {
            return await _client.SendMessageAsync(MessageObjectFactory.CreateInteractiveMessage(request.WhatsappId, request.InteractiveObject));
        }

        public record SendLocationMessageRequest(string WhatsappId, double Latitude, double Longitude, string Name = null, string Address = null);

        [HttpPost]
        public async Task<SendMessageResponse> SendLocation([FromBody] SendLocationMessageRequest request)
        {
            return await _client.SendMessageAsync(new MessageObject
            {
                RecipientType = "individual",
                To = request.WhatsappId,
                Type = MessageType.location,
                Location = new LocationObject()
                {
                    Longitude = request.Longitude,
                    Latitude = request.Latitude,
                    Name = request.Name,
                    Address = request.Address,
                }
            });
        }

        public record SendContactRequest(string WhatsappId, ContactObject ContactObject);

        [HttpPost]
        public async Task<SendMessageResponse> SendContact([FromBody] SendContactRequest request)
        {
            return await _client.SendMessageAsync(new MessageObject
            {
                RecipientType = "individual",
                To = request.WhatsappId,
                Type = MessageType.contacts,
                Contacts = request.ContactObject
            });
        }
        
        public record UploadMediaRequest(IFormFile File);

        [HttpPost]
        public async Task<UploadMediaResponse> UploadMedia([FromForm] UploadMediaRequest request)
        {
            await using var ms = new MemoryStream();
            await request.File.CopyToAsync(ms);
            
            return await _client.UploadMediaAsync(ms.ToArray(), request.File.ContentType);
        }

        public record GetMediaByIdRequest(string MediaId);
        [HttpPost]
        public async Task<ActionResult> GetMediaFile([FromBody] GetMediaByIdRequest request)
        {
            var response = await _client.GetMediaAsync(request.MediaId);

            return File(response.FileBytes, response.ContentType.MediaType, response.ContentDisposition.FileName);
        }

        [HttpPost]
        public async Task<CheckPhoneNumberResponse> CheckPhoneNumber()
        {
            return await _client.CheckPhoneNumberAsync();
        }

        [HttpPost]
        public async Task<HealthCheckResponse> HealthCheck()
        {
            return await _client.HealthCheckAsync();
        }

        public record SetWabaWebhookRequest(string Url, string HeaderName, string HeaderValue);

        [HttpPost]
        public async Task<SetWebhookUrlResponse> SetWebhook([FromBody] SetWabaWebhookRequest request)
        {
            var dict = new Dictionary<string, string>
            {
                {
                    request.HeaderName, request.HeaderValue
                }
            };

            return await _client.SetWebhookUrlAsync(request.Url, dict);
        }
        
        [HttpPost]
        public async Task<GetWebhookUrlResponse> GetWebhook()
        {
            return await _client.GetWebhookUrlAsync();
        }
    }
}