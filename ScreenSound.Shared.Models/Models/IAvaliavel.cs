using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Models
{
    public interface IAvaliavel
    {
        void AdicionarNota(AvaliacaoArtista nota);

        public IEnumerable<int> BuscarNotas();

    }
}
