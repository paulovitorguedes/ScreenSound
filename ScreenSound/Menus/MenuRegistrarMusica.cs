using Newtonsoft.Json.Linq;
using ScreenSound.Banco;
using ScreenSound.Models;
using System.ComponentModel;

namespace ScreenSound.Menus;

internal class MenuRegistrarMusica : Menus //Extend a classe Menus como herança
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Registro de músicas");


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
                    CadastrarMusica(artistaDal);
                    break;
                case "2":
                    //AlterarAlbum(artistaDal);
                    break;
                case "3":
                    //ExcluirAlbum(artistaDal);
                    break;
                case "0":
                    SairMusica();
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



    public void SairMusica()
    {
        Console.Write("\n\nDigite ENTER para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }





    public void CadastrarMusica(Dal<Artista> artistaDal)
    {
        Console.Write("\nDigite a banda cujo a música deseja registrar: ");
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

                //Verifica se existe a banda cadastrada
                if (artista != null)
                {
                    MenuRegistrarAlbum.ListarAlbumporArtista(artista);

                    Console.Write("\nAgora digite o título do álbum para registro da música: ");

                    string tituloAlbum = ""; //Impede a entrada de um valor vazio para cadastro do album
                    do
                    {
                        tituloAlbum = Console.ReadLine()!.ToUpper();

                        if (tituloAlbum == string.Empty)
                        {
                            Console.WriteLine("\nValor inserido é inválido\nTente Novamente");
                            Console.Write("\nAlbum: ");
                        }

                    } while (tituloAlbum == string.Empty);


                    Album? album = artista.Albuns.FirstOrDefault(a => a.Nome.Equals(tituloAlbum));
                    if (album != null) // Se existir o album para o cadastro de musicas
                    {
                        
                        ListarMusicasPorAlbum(album);
                        bool value = false; //Será usado para verificar a opção de novo cadastro de música
                        do
                        {
                            Console.Write("\nEntre com o nome da música: ");

                           
                            string tituloMusica = ""; //Impede a entrada de um valor vazio para cadastro do album
                            do
                            {
                                tituloMusica = Console.ReadLine()!.ToUpper();

                                if (tituloMusica == string.Empty)
                                {
                                    Console.WriteLine("\nValor inserido é inválido\nTente Novamente");
                                    Console.Write("\nMúsica: ");
                                }

                            } while (tituloMusica == string.Empty);

                            if (album.Musicas.Select(m => m.Nome.Equals(tituloMusica)).FirstOrDefault())
                            {
                                Console.WriteLine($"\nA Música: {tituloMusica} já encontra-se em nosso cadastro do álbum {tituloAlbum}\nTente novamente . . .");
                            }
                            else
                            {
                                Console.Write("Duração da música: ");
                                int duracao = 0;
                                while (!(int.TryParse(Console.ReadLine(), out duracao))) //ficará no loop caso o valor inserido não for inteiro
                                {
                                    Console.WriteLine("\nOpção inválida, tente novamente . . .");
                                    Console.Write("Duração da música: ");
                                }


                                Console.Write("Ano de lançamento: ");
                                int anoLancamento = 0;
                                while (!(int.TryParse(Console.ReadLine(), out anoLancamento))) //ficará no loop caso o valor inserido não for inteiro
                                {
                                    Console.WriteLine("\nOpção inválida, tente novamente . . .");
                                    Console.Write("Ano de lançamento: ");
                                }

                                Musica musica = new(tituloMusica)
                                {
                                    Duracao = duracao,
                                    Disponivel = true,
                                    AnoLancamento = anoLancamento
                                };

                                album.Musicas.Add(musica);
                                artistaDal.Alterar(artista);
                                Console.WriteLine($"\nA música {tituloMusica} foi registrada com sucesso!\nAguarde . . .");

                                Console.WriteLine($"Deseja registrar uma nova música no álbum {tituloAlbum} ?");
                                Console.Write("Digite 1 (sim) ou 2 (não)");
                                string option = Console.ReadLine();
                                
                                switch (option)
                                {
                                    case "1":
                                        value = true;
                                        break;
                                    case "2":
                                        value = false;
                                        break;
                                    default:
                                        Console.WriteLine("Opção inválida !");
                                        value = false;
                                        Console.ReadLine();

                                        break;
                                }
                            }

                        } while (value);

                        
                    }
                    else // Se NÃO existir o album para o cadastro de musicas
                    {
                        Console.WriteLine($"\nO Álbum: {tituloAlbum} não foi encontrado em nossos cadastros\nTente novamente . . .");
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



    public static void ListarMusicasPorAlbum(Album album)
    {

        int count = 0;
        if (album.Musicas.Count() > 0)
        {
            Console.WriteLine($"\nLISTA DE MÚSICAS Do ÁLBUM {album.Nome}:");
            foreach (Musica m in album.Musicas)
            {
                Console.WriteLine($"{++count}) {m.Nome}");
            }
        }
        else Console.WriteLine($"\nO ÁLBUM {album.Nome} AINDA NÃO POSSUI MÚSICAS CADASTRADAS !");
    }
}