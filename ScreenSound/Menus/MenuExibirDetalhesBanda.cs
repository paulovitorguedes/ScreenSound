using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Menus;

internal class MenuExibirDetalhesBanda : Menus //Extend a classe Menus como herança
{
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Avaliar Artistas");


        Console.Write("Digite o nome da banda que deseja conhecer: ");
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
                //Busca uma lista de artistas com o nome estipulado em nomeDoArtista
                //A lista será vazia caso não encontre algum cadastro de artista com o nome citado
                List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList();
                if (artistas.Count > 0)
                {
                    //Apresenta titulo e bio
                    Artista artista = artistas.FirstOrDefault(a => a.Nome.Equals(nomeDoArtista))!;
                    Console.WriteLine($"\n\n########## - {artista.Nome} - ##########");
                    Console.WriteLine($"\n{artista.Bio}");

                    //Apresenta a média das notas da banda
                    List<int> notas = artista.BuscarNotas().ToList();
                    if (notas.Count > 0) Console.WriteLine($"Média: {notas.Average()}");

                    //Apresenta os Albuns e Duração total de cada álbum
                    List<Album> albuns = artista.Albuns.ToList();
                    if(albuns.Count > 0)
                    {
                        foreach (Album al in albuns)
                        {
                            Console.WriteLine($"\nÁlbum: {al.Nome} - Total: {al.DuracaoAlbum()} segundos");
                            string musicasDoAlbum = al.ExibirMusicasDoAlbum();
                            if (musicasDoAlbum == string.Empty) Console.WriteLine("O Álbum não possui música cadatradas! ");
                            else Console.WriteLine(musicasDoAlbum);

                        }
                    }
                    else Console.WriteLine("A Banda não possui álbum cadastrado! ");
                    
                }
                else
                {
                    Console.WriteLine("Artista não encontrado em nosso cadastro!\nTente novamente . . .");
                }

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
