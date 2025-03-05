using PokemonApi.Models;
using PokemonAPi.Models;
namespace PokemonAPi.Repositories;

public interface IHobbiesRespository
{
    
    Task<Hobbie> GetHobbyByIdAsync(int id, CancellationToken cancellationToken);
    
    Task DeleteHobbyAsync (Hobbie hobbie,CancellationToken cancellationToken);

    Task <List<Hobbie>> GetHobbiesByNameAsync (string name, CancellationToken cancellationToken);

    Task AddAsync(Hobbie hobbie,CancellationToken cancellationToken);

Task UpdateAsync(Hobbie hobbie,CancellationToken cancellationToken);

}
