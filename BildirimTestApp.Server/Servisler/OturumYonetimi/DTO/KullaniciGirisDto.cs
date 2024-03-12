using System.ComponentModel.DataAnnotations;

namespace BildirimTestApp.Server.Servisler.OturumYonetimi.DTO
{
    public class KullaniciGirisDto
    {
        [Required(ErrorMessage = "Isim zorunlu")]
        public string KullaniciAdi { get; set; }


        [Required(ErrorMessage = "Sifre zorunlu")]
        [DataType(DataType.Password)]
        public string  KullaniciSifresi { get; set; }
    }
}
