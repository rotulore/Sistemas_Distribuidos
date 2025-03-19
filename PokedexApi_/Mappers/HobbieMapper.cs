using PokedexApi_.Dtos;
using PokedexApi_.Models;
using PokedexApi_.Infraestructure.Soap.Dtos;
namespace PokedexApi_.Mappers;

public static class HobbieMapper
{
public static HobbieResponse ToDto(this Hobbie hobbie){
return new HobbieResponse{
    Id=hobbie.Id,
    Name=hobbie.Name,
    Top=hobbie.Top
};
}

public static Hobbie ToModel(this HobbiesResponseDto hobbie){
return new Hobbie{
    Id=hobbie.Id,
    Name=hobbie.Name,
    Top=hobbie.Top
};

}

}