using Microsoft.EntityFrameworkCore;
using PokemonAPi.Infrastructure;
using PokemonAPi.Models;
using PokemonAPi.Mappers;
using PokemonApi.Models;

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
     public async Task DeleteAsync(Pokemon pokemon,CancellationToken cancellationToken){
            _context.Pokemons.Remove(pokemon.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);

     }


     public async Task AddAsync(Pokemon pokemon,CancellationToken cancellationToken) {
        await _context.Pokemons.AddAsync(pokemon.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken) ;
     }
     
     public async Task UpdateAsync(Pokemon pokemon,CancellationToken cancellationToken) {
        _context.Pokemons.Update(pokemon.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
     }
}