  using PokedexApi_.Models;
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

       }