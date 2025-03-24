  using PokedexApi_.Models;
  using PokedexApi_.Repositories;

   namespace PokedexApi_.Services;
   public class HobbiesService : IHobbiesService
   {
     private readonly IHobbieRepository _hobbieRepository;

     public HobbiesService(IHobbieRepository hobbieRepository)
     {
       _hobbieRepository = hobbieRepository;
     }

     public async Task<Hobbie?> GetHobbieById(int id, CancellationToken cancellationToken)
     {
       return await _hobbieRepository.GetHobbyByIdAsync(id, cancellationToken);
     }

     public async Task<List<Hobbie>> GetHobbiesByName(string name, CancellationToken cancellationToken)
     {
       var response = await _hobbieRepository.GetHobbiesByNameAsync(name, cancellationToken);
       return response?.ToList() ?? new List<Hobbie>();
     }
   }