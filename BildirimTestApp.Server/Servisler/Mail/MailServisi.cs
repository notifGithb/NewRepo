
using BildirimTestApp.Server.Servisler.Mail.DTO;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;
using System.Net;
using System.Net.Mail;

namespace BildirimTestApp.Server.Servisler.Mail
{
    public class MailServisi : IMailServisi
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<MailServisi> _logger;

        public MailServisi(IConfiguration configuration, ILogger<MailServisi> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task MailGonder(MailDto mailDto)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration["Mail:Username"]));

                if (mailDto.ToKullanici == null) throw new Exception();

                foreach (var kullanici in mailDto.ToKullanici)
                {
                    email.To.Add(MailboxAddress.Parse(kullanici));

                }
                email.Subject = mailDto.Baslik;
                email.Body = new TextPart(TextFormat.Html) { Text = mailDto.Icerik };

                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                await smtp.ConnectAsync(_configuration["Mail:Host"], Convert.ToInt32(_configuration["Mail:Port"]), SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_configuration["Mail:Username"], _configuration["Mail:Password"]);
                smtp.Send(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception)
            {
                _logger.LogInformation("Mail Gönderilemedi");
                //throw new Exception("Mail gönderilirken bir hata oluştu. Lütfen daha sonra tekrar deneyin.");
            }

        }

        #region Mail Servis
        //public async Task MailGonderAsync(string toKullanici, string baslik, string icerik, bool isHtml = true)
        //{
        //    await MailGonderAsync(new[] { toKullanici }, baslik, icerik, isHtml);
        //}

        //public async Task MailGonderAsync(string[] toKullanicilar, string baslik, string icerik, bool isHtml = true)
        //{
        //    MailMessage mail = new();
        //    mail.IsBodyHtml = isHtml;
        //    foreach (string kullanici in toKullanicilar)
        //    {
        //        mail.To.Add(kullanici);
        //    }
        //    mail.Subject = baslik;
        //    mail.Body = icerik;
        //    mail.From = new(_configuration["Mail:Username"]!, "gonderici", System.Text.Encoding.UTF8);

        //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //    smtp.Credentials = new NetworkCredential(_configuration["Mail:Username"], _configuration["Mail:Password"]);
        //    smtp.Port = Convert.ToInt32(_configuration["Mail:Port"]);
        //    smtp.EnableSsl = true;
        //    smtp.Host = _configuration["Mail:Host"]!;
        //    await smtp.SendMailAsync(mail);

        //}
        #endregion

    }
}
