namespace BildirimTestApp.Server.Models
{
    public class Gorev
    {
        public Gorev()
        {
            // SisKullanicis koleksiyonunu başlat
            SisKullanicis = new HashSet<SisKullanici>();
        }

        public int GorevId { get; set; }
        public string? Aciklama { get; set; }
        public DateTime GorevSonTarih { get; set; }

        public virtual ICollection<SisKullanici> SisKullanicis { get; set; }
    }
}
