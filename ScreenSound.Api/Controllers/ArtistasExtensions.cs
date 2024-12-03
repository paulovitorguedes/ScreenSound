using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Request;
using ScreenSound.Banco;
using ScreenSound.Models;

namespace ScreenSound.Api.Controllers;

public  static class ArtistasExtensions
{
    public static void EndpointArtistas(this WebApplication app)
    {
        //Configuramos um recurso nativo do Asp.NET que permite que ele crie os objetos que vamos utilizar na aplicação. Isso é chamado de injeção de dependência.
        //A partir da configuração via builder.Services, falamos que todos os nossos endpoints dependem de um serviço para funcionar, que definimos utilizando o atributo [FromService] para invocar o objeto DAL que vai ser criado pela própria aplicação.

        //Retorna todos os artistas
        app.MapGet("/Artistas/", ([FromServices] Dal<Artista> dal) =>
        {
            return dal.Listar();
        });


        //Retorna Artistas pelo Nome
        app.MapGet("/Artistas/{nome}", ([FromServices] Dal<Artista> dal, string nome) =>
        {
            var artista = dal.ListarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));
            if (artista is null) return Results.NotFound();
            else return Results.Ok(artista);
        });



        //Adiciona Novos Artistas
        app.MapPost("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaPostRequest artistaRequest) =>
        {
            Artista artista = new(artistaRequest.nome.ToUpper(), artistaRequest.bio.ToUpper());
            artista.FotoPerfil = artistaRequest.fotoPerfil;
            dal.Adicionar(artista);
            return Results.Ok();
        });



        //Apaga Artista por ID
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


        //Altera Artistas
        app.MapPut("/Artistas/{id}", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaPostRequest artistaRequest, int id) =>
        {
            Artista artista = new(artistaRequest.nome.ToUpper(), artistaRequest.bio.ToUpper());
            artista.FotoPerfil = artistaRequest.fotoPerfil;
            var artistaParaAtualizar = dal.ListarPor(a => a.Id == id).FirstOrDefault();

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

    }
}
