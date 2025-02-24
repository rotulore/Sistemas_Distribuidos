

using PokemonApi.Models;
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
//Se agrega el tomodel() para hobbies 
    public static Hobbie ToModel(this HobbiesEntity entity){
        if(entity is null){
            return null;
        }
        return new Hobbie{
            Id = entity.Id,
            Name = entity.Name,
            Top=entity.Top
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
//Se agrega el toDto() para hobbies 
public static HobbiesResponseDto ToDto(this Hobbie hobbie){
return new HobbiesResponseDto{
    Id=hobbie.Id,
    Name=hobbie.Name,
    Top=hobbie.Top
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
//Se agrega el toEntity() para hobbies 
public static HobbiesEntity ToEntity(this Hobbie hobbies){
    return new HobbiesEntity{
        Id=hobbies.Id,
        Name=hobbies.Name,
        Top=hobbies.Top
    };
}
}

