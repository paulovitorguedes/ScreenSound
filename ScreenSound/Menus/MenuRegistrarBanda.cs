using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar()
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar();

            var contex = new ScreenSoundContext();
            var bandaDal = new Dal<Banda>(contex);

            ExibirTituloDaOpcao("Cadastro de bandas");

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
                        CadastrarBanda(bandaDal);
                        break;
                    case "2":
                        AlterarBanda(bandaDal);
                        break;
                    case "3":
                        ExcluirBanda(bandaDal);
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
                Executar();
            }
        }



        private void SairBanda()
        {
            Console.Write("\n\nDigite ENTER para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }




        private void ExcluirBanda(Dal<Banda> bandaDal)
        {
            Console.Write("Digite o nome da banda que deseja Excluir: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();


            try
            {
                //Verifica se existe a Banda cadadtrada
                //Busca uma lista de bandas com o nome estipulado em nomeDaBanda
                //A lista será vazia caso não encontre algum cadastro de banda com o nome citado
                List<Banda> bandas = bandaDal.ListarPor(a => a.Nome.Equals(nomeDaBanda)).ToList();
                if (bandas.Count > 0)
                {
                    bandaDal.Deletar(bandas.FirstOrDefault(b => b.Nome.Equals(nomeDaBanda))!);
                    Console.WriteLine($"\nA banda {nomeDaBanda} foi removida com sucesso!\nAguarde . . .");
                    SairBanda();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar();
            }
            
            
        }







        private void AlterarBanda(Dal<Banda> bandaDal)
        {
            Console.Write("Digite o nome da banda que deseja Alterar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();


            try
            {
                //Verifica se existe a Banda cadadtrada
                //Busca uma lista de bandas com o nome estipulado em nomeDaBanda
                //A lista será vazia caso não encontre algum cadastro de banda com o nome citad
                List<Banda> bandas = bandaDal.ListarPor(a => a.Nome.Equals(nomeDaBanda)).ToList();
                if (bandas.Count > 0)
                {
                    Console.Write("Digite o novo nome da banda: ");
                    string novoNomeDaBanda = Console.ReadLine()!.ToUpper();

                    Console.Write("Digite uma rápida biografia da Banda: ");
                    string bioDaBanda = Console.ReadLine()!.ToUpper();

                    Banda banda = bandas.FirstOrDefault(b => b.Nome.Equals(nomeDaBanda))!;
                    banda.Nome = novoNomeDaBanda;
                    banda.Bio = bioDaBanda;
                    bandaDal.Alterar(banda);
                    Console.WriteLine($"\nA banda {nomeDaBanda} foi alterada com sucesso!\nAguarde . . .");
                    SairBanda();

                }
                else
                {
                    Console.WriteLine($"\nA Banda: {nomeDaBanda} não foi encontrada em nosso cadastro de bandas!\nTente novamente");
                    Console.Write("\n\nDigite ENTER para continuar . . . ");
                    Console.ReadKey();
                    Executar();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar();
            }
            
        }








        void CadastrarBanda(Dal<Banda> bandaDal)
        {
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();
                        
            try
            {
                //Verifica se existe a Banda cadadtrada
                //Busca uma lista de bandas com o nome estipulado em nomeDaBanda
                //A lista será vazia caso não encontre algum cadastro de banda com o nome citado
                List<Banda> bandas = bandaDal.ListarPor(a => a.Nome.Equals(nomeDaBanda)).ToList();
                if (bandas.Count > 0)
                {
                    Console.WriteLine($"\nA Banda: {nomeDaBanda} já encontra-se em nosso cadastro de bandas\nTente novamente . . .");
                    Console.Write("\n\nDigite ENTER para continuar ");
                    Console.ReadKey();
                    Executar();
                }
                else
                {
                    Console.Write("Digite uma rápida biografia da Banda: ");
                    string bioDaBanda = Console.ReadLine()!.ToUpper();

                    Banda banda = new(nomeDaBanda, bioDaBanda);
                    bandaDal.Adicionar(banda);
                    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!\nAguarde . . .");
                    SairBanda();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Falha apresentada: {ex.Message}");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar();
            }

        }
    }
}
