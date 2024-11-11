


//#####################    Esta classe foi mantida apenas para estudo e não está sendo utilizada

/*
using ScreenSound.Models;

namespace ScreenSound.Banco;

internal class BandaDal : Dal<Banda>
{

    

    //public BandaDal(ScreenSoundContext context) : base(context) { }


  /*  public Banda ListarBandaPorNome(string nome)
    {

        // return _context.Artistas.Where(n => n.Nome.Equals(nome)); //Aqui se houver mais de um cadastro da mesma Banda, retorta  IEnumerable<Banda>
        return _context.Artistas.FirstOrDefault(n => n.Nome.Equals(nome))!;
    }

  */


    /* public override IEnumerable<Banda> Listar()
     {
        
         //return _context.Artistas.ToList();






         //Utilizando a classe Conection e inserindo as querys manualmente


         //var lista = new List<Banda>();

         ////A instrução using tem como objetivo principal garantir que objetos descartáveis sejam utilizados corretamente.Quando declaramos uma variável local como using, ela é descartada no final do escopo em que ela foi declarada, portanto, será descartada ao finalizar a execução do try. Com isso conseguimos aplicar uma boa prática e gerenciar melhor os recursos que estão sendo utilizados e mantê-los somente quando estiverem sendo utilizados.
         //using var connection = new Connection().ObterConexao();
         //connection.Open();

         //string sql = "SELECT * FROM Artistas";

         //SqlCommand command = new SqlCommand(sql, connection); //SQLComand - representa a instrução SQL que será executada no banco de dados;

         //using SqlDataReader dataReader = command.ExecuteReader(); //SQLDataReader - fornece um modo de ler as linhas do banco de dados.

         //while (dataReader.Read())
         //{
         //    string nomeBanda = Convert.ToString(dataReader["Nome"]);
         //    string bioBanda = Convert.ToString(dataReader["Bio"]);
         //    int idBanda = Convert.ToInt32(dataReader["Id"]);

         //    Banda banda = new(nomeBanda, bioBanda) { Id = idBanda };

         //    lista.Add(banda);
         //}
         //return lista;
    }
    */



    /*  public override void Adicionar(Banda banda)
      {


          //Utilizando a classe ScreenSoundContext com o Entity Framework


          //using var context = new ScreenSoundContext();
          _context.Artistas.Add(banda);
          _context.SaveChanges();




          //Utilizando a classe Conection e inserindo as querys manualmente

          //using var connection = new Connection().ObterConexao();
          //connection.Open();

          //string sql = "INSERT INTO Artistas (Nome, FotoPerfil, Bio) VALUES (@nome, @perfilPadrao, @bio)";
          //SqlCommand command = new SqlCommand(sql, connection);

          //command.Parameters.AddWithValue("@nome", banda.Nome);
          //command.Parameters.AddWithValue("@perfilPadrao", banda.FotoPerfil);
          //command.Parameters.AddWithValue("@bio", banda.Bio);

          //int retorno = command.ExecuteNonQuery();
          //Console.WriteLine($"Linhas afetadas: {retorno}");
      }
  */



    /*   public override void Alterar(Banda banda)
       {

           //Utilizando a classe ScreenSoundContext com o Entuty Framework


           //using var context = new ScreenSoundContext();
           _context.Artistas.Update(banda);
           _context.SaveChanges();




           //Utilizando a classe Conection e inserindo as querys manualmente


           //using var connection = new Connection().ObterConexao();
           //connection.Open();

           //string sql = "UPDATE Artistas SET Nome = @nome, Bio = @bio WHERE Id = @id";
           //SqlCommand command = new SqlCommand(sql, connection);

           //command.Parameters.AddWithValue("@id", banda.Id);
           //command.Parameters.AddWithValue("@nome", banda.Nome);
           //command.Parameters.AddWithValue("@bio", banda.Bio);

           //int retorno = command.ExecuteNonQuery();
           //Console.WriteLine($"Linhas afetadas: {retorno}");
       }
    */


    /*   public override void Deletar(Banda banda)
       {


           //Utilizando a classe ScreenSoundContext com o Entuty Framework


           //using var context = new ScreenSoundContext();
           _context.Artistas.Remove(banda);
           _context.SaveChanges();





           //Utilizando a classe Conection e inserindo as querys manualmente


           //using var connection = new Connection().ObterConexao();
           //connection.Open();

           //string sql = "DELETE FROM Artistas WHERE Id = @id";
           //SqlCommand command = new SqlCommand(sql, connection);

           //command.Parameters.AddWithValue("@id", banda.Id);

           //int retorno = command.ExecuteNonQuery();
           //Console.WriteLine($"Linhas afetadas: {retorno}");
       }

   */

//}









//Se você já ouviu falar em DAO escrito com a letra “o”, pode estar se perguntando qual a diferença entre esta escrita e a de DAL com “l”, como utilizamos no vídeo anterior.Sim, os dois são duas coisas diferentes:

//DAO - Data Access Object
//DAL - Data Access Layer
//O DAL é a camada de acesso a dados que promove a abstração desses dados e vai emitir todos os comandos de SELECT, INSERT, UPDATE E DELETE de maneira separada da lógica das classes do projeto e independente da fonte de dados, enquanto o DAO é um objeto do banco de dados que representa um banco aberto.

//Basicamente, o DAL representa a estrutura de acesso aos dados, independente do tipo de banco utilizado, e o DAO é o objeto que representa o acesso a uma fonte de dados específica.

//Para saber mais sobre a situação de utilização de cada um deles e também ver outros exemplos de aplicação desses padrões, sugerimos acessar as documentações a seguir:

//Data Access Layer (DAL) https://learn.microsoft.com/en-us/aspnet/web-forms/overview/data-access/introduction/creating-a-data-access-layer-cs
//Data Access Object (DAO) https://learn.microsoft.com/pt-br/cpp/mfc/dao-classes?view=msvc-170


