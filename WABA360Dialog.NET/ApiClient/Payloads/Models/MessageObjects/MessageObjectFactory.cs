﻿using System.Collections.Generic;
using WABA360Dialog.ApiClient.Payloads.Enums;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.ContactObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.InteractiveObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.LocationObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.MediaObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TemplateObjects;
using WABA360Dialog.ApiClient.Payloads.Models.MessageObjects.TextObjects;
using WABA360Dialog.Common.Enums;

namespace WABA360Dialog.ApiClient.Payloads.Models.MessageObjects
{
    public static class MessageObjectFactory
    {
        public static MessageObject CreateTextMessage(string whatsAppId, string textMessage, bool previewUrl = false)
        {
            return new MessageObject
            {
                RecipientType = "individual",
                To = whatsAppId,
                Type = MessageType.text,
                PreviewUrl = previewUrl,
                Text = new TextObject()
                {
                    Body = textMessage
                }
            };
        }

        public static MessageObject CreateImageMessageByMediaId(string whatsAppId, string mediaId, string caption)
        {
            return new MessageObject
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

        public static MessageObject CreateImageMessageByLink(string whatsAppId, string imageLink, string caption, ProviderObject provider = null)
        {
            return new MessageObject
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

        public static MessageObject CreateVideoMessageByMediaId(string whatsAppId, string mediaId, string caption)
        {
            return new MessageObject
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

        public static MessageObject CreateVideoMessageByLink(string whatsAppId, string imageLink, string caption, ProviderObject provider = null)
        {
            return new MessageObject
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

        public static MessageObject CreateDocumentMessageByMediaId(string whatsAppId, string fileName, string mediaId, string caption)
        {
            return new MessageObject
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

        public static MessageObject CreateDocumentMessageByLink(string whatsAppId, string fileName, string documentLink, string caption, ProviderObject provider = null)
        {
            return new MessageObject
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

        public static MessageObject CreateAudioMessageByMediaId(string whatsAppId, string mediaId)
        {
            return new MessageObject
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

        public static MessageObject CreateAudioMessageByLink(string whatsAppId, string audioLink, ProviderObject provider = null)
        {
            return new MessageObject
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

        public static MessageObject CreateStickerMessageByMediaId(string whatsAppId, string mediaId)
        {
            return new MessageObject
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

        public static MessageObject CreateStickerMessageByLink(string whatsAppId, string stickerLink, ProviderObject provider = null)
        {
            return new MessageObject
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

        public static MessageObject CreateTemplateMessage(string whatsAppId, string templateNamespace, string templateName, WhatsAppLanguage language, List<TemplateMessageComponentObject> components)
        {
            return new MessageObject
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

        public static MessageObject CreateInteractiveMessage(string whatsappId, InteractiveObject interactiveObject)
        {
            return new MessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.interactive,
                Interactive = interactiveObject
            };
        }

        public static MessageObject CreateSingleProductMessage(string whatsappId, string bodyText, string footerText, string catalogId, string productRetailerId)
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

            return new MessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.interactive,
                Interactive = productMessageInteractiveObject
            };
        }

        public static MessageObject CreateMultiProductMessage(string whatsappId, string bodyText, string footerText, IEnumerable<SectionObject> productSections)
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
            
            return new MessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.interactive,
                Interactive = multiProductMessageInteractiveObject
            };
        }

        public static MessageObject CreateLocationMessage(string whatsappId, double latitude, double longitude, string name = null, string address = null)
        {
            return new MessageObject
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

        public static MessageObject CreateContactsMessage(string whatsappId, ContactObject contact)
        {
            return new MessageObject
            {
                RecipientType = "individual",
                To = whatsappId,
                Type = MessageType.contacts,
                Contacts = contact
            };
        }
    }
}