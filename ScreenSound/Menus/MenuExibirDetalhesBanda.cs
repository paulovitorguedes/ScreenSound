using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhesBanda : Menus //Extend a classe Menus como herança
{
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Avaliar Artistas");


        Console.Write("Digite o nome da banda que deseja conhecer: ");
        string nomeDoArtista = Console.ReadLine()!.ToUpper();

        if (nomeDoArtista == string.Empty) //Se for inserido um valor vazio
        {
            Console.WriteLine("O nome da banda é obrigatório!\nTente novamente.");
            Console.WriteLine("digite ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
            Executar(artistaDal);
        }
        else
        {
            try
            {
                //Verifica se existe a Artista cadadtrada
                //Busca uma lista de artistas com o nome estipulado em nomeDoArtista
                //A lista será vazia caso não encontre algum cadastro de artista com o nome citado
                List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList();
                if (artistas.Count > 0)
                {
                    //Apresenta titulo e bio
                    Artista artista = artistas.FirstOrDefault(a => a.Nome.Equals(nomeDoArtista))!;
                    Console.WriteLine($"\n\n########## - {artista.Nome} - ##########");
                    Console.WriteLine($"\n{artista.Bio}");
                }
                else
                {
                    Console.WriteLine("Artista não encontrado em nosso cadastro!\nTente novamente . . .");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar(artistaDal);
            }
        }
        Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }
}
