﻿using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuSair : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            Console.WriteLine("Tchau tchau :)");
        }
    }
}
