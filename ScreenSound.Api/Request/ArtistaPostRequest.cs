using System.ComponentModel.DataAnnotations;

namespace ScreenSound.Api.Request;

public record ArtistaPostRequest([Required] string nome, [Required] string bio, string fotoPerfil);

