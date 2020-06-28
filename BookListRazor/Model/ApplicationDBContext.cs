using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class ApplicationDBContext : DbContext
    {
        // created this constructor
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
               
        }

        public DbSet<Book> Book { get; set; }

        internal Task FindAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
        
    
}
