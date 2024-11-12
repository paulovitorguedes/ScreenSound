namespace ScreenSound.Banco
{
    internal class Dal<T> where T : class
    {
        protected readonly ScreenSoundContext _context;


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
