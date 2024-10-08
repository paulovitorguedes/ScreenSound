﻿using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuMostrarBandas : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar(bandasRegistradas);
            ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

            foreach (var banda in bandasRegistradas.Keys)
            {
                Console.WriteLine($"Banda: {banda}");
            }

            Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
