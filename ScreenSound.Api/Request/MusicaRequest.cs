using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Request;

public record MusicaRequest(
    [Required] string Nome,
    [Required] string Artista,
    [Required] string Album,
    int AnoLancamento,
    int Duracao,
    bool Disponivel,
    ICollection<GeneroRequest> Generos
 );
