
using PokedexApi_.Models;
namespace PokedexApi_.Services;
public interface IPokemonService
{
    
    Task<Pokemon?> GetPokemonById(Guid id,CancellationToken cancellationToken);
    Task<List<Pokemon>> GetPokemonByName(string name, CancellationToken cancellationToken);

}