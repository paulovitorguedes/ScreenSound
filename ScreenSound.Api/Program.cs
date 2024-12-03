using Microsoft.AspNetCore.Mvc;
using ScreenSound.Banco;
using ScreenSound.Models;
using System.Data.SqlTypes;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Estamos fazendo uma consulta e retornando um objeto do tipo "lista de artistas", mas o Artista possui uma lista de músicas, e em Musica existe uma referência para o Artista. Isso resulta em um loop e, no momento em que o nosso cliente precisa converter essa lista de objetos em um JSON, ocorre esse erro.
//O código abaixo resolve esse erro
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(
    options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


//Injeção de dependência
//Adicionando a criação do nosso objeto DAL no Builder Services.
//Para isso, usamos o builder.Services.AddTransient, passando DAL na anotação diamante.
//No DAL também há outra anotação diamante para especificar qual tipo de DAL estamos querendo criar.
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




//Configuramos um recurso nativo do Asp.NET que permite que ele crie os objetos que vamos utilizar na aplicação. Isso é chamado de injeção de dependência.
//A partir da configuração via builder.Services, falamos que todos os nossos endpoints dependem de um serviço para funcionar, que definimos utilizando o atributo [FromService] para invocar o objeto DAL que vai ser criado pela própria aplicação.

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
