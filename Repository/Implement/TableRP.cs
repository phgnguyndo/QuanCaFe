using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Data;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.TableFoodDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Repository.Implement
{
    public class TableRP : ITableRP
    {
        private readonly QLQuanCfDbContext dbContext;

        public TableRP(QLQuanCfDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<TableFood> CreateTableAsync(AddTableDTO addTableDTO)
        {
            var table = new TableFood
            {
                Name = addTableDTO.Name,
                status = addTableDTO.status
            };
            var exist = await dbContext.TableFoods.FirstOrDefaultAsync(x => x.Name == table.Name);
            if (exist != null) { return null; }
            else
            {
                dbContext.TableFoods.Add(table);
                await dbContext.SaveChangesAsync();
                return table;
            }
           
        }

        public async Task<TableFood> DeleteTableAsync(int id)
        {
            var exist= await dbContext.TableFoods.FirstOrDefaultAsync(x=>x.Id==id);
            if (exist==null) { return null; }
            dbContext.TableFoods.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<TableFood>> GetAllTableAsync()
        {
            return await dbContext.TableFoods.ToListAsync();
        }

        public async Task<TableFood> GetTableByNameAsync(int name)
        {
            var exist = await dbContext.TableFoods.FirstOrDefaultAsync(x=>x.Name == name);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<TableFood> UpdateTableAsync(int id, UpdateTableDTO updateTableDTO)
        {
            var exist = await dbContext.TableFoods.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null) { return null; }
            exist.Name = updateTableDTO.Name;
            exist.status = updateTableDTO.status;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
