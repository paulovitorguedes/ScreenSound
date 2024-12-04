using System.Text;

namespace ScreenSound.Shared.Models.Models;

public class Artista
{
    public virtual ICollection<Album> Albuns { get; set; } = new List<Album>();
    public virtual ICollection<AvaliacaoArtista> AvaliacoesArtista { get; set; } = new List<AvaliacaoArtista>();

    public Artista(string nome, string bio)
    {
        Nome = nome;
        Bio = bio;
        FotoPerfil = "https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png";
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Bio { get; set; }
    public string FotoPerfil { get; set; }



    public void AdicionarAlbum(Album album)
    {
        Albuns.Add(album);
    }


    public string ExibirDiscografia()
    {
        string value = "";
        int count = 1;

        if (Albuns.Count > 0)
        {
            foreach (Album a in Albuns)
            {
                value += $"\nÁlbum{count++}: {a.Nome}";
            }
        }

        return value;
    }

    public IEnumerable<string> NomesAlbuns()
    {
        return Albuns.Select(a => a.Nome).ToList();
    }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Nome: {Nome}");
        sb.AppendLine($"Foto de Perfil: {FotoPerfil}");
        sb.AppendLine($"Bio: {Bio}");
        return sb.ToString();
    }



    public void AdicionarNota(AvaliacaoArtista nota)
    {
        AvaliacoesArtista.Add(nota);
    }

    public IEnumerable<int> BuscarNotas()
    {
        return AvaliacoesArtista.Select(n => n.Nota).ToList();
    }

}