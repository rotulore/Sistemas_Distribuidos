using PokemonAPi.Models;

namespace PokemonAPi.Repositories;
public interface IBookRepositories
{
     Task <List<Book>> GetBooksByNameAsync (string name, CancellationToken cancellationToken);
}