using AutoMapper;
using BildirimTestApp.Server.Models;
using BildirimTestApp.Server.Models.DTOs.BildirimDTO;
using BildirimTestApp.Server.Servisler.Bildirim;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace BildirimTestApp.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class BildirimController : ControllerBase
    {
        private readonly IBildirimOlusturucu _bildirimOlusturucu;
        private readonly IBildirimHedefOlusturucu _bildirimHedefOlusturucu;
        private readonly IMapper _mapper;
        public BildirimController(IBildirimOlusturucu bildirimOlusturucu, IBildirimHedefOlusturucu bildirimHedefOlusturucu, IMapper mapper)
        {
            _bildirimOlusturucu = bildirimOlusturucu;
            _bildirimHedefOlusturucu = bildirimHedefOlusturucu;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> YemehaneDuyuruBildirimGonder([FromBody] YemekhaneDuyuruBildirimDTO yemekhaneDuyuruBildirimDTO)
        {
            try
            {
                var yemehaneDuyuruBildirim = _mapper.Map<YemekhaneDuyuruBildirim>(yemekhaneDuyuruBildirimDTO);

                await _bildirimOlusturucu.BildirimGonder(yemehaneDuyuruBildirim, _bildirimHedefOlusturucu, yemekhaneDuyuruBildirimDTO.Aciklama);

                return Ok("Yemekhane Duyurusu Basariyla Olusturuldu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata olustu: {ex.Message}");
            }
        }



        [HttpPost]
        public async Task<IActionResult> EkipToplantiDuyuruBildirimGonder([FromBody] ToplantiDuyuruBildirimDTO toplantiDuyuruBildirimDTO)
        {
            try
            {
                var toplantiDuyuruBildirim = _mapper.Map<ToplantiDuyuruBildirim>(toplantiDuyuruBildirimDTO);

                await _bildirimHedefOlusturucu.BildirimGonderilecekKullancilar(toplantiDuyuruBildirimDTO.GonderilecekKullaniciIdleri);

                await _bildirimOlusturucu.BildirimGonder(toplantiDuyuruBildirim, _bildirimHedefOlusturucu, toplantiDuyuruBildirimDTO.Aciklama);

                return Ok("Anlik Bildirim Basariyla Olusturuldu.");
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, $"Hata: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata olustu: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> EtkinlikDuyuruBildirimGonder([FromBody] EtkinlikDuyuruBildirimDTO etkinlikDuyuruBildirimDTO)
        {
            try
            {
                var etkinlikDuyuruBildirim = _mapper.Map<EtkinlikDuyuruBildirim>(etkinlikDuyuruBildirimDTO);


                await _bildirimOlusturucu.BildirimGonder(etkinlikDuyuruBildirim, _bildirimHedefOlusturucu, etkinlikDuyuruBildirimDTO.Aciklama);
                return Ok("Anlik Bildirim Başarıyla Oluşturuldu.");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }


        [HttpPost]
        public async Task<IActionResult> EpostaBildirimOlustur([FromBody] EpostaBildirim epostaBildirim)
        {
            try
            {
                await _bildirimOlusturucu.BildirimGonder(epostaBildirim, _bildirimHedefOlusturucu, epostaBildirim.Aciklama);
                return Ok("E-Posta Bildirimi Başarıyla Oluşturuldu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Bir hata oluştu: {ex.Message}");
            }
        }
    }
}
