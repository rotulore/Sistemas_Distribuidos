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

     public async Task AddAsync(Hobbie hobbie,CancellationToken cancellationToken) {
        await _context.Hobbies.AddAsync(hobbie.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken) ;
     }

     public async Task UpdateAsync(Hobbie hobbie,CancellationToken cancellationToken) {
      //   _context.Hobbies.Update(hobbie.ToEntity());
      //   await _context.SaveChangesAsync(cancellationToken);

         var existingHobbie = await _context.Hobbies
        .FirstOrDefaultAsync(h => h.Id == hobbie.Id, cancellationToken);

    if (existingHobbie != null)
    {
        // Actualizamos la entidad directamente sin crear una nueva instancia.
        existingHobbie.Name = hobbie.Name;
        existingHobbie.Top = hobbie.Top;

        // Guardamos los cambios en el contexto.
        await _context.SaveChangesAsync(cancellationToken);
    }
    else
    {
        throw new Exception("Hobbie not found");
    }
     }
    }

