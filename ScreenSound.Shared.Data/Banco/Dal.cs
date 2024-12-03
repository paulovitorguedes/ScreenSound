namespace ScreenSound.Banco
{
    public class Dal<T> where T : class
    {
        private readonly ScreenSoundContext _context;


        public Dal(ScreenSoundContext context)
        {
            _context = context;
        }


        public IEnumerable<T> Listar()//Aqui o T se refere a um objeto do Models
        {
            //return _context.Artistas.ToList();
            return _context.Set<T>().ToList();//Aqui o Set se refere a tabela que corresponde ao objeto do Models
        }


        public void Adicionar(T objeto)
        {
            // _context.Artistas.Add(banda);
            _context.Set<T>().Add(objeto);
            _context.SaveChanges();
        }


        public void Alterar(T objeto)
        {
            //_context.Artistas.Update(banda);
            _context.Set<T>().Update(objeto);
            _context.SaveChanges();
        }


        public void Deletar(T objeto)
        {
            //_context.Artistas.Remove(banda);
            _context.Set<T>().Remove(objeto);
            _context.SaveChanges();
        }



        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return _context.Set<T>().Where(condicao).ToList();
        }

        //Documentação do Func
        //https://learn.microsoft.com/pt-br/dotnet/api/system.func-2?view=net-8.0

    }
}





//Se você já ouviu falar em DAO escrito com a letra “o”, pode estar se perguntando qual a diferença entre esta escrita e a de DAL com “l”, como utilizamos no vídeo anterior.Sim, os dois são duas coisas diferentes:

//DAO - Data Access Object
//DAL - Data Access Layer
//O DAL é a camada de acesso a dados que promove a abstração desses dados e vai emitir todos os comandos de SELECT, INSERT, UPDATE E DELETE de maneira separada da lógica das classes do projeto e independente da fonte de dados, enquanto o DAO é um objeto do banco de dados que representa um banco aberto.

//Basicamente, o DAL representa a estrutura de acesso aos dados, independente do tipo de banco utilizado, e o DAO é o objeto que representa o acesso a uma fonte de dados específica.

//Para saber mais sobre a situação de utilização de cada um deles e também ver outros exemplos de aplicação desses padrões, sugerimos acessar as documentações a seguir:

//Data Access Layer (DAL) https://learn.microsoft.com/en-us/aspnet/web-forms/overview/data-access/introduction/creating-a-data-access-layer-cs
//Data Access Object (DAO) https://learn.microsoft.com/pt-br/cpp/mfc/dao-classes?view=msvc-170