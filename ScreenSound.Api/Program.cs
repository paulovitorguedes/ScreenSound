using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Models;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Estamos fazendo uma consulta e retornando um objeto do tipo "lista de artistas", mas o Artista possui uma lista de m�sicas, e em Musica existe uma refer�ncia para o Artista. Isso resulta em um loop e, no momento em que o nosso cliente precisa converter essa lista de objetos em um JSON, ocorre esse erro.
//O c�digo abaixo resolve esse erro
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
    options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//Inje��o de depend�ncia
//Adicionando a cria��o do nosso objeto DAL no Builder Services.
//Para isso, usamos o builder.Services.AddTransient, passando DAL na anota��o diamante.
//No DAL tamb�m h� outra anota��o diamante para especificar qual tipo de DAL estamos querendo criar.
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<Dal<Artista>>();
builder.Services.AddTransient<Dal<Musica>>();
builder.Services.AddTransient<Dal<Album>>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();




//Configuramos um recurso nativo do Asp.NET que permite que ele crie os objetos que vamos utilizar na aplica��o. Isso � chamado de inje��o de depend�ncia.
//A partir da configura��o via builder.Services, falamos que todos os nossos endpoints dependem de um servi�o para funcionar, que definimos utilizando o atributo [FromService] para invocar o objeto DAL que vai ser criado pela pr�pria aplica��o.

app.MapGet("/Artistas/", ([FromServices] Dal<Artista> dal) =>
{
    return dal.Listar();
});



app.MapGet("/Artistas/{nome}", ([FromServices] Dal<Artista> dal, string nome) =>
{
    var artista = dal.ListarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
    if (artista is null) return Results.NotFound();
    else return Results.Ok(artista);
});



app.MapPost("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();
});




app.MapDelete("/Artistas/{id}", ([FromServices] Dal<Artista> dal, int id) =>
{
    var artista = dal.ListarPor(a => a.Id == id).FirstOrDefault();
    if (artista is null) return Results.NotFound();
    else
    {
        dal.Deletar(artista);
        return Results.NoContent();
    }
    
});


app.MapPut("/Artistas/", ([FromServices] Dal<Artista> dal, [FromBody] Artista artista) =>
{
    var artistaParaAtualizar = dal.ListarPor(a => a.Id == artista.Id).FirstOrDefault();
  
    if (artistaParaAtualizar is null) return Results.NotFound();
    else
    {
        artistaParaAtualizar.Nome = artista.Nome;
        artistaParaAtualizar.Bio = artista.Bio;
        artistaParaAtualizar.FotoPerfil = artista.FotoPerfil;
        dal.Alterar(artistaParaAtualizar);
        return Results.Ok();
    }

});

app.Run();
