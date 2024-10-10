using ScreenSound.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menus
    {
        internal void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            Console.Clear();
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
