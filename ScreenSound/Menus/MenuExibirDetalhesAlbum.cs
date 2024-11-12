using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Models;

internal class MenuExibirDetalhesAlbum : Menus
{
    internal override void Executar()
    {
        var contex = new ScreenSoundContext();
        var albumDal = new Dal<Album>(contex);
        var bandaDal = new Dal<Banda>(contex);

        int bandaId = 0;

        base.Executar();
        ExibirTituloDaOpcao("Exibindo todos os albuns registrados por banda");

        Console.WriteLine("Enre com o nome da banda para conhecer os álbuns: ");
        string nomeDaBanda = Console.ReadLine()!;

        if (nomeDaBanda != string.Empty)
        {
            try
            {
                Banda banda = bandaDal.ListarPor(a => a.Nome.Equals(nomeDaBanda)).ToList()[0];
                if (banda is not null) bandaId = banda.Id;
                else
                {
                    Console.WriteLine($"Não encontramos a Banda: {nomeDaBanda} em nosso cadastro!\nTente Novamente");
                    Console.Write("Dogite ENTER para continuar . . .");
                    Console.ReadLine();
                    Executar();
                }

                Album album = albumDal.ListarPor(a => a.artista_id == bandaId).ToList()[0];
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



        try
        {
            
        }
        catch (Exception ex)
        {

        }


    }
}