namespace PokedexApi_.Exeptions;

public class PokemonNotFound:Exception
{
    public PokemonNotFound(string message):base(message){

    }
}