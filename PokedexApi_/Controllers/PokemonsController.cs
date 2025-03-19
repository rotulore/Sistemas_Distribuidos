using Microsoft.AspNetCore.Mvc;
using PokedexApi_.Services;
using PokedexApi_.Dtos;

using PokedexApi_.Mappers;


namespace PokedexApi_.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PokemonsController: ControllerBase
{

    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService){

        _pokemonService=pokemonService;
    }
    //localhost/api/v1/pokemons/12
    [HttpGet("{id}")]
    public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id,CancellationToken cancellationToken){

        var pokemon=await _pokemonService.GetPokemonById(id,cancellationToken);
        
        if (pokemon is null)
        {
         return NotFound();   
        }
        return Ok(pokemon.ToDto());
        
    }
}