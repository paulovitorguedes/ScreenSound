namespace ScreenSound.Menus;

internal class MenuAvaliarAlbum : Menus
{
    ////override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    //internal override void Executar()
    //{

    //    var contex = new ScreenSoundContext();
    //    var artistaDal = new Dal<Artista>(contex);


    //    //base = Chama primeiramente o método da classe base (PAI) 
    //    base.Executar();
    //    ExibirTituloDaOpcao("Avaliar Albuns");

    //    Console.Write("Digite o nome do artista que possui o álbum desejado: ");
    //    string nomeDoArtista = Console.ReadLine()!.ToUpper();

    //    Artista artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList()[0];
    //    //Verifica se existe a Artista cadadtrada
    //    if (artistas is null)
    //    {

    //        //Verifica se o Artista já possui algum Álbum cadastrado
    //        if (artistas.Albuns.Count != 0)
    //        {
    //            Console.WriteLine("\nInforme quais dos álbuns abaixo deseja avaliar:");

    //            // Apresenta o nome de todos os Álbum da Artista selecionada
    //            int cont = 1;
    //            foreach (Album a in artistas.Albuns)
    //            {
    //                Console.WriteLine($"Álbum{cont++}: {a.Nome}");
    //            }

    //            Console.Write("\n\nÁlbum: ");
    //            string tituloAlbum = Console.ReadLine()!.ToUpper();

    //            Album album = artistas.Albuns.Find(a => a.Nome.Equals(tituloAlbum))!;

    //            if (album != null)
    //            {
    //                Console.Write($"Qual a nota que álbum {album.Nome} merece: ");

    //                //Avaliacao.Parce é um método static na class Avaliacao transformando a string em int e após criando o obj Avaliação
    //                Avaliacao avaliacao = Avaliacao.Parse(Console.ReadLine()!);

    //                album.AdicionarNota(avaliacao);
    //                Console.WriteLine($"\nA nota {avaliacao.Nota} foi registrada com sucesso para o Álbum {tituloAlbum}");
    //                //Thread.Sleep(2000);

    //            }
    //            else Console.WriteLine($"A Artista {nomeDoArtista} não possui Álbuns cadastrados\nTente primeiramente cadastrar um Álbum.");


    //        }
    //        else Console.WriteLine($"A Artista {nomeDoArtista} não foi encontrada em nossos cadastros\nTente novamente . . .");


    //        Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
    //        Console.ReadKey();
    //        Console.Clear();
    //    }

    //}
}
