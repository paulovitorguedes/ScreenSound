using System.Text;

namespace ScreenSound.Shared.Models.Models;

public class Musica
{
    public virtual ICollection<AvaliacaoMusica> AvaliacoesMusica { get; set; } = new List<AvaliacaoMusica>()
        ;
    public Musica(string nome)
    {
        Nome = nome;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public int Duracao { get; set; }
    public bool Disponivel { get; set; }
    public int? AnoLancamento { get; set; }
    public virtual Album? Album { get; set; }


    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Id: {Id}");
        sb.AppendLine($"Nome: {Nome}");
        sb.AppendLine($"Duração: {Duracao}");
        sb.AppendLine($"Ano de Lançamento: {AnoLancamento}");
        sb.AppendLine($"Disponivel: {Disponivel}");
        return sb.ToString();
    }



    public void AdicionarNota(AvaliacaoMusica nota)
    {
        AvaliacoesMusica.Add(nota);
    }



    public IEnumerable<int> BuscarNotas()
    {
        return AvaliacoesMusica.Select(n => n.Nota).ToList();
    }
}