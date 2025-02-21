using System.ServiceModel;
using PokemonAPi.Dtos;
using PokemonAPi.Repositories;
using PokemonAPi.Mappers;

namespace PokemonAPi.Services;

public class HobbieService : IHobbieService
{
    private readonly IHobbiesRespository _hobbieRepository;

    public HobbieService(IHobbiesRespository hobbieRepository){
         _hobbieRepository= hobbieRepository;
    }

    public  async Task<HobbiesResponseDto> GetHobbieById(int id,CancellationToken cancellationToken){
         var hobbie =await _hobbieRepository.GetHobbyByIdAsync(id,cancellationToken);
   if (hobbie is null)
   {
    throw new FaultException("Hobbie not found");
   }
   return hobbie.ToDto();

    }

      
        public async Task<bool> DeleteHobbieById(int id, CancellationToken cancellationToken){
            var hobbie = await _hobbieRepository.GetHobbyByIdAsync(id,cancellationToken);
        if(hobbie is null)
{
    throw new FaultException("Hobbie not found");
}   
    await _hobbieRepository.DeleteHobbyAsync(hobbie, cancellationToken);
    return true;
        }

    
         public async Task<List<HobbiesResponseDto>> GetHobbieByName(string name,CancellationToken cancellationToken){
            
    // Llamar al repositorio para obtener los hobbies por nombre
    var hobbies = await _hobbieRepository.GetHobbiesByNameAsync(name, cancellationToken);

    // Si no hay hobbies encontrados, simplemente devuelve una lista vacía
    if (hobbies == null || !hobbies.Any())
    {
        return new List<HobbiesResponseDto>();
    }
    
    // Retornar la lista de hobbies mapeada a DTOs
    return hobbies.Select(h => h.ToDto()).ToList();

         }

}