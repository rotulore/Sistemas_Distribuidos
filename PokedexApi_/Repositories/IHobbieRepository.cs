using PokedexApi_.Models;
namespace PokedexApi_.Repositories;

public interface IHobbieRepository
{
     Task<Hobbie> GetHobbyByIdAsync(int id, CancellationToken cancellationToken);
    
      Task <List<Hobbie>> GetHobbiesByNameAsync (string name, CancellationToken cancellationToken);
}