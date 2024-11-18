namespace ScreenSound.Models
{
    internal interface IAvaliavel
    {
        void AdicionarNota(AvaliacaoArtista nota);

        public IEnumerable<int> BuscarNotas();

    }
}
