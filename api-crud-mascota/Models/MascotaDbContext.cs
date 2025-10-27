using Microsoft.EntityFrameworkCore;

namespace api_crud_mascota.Models
{
    public class MascotaDbContext: DbContext
    {
        public MascotaDbContext(DbContextOptions<MascotaDbContext> options) : base(options)
        {

        }

        public DbSet<Mascota> Mascotas { get; set; }
    }
}
