using PokemonApi.Models;
using PokemonAPi.Dtos;
using PokemonAPi.Infrastructure.Entities;
using PokemonAPi.Models;


namespace PokemonAPi.Mappers;

public static class HobbiesMappers
{
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

    //Se agrega el toDto() para hobbies 
public static HobbiesResponseDto ToDto(this Hobbie hobbie){
return new HobbiesResponseDto{
    Id=hobbie.Id,
    Name=hobbie.Name,
    Top=hobbie.Top
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

public static Hobbie ToModel(this CreateHobbieDto hobbie){
    return new Hobbie{
        Name=hobbie.Name,
        Top=hobbie.Top,
    };
}

}