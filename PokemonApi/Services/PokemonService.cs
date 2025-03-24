using System.ServiceModel;
using PokemonAPi.Dtos;
using PokemonAPi.Repositories;
using PokemonAPi.Mappers;
using PokemonAPI.Validators;

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

    public async Task<bool> DeletePokemonById(Guid id, CancellationToken cancellationToken){
        var pokemon = await _pokemonRepository.GetByIdAsync(id,cancellationToken);
        if(pokemon is null)
{
    throw new FaultException("Pokemon not found");
}   
    await _pokemonRepository.DeleteAsync(pokemon, cancellationToken);
    return true;
    }

    public async Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemon, CancellationToken cancellationToken){
        var pokemonToCreate = createPokemon.ToModel();
        pokemonToCreate.ValidateName().ValidateType().ValidateLevel();

        await _pokemonRepository.AddAsync(pokemonToCreate, cancellationToken);
        return pokemonToCreate.ToDto();
    }

    public async Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon,CancellationToken cancellationToken){

        var pokemonToUpdate=await _pokemonRepository.GetByIdAsync(pokemon.Id,cancellationToken);

        if(pokemonToUpdate is null){
            throw new FaultException("Pokemon not found");
        }

        pokemonToUpdate.name=pokemon.Name;
        pokemonToUpdate.Type=pokemon.Type;
        pokemonToUpdate.Level=pokemon.Level;
        pokemonToUpdate.Stats.Attack=pokemon.Stats.Attack;
        pokemonToUpdate.Stats.Defense=pokemon.Stats.Defense;
        pokemonToUpdate.Stats.Speed=pokemon.Stats.Speed;
        pokemonToUpdate.Stats.Health=pokemon.Stats.Health;

        await _pokemonRepository.UpdateAsync(pokemonToUpdate,cancellationToken);
        return pokemonToUpdate.ToDto();
     

    }
    

    public async Task<List<PokemonResponseDto>> GetPokemonByName(string name,CancellationToken cancellationToken){

          
    var pokemons = await _pokemonRepository.GetPokemonsByNameAsync(name, cancellationToken);

  
    if (pokemons == null || !pokemons.Any())
    {
        return new List<PokemonResponseDto>();
    }
    
  
    return pokemons.Select(h => h.ToDto()).ToList();
    }
}