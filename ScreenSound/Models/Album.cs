namespace ScreenSound.Models;

internal class Album : IAvaliavel
{
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new();
    private int? _avaliacaoId;

    // Construtor padrão
    public Album()
    {
    }

    public Album(string nome, int artista ,int nota = 0)
    {
        Nome = nome;
        ArtistaId = artista;
        AvaliacaoId = nota;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int ArtistaId { get; set; }

    public int? AvaliacaoId
    {
        get => _avaliacaoId; // Retorna o valor armazenado
        set
        {
            // Se o valor for null, atribui 0 ao campo privado
            _avaliacaoId = value ?? 0; // Atribui 0 se o valor for null
        }
    }

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



    public override string ToString()
    {
        return @$"ID: {Id}, Álbum: {Nome}.";
    }
}