using Microsoft.EntityFrameworkCore;

namespace Records.API.Entities
{
    public class RecordsStoreContext : DbContext
    {
        public RecordsStoreContext(DbContextOptions<RecordsStoreContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Record> Records { get; set; }
    }
}
