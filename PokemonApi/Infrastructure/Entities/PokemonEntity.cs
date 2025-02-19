namespace PokemonAPi.Infrastructure.Entities;

public class PokemonEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public string Type { get; set; }
    public int Level { get; set; }
        public int Attack { get; set; }

    public int Defense { get; set; }

    public int Speed { get; set; }

    public int Health { get; set; }

}