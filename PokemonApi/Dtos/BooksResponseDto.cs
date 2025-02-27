using System.Runtime.Serialization;

namespace PokemonAPi.Dtos;
[DataContract(Name = "BooksDto", Namespace = "http://book-api/book-service")]
public class BooksResponseDto
{
     [DataMember(Name = "id", Order = 1)]
    public int id { get; set; }
     [DataMember(Name = "title", Order = 2)]
    public string title { get; set; }
     [DataMember(Name = "author", Order = 3)]

    public string author { get; set; }
     [DataMember(Name = "publishedDate", Order = 4)]

    public DateTime publishedDate { get; set; }
}