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
    //localhost/api/v1/pokemons/byname/Pikachu
[HttpGet("byname/{name}")]
public async Task<ActionResult<List<PokemonResponse>>> GetPokemonByName(string name, CancellationToken cancellationToken)
{
    var pokemons = await _pokemonService.GetPokemonByName(name, cancellationToken);

    if (pokemons == null || !pokemons.Any())
    {
        return Ok(new List<PokemonResponse>()); // Mejor devolver lista vacía en lugar de 404
    }
    return Ok(pokemons.Select(p => p.ToDto()).ToList());
}
    
}