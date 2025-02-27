using PokemonAPi.Mappers;
using PokemonAPi.Infrastructure;
using PokemonAPi.Models;
using Microsoft.EntityFrameworkCore;

namespace PokemonAPi.Repositories;

public class BookRepositories : IBookRepositories
{
    private readonly RelationalDBContext _context;

    public BookRepositories(RelationalDBContext context)
        {
            _context = context;
        }

     public async Task <List<Book>> GetBooksByNameAsync (string name,CancellationToken cancellationToken){
        var book = await _context.Books.AsNoTracking().Where(s => s.title.Contains(name)).ToListAsync(cancellationToken);
     return book.Select(h => h.ToModel()).ToList(); 
     }
}