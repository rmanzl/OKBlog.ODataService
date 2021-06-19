using Microsoft.EntityFrameworkCore;

namespace OKBlogODataService.Model
{
    public class EventTicketDbContext : DbContext
    {
        public DbSet<Ticket> Ticket { get; set; }

        public EventTicketDbContext()
        {
        }

        public EventTicketDbContext(DbContextOptions<EventTicketDbContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "TODO");
            }
        }
    }
}
