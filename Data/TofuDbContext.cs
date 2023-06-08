using Microsoft.EntityFrameworkCore;


namespace Tofu.Data
{
	public class TofuDbContext : DbContext
	{
		public TofuDbContext(DbContextOptions<TofuDbContext> options) : base(options) {
		}

		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Animal> Animals { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}

}