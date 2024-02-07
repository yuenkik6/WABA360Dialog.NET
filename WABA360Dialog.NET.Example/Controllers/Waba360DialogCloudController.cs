using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WABA360Dialog.Cloud;
using WABA360Dialog.Cloud.ApiClient.Interfaces;
using WABA360Dialog.Cloud.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.Cloud.ApiClient.Payloads.Models.WebhookObjects;
using WABA360Dialog.Cloud.ApiClient.Payloads.Responses;
using WABA360Dialog.Common.Enums;
using ONPREM = WABA360Dialog.ApiClient.Payloads;

namespace WABA360Dialog.NET.Example.Controllers
{
    [ApiController]
    [Route("/waba/360dialog/[action]")]
    public class Waba360DialogCloudController : ControllerBase
    {
        private readonly ILogger<Waba360DialogCloudController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IWABA360DialogCloudApiClient _client;

        public Waba360DialogCloudController(ILogger<Waba360DialogCloudController> logger, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _configuration = configuration;

            var headerWabaApiKey = contextAccessor.HttpContext?.Request.Headers["360DialogChannelApiKey"];
            _client = new WABA360DialogCloudApiClient(!string.IsNullOrWhiteSpace(headerWabaApiKey) ? headerWabaApiKey : _configuration["WABA360Dialog:ChannelApiKey"]);
        }

        [HttpPost]
        public async Task<ActionResult> Webhook()
        {
            var stream = new MemoryStream();
            await HttpContext.Request.Body.CopyToAsync(stream);
            var byteArr = stream.ToArray();

            var payloadString = Encoding.UTF8.GetString(byteArr, 0, byteArr.Length);

            Log.Information($"Webhook:{payloadString}");
            var notification = JsonConvert.DeserializeObject<WebhookNotification>(payloadString);
            var payload = notification?.Entry?.FirstOrDefault().Changes?.FirstOrDefault()?.Value;
            Log.Information($"Contacts: {payload?.Contacts?.Count() ?? 0}, Messages: {payload?.Messages?.Count() ?? 0}.");

            return Ok(payload);
        }

        [HttpPost]
        public ActionResult WebhookObject([FromBody] WebhookNotification webhookPayload)
        {
            return Ok(webhookPayload);
        }

        public record CheckContactRequest(string PhoneNumber);

        public record SendMessageRequest(string WhatsappId, string TextMessage);

        [HttpPost]
        public async Task<SendMessageResponse> SendText([FromBody] SendMessageRequest request)
        {
            return await _client.SendMessageAsync(ONPREM.Models.MessageObjects.MessageObjectFactory.CreateTextMessage(request.WhatsappId, request.TextMessage));
        }

        public record SendMediaMessageRequest(string WhatsappId, string Link, string Caption);

        [HttpPost]
        public async Task<SendMessageResponse> SendImage([FromBody] SendMediaMessageRequest request)
        {
            return await _client.SendMessageAsync(ONPREM.Models.MessageObjects.MessageObjectFactory.CreateImageMessageByLink(request.WhatsappId, request.Link, request.Caption));
        }

        public record SendDocumentMessageRequest(string WhatsappId, string Link, string Filename, string Caption);

        [HttpPost]
        public async Task<SendMessageResponse> SendDocument([FromBody] SendDocumentMessageRequest request)
        {
            return await _client.SendMessageAsync(ONPREM.Models.MessageObjects.MessageObjectFactory.CreateDocumentMessageByLink(request.WhatsappId, request.Filename, request.Link, request.Caption));
        }

        public record SendNoCaptionMediaMessageRequest(string WhatsappId, string Link);

        [HttpPost]
        public async Task<SendMessageResponse> SendSticker([FromBody] SendNoCaptionMediaMessageRequest request)
        {
            return await _client.SendMessageAsync(ONPREM.Models.MessageObjects.MessageObjectFactory.CreateStickerMessageByLink(request.WhatsappId, request.Link));
        }

        public record SendTemplateMessageRequest(string WhatsappId, string TemplateNamespace, string TemplateName, WhatsAppLanguage Language, List<ONPREM.Models.MessageObjects.InteractiveObjects.TemplateMessageComponentObject> Components);

        [HttpPost]
        public async Task<SendMessageResponse> SendTemplate([FromBody] SendTemplateMessageRequest request)
        {
            return await _client.SendMessageAsync(ONPREM.Models.MessageObjects.MessageObjectFactory.CreateTemplateMessage(request.WhatsappId, request.TemplateNamespace, request.TemplateName, request.Language, request.Components));
        }

        public record SendInteractiveMessageRequest(string WhatsappId, ONPREM.Models.MessageObjects.InteractiveObjects.InteractiveObject InteractiveObject);

        [HttpPost]
        public async Task<SendMessageResponse> SendInteractive([FromBody] SendInteractiveMessageRequest request)
        {
            return await _client.SendMessageAsync(ONPREM.Models.MessageObjects.MessageObjectFactory.CreateInteractiveMessage(request.WhatsappId, request.InteractiveObject));
        }

        public record SendLocationMessageRequest(string WhatsappId, double Latitude, double Longitude, string Name = null, string Address = null);

        [HttpPost]
        public async Task<SendMessageResponse> SendLocation([FromBody] SendLocationMessageRequest request)
        {
            return await _client.SendMessageAsync(new MessageObject
            {
                RecipientType = "individual",
                To = request.WhatsappId,
                Type = ONPREM.Enums.MessageType.location,
                Location = new ONPREM.Models.MessageObjects.LocationObjects.LocationObject()
                {
                    Longitude = request.Longitude,
                    Latitude = request.Latitude,
                    Name = request.Name,
                    Address = request.Address,
                }
            });
        }

        public record SendContactRequest(string WhatsappId, ONPREM.Models.MessageObjects.ContactObjects.ContactObject ContactObject);

        [HttpPost]
        public async Task<SendMessageResponse> SendContact([FromBody] SendContactRequest request)
        {
            return await _client.SendMessageAsync(new MessageObject
            {
                RecipientType = "individual",
                To = request.WhatsappId,
                Type = ONPREM.Enums.MessageType.contacts,
                Contacts = request.ContactObject
            });
        }

        public record UploadMediaRequest(IFormFile File);

        [HttpPost]
        public async Task<UploadMediaResponse> UploadMedia([FromForm] UploadMediaRequest request)
        {
            await using var ms = new MemoryStream();
            await request.File.CopyToAsync(ms);

            return await _client.UploadMediaAsync(request.File.FileName, ms.ToArray(), request.File.ContentType);
        }

        public record MarkMessagesAsReadRequest(string MessageId);
        [HttpPost]
        public async Task<MarkMessagesAsReadResponse> MarkMessagesAsRead([FromForm] MarkMessagesAsReadRequest request)
        {
            return await _client.MarkMessagesAsReadAsync(request.MessageId);
        }

        public record GetTemplatesRequest(int Limit = 1000, int Offset = 0);
        [HttpPost]
        public async Task<ONPREM.GetTemplateResponse> GetTemplates([FromBody] GetTemplatesRequest request)
        {
            var response = await _client.GetTemplateAsync(request.Limit, request.Offset);

            return response;
        }

        public record CreateTemplateExampleRequest(ONPREM.Models.MessageObjects.TemplateObjects.CreateTemplateObject TemplateObject);
        [HttpPost]
        public async Task<ONPREM.CreateTemplateResponse> CreateTemplate([FromBody] CreateTemplateExampleRequest request)
        {
            var response = await _client.CreateTemplateAsync(request.TemplateObject);

            return response;
        }

        public record GetMediaByIdRequest(string MediaId);
        [HttpPost]
        public async Task<ActionResult> GetMediaFile([FromBody] GetMediaByIdRequest request)
        {
            var mediaInformationResponse = await _client.GetMediaInformationAsync(request.MediaId);
            var response = await _client.GetMediaAsync(mediaInformationResponse.Url);

            return File(response.FileBytes, response.ContentType.MediaType, response.ContentDisposition.FileName);
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