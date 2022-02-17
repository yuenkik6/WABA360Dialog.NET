using System;
using System.Net.Http;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Base;
using WABA360Dialog.PartnerClient.Payloads.Enums;
using WABA360Dialog.PartnerClient.Payloads.Models;

namespace WABA360Dialog.PartnerClient.Payloads
{
    public class SetCancellationRequestOnChannelRequest : PartnerApiRequestBase<SetCancellationRequestOnChannelResponse>
    {
        public SetCancellationRequestOnChannelRequest(string partnerId, string clientId, string channelId, bool enabled) : base($"partners/{partnerId}/clients/{clientId}/channels/{channelId}/control/cancellation_request", HttpMethod.Post)
        {
            PartnerId = partnerId;
            ClientId = clientId;
            ChannelId = channelId;
            Enabled = enabled;
        }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonIgnore]
        public string PartnerId { get; }

        [JsonIgnore]
        public string ClientId { get; }

        [JsonIgnore]
        public string ChannelId { get; }

    }

    public class SetCancellationRequestOnChannelResponse : PartnerApiResponseBase
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("account_mode")]
        public string AccountMode { get; set; }

        [JsonProperty("billing_started_at")]
        public DateTime BillingStartedAt { get; set; }

        [JsonProperty("terminated_at")]
        public DateTime TerminatedAt { get; set; }

        [JsonProperty("status")]
        public ChannelStatus Status { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("setup_info")]
        public SetupInfo SetupInfo { get; set; }

        [JsonProperty("waba_account")]
        public WhatsAppBusinessApiAccount WhatsAppBusinessApiAccount { get; set; }

        [JsonProperty("integration")]
        public Integration Integration { get; set; }
    }


}