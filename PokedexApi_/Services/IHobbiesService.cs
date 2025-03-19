using PokedexApi_.Models;

namespace PokedexApi_.Services;
public interface IHobbiesService
{
    Task<Hobbie?> GetHobbieById(int id, CancellationToken cancellationToken);
    Task<List<Hobbie>> GetHobbiesByName(string name, CancellationToken cancellationToken);
}