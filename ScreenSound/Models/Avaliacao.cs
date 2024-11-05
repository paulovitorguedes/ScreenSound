namespace ScreenSound.Models;

internal class Avaliacao
{
    // Construtor padrão
    public Avaliacao()
    {
    }

    public Avaliacao(int nota)
    {
        if (nota > 10) Nota = 10;
        else if (nota <= 0) Nota = 0;
        else Nota = nota;
    }

    public int Id { get; set; }
    public int Nota { get; }


    public static Avaliacao Parse(string texto)
    {
        int nota = int.Parse(texto);
        return new Avaliacao(nota);
    }
}
