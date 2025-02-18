using System.ServiceModel;
using PokemonAPi.Dtos;
using PokemonAPi.Repositories;
using PokemonAPi.Mappers;

namespace PokemonAPi.Services;


//TDD-unit test
public class PokemonService : IPokemonService
{
    private readonly IPokemonRespository _pokemonRepository;

    public PokemonService(IPokemonRespository pokemonRepository){
         _pokemonRepository= pokemonRepository;
    }
    public  async Task<PokemonResponseDto> GetPokemonById(Guid id,CancellationToken cancellationToken){
    
   var pokemon =await _pokemonRepository.GetByIdAsync(id,cancellationToken);
   if (pokemon is null)
   {
    throw new FaultException("Pokemon not found");
   }
   return pokemon.ToDto();
    }
    
}