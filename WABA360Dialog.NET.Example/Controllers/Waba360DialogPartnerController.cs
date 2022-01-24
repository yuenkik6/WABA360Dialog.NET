using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Serilog;
using WABA360Dialog.NET.Example.Controllers.Requests;
using WABA360Dialog.PartnerClient.Converters;
using WABA360Dialog.PartnerClient.Models;
using WABA360Dialog.PartnerClient.Payloads;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.NET.Example.Controllers
{
    [ApiController]
    [Route("/waba/360dialog/partner/")]
    public class Waba360DialogPartnerController : ControllerBase
    {

        private readonly ILogger<Waba360DialogPartnerController> _logger;

        private readonly IConfiguration _configuration;

        public Waba360DialogPartnerController(ILogger<Waba360DialogPartnerController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpPost("webhook")]
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

        [HttpPost("set-webhook")]
        public async Task<ActionResult<SetPartnerWebhookUrlResponse>> SetPartnerWebhook([FromBody] Requests.SetPartnerWebhookRequest request)
        {
            var client = new WABA360DialogPartnerClient(new PartnerInfo(_configuration["WABA360Dialog:PartnerId"]), _configuration["WABA360Dialog:PartnerAccessToken"]);

            var response = await client.SetPartnerWebhookUrlAsync(request.Url);

            return Ok(response);
        }

        [HttpPost("get-partner-clients")]
        public async Task<ActionResult<GetClientBalanceResponse>> GetPartnerClients([FromBody] Requests.GetPartnerClientsRequest request)
        {
            var client = new WABA360DialogPartnerClient(new PartnerInfo(_configuration["WABA360Dialog:PartnerId"]), _configuration["WABA360Dialog:PartnerAccessToken"]);
            var response = await client.GetPartnerClientsAsync(request.Limit, request.Offset, request.Sort, request.Filters);

            return Ok(response);
        }

        [HttpPost("get-partner-channels")]
        public async Task<ActionResult<GetClientBalanceResponse>> GetPartnerChannels([FromBody] Requests.GetPartnerChannelsRequest request)
        {
            var client = new WABA360DialogPartnerClient(new PartnerInfo(_configuration["WABA360Dialog:PartnerId"]), _configuration["WABA360Dialog:PartnerAccessToken"]);
            var response = await client.GetPartnerChannelsAsync(request.Limit, request.Offset, request.Sort, request.Filters);

            return Ok(response);
        }

        [HttpPost("get-client-balance")]
        public async Task<ActionResult<GetClientBalanceResponse>> GetClientBalance([FromBody] Requests.GetClientBalanceRequest request)
        {
            var client = new WABA360DialogPartnerClient(new PartnerInfo(_configuration["WABA360Dialog:PartnerId"]), _configuration["WABA360Dialog:PartnerAccessToken"]);
            var response = await client.GetClientBalanceAsync(request.ClientId, request.FromMonth, request.FromYear);

            return Ok(response);
        }

    }
}