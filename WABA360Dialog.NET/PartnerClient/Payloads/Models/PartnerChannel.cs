﻿using System;
using Newtonsoft.Json;
using WABA360Dialog.PartnerClient.Payloads.Enums;

namespace WABA360Dialog.PartnerClient.Payloads.Models
{
    public class PartnerChannel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("account_mode")]
        public AccountMode AccountMode { get; set; }

        [JsonProperty("billing_started_at")]
        public DateTime? BillingStartedAt { get; set; }

        [JsonProperty("terminated_at")]
        public DateTime? TerminatedAt { get; set; }
        
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }
        
        [JsonProperty("current_limit")]
        public string CurrentLimit { get; set; }
        
        [JsonProperty("current_quality_rating")]
        public string CurrentQualityRating { get; set; }

        [JsonProperty("status")]
        public PartnerChannelStatus Status { get; set; }

        [JsonProperty("client")]
        public Client Client { get; set; }

        [JsonProperty("setup_info")]
        public SetupInfo SetupInfo { get; set; }

        [JsonProperty("waba_account")]
        public WhatsAppBusinessApiAccount WhatsAppBusinessApiAccount { get; set; }

        [JsonProperty("integration")]
        public Integration Integration { get; set; }
        
        [JsonProperty("has_inbox")]
        public bool? HasInbox { get; set; }
        
        [JsonProperty("is_oba")]
        public bool? IsOba { get; set; }
    }
}