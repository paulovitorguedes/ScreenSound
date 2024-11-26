using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuAvaliarBanda : Menus  //Extend a classe Menus como herança
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);
        ExibirTituloDaOpcao("Avaliar Artistas");


        Console.Write("Digite o nome da banda que deseja avaliar: ");
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
                    Console.Write($"Entre com a nota entre 0 e 10 para a banda {nomeDoArtista}: ");
                    int notaIndicada;

                    if (int.TryParse(Console.ReadLine(), out notaIndicada)) //Se o valor da nota indicado for um inteiro
                    {
                        if (notaIndicada >= 0 && notaIndicada <= 10) // Se o valor da nota indicado estiver dentro do range esperado 1 à 10
                        {
                            Console.WriteLine("Cadastrar Nota");
                            Artista artista = artistas.FirstOrDefault(a => a.Nome.Equals(nomeDoArtista))!;
                            AvaliacaoArtista avaliacaoArtista = new(notaIndicada);
                            artista.AdicionarNota(avaliacaoArtista);

                            artistaDal.Alterar(artista);
                            Console.WriteLine($"Avaliação cadastrada com sucesso para o Banda {nomeDoArtista}");
                        }
                        else
                        {
                            Console.WriteLine("Entre somente com os valores de 0 à 10");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Entre com um valor válido para avaliar");
                    }

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
