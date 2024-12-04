namespace ScreenSound.Shared.Models.Models;

public class Album
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
                List<int> notas = m.BuscarNotas().ToList();
                double media = 0;
                string star = "*";
                if (notas.Count > 0) media = notas.Average();
                if (media != 0) star = string.Empty.PadLeft(Convert.ToInt32(media), '*');

                value += $"Música{count++}: {m.Nome} ( {star} )\n";
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


    public int DuracaoAlbum()
    {
        int duracao = 0;
        if (Musicas.Count > 0)
        {
            foreach (Musica m in Musicas)
            {
                duracao += m.Duracao;
            }
        }
        return duracao;
    }
}