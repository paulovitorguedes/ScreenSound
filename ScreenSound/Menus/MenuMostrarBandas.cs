using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuMostrarBandas : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar()
        {
            var contex = new ScreenSoundContext();
            var artistaDal = new Dal<Artista>(contex);

            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar();
            ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

            try
            {
                List<Artista> artistas = artistaDal.Listar().ToList();
                foreach (Artista a in artistas)
                {
                    Console.WriteLine(a.ToString());
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERRO: {ex}");
            }
            
            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
