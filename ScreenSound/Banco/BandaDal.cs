using Microsoft.Data.SqlClient;
using ScreenSound.Models;

namespace ScreenSound.Banco
{
    internal class BandaDal
    {
        public IEnumerable<Banda> Listar()
        {
            var lista = new List<Banda>();

            //A instrução using tem como objetivo principal garantir que objetos descartáveis sejam utilizados corretamente.Quando declaramos uma variável local como using, ela é descartada no final do escopo em que ela foi declarada, portanto, será descartada ao finalizar a execução do try. Com isso conseguimos aplicar uma boa prática e gerenciar melhor os recursos que estão sendo utilizados e mantê-los somente quando estiverem sendo utilizados.
            using var connection = new Connection().ObterConexao();
            connection.Open();

            string sql = "SELECT * FROM Artistas";

            SqlCommand command = new SqlCommand(sql, connection); //SQLComand - representa a instrução SQL que será executada no banco de dados;

            using SqlDataReader dataReader = command.ExecuteReader(); //SQLDataReader - fornece um modo de ler as linhas do banco de dados.

            while (dataReader.Read())
            {
                string nomeBanda = Convert.ToString(dataReader["Nome"]);
                string bioBanda = Convert.ToString(dataReader["Bio"]);
                int idBanda = Convert.ToInt32(dataReader["Id"]);

                Banda banda = new(nomeBanda, bioBanda) { Id = idBanda };

                lista.Add(banda);
            }
            return lista;
        }
    }
}
