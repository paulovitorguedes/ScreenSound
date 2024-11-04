using ScreenSound.Menus;
using ScreenSound.Models;
using OpenAI_API;
using System.Runtime.Intrinsics.X86;
using ScreenSound.Banco;
using static System.Formats.Asn1.AsnWriter;

// Para operar com o using OpenAI_API; será necessário instalar uma dependencia do OpenAi
// Ao instanciar o OpenAIAPI entramos como parâmetro a key gerada pelo chatGpt ex: new OpenAIAPI("chave gerada pelo site do chatGpt")

//var client = new OpenAIAPI("");
//var chat = client.Chat.CreateConversation();
//chat.AppendSystemMessage("Resuma a banda Metálica em 1 parágrafo. Adote um estilo informal.");

//Nesse caso, o método GetResponse() é executado de forma assíncrona. Isso significa que a execução não parará no fim desse trecho de código que criamos, ela continuará executando o restante.
//Precisamos informar para o #C que queremos esperar o término da execução dessa requisição. Para isso, antes de GetResponse() escrevemos
//await.

//string resposta = await chat.GetResponseFromChatbotAsync();
//string resposta2 = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
//Console.WriteLine(resposta2);

//A palavra reservada await precisa estar em conjunto com a palavra async.
//De forma geral, os métodos assíncronos retornam uma tarefa, porém, nesse caso, utilizaremos outra estrutura. Então apagamos o await.
//Feito isso, se passarmos o mouse no método de GetResponseFromChatbotAsync(), percebemos que essa é uma tarefa que retorna uma string.
//Então, na mesma linha, escrevemos .GetAwaiter(), para haver a espera e depois .GetResult() para termos o resultado.
//Recomendamos essa opção somente se não for possível utilizar o awaite o async



try
{
    
    var bandaDal = new BandaDal();

    bandaDal.Adicionar(new Banda("FOO FIGHTERS", "descreva uma biagrafia de 1 linha sobre FOO FIGHTERS\r\nFoo Fighters é uma banda de rock americana, formada em 1994 por Dave Grohl, ex-baterista do Nirvana."));

    var listaBandas = bandaDal.Listar();

    foreach ( var bandas in listaBandas)
    {
        //Console.WriteLine(bandas.Id);
        //Console.WriteLine(bandas.Nome);
        //Console.WriteLine(bandas.Bio);
        //Console.WriteLine(bandas.FotoPerfil);
        Console.WriteLine(bandas);

    }


}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

return;





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



//Para criarmos um banco para utilizar na nossa aplicação

//vamos em "Exibir > Pesquisador de Objetos do SQL Server". Ao clicar nele, abrirá uma janela na lateral esquerda do Visual Studio.

//Teremos a pasta "Banco de Dados", e clicando com o botão direito sobre ela, temos a opção "Adicionar Novo Banco de Dados". Vamos selecionar essa opção e criar um banco de dados com o nome do nosso projeto

//No banco de dados ScreenSound, se clicarmos com o botão direito, temos a opção "Nova Consulta…", onde conseguimos executar os scripts que vão realizar as ações com o banco.

//No Gerenciar Pacotes do NuGet para a Solução… vamos instalar o Microsoft.Data.SqlClient
//o qual utilizaremos em nosso projeto para estabelecer o vínculo do banco de dados com o projeto em si.