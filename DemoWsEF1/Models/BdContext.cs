using Microsoft.EntityFrameworkCore;

namespace DemoWsEF1.Models
{
    public class BdContext : DbContext
    {
        public BdContext()
        {   
        }
        public BdContext (DbContextOptions<BdContext> options)
            : base(options)
        {
        }
    }
}