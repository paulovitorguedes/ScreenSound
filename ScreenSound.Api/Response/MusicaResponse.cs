using ScreenSound.Shared.Models.Models;

namespace ScreenSound.Api.Response;

public record MusicaResponse(
    int Id,
    string Nome,
    string Artista,
    int Duracao,
    bool Disponivel,
    int? AnoLancamento,
    string Album,
    IEnumerable<string> Generos,
    IEnumerable<int> Avaliacoes);
