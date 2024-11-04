namespace ScreenSound.Models;

internal class Banda : IAvaliavel
{
    private List<Album> albuns = [];
    private List<Avaliacao> notas = [];

    public Banda(string nome, string bio = "")
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public string Nome { get; }

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
    public string Bio { get; set; }
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