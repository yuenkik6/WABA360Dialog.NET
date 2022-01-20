# WABA360Dialog.NET
C# .NET API Wrapper Classes for 360Dialog WhatsApp Business APIs and Partner APIs

 - 360Dialog WhatsApp Business API Client
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
var partnerClient = new WABA360DialogPartnerClient("partner-id","access-token"));
// or
var partnerClient = new WABA360DialogPartnerClient(new PartnerInfo("partner-id", "username", "password")); // For auto login

var clientBalanceResponse = await partnerClient.GetClientBalanceAsync("client-id", 1, 2022);

```

## Available Functions
All existing API provided by 360 Dialog are wrapped as functions for corresponding client

- **WABA360DialogApiClient.cs / WABA360DialogApiSandboxClient.cs** (WhatsApp API Business API)
```c#
Task<GetWebhookUrlResponse> GetWebhookUrlAsync();
Task<SetWebhookUrlResponse> SetWebhookUrlAsync(string url, Dictionary<string, string> headers);
Task<CheckContactsResponse> CheckContactsAsync(IEnumerable<string> contacts, Blocking blocking = Blocking.no_wait, bool forceCheck = false);
Task<SendMessageResponse> SendMessageAsync(MessageObject message);
Task<SendMessageResponse> SendMessageAsync(object message);
Task<GetMediaResponse> GetMediaAsync(string mediaId);
Task<UploadMediaResponse> UploadMediaAsync(byte[] fileBytes, string contentType);
Task<GetTemplateResponse> GetTemplateAsync(int limit = 1000, int offset = 0, string sort = null, CancellationToken cancellationToken = default);
Task<CreateTemplateResponse> CreateTemplateAsync(CreateTemplateObject template, CancellationToken cancellationToken = default);
Task<DeleteTemplateResponse> DeleteTemplateAsync(string templateName, CancellationToken cancellationToken = default);
Task<UpdateBusinessProfileResponse> UpdateBusinessProfileAsync(IEnumerable<string> vertical, IEnumerable<string> websites, string email, string description, string address);
Task<UpdateProfileInfoAboutTextResponse> UpdateProfileInfoAboutTextAsync(string aboutText);
Task<UpdateProfileInfoPhotoResponse> UpdateProfileInfoPhotoAsync(byte[] fileBytes, string contentType);
```

- **WABA360DialogPartnerClient.cs** (360Dialog Partner API)
```c#
Task<CreatePartnerWhatsAppBusinessApiTemplateResponse> CreatePartnerWhatsAppBusinessApiTemplateAsync(string whatsAppBusinessApiAccountId, string name, TemplateCategory category, WhatsAppLanguage language, TemplateComponentObject components, CancellationToken cancellationToken = default);
Task<GetClientBalanceResponse> GetClientBalanceAsync(string clientId, int fromMonth, int fromYear, CancellationToken cancellationToken = default);
Task<GetPartnerChannelsResponse> GetPartnerChannelsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerChannelsFilter filters = null, CancellationToken cancellationToken = default);
Task<GetPartnerClientsResponse> GetPartnerClientsAsync(int limit = 20, int offset = 0, string sort = null, GetPartnerClientsFilter filters = null, CancellationToken cancellationToken = default);
Task<GetPartnerWebhookUrlResponse> GetPartnerWebhookUrlAsync(CancellationToken cancellationToken = default);
Task<GetPartnerWhatsAppBusinessApiTemplatesResponse> GetPartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, int limit = 1000, int offset = 0, string sort = null, GetPartnerWhatsAppBusinessApiTemplatesFilter filters = null, CancellationToken cancellationToken = default);
Task<RemovePartnerWhatsAppBusinessApiTemplatesResponse> RemovePartnerWhatsAppBusinessApiTemplatesAsync(string whatsAppBusinessApiAccountId, string templateId, CancellationToken cancellationToken = default);
Task<SetCancellationRequestOnChannelResponse> SetCancellationRequestOnChannelAsync(string clientId, string channelId, bool enabled, CancellationToken cancellationToken = default);
Task<SetPartnerWebhookUrlResponse> SetPartnerWebhookUrlAsync(string webhookUrl, CancellationToken cancellationToken = default);
Task<UpdateClientResponse> UpdateClientAsync(string clientId, string partnerPayload, CancellationToken cancellationToken = default);
Task<TokenResponse> RequestOAuthTokenAsync(string username, string password, CancellationToken cancellationToken = default);
```

## Helpers

-  **MessageObjectFactory.cs** for creating common **MessageObject** in WABA360DialogApiClient.SendMessage()
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