using PokemonAPi.Dtos;

namespace PokemonAPi.Models;

public class Pokemon
{
    public Guid Id{ get; set; }
    public string name{ get; set; }
    public string Type{ get; set; }
    public int Level{ get; set; }

    public Stats Stats{ get; set; }
}