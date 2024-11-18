using Microsoft.IdentityModel.Tokens;
using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Models;

internal class MenuExibirDetalhesAlbum : Menus
{
    //internal override void Executar()
    //{
    //    var contex = new ScreenSoundContext();
    //    var albumDal = new Dal<Album>(contex);
    //    var artistaDal = new Dal<Artista>(contex);

    //    int aristaId = 0;

    //    base.Executar();
    //    ExibirTituloDaOpcao("Exibindo todos os albuns registrados por Artista");

    //    Console.Write("Enre com o nome do artista para conhecer os álbuns: ");
    //    string nomeDoArtista = Console.ReadLine()!.ToUpper();

    //    if (nomeDoArtista != string.Empty)
    //    {
    //        try
    //        {
    //            List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList();
    //            if (artistas.Count > 0)
    //            {
    //                Artista art = artistas.FirstOrDefault(a => a.Nome.Equals(nomeDoArtista))!;
    //                int artistaId = art.Id;

    //                List<Album> albuns = albumDal.ListarPor(a => a.ArtistaId == artistaId).ToList();

    //                if (albuns.Count > 0)
    //                {
    //                    Console.WriteLine($"\nÁlbuns cadadtrados da banda {nomeDoArtista}");
    //                    foreach (Album a in albuns)
    //                    {
    //                        Console.WriteLine(a.ToString());
    //                        Sair();
    //                    }
    //                }
    //                else
    //                {
    //                    Console.WriteLine($"A banda {art.Nome} ainda não possui álbum cadastrado.\n Tente novamente ...");
    //                    Sair();
    //                }
    //            }
    //            else
    //            {
    //                Console.WriteLine($"Não encontramos a banda: {nomeDoArtista} em nosso cadastro!\nTente Novamente");
    //                Sair();

    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine($"Falha apresentada: {ex.Message}");
    //            Sair();

    //        }

    //    }
    //    else
    //    {
    //        Console.WriteLine("O nome da banda é obrigatório!\nTente novamente.");
    //        Sair();
    //    }


    //    void Sair()
    //    {
    //        Console.WriteLine("\n\ndigite ENTER para continuar...");
    //        Console.ReadLine();
    //        Console.Clear();
    //    }

    //}
}