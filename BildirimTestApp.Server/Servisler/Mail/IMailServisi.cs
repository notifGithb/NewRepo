using BildirimTestApp.Server.Servisler.Mail.DTO;

namespace BildirimTestApp.Server.Servisler.Mail
{
    public interface IMailServisi
    {
        #region Mail Servis 
        //Task MailGonderAsync(string toKullanici, string baslik, string icerik, bool isHtml = true);
        //Task MailGonderAsync(string[] toKullanicilar, string baslik, string icerik, bool isHtml = true);
        #endregion
        Task MailGonder(MailDto mailDto);

    }
}
