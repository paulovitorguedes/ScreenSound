using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarMusica : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar()
        {
            var contex = new ScreenSoundContext();
            var artistaDal = new Dal<Artista>(contex);

            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar();
            ExibirTituloDaOpcao("Registro de músicas");
            Console.Write("Digite a artista cujo música deseja registrar: ");
            string nomeDoArtista = Console.ReadLine()!.ToUpper();

            Artista artista = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList()[0];
            //Verifica se existe a Artista cadadtrada
            if (artista is null)
            {
                //Artista artista = bandasRegistradas[nomeDoArtista];

                //Verifica se a Artista já possui algum Álbum cadastrado
                if (artista.Albuns.Count != 0)
                {
                    Console.WriteLine("\nInforme quais dos álbuns abaixo deseja adicionar uma música:");

                    // Apresenta o nome de todos os Álbum da Artista selecionada
                    int cont = 1;
                    foreach (Album a in artista.Albuns)
                    {
                        Console.WriteLine($"Álbum{cont++}: {a.Nome}");
                    }

                    Console.Write("\n\nÁlbum: ");
                    string tituloAlbum = Console.ReadLine()!.ToUpper();

                    Album album = artista.Albuns.Find(a => a.Nome.Equals(tituloAlbum))!;

                    if (album != null)
                    {
                        Console.Write($"\nEntre com o nome da música para o álbum {tituloAlbum}: ");
                        string tituloMusica = Console.ReadLine()!.ToUpper();

                        Console.Write($"\nEntre com a duração da música {tituloMusica} em segundos: ");
                        int duracaoMusica = int.Parse(Console.ReadLine()!);


                        bool boolDisponivel = false;
                        int value = 0;
                        do
                        {
                            Console.Write($"\nInforme se a música {tituloMusica} estára disponível no plano básico ( 1 - SIM / 2 - NÃO ): ");
                            string stringDisponivel = Console.ReadLine()!;
                            
                            switch (stringDisponivel)
                            {
                                case "1":
                                    boolDisponivel = true;
                                    value = 0;
                                    break;
                                case "2":
                                    boolDisponivel = false;
                                    value = 0;
                                    break;
                                default:
                                    Console.WriteLine("\nOpção Inválida, tente novamente . . .");
                                    Thread.Sleep(1000);
                                    value = 1;
                                    break;
                            }

                        } while (value == 1);
                        
                        

                        

                        Musica musica = new(artista, tituloMusica)
                        {
                            Duracao = duracaoMusica,
                            Disponivel = boolDisponivel
                        };

                        //Adiciona o obj Musica ao álbum cadastrado na lista de álbuns da classe Artista
                        foreach (Album a in artista.Albuns)
                        {
                            if (a.Nome.Equals(tituloAlbum)) a.AdicionarMusica(musica); break;

                        }

                        Console.WriteLine($"\nA música {tituloMusica} de {nomeDoArtista} foi registrado com sucesso no álbum {tituloAlbum}! \nAguarde . . .");
                        //Thread.Sleep(2000);

                    }
                    else
                    {
                        Console.WriteLine($"O Álbum {tituloAlbum} não foi encontrada em nossos cadastros\nTente novamente . . .");
                    }
                }
                else
                {
                    Console.WriteLine($"A Artista {nomeDoArtista} não possui Álbuns cadastrados\nTente primeiramente cadastrar um Álbum.");
                }

            }
            else
            {
                Console.WriteLine($"A Artista {nomeDoArtista} não foi encontrada em nossos cadastros\nTente novamente . . .");
            }

            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
