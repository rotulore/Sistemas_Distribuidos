namespace PokemonAPi.Infrastructure.Entities;

public class BooksEntity
{
    public int id { get; set; }
    public string title { get; set; }

    public string author { get; set; }

    public DateTime publishedDate { get; set; }
}