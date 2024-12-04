﻿namespace ScreenSound.Shared.Models.Models;


public class Genero
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public virtual ICollection<Musica>? Musicas { get; set; }

    public override string ToString()
    {
        return $"Nome: {Nome} - Descrição: {Descricao}";
    }
}
