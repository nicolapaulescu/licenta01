using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using maibagamofisa.Models;

namespace maibagamofisa.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<maibagamofisa.Models.Dialogue> Dialogue { get; set; } = default!;
    }
}
