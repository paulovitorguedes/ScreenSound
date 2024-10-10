﻿using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuAvaliarBanda : Menus
    {
        internal void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            Console.Clear();
            ExibirTituloDaOpcao("Avaliar banda");
            Console.Write("Digite o nome da banda que deseja avaliar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            if (bandasRegistradas.ContainsKey(nomeDaBanda))
            {
                Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
                //Avaliacao.Parce é um método static na class Avaliacao transformando a string em int e após criando o obj Avaliação
                Avaliacao avaliacao = Avaliacao.Parse(Console.ReadLine()!);

                bandasRegistradas[nomeDaBanda].AdicionarNota(avaliacao);
                Console.WriteLine($"\nA nota {avaliacao.Nota} foi registrada com sucesso para a banda {nomeDaBanda}");
                //Thread.Sleep(2000);

            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            }

            Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }
    }
}