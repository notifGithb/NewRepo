using AutoMapper;
using BildirimTestApp.Server.Models;
using BildirimTestApp.Server.Models.DTOs;
using BildirimTestApp.Server.RateLimitingMiddleware;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BildirimTestApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RateLimitController : ControllerBase
    {
        private readonly TestDbContext _testDbContext;
        private readonly IMapper _mapper;

        public RateLimitController(TestDbContext context, IMapper mapper)
        {
            _testDbContext = context;
            _mapper = mapper;
        }


        [HttpPost]
        public IActionResult RateLimitMuafKullaniciAdEkleTXT(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string content = reader.ReadToEnd();

                    string[] kullaniciAdlari = content.Split(new char[] { '\n', '\r', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (kullaniciAdlari.Length != 0)
                    {
                        foreach (var kullaniciAdi in kullaniciAdlari)
                        {

                            MuafKullanicilarListesi.MuafKullanicilar.Add(kullaniciAdi);
                        }
                        return Ok("Kullanicilar eklendi");

                    }
                    return NotFound("Kullanicilar bulunamadi.");
                }
            }
            return NotFound("Dosya boş veya yüklenemedi");
        }

        [HttpDelete]
        public IActionResult RateLimitMuafKullaniciAdCikarTXT(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var reader = new StreamReader(file.OpenReadStream()))
                {
                    string content = reader.ReadToEnd();

                    string[] kullaniciAdlari = content.Split(new char[] { '\n', '\r', ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    if (kullaniciAdlari.Length != 0)
                    {
                        foreach (var kullaniciAdi in kullaniciAdlari)
                        {
                            MuafKullanicilarListesi.MuafKullanicilar.Remove(kullaniciAdi);

                        }
                        return Ok("Kullanicilar Cikarildi");
                    }
                    return NotFound("Kullanicilar bulunamadi.");
                }
            }
            return NotFound("Dosya boş veya yüklenemedi");

        }


        [HttpGet]
        public async Task<IActionResult> RateLimitMuafKullanicilariGetir()
        {
            var kullaniciAdlari = MuafKullanicilarListesi.MuafKullanicilar.ToList();
            if (kullaniciAdlari.Count != 0)
            {
                var kullanicilar = await _testDbContext.SisKullanicis
                    .Where(u => kullaniciAdlari.Contains(u.KullaniciAdi)) // Assuming Id is the property representing the user ID
                    .ToListAsync();
                return Ok(_mapper.Map<List<GetKullaniciDto>>(kullanicilar));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult RateLimitMuafKullaniciEkle(string[] kullaniciAdlari)
        {
            if (kullaniciAdlari.Length != 0)
            {
                foreach (var kullaniciAdi in kullaniciAdlari)
                {
                    MuafKullanicilarListesi.MuafKullanicilar.Add(kullaniciAdi);
                }
                return Ok("Kullanici Eklendi");
            }
            return NotFound();

        }

        [HttpDelete]
        public IActionResult RateLimitMuafKullaniciCikar(string[] kullaniciAdlari)
        {
            if (kullaniciAdlari.Length != 0)
            {
                foreach (var kullaniciAdi in kullaniciAdlari)
                {
                    MuafKullanicilarListesi.MuafKullanicilar.Remove(kullaniciAdi);
                }
                return Ok("Kullanici Cikarildi");
            }
            return NotFound();
        }
    }
}
