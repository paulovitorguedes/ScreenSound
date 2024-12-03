namespace ScreenSound.Models;

public class AvaliacaoMusica
{

    public AvaliacaoMusica(int nota)
    {
        if (nota > 10) Nota = 10;
        else if (nota <= 0) Nota = 0;
        else Nota = nota;
    }

    public int Id { get; set; }
    public int Nota { get; set; }
    public virtual Musica? Musica { get; set; }


    public static AvaliacaoAlbum Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new AvaliacaoAlbum(nota);
    }
}