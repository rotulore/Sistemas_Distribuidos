  using PokedexApi_.Models;
  using PokedexApi_.Exeptions;
  using PokedexApi_.Repositories;

   namespace PokedexApi_.Services;

   public class PokemonService: IPokemonService
   {
      private readonly IPokemonRepository _pokemonRepository;
 
    public  PokemonService(IPokemonRepository pokemonRepository){

       _pokemonRepository = pokemonRepository;
    }
      public async Task<Pokemon?> GetPokemonById(Guid id,CancellationToken cancellationToken)
       {
         return await _pokemonRepository.GetPokemonByIdAsync(id, cancellationToken);    
       }
       
       public async Task<List<Pokemon>> GetPokemonByName(string name, CancellationToken cancellationToken)
{
    var response = await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);
    return response?.ToList() ?? new List<Pokemon>();
}

public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
    return await _pokemonRepository.DeletePokemonByIdAsync(id, cancellationToken);
}


public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken){
  //Todo:validae is pokemon already exists using the name fiels
            var existingPokemons = await GetPokemonByName(pokemon.Name, cancellationToken);
              if (existingPokemons.Any(p => p.Name.Equals(pokemon.Name, StringComparison.OrdinalIgnoreCase)))
    {
        throw new Exceptionvalidation($"Pokemon with name {pokemon.Name} already exists.");
    }
    return await _pokemonRepository.CreatePokemonAsync(pokemon, cancellationToken);
}

public async Task UpdatePokemonAsync(Guid id,Pokemon pokemon,CancellationToken cancellationToken){
var pokemons=await _pokemonRepository.GetPokemonByNameAsync(pokemon.Name,cancellationToken);

if (pokemons.Any(s=> s.Name.ToLower()==pokemon.Name.ToLower()&& s.Id != id))
{
  throw new Exceptionvalidation("existe ese pokemon");
}
if (pokemon.Level<=0)
{
  throw new PokemonValidationException("Nivel requerido superior a 0");
}
 pokemon.Id=id;
 await _pokemonRepository.UpdatePokemonAsync(pokemon,cancellationToken);
}
       }