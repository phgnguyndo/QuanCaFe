using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Models.Domain;

namespace QuanLiQuanCafe.Data
{
    public class QLQuanCfDbContext: DbContext
    {
        public QLQuanCfDbContext(DbContextOptions<QLQuanCfDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableFood>().ToTable(tb => tb.HasTrigger("AutoCreateBill"));
            modelBuilder.Entity<Bill>().ToTable(tb => tb.HasTrigger("AutoCreateBillInfo"));
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Acount> Acounts { get; set; }
        public DbSet<TableFood> TableFoods { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillInfo> BillsInfo { get; set; }
    }
}
