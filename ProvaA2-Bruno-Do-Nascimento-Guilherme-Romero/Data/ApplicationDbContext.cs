
using ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
using Microsoft.EntityFrameworkCore;

namespace ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Data;
using  ProvaA2_Bruno_Do_Nascimento_Guilherme_Romero.Models;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Evento> Eventos { get; set; }
}