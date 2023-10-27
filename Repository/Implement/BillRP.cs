using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Data;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.BillDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Repository.Implement
{
    public class BillRP: IBillRP
    {
        private readonly QLQuanCfDbContext dbContext;

        public BillRP(QLQuanCfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Bill> CreateBillAsync(AddBillDTO addBillDTO)
        {
            var newBill = new Bill
            {
                status = addBillDTO.status,
                TableFoodId = addBillDTO.TableFoodId
            };
            dbContext.Bills.Add(newBill);
            await dbContext.SaveChangesAsync();
            return newBill;
        }

        public async Task<Bill> DeleteBillAsync(int id)
        {
            var exist = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null) { return null; }
            dbContext.Bills.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<Bill>> GetAllBillAsync()
        {
            return await dbContext.Bills.ToListAsync();
        }

        public async Task<Bill> GetBillByTableIdAsync(int TableId)
        {
            var exist= await dbContext.Bills.FirstOrDefaultAsync(x=>x.TableFoodId==TableId);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<Bill> UpdateBillAsync(int id, UpdateBillDTO updateBillDTO)
        {
            var exist = await dbContext.Bills.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null) { return null; }
            exist.status = updateBillDTO.status;
            exist.TableFoodId= updateBillDTO.TableFoodId;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
