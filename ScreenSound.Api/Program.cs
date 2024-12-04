using ScreenSound.Api.Controllers;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;
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


//Controllers
app.EndpointArtistas();

app.Run();
