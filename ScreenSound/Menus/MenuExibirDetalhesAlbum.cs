using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Models;

internal class MenuExibirDetalhesAlbum : Menus
{
    internal override void Executar()
    {
        var contex = new ScreenSoundContext();
        var albumDal = new Dal<Album>(contex);
        var artistaDal = new Dal<Artista>(contex);

        int aristaId = 0;

        base.Executar();
        ExibirTituloDaOpcao("Exibindo todos os albuns registrados por Artista");

        Console.WriteLine("Enre com o nome do artista para conhecer os álbuns: ");
        string nomeDoArtista = Console.ReadLine()!;

        if (nomeDoArtista != string.Empty)
        {
            try
            {
                Artista artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList()[0];
                if (artistas is not null) aristaId = artistas.Id;
                else
                {
                    Console.WriteLine($"Não encontramos a Artista: {nomeDoArtista} em nosso cadastro!\nTente Novamente");
                    Console.Write("Dogite ENTER para continuar . . .");
                    Console.ReadLine();
                    Executar();
                }

                Album album = albumDal.ListarPor(a => a.ArtistaId == aristaId).ToList()[0];
                //foreach (var a in album)
                //{
                //    Console.WriteLine($"Album: {album}");
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar();
            }

        }


    }
}