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
[HttpGet]
public async Task<ActionResult<List<PokemonResponse>>> GetPokemonByName([FromQuery]string name, CancellationToken cancellationToken)
{
    var pokemons = await _pokemonService.GetPokemonByName(name, cancellationToken);

    if (pokemons == null || !pokemons.Any())
    {
        return Ok(new List<PokemonResponse>()); // Mejor devolver lista vacía en lugar de 404
    }
    return Ok(pokemons.Select(p => p.ToDto()).ToList());
}
//404 -not found
//204 -No content(se encontro y elimino el pokemon) de forma correcta pero el body de respuesta esta vacia
//200 -OK se encontró y se elimino el pokemon y en el body de respuesta se envia un msj de exito

[HttpDelete("{id}")]
public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationToken)
{
    var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);

    if (deleted)
    {
        return NoContent();
    }

    return NotFound();

}}