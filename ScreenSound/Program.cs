using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Models;
using System.Reflection;



#region Espaco para testes 

//A instrução using tem como objetivo principal garantir que objetos descartáveis sejam utilizados corretamente.Quando declaramos uma variável local como using, ela é descartada no final do escopo em que ela foi declarada, portanto, será descartada ao finalizar a execução do try. Com isso conseguimos aplicar uma boa prática e gerenciar melhor os recursos que estão sendo utilizados e mantê-los somente quando estiverem sendo utilizados.



//______________________Descrição para utilizaçõ do OpenAI_API (Inteligencia artificial)

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





//____________________________TESTES COM BANDADAL

//try
//{

//    var contex = new ScreenSoundContext();
//    var bandaDal = new Dal<Artista>(contex);

//    //Adiciona a Artista no banco
//    //bandaDal.Adicionar(new Artista("Gilberto Gil", "Gilberto Gil é um cantor, compositor e instrumentista brasileiro, nascido em 26 de junho de 1942 em Salvador, Bahia, e um dos criadores do Movimento Tropicalista.."));




//    //altera a Artista de ID = 1 para a banda informada
//    //bandaDal.Alterar(new Artista("TESTE SOUND", "TEST TESTE SOUND") { Id = 3002 });



//    //Deletar a Artista de ID = 1002
//    //bandaDal.Deletar(new Artista() { Id = 1002 });



//    //Apresenta as Bandas do Banco
//    var listaBandas = bandaDal.Listar();

//    foreach (var bandas in listaBandas)
//    {
//        //Console.WriteLine(bandas.Id);
//        //Console.WriteLine(bandas.Nome);
//        //Console.WriteLine(bandas.Bio);
//        //Console.WriteLine(bandas.FotoPerfil);
//        Console.WriteLine(bandas);

//    }
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}

//return;


#endregion 


internal partial class Program
{
    private static void Main(string[] args)
    {

        // Obtém o assembly atual
        Assembly assembly = Assembly.GetExecutingAssembly();

        // Obtém o nome do assembly
        string assemblyName = assembly.GetName().Name;
        Console.WriteLine($"Nome do Assembly: {assemblyName}");

        // Obtém a versão do assembly
        Version version = assembly.GetName().Version;
        Console.WriteLine($"Versão do Assembly: {version}");

        // Obtém informações sobre o arquivo do assembly
        string location = assembly.Location;
        Console.WriteLine($"Localização do Assembly: {location}");

        // Obtém atributos do assembly
        object[] attributes = assembly.GetCustomAttributes(false);
        foreach (var attribute in attributes)
        {
            Console.WriteLine($"Atributo: {attribute.GetType().Name}");
        }














    var contex = new ScreenSoundContext();
        var artistadal = new Dal<Artista>(contex);
        Dictionary<string, Artista> bandasRegistradas = []; //Dicionary para a criação do Menu

        Dictionary<int, Menus> opcoes = [];
        opcoes.Add(1, new MenuRegistrarBanda());
        opcoes.Add(2, new MenuRegistrarAlbum());
        opcoes.Add(3, new MenuRegistrarMusica());
        opcoes.Add(4, new MenuAvaliarBanda());
        opcoes.Add(5, new MenuAvaliarAlbum());
        opcoes.Add(6, new MenuAvaliarMusica());
        opcoes.Add(7, new MenuMostrarBandas());
        opcoes.Add(8, new MenuExibirDetalhesAlbum());
        opcoes.Add(9, new MenuExibirDetalhesBanda());
        opcoes.Add(0, new MenuSair());

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
            Console.WriteLine("\nDigite 1 para Cadastrar uma Banda");
            Console.WriteLine("Digite 2 para Cadastrar um Álbum");
            Console.WriteLine("Digite 3 para registrar uma música de um album");
            Console.WriteLine("Digite 4 para avaliar uma banda");
            Console.WriteLine("Digite 5 para avaliar um álbum");
            Console.WriteLine("Digite 6 para avaliar uma música");
            Console.WriteLine("Digite 7 para mostrar todas as bandas");
            Console.WriteLine("Digite 8 para exibir os detalhes de um Album");
            Console.WriteLine("Digite 9 para exibir os detalhes de uma banda");
            Console.WriteLine("Digite 0 para sair");

            Console.Write("\nDigite a sua opção: ");
            string opcaoEscolhida = Console.ReadLine()!;

            int opcaoEscolhidaNumerica;
            //TryParse retornará um bool se a converção do string opcaoEscolhida para o int opcaoEscolhidaNumerica for sucedida
            bool ehNumero = int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica);

            //se a converção for sucedida e se a opcaoEscolhidaNumerica conter no menu
            if (ehNumero && opcoes.ContainsKey(opcaoEscolhidaNumerica))
            {
                Menus MenuASerExibido = opcoes[opcaoEscolhidaNumerica];
                MenuASerExibido.Executar(artistadal);
                if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
            }
            else
            {
                Console.WriteLine("Opção Inválida! Tente novamente");
                Console.WriteLine("Digite ENTER para continuar . . .");
                Console.ReadLine();
                Console.Clear();
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