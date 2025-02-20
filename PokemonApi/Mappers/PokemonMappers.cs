

using PokemonAPi.Dtos;
using PokemonAPi.Infrastructure.Entities;
using PokemonAPi.Models;


namespace PokemonAPi.Mappers;
public static class PokemonMappers
{
    public static Pokemon ToModel(this PokemonEntity entity)
{
    if(entity is null){
return null;
    }
    return new Pokemon{
        Id = entity.Id,
        name = entity.Name,
        Level=entity.Level,
        Type=entity.Type,
        Stats=new Stats{
            Attack=entity.Attack,
            Defense=entity.Defense,
            Speed=entity.Speed,
             Health = entity.Health
        }
    };
}
public static PokemonResponseDto ToDto(this Pokemon pokemon){
return new PokemonResponseDto{
    Id=pokemon.Id,
    Level=pokemon.Level,
    Name=pokemon.name,
    Type=pokemon.Type,
    Stats=new StatsDto{
        Attack=pokemon.Stats.Attack,
        Defense=pokemon.Stats.Defense,
        Speed=pokemon.Stats.Speed,
        Health=pokemon.Stats.Health
    }

};
}

public static PokemonEntity ToEntity(this Pokemon pokemon){

    return new PokemonEntity{
        Id=pokemon.Id,
        Name=pokemon.name,
        Type=pokemon.Type,
        Level=pokemon.Level,
        Attack=pokemon.Stats.Attack,
        Defense=pokemon.Stats.Defense,
        Speed=pokemon.Stats.Speed,
        Health=pokemon.Stats.Health
    };
}
}

