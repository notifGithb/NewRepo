using BildirimTestApp.Server.Models.DTOs;

namespace BildirimTestApp.Server.Servisler.KullaniciGorev
{
    public interface IGorevServisi
    {
        Task GorevAta(GorevOlusturmaDTO gorevDTO);
    }
}
