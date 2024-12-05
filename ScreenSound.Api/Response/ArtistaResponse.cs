﻿namespace ScreenSound.Api.Response
{
    public record ArtistaResponse(
        int Id, 
        string Nome, 
        string Bio, 
        string FotoPerfil, 
        IEnumerable<string> Albuns, 
        IEnumerable<int> Avaliacoes);
}
