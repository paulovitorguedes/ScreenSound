using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Request;

public record GeneroRequest([Required] string Nome, string? Descricao = null);

