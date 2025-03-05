using PokemonAPi.Mappers;
using PokemonAPi.Infrastructure;
using PokemonApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PokemonAPi.Repositories;

    public class HobbiesRepository : IHobbiesRespository
    {
        private readonly RelationalDBContext _context;

        public HobbiesRepository(RelationalDBContext context)
        {
            _context = context;
        }

        public async Task<Hobbie>GetHobbyByIdAsync(int id,CancellationToken cancellationToken){
        var hobbie = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
     return hobbie.ToModel();  
     }

//Delete hobbie by id
    public async Task DeleteHobbyAsync(Hobbie hobbie,CancellationToken cancellationToken){
            _context.Hobbies.Remove(hobbie.ToEntity());
            await _context.SaveChangesAsync(cancellationToken);

     }

//Get hobbie by name
 public async Task <List<Hobbie>> GetHobbiesByNameAsync(string name,CancellationToken cancellationToken){
        var hobbie = await _context.Hobbies.AsNoTracking().Where(s => s.Name.Contains(name)).ToListAsync(cancellationToken);
     return hobbie.Select(h => h.ToModel()).ToList(); 
     }
    }

