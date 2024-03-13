using AutoMapper;
using BildirimTestApp.Server.Models;
using BildirimTestApp.Server.Models.DTOs;
using BildirimTestApp.Server.Servisler.Bildirim;
using BildirimTestApp.Server.Servisler.Kullanici;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BildirimTestApp.Server.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class GorevController : ControllerBase
    {
        private readonly TestDbContext _context;
        private readonly IBildirimHedefOlusturucu _bildirimHedefOlusturucu;
        private readonly IBildirimOlusturucu _bildirimOlusturucu;
        private readonly IMapper _mapper;
        private readonly IKullaniciBilgiServisi _kullaniciBilgiServisi;

        public GorevController(TestDbContext context, IBildirimHedefOlusturucu bildirimHedefOlusturucu, IBildirimOlusturucu bildirimOlusturucu, IMapper mapper, IKullaniciBilgiServisi kullaniciBilgiServisi)
        {

            _context = context;
            _bildirimHedefOlusturucu = bildirimHedefOlusturucu;
            _bildirimOlusturucu = bildirimOlusturucu;
            _mapper = mapper;
            _kullaniciBilgiServisi = kullaniciBilgiServisi;
        }

        [HttpPost]
        public async Task<IActionResult> GorevOlustur(GorevOlusturmaDTO gorevDTO)
        {
            var gorev = _mapper.Map<Gorev>(gorevDTO);
            if (gorevDTO.GonderilecekKullaniciIdleri != null && gorevDTO.GonderilecekKullaniciIdleri.Any())
            {
                foreach (var kullaniciId in gorevDTO.GonderilecekKullaniciIdleri)
                {
                    ///var kullanici = await _kullaniciBilgiServisi.GetKullaniciBilgiAsync(kullaniciId);
                    var kullanici = await _context.SisKullanicis.FindAsync(kullaniciId);
                    if (kullanici != null)
                    {
                        gorev.SisKullanicis.Add(kullanici);
                    }
                    else
                    {
                        return BadRequest($"Kullanici Bulunamadi.");
                    }
                }
                await _context.Gorevs.AddAsync(gorev);
                await _context.SaveChangesAsync();
                var gorevAtandiAnlikBildirim = _mapper.Map<GorevAtandiAnlikBildirim>(gorevDTO);
                await _bildirimHedefOlusturucu.BildirimGonderilecekKullancilar(gorevDTO.GonderilecekKullaniciIdleri);
                await _bildirimOlusturucu.BildirimGonder(gorevAtandiAnlikBildirim, _bildirimHedefOlusturucu, gorevDTO.Aciklama);

                return Ok("Gorev Olusturuldu.");
            }
            return BadRequest("Gorev Olusturulamadi.");
        }
    }
}
