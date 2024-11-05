using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;
using System.Collections.Generic;
using System;

namespace ScreenSound.Banco;

//O Entity Framework segue alguns padrões chamados de convenção para conseguir identificar corretamente os objetos, tabelas e informações que estamos passando através dele. No vídeo anterior conhecemos algumas dessas convenções:
//Chave primária identificada como Id;
//Mapear o nome da classe como o nome da tabela através do DbSet.
//Existem outras convenções que vão ser utilizadas de acordo com a necessidade e complexidade da aplicação que está sendo desenvolvida.Para saber mais sobre este tema
//https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties

internal class ScreenSoundContext : DbContext
{
    public DbSet<Banda> Artistas { get; set; } //Artistas precisa ser o mesmo nome da tabela do banco de dados


    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSound;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    //Essa string foi recuperado do "Pesquisador de objetos do SQL Server", clicando com o botão direito no Bando "Screen Sound" em propriedades e na linha Cadeia de Conexão.


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer(connectionString);
    }
}




//O Microsoft.EntityFrameworkCore.SqlServer é uma biblioteca ORM (Object Relational Mapping, ou Mapeamento de Objetos Relacionais, em português) responsável por fazer esse mapeamento do banco de dados relacional com uma aplicação orientada a objetos, que é o que estamos utilizando.

//ORM significa Object-Relational Mapping e é uma técnica que permite a interação de um sistema orientado a objetos com um banco de dados relacional de maneira mais intuitiva. O objetivo principal do ORM é mapear os objetos da aplicação diretamente para as tabelas do banco de dados utilizado, abstraindo esse acesso e se tornando mais próximo do que utilizamos em orientação a objetos

//Existem diversas bibliotecas ORM para as diversas linguagens de programação, e para o C# a mais utilizada no mercado de trabalho é o Entity Framework que vamos trabalhar ao longo deste curso. Para conhecer mais sobre essa relação entre as bibliotecas ORM e o gerenciamento de dados, confira a página https://learn.microsoft.com/pt-br/sql/connect/sql-connection-libraries?view=sql-server-ver16