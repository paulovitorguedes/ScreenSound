using Microsoft.EntityFrameworkCore;
using ScreenSound.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Numerics;
using static Azure.Core.HttpHeader;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System.Text;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace ScreenSound.Banco;

//O Entity Framework segue alguns padrões chamados de convenção para conseguir identificar corretamente os objetos, tabelas e informações que estamos passando através dele. No vídeo anterior conhecemos algumas dessas convenções:
//Chave primária identificada como Id;
//Mapear o nome da classe como o nome da tabela através do DbSet.
//Existem outras convenções que vão ser utilizadas de acordo com a necessidade e complexidade da aplicação que está sendo desenvolvida.Para saber mais sobre este tema
//https://learn.microsoft.com/pt-br/ef/ef6/modeling/code-first/fluent/types-and-properties

internal class ScreenSoundContext : DbContext
{
    public DbSet<Artista> Artistas { get; set; } //Artistas precisa ser o mesmo nome da tabela do banco de dados
    public DbSet<Album> Albuns { get; set; }

    private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ScreenSoundV0;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

    //Essa string foi recuperado do "Pesquisador de objetos do SQL Server", clicando com o botão direito no Bando "Screen Sound" em propriedades e na linha Cadeia de Conexão.


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       optionsBuilder.UseSqlServer(connectionString);
    }
}




//O Microsoft.EntityFrameworkCore.SqlServer é uma biblioteca ORM (Object Relational Mapping, ou Mapeamento de Objetos Relacionais, em português) responsável por fazer esse mapeamento do banco de dados relacional com uma aplicação orientada a objetos, que é o que estamos utilizando.

//ORM significa Object-Relational Mapping e é uma técnica que permite a interação de um sistema orientado a objetos com um banco de dados relacional de maneira mais intuitiva. O objetivo principal do ORM é mapear os objetos da aplicação diretamente para as tabelas do banco de dados utilizado, abstraindo esse acesso e se tornando mais próximo do que utilizamos em orientação a objetos

//Existem diversas bibliotecas ORM para as diversas linguagens de programação, e para o C# a mais utilizada no mercado de trabalho é o Entity Framework que vamos trabalhar ao longo deste curso. Para conhecer mais sobre essa relação entre as bibliotecas ORM e o gerenciamento de dados, confira a página https://learn.microsoft.com/pt-br/sql/connect/sql-connection-libraries?view=sql-server-ver16


//###############   MIGRATIONS
//No Entity Framework, as migrations são como um "arquiteto" que cuida de todas as alterações no seu banco de dados.Ele cria um plano detalhado para cada mudança, garantindo que tudo seja feito de forma organizada e segura.

//Para utilizá-la em nosso projeto, precisamos instalar alguns pacotes. Podemos ir em "Ferramentas > Gerenciador de pacotes do NuGet > Gerenciar pacotes do NuGet para a solução". No campo "Procurar", vamos procurar novamente por "Entity Framework".

//Agora, vamos instalar dois pacotes necessários neste momento: Microsoft Entity Framework Core Design e Microsoft Entity Framework Core Tools.

//Adicionar migration
//Com os pacotes instalados, precisamos adicionar a primeira migration ao nosso projeto.
//Para fazer isso, vamos em "Ferramentas > Gerenciador de pacotes do NuGet > Console do gerenciador de pacotes". É nesse console que vamos executar os comandos relacionados às migrations.Primeiramente, vamos adicionar essa migration inicial, que é referente ao status inicial do nosso banco.Vamos usar o comando Add.

//Quando escrevemos "Add", se pressionarmos "Tab", ele já começa a sugerir algumas opções.Podemos começar a escrever migration, e a sugestão de que queremos usar essa migration irá aparecer.

//Vamos usar "Tab" novamente para ele autocompletar e também precisamos informar qual será o nome inicial, o nome da nossa primeira migration. Podemos colocar projeto inicial.

//comando:
//Add-Migration projetoInicial      // onde projetoInicial é um nome que criamos para essa migration



//Se olharmos em nosso gerenciador de soluções, veremos que tem uma pasta nova em nosso projeto, chamada "migrations", que foi criada automaticamente assim que executamos a migration.Essa pasta contém dois arquivos: um com as informações do nosso projeto inicial e um snapshot, que é um outro arquivo gerado pela nossa migration, com outras informações adicionais.Mais adiante veremos o que tem em cada um desses arquivos.
//As migrations são um recurso do Entity que nos permite gerenciar tanto a estrutura do nosso banco quanto as diferentes versões que ele terá durante o projeto, sem precisar mexer nos scripts SQL.
//Através delas conseguimos fazer inclusão e exclusão de tabelas, alterações de colunas e mudanças de informações, tudo isso atrelado à evolução e crescimento do projeto de forma estruturada.

//Além disso, utilizando as migrations, é possível ter um histórico estruturado das alterações que ocorreram no banco de dados, facilitando o trabalho em equipe e também as atualizações em diversos ambientes existentes
//https://learn.microsoft.com/pt-br/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli


//cpmando:
// Update-Database projetoInicial

//Com esse comando, nossa migration vai conseguir localizar e executar a criação dessas tabelas e do banco comforme o nome encontra-se no connectionString catalog=.

//A primeira coisa que vamos fazer é adicionar uma nova migration para pegar o status atual do nosso banco e realizar as alterações.Vamos novamente no menu "Ferramentas > Gerenciador de Pacotes do Nuget > Console do Gerenciador de Pacotes".

//Vamos adicionar uma nova migration.Faremos o seguinte comando:

//comando:
//Add-Migration PopularTabela


//verificarmos no nosso gerenciador de soluções, na pasta "Migrations", veremos que foi criada uma nova classe chamada PopularTabela, que é exatamente a que acabamos de criar.
//Ainda temos os mesmos métodos, o Up() e o Down(), porém, eles estão vazios. Isso acontece porque não houve nenhuma alteração na nossa tabela. Não fizemos nenhuma alteração nem na tabela, nem no código, então, não tem nenhuma informação para eles trazerem

//Queremos adicionar na tabela Artistas. Escrevemos Artistas, entre aspas, e depois adicionamos uma vírgula e precisamos passar quais são as colunas que queremos adicionar os dados. Para passar as colunas, fazemos um new String e passamos os colchetes, porque vamos passar um array de strings. Seguindo as chaves, passamos todas as colunas que queremos adicionar. Temos a coluna Nome, em seguida, temos a coluna Bioe a coluna FotoPerfil.

//protected override void Up(MigrationBuilder migrationBuilder)
//{
//    migrationBuilder.InsertData("Artistas", new string[] { "Nome", "Bio", "FotoPerfil" }


//Quando chamamos só o Update-Database, ele verifica entre as nossas Migrações qual é a última atualização, o que tem de diferente do que já temos no nosso banco e executa.

//E quando passamos o nome de uma migration específica, ele executa as alterações somente até aquela migration.Aqui podemos rodar só o Update-Database que vai funcionar para nós com essas inclusões.


//comando
//Update-Database

// Em nossa tabela Musicas não havia o campo Nome
//para realizar essa alteração criamos a propriedade Nome na classe Musica 
//após isso criamos uma nova migratiom para essa função com o comando abaixo

//comando:
//Add-Migration AdicionarColunaNome

//Em seguida rodar o update para criar a coluna na tabela
//comando:
//Update-Database

