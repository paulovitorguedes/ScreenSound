namespace ScreenSound.Models;

public class AvaliacaoArtista
{

    public AvaliacaoArtista(int nota)
    {
        if (nota > 10) Nota = 10;
        else if (nota <= 0) Nota = 0;
        else Nota = nota;
    }

    public int Id { get; set; }
    public int Nota { get; set; }
    public virtual Artista? Artista { get; set; }


    public static AvaliacaoArtista Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new AvaliacaoArtista(nota);
    }
}
