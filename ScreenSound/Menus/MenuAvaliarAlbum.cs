﻿using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuAvaliarAlbum : Menus
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Avaliar Albuns");

            Console.Write("Digite o nome da banda que possui o álbum desejado: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            //Verifica se existe a Banda cadadtrada
            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[nomeDaBanda];

                //Verifica se a Banda já possui algum Álbum cadastrado
                if (banda.Albuns.Count != 0)
                {
                    Console.WriteLine("\nInforme quais dos álbuns abaixo deseja avaliar:");

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
                        Console.Write($"Qual a nota que álbum {album.Nome} merece: ");

                        //Avaliacao.Parce é um método static na class Avaliacao transformando a string em int e após criando o obj Avaliação
                        Avaliacao avaliacao = Avaliacao.Parse(Console.ReadLine()!);

                        album.AdicionarNota(avaliacao);
                        Console.WriteLine($"\nA nota {avaliacao.Nota} foi registrada com sucesso para o Álbum {tituloAlbum}");
                        //Thread.Sleep(2000);

                    }
                    else Console.WriteLine($"A Banda {nomeDaBanda} não possui Álbuns cadastrados\nTente primeiramente cadastrar um Álbum.");


                }
                else Console.WriteLine($"A Banda {nomeDaBanda} não foi encontrada em nossos cadastros\nTente novamente . . .");


                Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
