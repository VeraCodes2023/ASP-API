using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options)
        {
            
        }
    }
}