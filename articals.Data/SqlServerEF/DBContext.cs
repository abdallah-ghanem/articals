using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using articals.Core;
using Microsoft.EntityFrameworkCore;

namespace articals.Data.SqlServerEF
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ABDALLAH\\SQLEXPRESS;Database=artical;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        public DbSet<Catigory> Catigory {  get; set; }

    }
}
