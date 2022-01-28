using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using WABA360Dialog.ApiClient.Exceptions;
using WABA360Dialog.ApiClient.Payloads;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.LocationObjects;
using WABA360Dialog.NET.Example.Controllers.Requests;
using SendMessageRequest = WABA360Dialog.NET.Example.Controllers.Requests.SendMessageRequest;

namespace WABA360Dialog.NET.Example.Controllers
{
    [ApiController]
    [Route("/waba/360dialog/")]
    public class Waba360DialogController : ControllerBase
    {
        private readonly ILogger<Waba360DialogController> _logger;
        private readonly IConfiguration _configuration;

        public Waba360DialogController(ILogger<Waba360DialogController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("webhook")]
        public async Task<ActionResult> Get()
        {
            var stream = new MemoryStream();
            await HttpContext.Request.Body.CopyToAsync(stream);
            var byteArr = stream.ToArray();

            var payloadString = Encoding.UTF8.GetString(byteArr, 0, byteArr.Length);

            Log.Information($"Webhook:{payloadString}");
            var payload = JsonConvert.DeserializeObject<WABA360DialogWebhookPayload>(payloadString);
            Log.Information($"Contacts: {payload?.Contacts?.Count() ?? 0}, Messages: {payload?.Messages?.Count() ?? 0}.");

            return Ok();
        }

        [HttpPost("check-contact")]
        public async Task<ActionResult<CheckContactsResponse>> CheckContact([FromBody] CheckContactRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            CheckContactsResponse checkContactsResponse = await client.CheckContactsAsync(new[] { request.PhoneNumber }, Blocking.wait);

            return Ok(checkContactsResponse);
        }

        [HttpPost("message/send-text")]
        public async Task<ActionResult<SendMessageResponse>> SendText([FromBody] SendMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(MessageObjectFactory.CreateTextMessage(request.WhatsappId, request.TextMessage));

            return Ok(response);
        }

        [HttpPost("message/send-image")]
        public async Task<ActionResult<SendMessageResponse>> SendImage([FromBody] SendMediaMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(MessageObjectFactory.CreateImageMessageByLink(request.WhatsappId, request.Link, request.Caption));

            return Ok(response);
        }

        [HttpPost("message/send-document")]
        public async Task<ActionResult<SendMessageResponse>> SendDocument([FromBody] SendDocumentMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(MessageObjectFactory.CreateDocumentMessageByLink(request.WhatsappId, request.Filename, request.Link, request.Caption));

            return Ok(response);
        }

        [HttpPost("message/send-sticker")]
        public async Task<ActionResult<SendMessageResponse>> SendSticker([FromBody] SendNoCaptionMediaMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(MessageObjectFactory.CreateStickerMessageByLink(request.WhatsappId, request.Link));

            return Ok(response);
        }

        [HttpPost("message/send-template")]
        public async Task<ActionResult<SendMessageResponse>> SendTemplate([FromBody] SendTemplateMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(MessageObjectFactory.CreateTemplateMessage(request.WhatsappId, request.TemplateNamespace, request.TemplateName, request.Language, request.Components));

            return Ok(response);
        }

        [HttpPost("message/send-interactive")]
        public async Task<ActionResult<SendMessageResponse>> SendInteractive([FromBody] SendInteractiveMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(MessageObjectFactory.CreateInteractiveMessage(request.WhatsappId, request.InteractiveObject));

            return Ok(response);
        }

        [HttpPost("message/send-location")]
        public async Task<ActionResult<SendMessageResponse>> SendLocation([FromBody] SendLocationMessageRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(new MessageObject
            {
                RecipientType = "individual",
                To = request.WhatsappId,
                Type = MessageType.location,
                Location = new LocationObject()
                {
                    Longitude = request.longitude,
                    Latitude = request.latitude,
                    Name = request.name,
                    Address = request.address,
                }
            });

            return Ok(response);
        }

        [HttpPost("message/send-contact")]
        public async Task<ActionResult<SendMessageResponse>> SendContact([FromBody] SendContact request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.SendMessageAsync(new MessageObject
            {
                RecipientType = "individual",
                To = request.WhatsappId,
                Type = MessageType.contacts,
                Contacts = request.ContactObject
            });

            return Ok(response);
        }


        [HttpPost("get-media")]
        public async Task<ActionResult<GetMediaResponse>> GetMedia([FromBody] GetMediaByIdRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var response = await client.GetMediaAsync(request.MediaId);

            return Ok(response);
        }

        [HttpPost("set-webhook")]
        public async Task<ActionResult<SetWebhookUrlResponse>> SetWebhook([FromBody] SetWabaWebhookRequest request)
        {
            var client = new WABA360DialogApiClient(_configuration["WABA360Dialog:ChannelKey"]);

            var dict = new Dictionary<string, string>
            {
                {
                    request.HeaderName, request.HeaderValue
                }
            };

            var response = await client.SetWebhookUrlAsync(request.Url, dict);

            return Ok(response);
        }
    }
}