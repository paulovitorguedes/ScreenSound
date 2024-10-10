using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Registro das bandas");
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            //Verifica sa já existe a Banda cadastrada
            if (!bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Banda banda = new(nomeDaBanda);
                bandasRegistradas.Add(nomeDaBanda, banda);
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
