using API_FIlmes_Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace API_FIlmes_Entity.Data;

public class UsuarioContext : DbContext
{
    public UsuarioContext(DbContextOptions<UsuarioContext> opts) : base(opts)
    {

    }

    protected UsuarioContext()
    {
    }

    public DbSet<Usuario> Usuario { get; set; }

}

