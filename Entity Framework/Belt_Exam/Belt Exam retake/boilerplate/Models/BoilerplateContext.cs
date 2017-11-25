using Microsoft.EntityFrameworkCore;

namespace boilerplate.Models
{
    public class BoilerplateContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public BoilerplateContext(DbContextOptions<BoilerplateContext> options) : base(options) { }
        public DbSet<User> user { get; set; }
        public DbSet<Auction> auctions { get; set; }
        public DbSet<Bidder> bidders { get; set; }
        
    }
}