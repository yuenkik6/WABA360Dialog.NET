namespace WABA360Dialog.PartnerClient.Models
{
    public class PartnerInfo
    {
        public PartnerInfo(string partnerId)
        {
            PartnerId = partnerId;
        }

        public PartnerInfo(string partnerId, string username, string password)
        {
            PartnerId = partnerId;
            Username = username;
            Password = password;
        }

        public string PartnerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}