using HW_Week_End.Entties;
using HW_Week12_End.Entties;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week_End.Repositories
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
                ("Data Source =ELAMIR\\SQLEXPRESS; Database = HW12; Integrated Security=True; User ID = sa; Password =123456 ; TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Duty> Duties { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
