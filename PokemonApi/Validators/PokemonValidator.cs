
using PokemonAPi.Models;
using System.ServiceModel;
namespace PokemonAPI.Validators
{
    public static class PokemonValidator
    {
        public static Pokemon ValidateName(this Pokemon pokemon)=>
       string.IsNullOrEmpty(pokemon.name) ? throw new FaultException("Pokemon name is requered") : pokemon;

       public static Pokemon ValidateType(this Pokemon pokemon)=>
         string.IsNullOrEmpty(pokemon.Type) ? throw new FaultException("Pokemon type is requered") : pokemon;

         public static Pokemon ValidateLevel(this Pokemon pokemon)=>
         pokemon.Level <= 0 ? throw new FaultException("Pokemon level is requerid") : pokemon;
    }
}
