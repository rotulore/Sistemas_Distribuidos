
using System.ServiceModel;
using PokedexApi_.Models;
using PokedexApi_.Mappers;
using PokedexApi_.Infraestructure.Soap.Contracts;
using PokedexApi_.Exeptions;
namespace PokedexApi_.Repositories;


public class PokemonRepository: IPokemonRepository
{
    private readonly ILogger<PokemonRepository> _logger;
    private readonly IPokemonService _pokemonService;
    public PokemonRepository(ILogger<PokemonRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        var endpoint=new EndpointAddress(configuration.GetValue<string>("PokemonServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _pokemonService=new ChannelFactory<IPokemonService>(binding,endpoint).CreateChannel(); 
    }

    public async  Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken)
    {
     try
     {
         var pokemon=await _pokemonService.GetPokemonById(id,cancellationToken);
         return pokemon.ToModel();
     }
     catch (FaultException ex)when (ex.Message=="Pokemon not found")
    {
        _logger.LogError(ex,"Failed to get pokemon with id:{id}",id);
        return null;
     }  
    }

    public async Task<IEnumerable<Pokemon>?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
{
    try
    {
        var pokemons = await _pokemonService.GetPokemonByName(name, cancellationToken);
        return pokemons?.Select(p => p.ToModel()) ?? new List<Pokemon>();
    }
    catch (FaultException ex) when (ex.Message.Contains("Pokemon not found"))
    {
        _logger.LogError(ex, "Failed to get pokemon with name: {name}", name);
        return Enumerable.Empty<Pokemon>();
    }
}

public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken)
{
    try
    {
         await _pokemonService.DeletePokemonById(id, cancellationToken);
         return true;
    }
    catch (FaultException ex) when (ex.Message.Contains("Pokemon not found"))
    {
       
        return false;
    }
    catch (FaultException ex)
    {
        _logger.LogError(ex, "Failed to delete pokemon with id: {id}", id);
        throw;
    }


}

public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken)
{
    try
    {
      var pokemonCreated=await _pokemonService.CreatePokemon(pokemon.ToSoapDto(),cancellationToken);
      return pokemonCreated.ToModel();
    }

    catch(FaultException ex)when(ex.Message.Contains("Pokemon")){

throw new PokemonValidationException(ex.Message);
    }
    catch (FaultException ex)
    {
        _logger.LogError(ex, "Error creating pokemon");
        throw;
}


}
public async Task UpdatePokemonAsync (Pokemon pokemon,CancellationToken cancellationToken){

    try
    {
        await _pokemonService.UpdatePokemon(pokemon.ToUpdateSoapDto(),cancellationToken);
    }
    catch (FaultException ex) when (ex.Message.Contains("Pokemon not found"))
    {
        
        throw new PokemonNotFound(ex.Message);
    }
    catch(FaultException ex)
    {
      _logger.LogError(ex, "Error updating pokemon");
      throw;
    }
}

}