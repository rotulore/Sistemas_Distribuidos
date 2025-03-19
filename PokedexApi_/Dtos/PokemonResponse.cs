
namespace PokedexApi_.Dtos;
public class PokemonResponse
{
    public Guid Id {get;set;}
      public  string Name{get;set;}
       public  string Type{get;set;}

       public int Level {get;set;}
        public required StatsResponse Stats{get;set;}
}