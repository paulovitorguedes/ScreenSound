using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarAlbum : Menus
    {
        internal void Executar(Dictionary<string, Banda> bandasRegistradas)
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
        }
    }
}
