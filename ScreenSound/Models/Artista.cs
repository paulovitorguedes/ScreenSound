namespace ScreenSound.Models;

internal class Artista : IAvaliavel
{
    private List<Album> albuns = [];
    private List<Avaliacao> notas = [];
    private int? _avaliacaoId;

    //Construtor Padão
    public Artista()
    {
    }

    public Artista(string nome, string bio = "", int? nota = 0)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
        AvaliacaoId = nota;
    }



    //public double Media => notas.Average(a => a.Nota);
    public double Media
    {
        get
        {
            if (notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Bio { get; set; }

    //??: Este é o operador de coalescência nula. Ele verifica se o valor à esquerda (_avaliacaoId) é null. Se for null, ele retorna o valor à direita (0). Caso contrário, ele retorna o valor à esquerda.
    
    public int? AvaliacaoId
    {
        get => _avaliacaoId; // Retorna o valor armazenado
        set
        {
            // Se o valor for null, atribui 0 ao campo privado
            _avaliacaoId = value ?? 0; // Atribui 0 se o valor for null
        }
    }

    public string FotoPerfil { get; set; }

    public List<Album> Albuns => albuns;
    //public IEnumerable<Album> Albuns => albuns;

    public List<Avaliacao> Notas => notas;
    //public IEnumerable<Avaliacao> Notas => notas;

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void AdicionarNota(Avaliacao nota)
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


    public override string ToString()
    {
        return $@"Id: {Id}
            Nome: {Nome}
            Foto de Perfil: {FotoPerfil}
            Bio: {Bio}";
    }
}