using FilmListeApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmListeApp.Data;

public class FilmDbContext : DbContext
{
    public FilmDbContext(DbContextOptions<FilmDbContext> options) : base(options) {}

    public DbSet<Film> Filmliste => Set<Film>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(e =>
        {
            e.ToTable("filmliste");          // matcher tabellnavnet ditt
            e.HasKey(x => x.Id);

            e.Property(x => x.Id).HasColumnName("id");
            e.Property(x => x.Tittel).HasColumnName("tittel");
            e.Property(x => x.Sjanger).HasColumnName("sjanger");
            e.Property(x => x.Utgitt).HasColumnName("utgitt");
            e.Property(x => x.Beskrivelse).HasColumnName("beskrivelse");
        });
    }
}
