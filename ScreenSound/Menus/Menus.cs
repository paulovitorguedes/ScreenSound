using ScreenSound.Models;

namespace ScreenSound.Menus
{
    internal class Menus
    {

        internal virtual void Executar(Dictionary<string, Banda> bandasRegistradas)
        {
            Console.Clear();
            Console.WriteLine("TESTE");
        }

        //Cria um título composto com * como borda
        internal void ExibirTituloDaOpcao(string titulo)
        {
            int quantidadeDeLetras = titulo.Length;
            string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
            Console.WriteLine(asteriscos);
            Console.WriteLine(titulo);
            Console.WriteLine(asteriscos + "\n");
        }

    }
}
