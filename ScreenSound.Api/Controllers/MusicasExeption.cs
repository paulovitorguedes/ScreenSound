using Microsoft.AspNetCore.Mvc;
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

                        MusicaResponse musicaResponse = new(
                            musica.Id,
                            musica.Nome,
                            artista.Nome,
                            musica.Duracao,
                            musica.Disponivel,
                            musica.AnoLancamento,
                            album.Nome,
                            notas);

                        musicaResponses.Add(musicaResponse);
                    }

                }

            }

            return musicaResponses;
        });
    }
}
