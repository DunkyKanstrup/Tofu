using Microsoft.EntityFrameworkCore;
using SQLite;

namespace Tofu.Data
{
	public class TofuDbContext : DbContext
	{
        SQLiteAsyncConnection Database;
        public TofuDbContext()
        {
        }
        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<Animal>();
        }

        public async Task<List<Animal>> GetAnimalsAsync()
        {
            await Init();
            return await Database.Table<Animal>().ToListAsync();
        }

        public async Task<List<Animal>> GetAnimalsThatIsBoughtAsync()
        {
            await Init();
            return await Database.Table<Animal>().Where(t => t.TransactionType == TransactionTypes.Buy).ToListAsync();

            // SQL queries are also possible
            //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public async Task<Supplier> GetSupplierAsync(int id)
        {
            await Init();
            return await Database.Table<Supplier>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveAnimalAsync(Animal animal)
        {
            await Init();
            if (animal.Id != 0)
            {
                return await Database.UpdateAsync(animal);
            }
            else
            {
                return await Database.InsertAsync(animal);
            }
        }

        public async Task<int> DeleteAnimalAsync(Animal animal)
        {
            await Init();
            return await Database.DeleteAsync(animal);
        }
        public TofuDbContext(DbContextOptions<TofuDbContext> options) : base(options) {
		}

		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Animal> Animals { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}

}