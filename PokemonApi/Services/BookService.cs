
using PokemonAPi.Dtos;
using PokemonAPi.Repositories;
using PokemonAPi.Mappers;

namespace PokemonAPi.Services;

public class BookService : IBookService
{
    private readonly IBookRepositories _bookRepository;

    public BookService(IBookRepositories bookRepository){
        _bookRepository = bookRepository;
    }

    public async Task<List<BooksResponseDto>> GetBooksByName(string name,CancellationToken cancellationToken){
            
    var  books = await _bookRepository.GetBooksByNameAsync(name, cancellationToken);

    
    if (books == null || !books.Any())
    {
        return new List<BooksResponseDto>();
    }
    
   
    return books.Select(h => h.ToDto()).ToList();

         }

}