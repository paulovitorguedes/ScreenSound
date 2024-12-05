using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenAI_API.Moderation;
using ScreenSound.Api.Request;
using ScreenSound.Api.Response;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Api.Controllers;

public static class ArtistasExtensions
{
    public static void EndpointArtistas(this WebApplication app)
    {
        //Configuramos um recurso nativo do Asp.NET que permite que ele crie os objetos que vamos utilizar na aplicação. Isso é chamado de injeção de dependência.
        //A partir da configuração via builder.Services, falamos que todos os nossos endpoints dependem de um serviço para funcionar, que definimos utilizando o atributo [FromService] para invocar o objeto DAL que vai ser criado pela própria aplicação.

        //Retorna todos os artistas
        app.MapGet("/Artistas/", ([FromServices] Dal<Artista> dal) =>
        {
            List<Artista> astistas = dal.Listar().ToList();
            List<ArtistaResponse> artistaResponses = new();

            foreach (Artista artista in astistas)
            {

                List<Album> albuns = artista.Albuns.ToList();
                List<AvaliacaoArtista> avaliacaoArtistas = artista.AvaliacoesArtista.ToList();

                List<string> nomesAlbuns = new();
                foreach (Album album in albuns)
                {
                    nomesAlbuns.Add(album.Nome);
                }

                List<int> notas = new();
                foreach (AvaliacaoArtista aa in avaliacaoArtistas)
                {
                    notas.Add(aa.Nota);
                }
                

                ArtistaResponse ar = new(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil, nomesAlbuns, notas);
                artistaResponses.Add(ar);
            }
            return Results.Ok(artistaResponses);
        });



        //Retorna Artistas pelo Nome
        app.MapGet("/Artistas/{Nome}", ([FromServices] Dal<Artista> dal, string nome) =>
        {
            Artista? artista = dal.ListarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper())).FirstOrDefault();
            if (artista is null) 
            {
                return Results.NotFound();
            } 
            else 
            {

                List<ArtistaResponse> artistaResponses = new();
                List<Album> albuns = artista.Albuns.ToList();
                List<AvaliacaoArtista> avaliacaoArtistas = artista.AvaliacoesArtista.ToList();

                List<string> nomesAlbuns = new();
                foreach (Album album in albuns)
                {
                    nomesAlbuns.Add(album.Nome);
                }

                List<int> notas = new();
                foreach (AvaliacaoArtista aa in avaliacaoArtistas)
                {
                    notas.Add(aa.Nota);
                }

                ArtistaResponse ar = new(artista.Id, artista.Nome, artista.Bio, artista.FotoPerfil, nomesAlbuns, notas);
                artistaResponses.Add(ar);

                return Results.Ok(artistaResponses);

            }
            
        });






        //Adiciona Novos Artistas
        app.MapPost("/Artistas", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaRequest artistaRequest) =>
        {
            Artista? artista = dal.ListarPor(a => a.Nome.Equals(artistaRequest.Nome)).FirstOrDefault();
            if (artista is null)
            {
                Artista artistaNovo = new(artistaRequest.Nome.ToUpper(), artistaRequest.Bio.ToUpper());
                artistaNovo.FotoPerfil = artistaRequest.FotoPerfil;
                dal.Adicionar(artistaNovo);
                return Results.Ok();
            }
            else return Results.Conflict("Conflict name.");
        });
        


        //Apaga Artista por ID
        app.MapDelete("/Artistas/{id}", ([FromServices] Dal<Artista> dal, int id) =>
        {
            var artista = dal.ListarPor(a => a.Id == id).FirstOrDefault();
            if (artista is null) return Results.NotFound();
            else
            {
                try
                {
                    dal.Deletar(artista);
                    return Results.NoContent();
                }
                catch (DbUpdateException)
                {
                    return Results.StatusCode(500); // Retorna 500 Internal Server Error
                }
                
            }

        });


        //Altera Artistas
        app.MapPut("/Artistas/{id}", ([FromServices] Dal<Artista> dal, [FromBody] ArtistaRequest artistaRequest, int id) =>
        {
            var artistaParaAtualizar = dal.ListarPor(a => a.Id == id).FirstOrDefault();

            if (artistaParaAtualizar is null) return Results.NotFound();
            else
            {
                artistaParaAtualizar.Nome = artistaRequest.Nome.ToUpper();
                artistaParaAtualizar.Bio = artistaRequest.Bio.ToUpper();
                artistaParaAtualizar.FotoPerfil = artistaRequest.FotoPerfil;
                try
                {
                    dal.Alterar(artistaParaAtualizar);
                    return Results.Ok();
                }
                catch (DbUpdateException)
                {
                    return Results.StatusCode(500); // Retorna 500 Internal Server Error
                }
                
            }

        });

    }
}
