namespace ScreenSound.Models;

class Banda
{
    private List<Album> albuns = [];
    private List<double> notas = [];

    public Banda(string nome)
    {
        Nome = nome;
    }

    public string Nome { get; }
    public double Media => notas.Average();
    public List<Album> Albuns => albuns;
    public List<double> Notas => notas;

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(double nota)
    {
        notas.Add(nota);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine($"Discografia da banda {Nome}");
        foreach (Album album in albuns)
        {
            Console.WriteLine($"Álbum: {album.Nome} ({album.DuracaoTotal})");
        }
    }
}