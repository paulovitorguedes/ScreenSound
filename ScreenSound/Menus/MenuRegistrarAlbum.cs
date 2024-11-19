using ScreenSound.Banco;
using ScreenSound.Models;
using System.Linq;

namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menus //Extend a classe Menus como herança
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {

        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Cadastro de álbuns");

        Console.WriteLine("\nDigite 1 para Cadastrar");
        Console.WriteLine("Digite 2 para Alterar");
        Console.WriteLine("Digite 3 para Excluir");
        Console.WriteLine("Digite 0 para retornar ao menu principal");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;

        int opcaoEscolhidaNumerica;
        if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica) && (opcaoEscolhidaNumerica >= 0 && opcaoEscolhidaNumerica <= 3))
        {
            switch (opcaoEscolhida)
            {
                case "1":
                    CadastrarAlbum(artistaDal);
                    break;
                case "2":
                    //AlterarBanda(artistaDal);
                    break;
                case "3":
                    //ExcluirBanda(artistaDal);
                    break;
                case "0":
                    SairAlbum(artistaDal);
                    break;
            }
        }
        else
        {
            Console.WriteLine("Opção inválida! Tente novamente.");
            Console.WriteLine("Digitr ENTER para continuar . . .");
            Console.ReadLine();
            Executar(artistaDal);
        }
    }



    public void SairAlbum(Dal<Artista> artistaDal)
    {
        Console.Write("\n\nDigite ENTER para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }



    public void CadastrarAlbum(Dal<Artista> artistaDal)
    {
        Console.Write("\nDigite a banda cujo álbum deseja registrar: ");
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
                //List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList();
                Artista? artista = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).FirstOrDefault();

                //Verifica se existe a banda cadadtrada
                if (artista != null)
                {
                    Console.Write("\nAgora digite o título do álbum: ");

                    string tituloAlbum = ""; //Impede a entrada de um valor vazio para cadastro do album
                    do
                    {
                        tituloAlbum = Console.ReadLine()!.ToUpper();

                        if (tituloAlbum == string.Empty)
                        {
                            Console.WriteLine("\nValor inserido é inválido\nTente Novamente");
                            Console.WriteLine("\nAlbum: ");
                        }

                    } while (tituloAlbum == string.Empty);


                    if (artista.Albuns.Select(a => a.Nome.Equals(tituloAlbum)).FirstOrDefault()) //Retorna true ou false se o album for encontrado
                    {
                        Console.WriteLine($"\nO Álbum: {tituloAlbum} já encontra-se em nosso cadastro do artista {nomeDoArtista}\nTente novamente . . .");
                    }
                    else
                    {
                        Album album = new(tituloAlbum);
                        artista.AdicionarAlbum(album);
                        artistaDal.Alterar(artista);
                        Console.WriteLine($"\nO álbum {tituloAlbum} de {nomeDoArtista} foi registrado com sucesso! \nAguarde . . .");
                    }
                }
                else
                {
                    Console.WriteLine($"\nA banda {nomeDoArtista} não foi encontrada em nossos cadastros\nTente novamente . . .");
                }

                Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
                Console.ReadKey();
                Console.Clear();
                Executar(artistaDal);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Console.Clear();
                Executar(artistaDal);
            }
        }

    }
}
