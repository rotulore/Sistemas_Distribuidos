using Microsoft.EntityFrameworkCore;
using PokemonAPi.Infrastructure.Entities;
namespace PokemonAPi.Infrastructure;

public class RelationalDBContext : DbContext
{
    public DbSet<PokemonEntity> Pokemons { get; set; }
    public DbSet<HobbiesEntity> Hobbies { get; set;}
    public RelationalDBContext(DbContextOptions<RelationalDBContext> options) : base(options){

}
protected override void OnModelCreating(ModelBuilder modelBuilder){

    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<PokemonEntity>(entity =>{
    entity.HasKey(s=>s.Id);
    entity.Property(s=>s.Name).IsRequired().HasMaxLength(100);
   entity.Property(s=>s.Type).IsRequired().HasMaxLength(50);
 entity.Property(s=>s.Level).IsRequired();
  entity.Property(s=>s.Attack).IsRequired();
   entity.Property(s=>s.Defense).IsRequired();
    entity.Property(s=>s.Speed).IsRequired();
    });

    modelBuilder.Entity<HobbiesEntity>(entity =>{
        entity.HasKey(s=>s.Id);
        entity.Property(s=>s.Name).IsRequired().HasMaxLength(100);
        entity.Property(s=>s.Top).IsRequired();
    });

    }
    }

