using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Models;

internal class MenuAvaliarMusica : Menus
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Avaliar Músicas");


        Console.Write("Digite o nome da banda: ");
        string nomeDoArtista = Console.ReadLine()!.ToUpper();

        if (nomeDoArtista == string.Empty) //Se for inserido um valor vazio
        {
            Console.WriteLine("O nome da banda é obrigatório!\nTente novamente.");
            Console.WriteLine("digite ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
            Executar(artistaDal);
        }
        else
        {
            try
            {
                //Verifica se existe a Artista cadadtrada
                //Artista poderá ser nulo 
                Artista? artista = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).FirstOrDefault();
                if (artista != null)
                {
                    //Se a banda exist - exibe os albuns
                    if (artista.Albuns.Count() > 0)
                    {
                        Console.WriteLine(artista.ExibirDiscografia());

                        string tituloAlbum = ""; //Impede a entrada de um valor vazio para cadastro do album
                        do
                        {
                            tituloAlbum = Console.ReadLine()!.ToUpper();

                            if (tituloAlbum == string.Empty)
                            {
                                Console.WriteLine("\nValor inserido é inválido\nTente Novamente");
                                Console.Write("\nAlbum: ");
                            }

                        } while (tituloAlbum == string.Empty);


                        //verifica se existe o Album cadastrado
                        if (artista.NomesAlbuns().Contains(tituloAlbum))
                        {
                            //Se a album exist - exibe as musicas

                            //solicita escolha da musica

                            //solicita entrada da nota

                            //cadastra no banco
                        }
                        else Console.WriteLine("O álbum inserido não encontra-se em nosso cadastro");

                    }
                    else Console.WriteLine("A banda inserida não possui musica cadastrada");
                    
                }
                else Console.WriteLine("A Banda inserida não encontra-se em nosso cadastro");
             
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar(artistaDal);
            }
        }
        Console.Write("\n\nDigite uma tecla para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }

}