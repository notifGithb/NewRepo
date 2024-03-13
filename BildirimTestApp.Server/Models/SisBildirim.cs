using Azure;
using BildirimTestApp.Server.Servisler.Bildirim;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;

namespace BildirimTestApp.Server.Models
{
    public partial class SisBildirim : IBildirim
    {
        public SisBildirim()
        {
            SisBildirimOutboxes = new HashSet<SisBildirimOutbox>();
        }

        public int BildirimId { get; set; }
        public int GonderilecekKullaniciId { get; set; }
        public int GonderimDurumu { get; set; }
        public int BildirimIcerikId { get; set; }

        public virtual SisBildirimIcerik BildirimIcerik { get; set; } = null!;
        public virtual SisKullanici GonderilecekKullanici { get; set; } = null!;
        public virtual ICollection<SisBildirimOutbox> SisBildirimOutboxes { get; set; }
    }

    public class AnlikBildirim : IAnlikBildirim
    {
        public string? Aciklama { get; set; }

    }

    public class GorevAtandiAnlikBildirim : IAnlikBildirim
    {
        public string? Aciklama { get; set; }
        public DateTime GorevSonTarih { get; set; }

    }

    public class EtkinlikDuyuruBildirim : IDuyuruBildirim
    {
        public string? Aciklama { get; set; }
        public DateTime EtkinlikZamani { get; set; }
        public string? EtkinlikKonumu { get; set; }
    }

    public class ToplantiDuyuruBildirim : IDuyuruBildirim
    {
        public string? BirimAdi { get; set; }
        public string? Aciklama { get; set; }
        public string? ToplantiKonumu { get; set; }
        public DateTime ToplantiZamani { get; set; }

    }

    public class YemekhaneDuyuruBildirim : IDuyuruBildirim
    {
        public string? Aciklama { get; set; }
        public DateTime YemekZamani { get; set; }

    }


    public class EpostaBildirim : IEPostaBildirim
    {
        public string? Aciklama { get; set; }
        public string? Baslik { get; set; }

    }

}
