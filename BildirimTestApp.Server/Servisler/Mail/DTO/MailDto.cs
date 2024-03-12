namespace BildirimTestApp.Server.Servisler.Mail.DTO
{
    public class MailDto
    {
        public string[]? ToKullanici { get; set; }
        public string? Baslik { get; set; } 
        public string Icerik { get; set; } = string.Empty;

    }
}
