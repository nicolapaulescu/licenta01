using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using maibagamofisa.Models;

namespace maibagamofisa.Data
{
    public class secretdiscretContext : DbContext
    {
        public secretdiscretContext (DbContextOptions<secretdiscretContext> options)
            : base(options)
        {
        }

        public DbSet<maibagamofisa.Models.Chat> Chat { get; set; } = default!;
    }
}
