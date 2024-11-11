using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class MenuExibirDetalhesBanda : Menus //Extend a classe Menus como herança
    {
        //override = cria a sobrecarga do método Executar que encontra-se na classe Pai Menus (Polimofirmo) 
        internal override void Executar(Dal<Banda> bandaDal)
        {
            //base = Chama primeiramente o método da classe base (PAI) 
            base.Executar(bandaDal);
            ExibirTituloDaOpcao("Exibir detalhes da banda");
            Console.Write("Digite o nome da banda que deseja conhecer melhor: ");
            string nomeDaBanda = Console.ReadLine()!.ToUpper();
            Banda banda = bandaDal.ListarBandaPor(a => a.Nome.Equals(nomeDaBanda))!;

            //Verifica se existe a Banda cadastrada
            if (banda != null)
            {
                // Apresenta o nome de todos os Álbum da Banda selecionada
                Console.WriteLine($"\n\nA banda {nomeDaBanda} possui o(s) álbun(s) cadastrado(s): ");
                int cont = 1;
                if (banda.Albuns.Count > 0)
                {
                    foreach (Album a in banda.Albuns)
                    {
                        Console.WriteLine($"Álbum{cont++}: {a.Nome} com duração de {a.DuracaoTotal} Segundos.");
                    }
                }
                else
                {
                    Console.WriteLine("Não foi detectado albuns cadastrados");
                }

                Console.WriteLine("\nPossui a(s) nota(s) cadastrada(s): ");
                Console.WriteLine("Notas: ");
                foreach (Avaliacao avaliacao in banda.Notas)
                {
                    Console.Write(avaliacao.Nota + " ");
                }
                Console.WriteLine($"Média: {banda.Media}");
            }
            else
            {
                Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
            }

            Console.WriteLine("\n\nDigite uma tecla para voltar ao menu principal ");
            Console.ReadKey();
            Console.Clear();

        }
    }
}
