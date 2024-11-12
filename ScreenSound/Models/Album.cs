namespace ScreenSound.Models;

internal class Album : IAvaliavel
{
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new();


    // Construtor padrão
    public Album()
    {
    }

    public Album(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; }
    public int artista_id { get; set; }
    public int avaliacao_id { get; set; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);
    public List<Musica> Musicas => musicas;

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicasDoAlbum()
    {
        Console.WriteLine($"Lista de músicas do álbum {Nome}:\n");
        foreach (var musica in musicas)
        {
            Console.WriteLine($"Música: {musica.Nome}");
        }
        Console.WriteLine($"\nPara ouvir este álbum inteiro você precisa de {DuracaoTotal}");
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

    public double Media
    {
        get
        {
            if (musicas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }
}