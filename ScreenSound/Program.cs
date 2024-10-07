﻿using ScreenSound.Models;

Dictionary<String, Banda> bandasRegistradas = [];
//bandasRegistradas.Add("Linkin Park", new List<int> { 10, 8, 6 });
//bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine("Boas vindas ao Screen Sound 2.0!");
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para registrar o álbum de uma banda");
    Console.WriteLine("Digite 3 para mostrar todas as bandas");
    Console.WriteLine("Digite 4 para avaliar uma banda");
    Console.WriteLine("Digite 5 para exibir os detalhes de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBanda();
            break;
        case 2:
            RegistrarAlbum();
            break;
        case 3:
            MostrarBandasRegistradas();
            break;
        case 4:
            //AvaliarUmaBanda();
            break;
        case 5:
            //ExibirDetalhes();
            break;
        case -1:
            Console.WriteLine("Tchau tchau :)");
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!.ToUpper();

    if (!bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Banda banda = new(nomeDaBanda);
        bandasRegistradas.Add(nomeDaBanda, banda);
        Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!");
    }
    else
    {
        Console.WriteLine($"A Banda: {nomeDaBanda} já encontra-se em nosso cadastro de bandas");
    }
    
    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void RegistrarAlbum()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de álbuns");
    Console.Write("Digite a banda cujo álbum deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!.ToUpper();

    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write("Agora digite o título do álbum: ");
        string tituloAlbum = Console.ReadLine()!.ToUpper();
        Album album = new(tituloAlbum);

        foreach(var i in bandasRegistradas.Keys)
        {
            if (i.Equals(nomeDaBanda))
            {
                Banda banda = bandasRegistradas[i];
                banda.AdicionarAlbum(album);
            }
        }

        Console.WriteLine($"O álbum {tituloAlbum} de {nomeDaBanda} foi registrado com sucesso!");
    }
    else
    {
        Console.WriteLine($"A Banda {nomeDaBanda} não foi encontrada em nossos cadastros \nTente Novamente ... ");
    }

    Thread.Sleep(4000);
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas registradas na nossa aplicação");

    foreach (var banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
    Console.ReadKey();
    Console.Clear();
    ExibirOpcoesDoMenu();

}

//void AvaliarUmaBanda()
//{
//    Console.Clear();
//    ExibirTituloDaOpcao("Avaliar banda");
//    Console.Write("Digite o nome da banda que deseja avaliar: ");
//    string nomeDaBanda = Console.ReadLine()!;
//    if (bandasRegistradas.ContainsKey(nomeDaBanda))
//    {
//        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
//        int nota = int.Parse(Console.ReadLine()!);
//        bandasRegistradas[nomeDaBanda].Add(nota);
//        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso para a banda {nomeDaBanda}");
//        Thread.Sleep(2000);
//        Console.Clear();
//        ExibirOpcoesDoMenu();
//    }
//    else
//    {
//        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
//        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
//        Console.ReadKey();
//        Console.Clear();
//        ExibirOpcoesDoMenu();
//    }

//}

//void ExibirDetalhes()
//{
//    Console.Clear();
//    ExibirTituloDaOpcao("Exibir detalhes da banda");
//    Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
//    string nomeDaBanda = Console.ReadLine()!;
//    if (bandasRegistradas.ContainsKey(nomeDaBanda))
//    {
//        List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
//        Console.WriteLine($"\nA média da banda {nomeDaBanda} é {notasDaBanda.Average()}.");
//        /**
//        * ESPAÇO RESERVADO PARA COMPLETAR A FUNÇÃO
//        */
//        Console.WriteLine("Digite uma tecla para votar ao menu principal");
//        Console.ReadKey();
//        Console.Clear();
//        ExibirOpcoesDoMenu();

//    }
//    else
//    {
//        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
//        Console.WriteLine("Digite uma tecla para voltar ao menu principal");
//        Console.ReadKey();
//        Console.Clear();
//        ExibirOpcoesDoMenu();
//    }
//}

ExibirOpcoesDoMenu();