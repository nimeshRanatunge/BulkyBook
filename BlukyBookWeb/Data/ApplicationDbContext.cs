using BlukyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BlukyBookWeb.Data
{
    //need to inherit this class from DBcontext that is inside EF core
    public class ApplicationDbContext :DbContext
    {
        //configure DbContextOptions on the class we are in right now
        //those options we have to pass to the base class
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
    }
}
