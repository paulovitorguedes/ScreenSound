using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarAlbum : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar()
        {
            var contex = new ScreenSoundContext();
            var albumDal = new Dal<Album>(contex);
            var artistaDal = new Dal<Artista>(contex);

            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar();
            ExibirTituloDaOpcao("Registro de álbuns");
            Console.Write("\nDigite a artista cujo álbum deseja registrar: ");
            string nomeDoArista = Console.ReadLine()!.ToUpper();

            try
            {
                List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArista)).ToList();

                //Verifica se existe a Artista cadadtrada
                if (artistas.Count > 0)
                {
                    Console.Write("\nAgora digite o título do álbum: ");

                    string tituloAlbum = "";
                    do
                    {
                        tituloAlbum = Console.ReadLine()!.ToUpper();

                        if (tituloAlbum == string.Empty)
                        {
                            Console.WriteLine("\nValor inserido é inválido\nTente Novamente");
                            Console.WriteLine("\nAlbum: ");
                        }

                    } while (tituloAlbum == string.Empty);


                    List<Album> albuns = albumDal.ListarPor(a => a.Nome.Equals(tituloAlbum)).ToList();
                    Artista artista = artistas.FirstOrDefault(b => b.Nome.Equals(nomeDoArista))!;

                    if (albuns.Count > 0)
                    {
                        Console.WriteLine($"\nO Álbum: {tituloAlbum} já encontra-se em nosso cadastro do artista {nomeDoArista}\nTente novamente . . .");
                    }
                    else
                    {
                        Album album = new(tituloAlbum);
                        album.Artista_id = artista.Id;
                        albumDal.Adicionar(album);
                        Console.WriteLine($"\nO álbum {tituloAlbum} de {nomeDoArista} foi registrado com sucesso! \nAguarde . . .");
                    }

                }
                else
                {
                    Console.WriteLine($"\nA Artista {nomeDoArista} não foi encontrada em nossos cadastros\nTente novamente . . .");
                }

                Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Console.Clear();
            }


        }
    }
}
