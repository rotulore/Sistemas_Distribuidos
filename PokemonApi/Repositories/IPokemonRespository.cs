using PokemonAPi.Models;
namespace PokemonAPi.Repositories;
public  interface IPokemonRespository
{ //r
    Task<Pokemon> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    
    Task DeleteAsync (Pokemon pokemon,CancellationToken cancellationToken);

    Task AddAsync(Pokemon pokemon,CancellationToken cancellationToken);

Task UpdateAsync(Pokemon pokemon,CancellationToken cancellationToken);

    }