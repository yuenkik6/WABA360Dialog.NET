# WABA360Dialog.NET
C# .NET API Wrapper Classes for 360Dialog WhatsApp Business APIs (On-Premises) and Partner APIs

 - 360Dialog WhatsApp Business API (On-Premises) Client
 - 360Dialog WhatsApp Business API Sandbox Client
 - 360Dialog Partner API
 - Webhook Models
 
## Getting Started
To get started, you must own an API Key managed by 360Dialog.

- **WABA360DialogApiClient.cs / WABA360DialogApiSandboxClient.cs** (WhatsApp API Business API)
```c#
var client = new WABA360DialogApiClient("your-api-key");
var createMessageResposne = await client.SendMessageAsync(MessageObjectFactory.CreateTextMessage("whatsapp-id", "Hello World!"));
```

- **WABA360DialogPartnerClient.cs** (360Dialog Partner API)
```c#
var partnerClient = new WABA360DialogPartnerClient(new PartnerInfo("partner-id"),"access-token"));
// or
var partnerClient = new WABA360DialogPartnerClient(new PartnerInfo("partner-id", "username", "password")); // For auto login

var clientBalanceResponse = await partnerClient.GetClientBalanceAsync("client-id", 1696118400, 1698796799, "month");

```

## Available Functions
All existing API provided by 360 Dialog are wrapped as functions for corresponding client

- **WABA360DialogApiClient.cs / WABA360DialogApiSandboxClient.cs** (WhatsApp API Business API (On-Premises))
```c#
Task<GetWebhookUrlResponse> GetWebhookUrlAsync(CancellationToken cancellationToken = default);
Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers, CancellationToken cancellationToken = default);
Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false, CancellationToken cancellationToken = default);
Task<SendMessageResponse> SendMessageAsync(MessageObject message, CancellationToken cancellationToken = default);
Task<SendMessageResponse> SendMessageAsync(object message, CancellationToken cancellationToken = default);
Task<MarkMessagesAsReadResponse> MarkMessagesAsReadAsync(string messageId, CancellationToken cancellationToken = default);
Task<GetMediaResponse> GetMediaAsync(string mediaId, CancellationToken cancellationToken = default);
Task<UploadMediaResponse> UploadMediaAsync(byte[] fileBytes, string contentType, CancellationToken cancellationToken = default);
Task<GetTemplateResponse> GetTemplateAsync(int limit = 1000, int offset = 0, string sort = null, CancellationToken cancellationToken = default);
Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateObject template, CancellationToken cancellationToken = default);
Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateName, CancellationToken cancellationToken = default);
Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(IEnumerable<string> vertical, IEnumerable<string> websites, string email, string description, string address, CancellationToken cancellationToken = default);
Task<UpdateProfileInfoAboutTextResponse> UpdateProfileInfoAboutTextAsync(string aboutText, CancellationToken cancellationToken = default);
Task<UpdateProfileInfoPhotoResponse> UpdateProfileInfoPhotoAsync(byte[] fileBytes, string contentType, CancellationToken cancellationToken = default);
Task<CheckPhoneNumberResponse> CheckPhoneNumberAsync(CancellationToken cancellationToken = default);
Task<HealthCheckResponse> HealthCheckAsync(CancellationToken cancellationToken = default);
```

- **WABA360DialogPartnerClient.cs** (360Dialog Partner API)
```c#
Task<CreatePartnerWhatsAppBusinessApiTemplateResponse> CreatePartnerWhatsAppBusinessApiTemplateAsync(string whatsAppBusinessApiAccountId, string name, string category, WhatsAppLanguage language, TemplateComponentObject components, CancellationToken cancellationToken = default);
Task<GetClientBalanceResponse> GetClientBalanceAsync(string clientId, string clientId, long? startDate, long? endDate, string granularity, CancellationToken cancellationToken = default);
Task<GetPartnerChannelsResponse> GetPartnerChannelsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerChannelsFilter filters = null, CancellationToken cancellationToken = default);
Task<GetPartnerClientsResponse> GetPartnerClientsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerClientsFilter filters = null, CancellationToken cancellationToken = default);
Task<GetPartnerWebhookUrlResponse> GetPartnerWebhookUrlAsync(CancellationToken cancellationToken = default);
Task<SetPartnerWebhookUrlResponse> SetPartnerWebhookUrlAsync(string webhookUrl, CancellationToken cancellationToken = default);
Task<GetPartnerWhatsAppBusinessApiTemplatesResponse> GetPartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, int limit = 1000, int offset = 0, string sort = null, GetPartnerWhatsAppBusinessApiTemplatesFilter filters = null, CancellationToken cancellationToken = default);
Task<RemovePartnerWhatsAppBusinessApiTemplatesResponse> RemovePartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, string templateId, CancellationToken cancellationToken = default);
Task<SetCancellationRequestOnChannelResponse> SetCancellationRequestOnChannelAsync(string clientId, string channelId, bool enabled, CancellationToken cancellationToken = default);
Task<UpdateClientResponse> UpdateClientAsync(string clientId, string partnerPayload, CancellationToken cancellationToken = default);
Task<GetApiKeyByChannelResponse> GetApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default);
Task<CreateApiKeyByChannelResponse> CreateApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default);
Task<GetPartnerPublicDataResponse> GetPartnerPublicDataAsync(CancellationToken cancellationToken = default);
Task<PatchPartnerPublicDataResponse> PatchPartnerPublicDataAsync(string webhookUrl, string partnerRedirectUrl, CancellationToken cancellationToken = default);
Task<DeleteApiKeyByChannelResponse> DeleteApiKeyByChannelAsync(string clientId, CancellationToken cancellationToken = default);
Task<TokenResponse> RequestOAuthTokenAsync(string username, string password, CancellationToken cancellationToken = default);
```

- All Response type now have **Response Body** field for recording http response body from 360Dialog
```public string ResponseBody { get; set; }```

## Helpers

-  **MessageObjectFactory.cs** is a simple factory for creating common **MessageObject** used in WABA360DialogApiClient.SendMessage()
```c#
MessageObjectFactory.CreateTextMessage(string whatsAppId, string textMessage, bool previewUrl = false);
MessageObjectFactory.CreateImageMessageByMediaId(string whatsAppId, string mediaId, string caption);
MessageObjectFactory.CreateImageMessageByLink(string whatsAppId, string imageLink, string caption, ProviderObject provider = null);
MessageObjectFactory.CreateVideoMessageByMediaId(string whatsAppId, string mediaId, string caption);
MessageObjectFactory.CreateVideoMessageByLink(string whatsAppId, string imageLink, string caption, ProviderObject provider = null);
MessageObjectFactory.CreateDocumentMessageByMediaId(string whatsAppId, string fileName, string mediaId, string caption);
MessageObjectFactory.CreateDocumentMessageByLink(string whatsAppId, string fileName, string documentLink, string caption, ProviderObject provider = null);
MessageObjectFactory.CreateAudioMessageByMediaId(string whatsAppId, string mediaId);
MessageObjectFactory.CreateAudioMessageByLink(string whatsAppId, string audioLink, ProviderObject provider = null);
MessageObjectFactory.CreateStickerMessageByMediaId(string whatsAppId, string mediaId);
MessageObjectFactory.CreateStickerMessageByLink(string whatsAppId, string stickerLink, ProviderObject provider = null);
MessageObjectFactory.CreateTemplateMessage(string whatsAppId, string templateNamespace, string templateName, WhatsAppLanguage language, List<ComponentObject> components);
MessageObjectFactory.CreateInteractiveMessage(string whatsappId, InteractiveObject interactiveObject);
MessageObjectFactory.CreateLocationMessage(string whatsappId, double latitude, double longitude, string name = null, string address = null);
MessageObjectFactory.CreateContactsMessage(string whatsappId, ContactObject contact);
```

## Enums
The Enums definition, value, converters are located at these folders:

```c#
ApiClient\Payloads\Converters\...
ApiClient\Payloads\Enums\...

PartnerClient\Payloads\Converters\...
PartnerClient\Payloads\Enums\...

Common\Converters\...
Common\Enums\...
```

- To Get the string value of the enums, use `.GetString()`

However, once Facebook updated the enums string value may cause issues during JSON deserialize.

## Webhook Models
Webhook Models classes (Recommend using Newtonsoft.Json >= 13.01 for JSON deserialization):

- WhatsApp API Business API
```c#
ApiClient\Payloads\Models\WABA360DialogWebhookPayload.cs
```

- 360Dialog Partner API
```c#
PartnerClient\Payloads\Models\WABA360DialogPartnerWebhookPayload.cs
```


## Exceptions
Exceptions will throw when Response HTTP Status Code or Response is not success.

- WhatsApp API Business API
```c#
ApiClientException // Throw when Response HTTP status code is not success, use ex.ToString() / ex.Error to access detail
```

- 360Dialog Partner API
```c#
PartnerClientException  // Throw when HTTP Response Status Code is not success, use ex.ToString() / ex.Message to access detail
PartnerClientAuthenticationException // Throw when HTTP Response Status Code is 401 like access token invalid or no credentials set.
```


## Example
Run **WABA360Dialog.NET.Example** with your Api Key and Partner Id, Token. It Include Swagger UI for you to test certain APIs.

You can either set the api key / partner secret through `appsetting.json` or Swagger UI
1. `appsetting.json`
    Example:
    ```json
    {
        "WABA360Dialog": {
            "ChannelApiKey": "",
            "PartnerId": "",
            "PartnerToken": ""
        }
    }
    ```

2. Swagger UI > Authorize
    
    Set `360Dialog Channel ApiKey`, `Partner Id` & `Partner Token` 

## Extendability
Feel free to extend or improve the capability of the current version of the client that cannot satisfy all your needs.

Please visit these Folder for more details: 
```c#
ApiClient\Interfaces                            // Abstract WhatsApp Business API Client class
ApiClient\Payloads\Base                         // Abstract WhatsApp Business API Request & Response class
ApiClient\Payloads\                             // Concrete WhatsApp Business API Request & Response class

PartnerClient\Interfaces                        // Abstract Partner API Client class
PartnerClient\Payloads\Base                     // Abstract Partner API Request & Response class
PartnerClient\Payloads\                         // Concrete Partner API Request & Response class
``` 

## Official Documents
 - Introduction: https://docs.360dialog.com/
 - WhatsApp Business API Documents: https://docs.360dialog.com/whatsapp-api/whatsapp-api
 - Sandbox Documents: https://docs.360dialog.com/whatsapp-api/whatsapp-api/sandbox
 - Facebook API: https://developers.facebook.com/docs/whatsapp/api/messages
 - Partner API Documents: https://api.360dialog.com/