using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhesBanda : Menus //Extend a classe Menus como herança
{
    ////override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    //internal override void Executar()
    //{
    //    var contex = new ScreenSoundContext();
    //    var artistaDal = new Dal<Artista>(contex);
    //    var albumaDal = new Dal<Album>(contex);

    //    //base = Chama primeiramente o método da classe base (PAI) 
    //    base.Executar();
    //    ExibirTituloDaOpcao("Exibir detalhes da banda");
    //    Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
    //    string nomeDoArtista = Console.ReadLine()!.ToUpper();


    //    try
    //    {
    //        List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList();

    //        //Verifica se existe a Artista cadastrada
    //        if (artistas.Count > 0)
    //        {
    //            int artistaId = artistas.FirstOrDefault(b => b.Nome.Equals(nomeDoArtista))!.Id;

    //            List<Album> albuns = albumaDal.ListarPor(a => a.ArtistaId == artistaId).ToList();




    //            int cont = 1;
    //            if (albuns.Count > 0)
    //            {
    //                Console.WriteLine($"\n\nA banda {nomeDoArtista} possui o(s) álbun(s) cadastrado(s): ");

    //                foreach (Album a in albuns)
    //                {
    //                    Console.WriteLine($"Álbum{cont++}: {a.Nome} com duração de {a.DuracaoTotal} Segundos.");
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine("Não foi detectado albuns cadastrados");
    //            }

    //            //Console.WriteLine("\nPossui a(s) nota(s) cadastrada(s): ");
    //            //Console.WriteLine("Notas: ");
    //            //foreach (Avaliacao avaliacao in banda.Notas)
    //            //{
    //            //    Console.Write(avaliacao.Nota + " ");
    //            //}
    //            //Console.WriteLine($"Média: {banda.Media}");
    //        }
    //        else
    //        {
    //            Console.WriteLine($"\nA banda {nomeDoArtista} não foi encontrada!");
    //        }

    //        Console.WriteLine("\n\nDigite uma tecla para voltar ao menu principal ");
    //        Console.ReadKey();
    //        Console.Clear();

    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine($"Falha apresentada: {ex.Message}");
    //        Console.Write("\n\nDigite ENTER para continuar ");
    //        Console.ReadKey();
    //        Executar();
    //    }

    //}
}
