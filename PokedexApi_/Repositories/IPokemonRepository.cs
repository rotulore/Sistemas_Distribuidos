using PokedexApi_.Models;
namespace PokedexApi_.Repositories;

    public interface IPokemonRepository
    {
        Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Pokemon>?> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);

        Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);
    }
