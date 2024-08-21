using API_FIlmes_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace API_FIlmes_Entity.Data;

public class FilmeContext : DbContext
{
    public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts)
    {
               
    }

    protected FilmeContext()
    {
    }

    public DbSet<Filme> Filmes { get; set; }

}
