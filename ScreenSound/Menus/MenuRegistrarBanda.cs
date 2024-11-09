using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuRegistrarBanda : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(BandaDal bandaDal)
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar(bandaDal);

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
                Executar(bandaDal);
            }
        }

        private void SairBanda()
        {
            Console.Write("\n\nDigite ENTER para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();
        }

        private void ExcluirBanda(BandaDal bandaDal)
        {
            throw new NotImplementedException();
        }







        private void AlterarBanda(BandaDal bandaDal)
        {
            Console.Write("Digite o nome da banda que deseja Alterar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            Banda banda = bandaDal.ListarBandaPorNome(nomeDaBanda);
            if (banda != null)
            {
                try
                {
                    Console.Write("Digite o novo nome da banda: ");
                    nomeDaBanda = Console.ReadLine()!.ToUpper();

                    Console.Write("Digite uma rápida biografia da Banda: ");
                    string bioDaBanda = Console.ReadLine()!.ToUpper();
                    banda.Nome = nomeDaBanda;
                    banda.Bio = bioDaBanda;
                    bandaDal.Alterar(banda);
                    //bandaDal.Alterar(new Banda(nomeDaBanda, bioDaBanda) { Id = 3002 });
                    Console.WriteLine($"\nA banda {nomeDaBanda} foi alterada com sucesso!\nAguarde . . .");
                    SairBanda();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Falha apresentada: {ex.Message}");
                    Console.Write("\n\nDigite ENTER para continuar ");
                    Console.ReadKey();
                    Executar(bandaDal);
                }

            }
            else
            {
                Console.WriteLine($"\nA Banda: {nomeDaBanda} não foi encontrada em nosso cadastro de bandas!\nTente novamente");
                Console.Write("\n\nDigite ENTER para continuar . . . ");
                Console.ReadKey();
                Executar(bandaDal);
            }
        }








        void CadastrarBanda(BandaDal bandaDal)
        {
            Console.Write("Digite o nome da banda que deseja registrar: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();

            Console.Write("Digite uma rápida biografia da Banda: ");
            string bioDaBanda = Console.ReadLine()!.ToUpper();

            Banda banda = bandaDal.ListarBandaPorNome(nomeDaBanda);
            //Verifica se existe a Banda cadadtrada
            if (banda == null)
            {
                banda = new(nomeDaBanda, bioDaBanda);
                try
                {
                    bandaDal.Adicionar(banda);
                    Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!\nAguarde . . .");
                    SairBanda();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Falha apresentada: {ex.Message}");
                    Console.Write("\n\nDigite ENTER para continuar ");
                    Console.ReadKey();
                    Executar(bandaDal);
                }
               
            }
            else
            {
                Console.WriteLine($"\nA Banda: {nomeDaBanda} já encontra-se em nosso cadastro de bandas\nTente novamente . . .");
                Console.Write("\n\nDigite ENTER para continuar ");
                Console.ReadKey();
                Executar(bandaDal);
            }
        }
    }
}
