using Microsoft.EntityFrameworkCore;
using TestApiActiDirectory.Models;

namespace TestApiActiDirectory.context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext( DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<TodoItem> TodoItems { get; set; }

    }
}
