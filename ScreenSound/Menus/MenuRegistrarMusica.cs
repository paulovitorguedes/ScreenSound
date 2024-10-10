using ScreenSound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarMusica : Menus
    {
        internal void Executar(Dictionary<string, Banda> bandasRegistradas)
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
        }
    }
}
