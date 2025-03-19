using PokemonAPi.Models;
using System.ServiceModel;
using PokemonApi.Models;
namespace PokemonAPI.Validators;

public static class HobbieValidator
{
    public static Hobbie ValidateName(this Hobbie hobbie)=>
       string.IsNullOrEmpty(hobbie.Name) ? throw new FaultException("Hobbie name is requered") : hobbie;


         public static Hobbie ValidateTop(this Hobbie hobbie)=>
         hobbie.Top<= 0 ? throw new FaultException("Hobbie top is requerid") : hobbie;
}