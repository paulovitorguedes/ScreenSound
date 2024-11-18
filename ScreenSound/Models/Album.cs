namespace ScreenSound.Models;

internal class Album
{

    public virtual ICollection<Musica> Musicas { get; set; } = new List<Musica>();
    public virtual ICollection<AvaliacaoAlbum> AvaliacoesAlbum { get; set; } = new List<AvaliacaoAlbum>();


    public Album(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual Artista? Artista { get; set; }



    public void AdicionarMusica(Musica musica)
    {
        Musicas.Add(musica);
    }


    public string ExibirMusicasDoAlbum()
    {
        string value = "";
        int count = 1;

        if (Musicas.Count > 0)
        {
            foreach (Musica m in Musicas)
            {
                value += $"Música{count++}: {m.Nome}";
            }
        }

        return value;
    }

  
    public override string ToString()
    {
        return @$"ID: {Id}, Álbum: {Nome}.";
    }



    public void AdicionarNota(AvaliacaoAlbum nota)
    {
        AvaliacoesAlbum.Add(nota);
    }



    public IEnumerable<int> BuscarNotas()
    {
        return AvaliacoesAlbum.Select(n => n.Nota).ToList();
    }
}