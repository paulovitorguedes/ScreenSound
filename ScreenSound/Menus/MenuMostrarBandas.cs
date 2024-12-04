using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Menus;

internal class MenuMostrarBandas : Menus //Extend a classe Menus como herança
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

        try
        {
            List<Artista> artistas = artistaDal.Listar().ToList();
            if (artistas.Count > 0)
            {
                foreach (Artista a in artistas)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            else 
            {
                Console.WriteLine("No momento não há bandas cadastradas em nosso sistema!");
            }
            
        }
        catch (Exception ex)
        {

            Console.WriteLine($"ERRO: {ex.Message}");
        }

        Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
        Console.ReadKey();
        Console.Clear();
    }
}
