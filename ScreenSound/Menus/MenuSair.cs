﻿using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Menus
{
    internal class MenuSair : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(Dal<Artista> artistadal)
        {
            Console.WriteLine("Tchau tchau :)");
        }
    }
}
