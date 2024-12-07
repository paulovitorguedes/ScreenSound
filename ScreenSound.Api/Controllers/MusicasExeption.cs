using Microsoft.AspNetCore.Mvc;
using ScreenSound.Api.Request;
using ScreenSound.Api.Response;
using ScreenSound.Shared.Data.Banco;
using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Api.Controllers;

public static class MusicasExeption
{
    public static void EndpointMusicas(this WebApplication app)
    {
        app.MapGet("/Musicas/", ([FromServices] Dal<Artista> dal) =>
        {

            List<Artista> artistas = dal.Listar().ToList();
            List<MusicaResponse> musicaResponses = new List<MusicaResponse>();
            foreach (Artista artista in artistas)
            {
                List<Album> albuns = artista.Albuns.ToList();
                foreach (Album album in albuns)
                {

                    List<Musica> musicas = album.Musicas.ToList();
                    foreach (Musica musica in musicas)
                    {

                        List<AvaliacaoMusica> avaliacaoMusicas = new List<AvaliacaoMusica>();
                        List<int> notas = new List<int>();
                        foreach (AvaliacaoMusica am in avaliacaoMusicas)
                        {

                            notas.Add(am.Nota);
                        }

                        musicaResponses.Add(ResponseToEntityMusicResponse(musica));
                    }

                }

            }

            return musicaResponses;
        });




        app.MapGet("/Musicas/{id}", ([FromServices] Dal<Musica> dal, int id) =>
        {

            Musica? musica = dal.ListarPor(m => m.Id == id).FirstOrDefault();
            if (musica is null)
            {
                return Results.NotFound();
            }
            else
            {
                return Results.Ok(ResponseToEntityMusicResponse(musica));
            }
            
        });





        app.MapPost("/Musicas/", ([FromServices] Dal<Album> dalAlbum, [FromServices] Dal < Genero > dalGenero, [FromServices] Dal<Musica> dalMusica, [FromBody] MusicaRequest musicaRequest) =>
        {
            //Recupera o Álbum (pelo nomeinserido) da música a ser cadastrada
            List<Album> albuns = dalAlbum.ListarPor(a => a.Nome.Equals(musicaRequest.Album.ToUpper())).ToList();
            Album? album = null;

            //Caso encontre albuns igaus referente a diferentes bandas, podendo retornar mais de um Album na lista
            if (albuns.Count() >= 1)
            {
                //Verifica qual album possui o nome do artista inserido
                foreach (Album a in albuns)
                {
                    if (a.Artista!.Nome.Equals(musicaRequest.Artista.ToUpper()))
                    {
                        album = a; break;
                    }
                }
            }
            else
            {
                return Results.NotFound();
            }

            Musica musica = new(musicaRequest.Nome.ToUpper())
            {
                Album = album,
                AnoLancamento = musicaRequest.AnoLancamento,
                Disponivel = musicaRequest.Disponivel,
                Duracao = musicaRequest.Duracao,
                Generos = musicaRequest.Generos is not null ? GeneroRequestConverter(musicaRequest.Generos, dalGenero) : new List<Genero>()
            };

            album.AdicionarMusica(musica);
            dalAlbum.Alterar(album);
            return Results.Ok();
        });

    }






    private static ICollection<Genero> GeneroRequestConverter(ICollection<GeneroRequest> generos, Dal<Genero> dalGenero)
    {
        var listaDeGeneros = new List<Genero>();
        foreach (var item in generos)
        {
            var entity = RequestToEntityGenero(item);
            var genero = dalGenero.ListarPor(g => g.Nome.ToUpper().Equals(item.Nome.ToUpper())).FirstOrDefault();
            if (genero is not null)
            {
                listaDeGeneros.Add(genero);
            }
            else
            {
                listaDeGeneros.Add(entity);
            }
        }

        return listaDeGeneros;
    }

    private static Genero RequestToEntityGenero(GeneroRequest genero)
    {
        return new Genero() { Nome = genero.Nome, Descricao = genero.Descricao };
    }

    private static MusicaResponse ResponseToEntityMusicResponse(Musica musica)
    {
        List<AvaliacaoMusica> avaliacaoMusica = musica.AvaliacoesMusica.ToList();
        List<int> notas = new();
        foreach (AvaliacaoMusica am in avaliacaoMusica)
        {
            notas.Add(am.Nota);
        }

        return new(musica.Id, musica.Nome, musica.Album!.Artista!.Nome, musica.Duracao, musica.Disponivel, musica.AnoLancamento, musica.Album.Nome, notas);
    }
}
