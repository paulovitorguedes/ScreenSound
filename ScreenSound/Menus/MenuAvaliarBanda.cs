using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menus  //Extend a classe Menus como herança
{
    ////override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    //internal override void Executar()
    //{

    //    var contex = new ScreenSoundContext();
    //    var astistaDal = new Dal<Artista>(contex);

    //    //base = Chama primeiramente o método da classe base (PAI) 
    //    base.Executar();
    //    ExibirTituloDaOpcao("Avaliar artistas");
    //    Console.Write("Digite o nome da artistas que deseja avaliar: ");
    //    string nomeDoArtista = Console.ReadLine()!.ToUpper();

    //    Artista artistas = astistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList()[0];
    //    if (artistas == null)
    //    {
    //        Console.WriteLine($"\nA artistas {nomeDoArtista} não foi encontrada!");

    //    }
    //    else
    //    {
    //        Console.Write($"Qual a nota que a artistas {nomeDoArtista} merece: ");
    //        //Avaliacao.Parce é um método static na class Avaliacao transformando a string em int e após criando o obj Avaliação
    //        Avaliacao avaliacao = Avaliacao.Parse(Console.ReadLine()!);

    //        artistas.AdicionarNota(avaliacao);
    //        Console.WriteLine($"\nA nota {avaliacao.Nota} foi registrada com sucesso para a artistas {nomeDoArtista}");
    //        //Thread.Sleep(2000);
    //    }

    //    Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
    //    Console.ReadKey();
    //    Console.Clear();
    //}
}
