using System.Collections.Generic;
using WABA360Dialog.Common.Enums;
using WABA360Dialog.NET.ApiClient.Payloads.Base.Models;
using ONPREM = WABA360Dialog.ApiClient.Payloads.Models.MessageObjects;

namespace WABA360Dialog.Cloud.ApiClient.Payloads.Models.MessageObjects
{
	public static class MessageObjectFactory
	{
        public static MessageObject CreateTextMessage(string whatsAppId, string textMessage)
        {
           return AbstractMessageObjectFactory.CreateTextMessage<MessageObject>(whatsAppId, textMessage);
        }

        public static MessageObject CreateImageMessageByMediaId(string whatsAppId, string mediaId, string caption)
        {
            return AbstractMessageObjectFactory.CreateImageMessageByMediaId<MessageObject>(whatsAppId, mediaId, caption);
        }

        public static MessageObject CreateImageMessageByLink(string whatsAppId, string imageLink, string caption, ONPREM.MediaObjects.ProviderObject provider = null)
        {
            return AbstractMessageObjectFactory.CreateImageMessageByLink<MessageObject>(whatsAppId, imageLink, caption, provider);
        }

        public static MessageObject CreateVideoMessageByMediaId(string whatsAppId, string mediaId, string caption)
        {
            return AbstractMessageObjectFactory.CreateVideoMessageByMediaId<MessageObject>(whatsAppId, mediaId, caption);
        }

        public static MessageObject CreateVideoMessageByLink(string whatsAppId, string imageLink, string caption, ONPREM.MediaObjects.ProviderObject provider = null)
        {
            return AbstractMessageObjectFactory.CreateVideoMessageByLink<MessageObject>(whatsAppId, imageLink, caption, provider);
        }

        public static MessageObject CreateDocumentMessageByMediaId(string whatsAppId, string fileName, string mediaId, string caption)
        {
            return AbstractMessageObjectFactory.CreateDocumentMessageByMediaId<MessageObject>(whatsAppId, fileName, mediaId, caption);
        }

        public static MessageObject CreateDocumentMessageByLink(string whatsAppId, string fileName, string documentLink, string caption, ONPREM.MediaObjects.ProviderObject provider = null)
        {
            return AbstractMessageObjectFactory.CreateDocumentMessageByLink<MessageObject>(whatsAppId, fileName, documentLink, caption, provider);
        }

        public static MessageObject CreateAudioMessageByMediaId(string whatsAppId, string mediaId)
        {
            return AbstractMessageObjectFactory.CreateAudioMessageByMediaId<MessageObject>(whatsAppId, mediaId);
        }

        public static MessageObject CreateAudioMessageByLink(string whatsAppId, string audioLink, ONPREM.MediaObjects.ProviderObject provider = null)
        {
            return AbstractMessageObjectFactory.CreateAudioMessageByLink<MessageObject>(whatsAppId, audioLink, provider);
        }

        public static MessageObject CreateStickerMessageByMediaId(string whatsAppId, string mediaId)
        {
            return AbstractMessageObjectFactory.CreateStickerMessageByMediaId<MessageObject>(whatsAppId, mediaId);
        }

        public static MessageObject CreateStickerMessageByLink(string whatsAppId, string stickerLink, ONPREM.MediaObjects.ProviderObject provider = null)
        {
            return AbstractMessageObjectFactory.CreateStickerMessageByLink<MessageObject>(whatsAppId, stickerLink, provider);
        }

        public static MessageObject CreateTemplateMessage(string whatsAppId, string templateNamespace, string templateName, WhatsAppLanguage language, List<ONPREM.InteractiveObjects.TemplateMessageComponentObject> components)
        {
            return AbstractMessageObjectFactory.CreateTemplateMessage<MessageObject>(whatsAppId, templateNamespace, templateName, language, components);
        }

        public static MessageObject CreateInteractiveMessage(string whatsAppId, ONPREM.InteractiveObjects.InteractiveObject interactiveObject)
        {
            return AbstractMessageObjectFactory.CreateInteractiveMessage<MessageObject>(whatsAppId, interactiveObject);
        }

        public static MessageObject CreateSingleProductMessage(string whatsAppId, string bodyText, string footerText, string catalogId, string productRetailerId)
        {
            return AbstractMessageObjectFactory.CreateSingleProductMessage<MessageObject>(whatsAppId, bodyText, footerText, catalogId, productRetailerId);
        }

        public static MessageObject CreateMultiProductMessage(string whatsAppId, string bodyText, string footerText, IEnumerable<ONPREM.InteractiveObjects.SectionObject> productSections)
        {
            return AbstractMessageObjectFactory.CreateMultiProductMessage<MessageObject>(whatsAppId, bodyText, footerText, productSections);
        }

        public static MessageObject CreateLocationMessage(string whatsAppId, double latitude, double longitude, string name = null, string address = null)
        {
            return AbstractMessageObjectFactory.CreateLocationMessage<MessageObject>(whatsAppId, latitude, longitude, name, address);
        }

        public static MessageObject CreateContactsMessage(string whatsAppId, ONPREM.ContactObjects.ContactObject contact)
        {
            return AbstractMessageObjectFactory.CreateContactsMessage<MessageObject>(whatsAppId, contact);
        }
    }
}