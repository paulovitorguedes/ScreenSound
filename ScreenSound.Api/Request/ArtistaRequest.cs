using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Request;

public record ArtistaRequest([Required] string Nome, [Required] string Bio, string FotoPerfil);

