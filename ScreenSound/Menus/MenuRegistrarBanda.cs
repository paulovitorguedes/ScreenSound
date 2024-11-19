using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menus //Extend a classe Menus como herança
{
    //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
    internal override void Executar(Dal<Artista> artistaDal)
    {
        //base = Chama primeiramente o método da classe base (PAI) 
        base.Executar(artistaDal);

        ExibirTituloDaOpcao("Cadastro de artistas");

        Console.WriteLine("\nDigite 1 para Cadastrar");
        Console.WriteLine("Digite 2 para Alterar");
        Console.WriteLine("Digite 3 para Excluir");
        Console.WriteLine("Digite 0 para retornar ao menu principal");

        Console.Write("\nDigite a sua opção: ");
        string opcaoEscolhida = Console.ReadLine()!;

        int opcaoEscolhidaNumerica;
        if (int.TryParse(opcaoEscolhida, out opcaoEscolhidaNumerica) && (opcaoEscolhidaNumerica >= 0 && opcaoEscolhidaNumerica <= 3))
        {
            switch (opcaoEscolhida)
            {
                case "1":
                    CadastrarBanda(artistaDal);
                    break;
                case "2":
                    AlterarBanda(artistaDal);
                    break;
                case "3":
                    ExcluirBanda(artistaDal);
                    break;
                case "0":
                    SairBanda();
                    break;
            }
        }
        else
        {
            Console.WriteLine("Opção inválida! Tente novamente.");
            Console.WriteLine("Digitr ENTER para continuar . . .");
            Console.ReadLine();
            Executar(artistaDal);
        }
    }

    private void SairBanda()
    {
        Console.Write("\n\nDigite ENTER para voltar ao menu principal ");
        Console.ReadKey();
        Console.Clear();
    }




    private void ExcluirBanda(Dal<Artista> artistaDal)
    {
        Console.Write("Digite o nome da banda que deseja Excluir: ");
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
                    artistaDal.Deletar(artistas.FirstOrDefault(b => b.Nome.Equals(nomeDoArtista))!);
                    Console.WriteLine($"\nA banda {nomeDoArtista} foi removida com sucesso!\nAguarde . . .");
                    SairBanda();
                }
                else
                {
                    Console.WriteLine($"\nA banda: {nomeDoArtista} Não foi encontrada em nossos cadastros\nTente novamente . . .");
                    Console.Write("\n\nDigite ENTER para continuar ");
                    Console.ReadKey();
                    Executar(artistaDal);
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



    }







    private void AlterarBanda(Dal<Artista> artistaDal)
    {
        Console.Write("Digite o nome da banda que deseja Alterar: ");
        string nomeDoArtista = Console.ReadLine()!.ToUpper();


        try
        {
            //Verifica se existe a Artista cadadtrada
            //Busca uma lista de artistas com o nome estipulado em nomeDoArtista
            //A lista será vazia caso não encontre algum cadastro de artista com o nome citado
            List<Artista> artistas = artistaDal.ListarPor(a => a.Nome.Equals(nomeDoArtista)).ToList();
            if (artistas.Count > 0)
            {
                Console.Write("Digite o novo nome da banda: ");
                string novoNomeDoArtista = Console.ReadLine()!.ToUpper();

                Console.Write("Digite uma rápida biografia da banda: ");
                string bioDoArtista = Console.ReadLine()!.ToUpper();

                Artista artista = artistas.FirstOrDefault(b => b.Nome.Equals(nomeDoArtista))!;
                artista.Nome = novoNomeDoArtista;
                artista.Bio = bioDoArtista;
                artistaDal.Alterar(artista);
                Console.WriteLine($"\nA banda {nomeDoArtista} foi alterada com sucesso!\nAguarde . . .");
                SairBanda();

            }
            else
            {
                Console.WriteLine($"\nA banda: {nomeDoArtista} não foi encontrada em nosso cadastro de artistas!\nTente novamente");
                Console.Write("\n\nDigite ENTER para continuar . . . ");
                Console.ReadKey();
                Executar(artistaDal);
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








    void CadastrarBanda(Dal<Artista> artistaDal)
    {
        Console.Write("Digite o nome da banda que deseja registrar: ");
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
                    Console.WriteLine($"\nA banda: {nomeDoArtista} já encontra-se em nosso cadastro de artistas\nTente novamente . . .");
                    Console.Write("\n\nDigite ENTER para continuar ");
                    Console.ReadKey();
                    Executar(artistaDal);
                }
                else
                {
                    Console.Write("Digite uma rápida biografia da banda: ");
                    string bioDoArtista = Console.ReadLine()!.ToUpper();

                    Artista artista = new(nomeDoArtista, bioDoArtista);
                    artistaDal.Adicionar(artista);
                    Console.WriteLine($"\nA banda {nomeDoArtista} foi registrada com sucesso!\nAguarde . . .");
                    SairBanda();
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
    }
}
