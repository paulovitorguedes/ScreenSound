using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(BandaDal bandaDal)
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar(bandaDal);

            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            Console.Write("Digite uma rápida biografia da Banda: ");
            string bioDaBanda = Console.ReadLine()!.ToUpper();

            Banda banda = bandaDal.ListarBandaPorNome(nomeDaBanda);
            //Verifica se existe a Banda cadadtrada
            if (banda == null)
            {
                banda = new(nomeDaBanda, bioDaBanda);
                bandaDal.Adicionar(banda);
                Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!\nAguarde . . .");
                //Thread.Sleep(2000);
            }
            else
            {
                Console.WriteLine($"\nA Banda: {nomeDaBanda} já encontra-se em nosso cadastro de bandas\nTente novamente . . .");

            }
            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
