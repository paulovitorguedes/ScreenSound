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
            var bandaDal = new Dal<Banda>(contex);

            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar();
            ExibirTituloDaOpcao("Registro de álbuns");
            Console.Write("\nDigite a banda cujo álbum deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            Banda banda = bandaDal.ListarPor(a => a.Nome.Equals(nomeDaBanda)).ToList()[0];
            //Verifica se existe a Banda cadadtrada
            if (banda is not null)
            {
                Console.Write("\nAgora digite o título do álbum: ");

                string tituloAlbum = "";
                bool estaVazio = false;
                do
                {
                    tituloAlbum = Console.ReadLine()!.ToUpper();

                    if (tituloAlbum == "")
                    {
                        estaVazio = true;
                        Console.WriteLine("\nValor inserido é inválido\nTente Novamente");
                        Console.WriteLine("\nAlbum: ");
                    }
                    else estaVazio = false;

                } while (estaVazio);

                Album album = albumDal.ListarPor(a => a.Nome.Equals(tituloAlbum)).ToList()[0];
             

                if (album is null && album?.artista_id != banda.Id)
                {
                    album = new(tituloAlbum);
                    album.artista_id = banda.Id;

                    
                }
                else
                {
                    Console.WriteLine($"\nO Álbum: {tituloAlbum} já encontra-se em nosso cadastro da banda {nomeDaBanda}\nTente novamente . . .");
                }

                try
                {
                    albumDal.Adicionar(album);
                    Console.WriteLine($"\nO álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso! \nAguarde . . .");
                }
                catch (Exception)
                {

                    throw;
                }

  
            }
            else
            {
                Console.WriteLine($"\nA Banda {nomeDaBanda} não foi encontrada em nossos cadastros\nTente novamente . . .");
            }

            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
