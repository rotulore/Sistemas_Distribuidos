using Microsoft.AspNetCore.Mvc;
using PokedexApi_.Dtos;
using PokedexApi_.Services;
using PokedexApi_.Mappers;


namespace PokedexApi_.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class HobbiesController:ControllerBase
{
     private readonly IHobbiesService _hobbyService;

        public HobbiesController(IHobbiesService hobbyService)
        {
            _hobbyService = hobbyService;
        }

        // localhost/api/v1/hobbies/12
        [HttpGet("{id}")]
        public async Task<ActionResult<HobbieResponse>> GetHobbyById(int id, CancellationToken cancellationToken)
        {
           var hobby = await _hobbyService.GetHobbieById(id, cancellationToken);
            if (hobby is null)
            {
                return NotFound();
            }
            return Ok(hobby.ToDto());
        }

        // localhost/api/v1/hobbies/byname/Chess
        //pokemons?name=pikach&variable2=343.....  query paremerters
        //Se deja solo para query parameters  -->Se usa FromQuery en el metodo gethobbiesbyname
        [HttpGet]
        public async Task<ActionResult<List<HobbieResponse>>> GetHobbiesByName([FromQuery]string name, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbyService.GetHobbiesByName(name, cancellationToken);

            if (hobbies == null || !hobbies.Any())
            {
                return Ok(new List<HobbieResponse>()); // Retornar lista vacía si no hay coincidencias
            }
            return Ok(hobbies.Select(h => h.ToDto()).ToList());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteHobbyById(int id, CancellationToken cancellationToken)
        {
            var result = await _hobbyService.DeleteHobbieByIdAsync(id, cancellationToken);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
