using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.LocationObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TextObjects;
using WABA360Dialog.Common.Enums;

namespace WABA360Dialog.NET.ApiClient.Payloads.Base.Models
{
	public static class AbstractMessageObjectFactory
	{
        public static TMessageObject CreateTextMessage<TMessageObject>(string whatsAppId, string textMessage)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.text,
                Text = new TextObject()
                {
                    Body = textMessage
                }
            };
        }

        public static TMessageObject CreateImageMessageByMediaId<TMessageObject>(string whatsAppId, string mediaId, string caption)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.image,
                Image = new MediaObject()
                {
                    Id = mediaId,
                    Caption = caption
                }
            };
        }

        public static TMessageObject CreateImageMessageByLink<TMessageObject>(string whatsAppId, string imageLink, string caption, ProviderObject provider = null)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.image,
                Image = new MediaObject()
                {
                    Link = imageLink,
                    Caption = caption,
                    Provider = provider
                }
            };
        }

        public static TMessageObject CreateVideoMessageByMediaId<TMessageObject>(string whatsAppId, string mediaId, string caption)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.video,
                Video = new MediaObject()
                {
                    Id = mediaId,
                    Caption = caption
                }
            };
        }

        public static TMessageObject CreateVideoMessageByLink<TMessageObject>(string whatsAppId, string imageLink, string caption, ProviderObject provider = null)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.video,
                Video = new MediaObject()
                {
                    Link = imageLink,
                    Caption = caption,
                    Provider = provider
                }
            };
        }

        public static TMessageObject CreateDocumentMessageByMediaId<TMessageObject>(string whatsAppId, string fileName, string mediaId, string caption)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.document,
                Document = new MediaObject()
                {
                    Id = mediaId,
                    Filename = fileName,
                    Caption = caption,
                }
            };
        }

        public static TMessageObject CreateDocumentMessageByLink<TMessageObject>(string whatsAppId, string fileName, string documentLink, string caption, ProviderObject provider = null)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.document,
                Document = new MediaObject()
                {
                    Link = documentLink,
                    Caption = caption,
                    Filename = fileName,
                    Provider = provider,
                }
            };
        }

        public static TMessageObject CreateAudioMessageByMediaId<TMessageObject>(string whatsAppId, string mediaId)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.audio,
                Audio = new MediaObject()
                {
                    Id = mediaId,
                }
            };
        }

        public static TMessageObject CreateAudioMessageByLink<TMessageObject>(string whatsAppId, string audioLink, ProviderObject provider = null)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.audio,
                Audio = new MediaObject()
                {
                    Link = audioLink,
                    Provider = provider,
                }
            };
        }

        public static TMessageObject CreateStickerMessageByMediaId<TMessageObject>(string whatsAppId, string mediaId)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.sticker,
                Sticker = new MediaObject()
                {
                    Id = mediaId,
                }
            };
        }

        public static TMessageObject CreateStickerMessageByLink<TMessageObject>(string whatsAppId, string stickerLink, ProviderObject provider = null)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.sticker,
                Sticker = new MediaObject()
                {
                    Link = stickerLink,
                    Provider = provider
                }
            };
        }

        public static TMessageObject CreateTemplateMessage<TMessageObject>(string whatsAppId, string templateNamespace, string templateName, WhatsAppLanguage language, List<TemplateMessageComponentObject> components)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                To = whatsAppId,
                Type = MessageType.template,
                Template = new TemplateMessageObject()
                {
                    Namespace = templateNamespace,
                    Name = templateName,
                    Language = new LanguageObject() { Code = language, Policy = "deterministic" },
                    Components = components,
                }
            };
        }

        public static TMessageObject CreateInteractiveMessage<TMessageObject>(string whatsappId, InteractiveObject interactiveObject)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.interactive,
                Interactive = interactiveObject
            };
        }

        public static TMessageObject CreateSingleProductMessage<TMessageObject>(string whatsappId, string bodyText, string footerText, string catalogId, string productRetailerId)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            var productMessageInteractiveObject = new InteractiveObject()
            {
                Type = InteractiveType.product,
            };

            if (!string.IsNullOrWhiteSpace(bodyText)) productMessageInteractiveObject.Body = new TextBodyObject() { Text = bodyText };
            if (!string.IsNullOrWhiteSpace(footerText)) productMessageInteractiveObject.Footer = new TextFooterObject() { Text = footerText };

            productMessageInteractiveObject.Action = new ActionObject()
            {
                CatalogId = catalogId,
                ProductRetailerId = productRetailerId
            };

            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.interactive,
                Interactive = productMessageInteractiveObject
            };
        }

        public static TMessageObject CreateMultiProductMessage<TMessageObject>(string whatsappId, string bodyText, string footerText, IEnumerable<SectionObject> productSections)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            var multiProductMessageInteractiveObject = new InteractiveObject()
            {
                Type = InteractiveType.product_list,
            };

            if (!string.IsNullOrWhiteSpace(bodyText)) multiProductMessageInteractiveObject.Body = new TextBodyObject() { Text = bodyText };
            if (!string.IsNullOrWhiteSpace(footerText)) multiProductMessageInteractiveObject.Footer = new TextFooterObject() { Text = footerText };

            multiProductMessageInteractiveObject.Action = new ActionObject()
            {
                Sections = productSections
            };

            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.interactive,
                Interactive = multiProductMessageInteractiveObject
            };
        }

        public static TMessageObject CreateLocationMessage<TMessageObject>(string whatsappId, double latitude, double longitude, string name = null, string address = null)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.location,
                Location = new LocationObject()
                {
                    Latitude = latitude,
                    Longitude = longitude,
                    Name = name,
                    Address = address,
                }
            };
        }

        public static TMessageObject CreateContactsMessage<TMessageObject>(string whatsappId, ContactObject contact)
            where TMessageObject : WABA360Dialog.ApiClient.Payloads.Base.Models.AbstractMessageObject, new()
        {
            return new TMessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.contacts,
                Contacts = contact
            };
        }
    }
}
