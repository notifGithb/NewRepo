﻿namespace BildirimTestApp.Server.Models.DTOs
{
    public class GetKullaniciDto
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; } = null!;
        public string? Rol { get; set; }
    }
}
