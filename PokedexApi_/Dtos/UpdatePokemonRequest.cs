namespace PokedexApi_.Dtos;

public class UpdatePokemonRequest
{
public required string Name { get; set; }
public required string Type { get; set; }
public int Level {get;set;}
public int Attack{get;set;}
public int Defense {get;set;}
public int Speed {get;set;}   
}