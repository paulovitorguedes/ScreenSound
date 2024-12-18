﻿using ScreenSound.Menus;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;

internal class MenuAvaliarMusica : Menus
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Avaliar Músicas");


        Console.Write("Digite o nome da banda: ");
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
                //Artista poderá ser nulo 
                Artista? artista = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).FirstOrDefault();
                if (artista != null)
                {
                    //Se a banda exist - exibe os albuns
                    if (artista.Albuns.Count() > 0)
                    {
                        Console.WriteLine(artista.ExibirDiscografia());

                        Console.Write("\nDigite o título do álbum: ");
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


                        //verifica se existe o Album cadastrado
                        if (artista.NomesAlbuns().Contains(tituloAlbum))
                        {
                            //exibe as musicas do álbum
                            Album album = artista.Albuns.FirstOrDefault(a => a.Nome.Equals(tituloAlbum))!;
                            Console.WriteLine(album.ExibirMusicasDoAlbum());


                            //solicita escolha da musica
                            Console.Write("\nEntre com a música que deseja avaliar: ");
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



                            Musica? musica = album.Musicas.FirstOrDefault(m => m.Nome.Equals(tituloMusica));
                            if (musica != null)
                            {
                                //solicita entrada da nota
                                Console.Write("Entre com uma nota entre 1 à 5: ");
                                int nota;
                                bool value = true;
                                do
                                {
                                    if (int.TryParse(Console.ReadLine(), out nota))
                                    {
                                        if (nota >= 1 && nota <= 5)
                                        {
                                            //cadastra no banco
                                            AvaliacaoMusica avaliacaoMusica = new(nota);
                                            musica.AdicionarNota(avaliacaoMusica);
                                            artistaDal.Alterar(artista);
                                            Console.WriteLine($"Nota {nota} cadastrada para música {tituloMusica}");
                                            value = false;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Somente valores entre 1 à 5");
                                            Console.Write("Nota: ");
                                            value = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Valor inválido para nota!");
                                        Console.WriteLine("Somente valores entre 1 à 5");
                                        Console.Write("Nota: ");
                                        value = true;
                                    }

                                } while (value);
                            }
                            else Console.WriteLine("A música inserida não encontra-se em nosso cadastro");

                        }
                        else Console.WriteLine("O álbum inserido não encontra-se em nosso cadastro");

                    }
                    else Console.WriteLine("A banda inserida não possui musica cadastrada");

                }
                else Console.WriteLine("A Banda inserida não encontra-se em nosso cadastro");

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