using Microsoft.EntityFrameworkCore;

namespace Project1.Models.Local_DB
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> Option) :base(Option)  
        {
            
        }


        public DbSet<Student> Students { get; set; }
    }


   
}

