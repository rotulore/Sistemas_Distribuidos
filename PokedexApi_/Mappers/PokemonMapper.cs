using PokedexApi_.Dtos;
using PokedexApi_.Models;
using PokedexApi_.Infraestructure.Soap.Dtos;
namespace PokedexApi_.Mappers;
public static class PokemonMapper
{
    public static PokemonResponse ToDto(this Pokemon pokemon){
return new PokemonResponse{
Id=pokemon.Id,
Name=pokemon.Name,
Type=pokemon.Type,
Level=pokemon.Level,
Stats=new StatsResponse{

    Attack=pokemon.Attack,
    Defense=pokemon.Defense,
    Speed=pokemon.Speed,
}
};
    }
    public static Pokemon ToModel(this PokemonResponseDto pokemon){
return new Pokemon{
Id=pokemon.Id,
Name=pokemon.Name,
Type=pokemon.Type,
Level=pokemon.Level,
Attack=pokemon.Stats.Attack,
Defense=pokemon.Stats.Defense,
Speed=pokemon.Stats.Speed,
};
    }
    }