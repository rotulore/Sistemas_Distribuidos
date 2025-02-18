using Microsoft.EntityFrameworkCore;
using PokemonAPi.Infrastructure;
using PokemonAPi.Models;
using PokemonAPi.Mappers;

namespace PokemonAPi.Repositories;
public class PokemonRepository: IPokemonRespository
{
    private readonly RelationalDBContext _context;
    public PokemonRepository(RelationalDBContext context){
        _context = context;
    }
    public async Task<Pokemon> GetByIdAsync(Guid id,CancellationToken cancellationToken){
        var pokemon = await _context.Pokemons.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
     return pokemon.ToModel();   
    }
}