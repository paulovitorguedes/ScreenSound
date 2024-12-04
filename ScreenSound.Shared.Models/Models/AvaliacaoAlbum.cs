namespace ScreenSound.Shared.Models.Models;

public class AvaliacaoAlbum
{

    public AvaliacaoAlbum(int nota)
    {
        if (nota > 10) Nota = 10;
        else if (nota <= 0) Nota = 0;
        else Nota = nota;
    }

    public int Id { get; set; }
    public int Nota { get; set; }
    public virtual Album? Album { get; set; }


    public static AvaliacaoAlbum Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new AvaliacaoAlbum(nota);
    }
}
