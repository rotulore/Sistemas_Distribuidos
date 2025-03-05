using System.ServiceModel;
using PokemonAPi.Dtos;
[ServiceContract(Name ="BookService",Namespace ="http://book-api/book-service")]
public interface IBookService
{
     [OperationContract]
         Task<List<BooksResponseDto>> GetBooksByName(string name,CancellationToken cancellationToken);
}