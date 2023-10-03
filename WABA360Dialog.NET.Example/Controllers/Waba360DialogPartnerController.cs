using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using WABA360Dialog.PartnerClient.Converters;
using WABA360Dialog.PartnerClient.Interfaces;
using WABA360Dialog.PartnerClient.Models;
using WABA360Dialog.PartnerClient.Payloads;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.NET.Example.Controllers
{
    [ApiController]
    [Route("/waba/360dialog/partner/[action]")]
    public class Waba360DialogPartnerController : ControllerBase
    {
        private readonly ILogger<Waba360DialogPartnerController> _logger;

        private readonly IConfiguration _configuration;
        private readonly IWABA360DialogPartnerClient _client;

        public Waba360DialogPartnerController(ILogger<Waba360DialogPartnerController> logger, IConfiguration configuration, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _configuration = configuration;

            var headerPartnerId = contextAccessor.HttpContext?.Request.Headers["PartnerId"];
            var headerPartnerToken = contextAccessor.HttpContext?.Request.Headers["PartnerToken"];

            if (!string.IsNullOrWhiteSpace(headerPartnerId) && !string.IsNullOrWhiteSpace(headerPartnerToken))
            {
                _client = new WABA360DialogPartnerClient(new PartnerInfo(headerPartnerId), headerPartnerToken);
            }
            else
            {
                _client = new WABA360DialogPartnerClient(new PartnerInfo(_configuration["WABA360Dialog:PartnerId"]), _configuration["WABA360Dialog:PartnerToken"]);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Webhook()
        {
            var stream = new MemoryStream();
            await HttpContext.Request.Body.CopyToAsync(stream);
            var byteArr = stream.ToArray();

            var payloadString = Encoding.UTF8.GetString(byteArr, 0, byteArr.Length);

            Log.Information($"Partner Webhook:{payloadString}");
            var payload = JsonConvert.DeserializeObject<WABA360DialogPartnerWebhookPayload>(payloadString);
            Log.Information($"Event: {payload?.Event.GetString() ?? ""}");

            return Ok();
        }
        
        public record GetPartnerClientsRequest(int Limit = 20, int Offset = 0, string Sort = null, GetPartnerClientsFilter Filters = null);
        
        [HttpPost]
        public async Task<GetPartnerClientsResponse> GetPartnerClients([FromBody] GetPartnerClientsRequest request)
        {
            return await _client.GetPartnerClientsAsync(request.Limit, request.Offset, request.Sort, request.Filters);
        }

        public record GetPartnerChannelsRequest(int Limit = 20, int Offset = 0, string Sort = null, GetPartnerChannelsFilter Filters = null);

        [HttpPost]
        public async Task<GetPartnerChannelsResponse> GetPartnerChannels([FromBody] GetPartnerChannelsRequest request)
        {
            return await _client.GetPartnerChannelsAsync(request.Limit, request.Offset, request.Sort, request.Filters);
        }

        public record GetClientBalanceRequest(string ClientId, long? StartDate, long? EndDate, string Granularity = "month");

        [HttpPost]
        public async Task<ActionResult<GetClientBalanceResponse>> GetClientBalance([FromBody] GetClientBalanceRequest request)
        {
            return await _client.GetClientBalanceAsync(request.ClientId, request.StartDate, request.EndDate, request.Granularity);
        }

        public record UpdateClientRequest(string ClientId, string PartnerPayload, int? MaxChannels);
        
        [HttpPost]
        public async Task<UpdateClientResponse> UpdateClient([FromBody] UpdateClientRequest request)
        {
            return await _client.UpdateClientAsync(request.ClientId, request.PartnerPayload, request.MaxChannels);
        }
        
        [HttpPost]
        public async Task<GetPartnerPublicDataResponse> GetPartnerPublicData()
        {
            return await _client.GetPartnerPublicDataAsync();
        }

        public record PatchPartnerPublicDataRequest(string Webhook, string PartnerRedirectUrl);

        [HttpPost]
        public async Task<PatchPartnerPublicDataResponse> PatchPartnerPublicData([FromBody] PatchPartnerPublicDataRequest request)
        {
            return await _client.PatchPartnerPublicDataAsync(request.Webhook, request.PartnerRedirectUrl);
        }

        public record ApiKeyRequest(string ChannelId);

        [HttpPost]
        public async Task<GetApiKeyByChannelResponse> GetApiKeyByChannel([FromBody] ApiKeyRequest request)
        {
            return await _client.GetApiKeyByChannelAsync(request.ChannelId);
        }

        [HttpPost]
        public async Task<CreateApiKeyByChannelResponse> CreateApiKeyByChannel([FromBody] ApiKeyRequest request)
        {
            return await _client.CreateApiKeyByChannelAsync(request.ChannelId);
        }

        [HttpPost]
        public async Task<DeleteApiKeyByChannelResponse> DeleteApiKeyByChannel([FromBody] ApiKeyRequest request)
        {
            return await _client.DeleteApiKeyByChannelAsync(request.ChannelId);
        }
    }
}