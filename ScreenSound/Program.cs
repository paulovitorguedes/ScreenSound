using ScreenSound.Menus;
using ScreenSound.Models;
using OpenAI_API;
using System.Runtime.Intrinsics.X86;

// Para operar com o using OpenAI_API; será necessário instalar uma dependencia do OpenAi
// Ao instanciar o OpenAIAPI entramos como parâmetro a key gerada pelo chatGpt
var client = new OpenAIAPI("");

var chat = client.Chat.CreateConversation();
chat.AppendSystemMessage("Resuma a banda Metálica em 1 parágrafo. Adote um estilo informal.");

//Nesse caso, o método GetResponse() é executado de forma assíncrona. Isso significa que a execução não parará no fim desse trecho de código que criamos, ela continuará executando o restante.
//Precisamos informar para o #C que queremos esperar o término da execução dessa requisição. Para isso, antes de GetResponse() escrevemos await.
string resposta = await chat.GetResponseFromChatbotAsync();
string resposta2 = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
Console.WriteLine(resposta2);

//A palavra reservada await precisa estar em conjunto com a palavra async.

//De forma geral, os métodos assíncronos retornam uma tarefa, porém, nesse caso, utilizaremos outra estrutura. Então apagamos o await.

//Feito isso, se passarmos o mouse no método de GetResponseFromChatbotAsync(), percebemos que essa é uma tarefa que retorna uma string.

//Então, na mesma linha, escrevemos .GetAwaiter(), para haver a espera e depois .GetResult() para termos o resultado.

//Recomendamos essa opção somente se não for possível utilizar o awaite o async



internal partial class Program
{
    private static void Main(string[] args)
    {
        Dictionary<string, Banda> bandasRegistradas = [];

        Dictionary<int, Menus> opcoes = [];
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuRegistrarMusica());
        opcoes.Add(4, new MenuMostrarBandas());
        opcoes.Add(5, new MenuAvaliarBanda());
        opcoes.Add(6, new MenuExibirDetalhes());
        opcoes.Add(7, new MenuAvaliarAlbum());
        opcoes.Add(-1, new MenuSair());

        ExibirOpcoesDoMenu();

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
            Console.WriteLine("Digite 3 para registrar uma música de um album");
            Console.WriteLine("Digite 4 para mostrar todas as bandas");
            Console.WriteLine("Digite 5 para avaliar uma banda");
            Console.WriteLine("Digite 6 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite 7 para avaliar um álbum");
            Console.WriteLine("Digite -1 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;
            int opcaoEscolhidaNumerica;

            //int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
            bool ehNumero = int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica);

            if (ehNumero && opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {

                Menus MenuASerExibido = opcoes[opcaoEscolhidaNumerica];
                MenuASerExibido.Executar(bandasRegistradas);
                if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
            }
            else
            {
                Console.WriteLine("Opção Inválida . . .\nTente novamente");
                ExibirOpcoesDoMenu();
            }

        }
    }
}