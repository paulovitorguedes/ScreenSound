using ScreenSound.Menus;
using ScreenSound.Models;



internal class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Banda> bandasRegistradas = [];

        void ExibirLogo()
        {
            Console.WriteLine(@"

                ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
                ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
                ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
                ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
                ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
                ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
             ");
            Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
        }


        void ExibirOpcoesDoMenu()
        {
            ExibirLogo();
            Console.WriteLine("\nDigite 1 para registrar uma banda");
            Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
            Console.WriteLine("Digite 3 para registrar uma música de um album");
            Console.WriteLine("Digite 4 para mostrar todas as bandas");
            Console.WriteLine("Digite 5 para avaliar uma banda");
            Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

            switch (opcaoEscolhidaNumerica)
            {
                case 1:
                    RegistrarBanda();
                    break;
                case 2:
                    RegistrarAlbum();
                    break;
                case 3:
                    RegistrarMusica();
                    break;
                case 4:
                    MenuMostrarBandas menuMostrarBandas = new();
                    menuMostrarBandas.Executar(bandasRegistradas);
                    break;
                case 5:
                    MenuAvaliarBanda menuAvaliacao = new();
                    menuAvaliacao.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case 6:
                    MenuExibirDetalhes menuDetalhes = new();
                    menuDetalhes.Executar(bandasRegistradas);
                    ExibirOpcoesDoMenu();
                    break;
                case -1:
                    Console.WriteLine("Tchau tchau :)");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }


        //Cria um título composto com * como borda
        void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

        void RegistrarBanda()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            //Verifica sa já existe a Banda cadastrada
            if (!bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = new(nomeDaBanda);
                bandasRegistradas.Add(nomeDaBanda, banda);
                Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!\nAguarde . . .");
                //Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"\nA Banda: {nomeDaBanda} já encontra-se em nosso cadastro de bandas\nTente novamente . . .");

            }
            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }


        void RegistrarAlbum()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Registro de álbuns");
            Console.Write("\nDigite a banda cujo álbum deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            //Verifica sa já existe a Banda cadastrada
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.Write("\nAgora digite o título do álbum: ");
                string tituloAlbum = Console.ReadLine()!.ToUpper();
                Album album = new(tituloAlbum);

                Banda banda = bandasRegistradas[nomeDaBanda];

                //Busca na lista de Albuns cadastrado na classe Banda se já existe registrado no nome do álbum
                Album existeAlbum = bandasRegistradas[nomeDaBanda].Albuns.Find(a => a.Nome.Equals(tituloAlbum))!;
                if (existeAlbum == null)
                {
                    banda.AdicionarAlbum(album);
                    Console.WriteLine($"\nO álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso! \nAguarde . . .");
                    //Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine($"\nO Álbum: {tituloAlbum} já encontra-se em nosso cadastro da banda {nomeDaBanda}\nTente novamente . . .");
                }
            }
            else
            {
                Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada em nossos cadastros\nTente novamente . . .");
            }

            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }


        void RegistrarMusica()
        {
            Console.Clear();
            ExibirTituloDaOpcao("Registro de músicas");
            Console.Write("Digite a banda cujo música deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            //Verifica se existe a Banda cadadtrada
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];

                //Verifica se a Banda já possui algum Álbum cadastrado
                if (banda.Albuns.Count != 0)
                {
                    Console.WriteLine("\nInforme quais dos álbuns abaixo deseja adicionar uma música:");

                    // Apresenta o nome de todos os Álbum da Banda selecionada
                    int cont = 1;
                    foreach (Album a in banda.Albuns)
                    {
                        Console.WriteLine($"Álbum{cont++}: {a.Nome}");
                    }

                    Console.Write("\n\nÁlbum: ");
                    string tituloAlbum = Console.ReadLine()!.ToUpper();

                    Album album = banda.Albuns.Find(a => a.Nome.Equals(tituloAlbum))!;

                    if (album != null)
                    {
                        Console.Write($"\nEntre com o nome da música para o álbum {tituloAlbum}: ");
                        string tituloMusica = Console.ReadLine()!.ToUpper();

                        Console.Write($"\nEntre com a duração da música {tituloMusica} em segundos: ");
                        int duracaoMusica = int.Parse(Console.ReadLine()!);

                        Console.Write($"\nInforme se a música {tituloMusica} estára disponível no plano básico ( 1 - SIM / 2 - NÃO ): ");
                        string stringDisponivel = Console.ReadLine()!;

                        bool boolDisponivel = false;
                        switch (stringDisponivel)
                        {
                            case "1":
                                boolDisponivel = true;
                                break;
                            case "2":
                                boolDisponivel = false;
                                break;
                            default:
                                Console.WriteLine("\nOpção Inválida, tente novamente . . .");
                                Thread.Sleep(2000);
                                RegistrarMusica();
                                break;
                        }

                        Musica musica = new(banda, tituloMusica)
                        {
                            Duracao = duracaoMusica,
                            Disponivel = boolDisponivel
                        };

                        //Adiciona o obj Musica ao álbum cadastrado na lista de álbuns da classe Banda
                        foreach (Album a in banda.Albuns)
                        {
                            if (a.Nome.Equals(tituloAlbum)) a.AdicionarMusica(musica); break;

                        }

                        Console.WriteLine($"\nA música {tituloMusica} de {nomeDaBanda} foi registrado com sucesso no álbum {tituloAlbum}! \nAguarde . . .");
                        //Thread.Sleep(2000);

                    }
                    else
                    {
                        Console.WriteLine($"O Álbum {tituloAlbum} não foi encontrada em nossos cadastros\nTente novamente . . .");
                    }
                }
                else
                {
                    Console.WriteLine($"A Banda {nomeDaBanda} não possui Álbuns cadastrados\nTente primeiramente cadastrar um Álbum.");
                }

            }
            else
            {
                Console.WriteLine($"A Banda {nomeDaBanda} não foi encontrada em nossos cadastros\nTente novamente . . .");
            }

            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
            ExibirOpcoesDoMenu();
        }

        ExibirOpcoesDoMenu();
    }
}