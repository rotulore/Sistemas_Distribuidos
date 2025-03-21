using PokedexApi_.Models;
namespace PokedexApi_.Repositories;

    public interface IPokemonRepository
    {
        Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);
    }
