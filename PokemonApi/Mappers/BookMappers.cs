using PokemonApi.Models;
using PokemonAPi.Dtos;
using PokemonAPi.Infrastructure.Entities;
using PokemonAPi.Models;
namespace PokemonAPi.Mappers;

public static class BookMappers
{
    
public static Book ToModel(this BooksEntity entity)
{
    if(entity is null){
return null;
    }
    return new Book{
        id = entity.id,
        title = entity.title,
        author=entity.author,
        publishedDate=entity.publishedDate
    };
}


public static BooksResponseDto ToDto(this Book book){
return new BooksResponseDto{
    id=book.id,
    title=book.title,
    author=book.author,
    publishedDate=book.publishedDate

};
}


public static BooksEntity ToEntity(this Book book){

    return new BooksEntity{
        id=book.id,
        title=book.title,
        author=book.author,
        publishedDate=book.publishedDate
    };
}

}