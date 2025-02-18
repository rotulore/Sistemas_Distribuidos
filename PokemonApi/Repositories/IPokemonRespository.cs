using PokemonAPi.Models;
namespace PokemonAPi.Repositories;
public  interface IPokemonRespository
{ //r
    Task<Pokemon> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    }