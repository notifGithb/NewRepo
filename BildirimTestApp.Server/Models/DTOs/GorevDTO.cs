namespace BildirimTestApp.Server.Models.DTOs
{
    public class GorevDTO
    {
        public string? Aciklama { get; set; }
        public DateTime GorevSonTarih { get; set; }
        public List<int>? GonderilecekKullaniciIdleri { get; set; }

    }
}
