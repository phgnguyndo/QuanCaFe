using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Data;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.BillInfoDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Repository.Implement
{
    public class BillInfoRP : IBillInfoRP
    {
        private readonly QLQuanCfDbContext dbContext;

        public BillInfoRP(QLQuanCfDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }

        public async Task<BillInfo> CreateBillInfoAsync(AddBillInfoDTO addBillInfoDTO)
        {
            var newBillInfo = new BillInfo
            {
                count = addBillInfoDTO.count,
                BillId = addBillInfoDTO.BillId,
                FoodId = addBillInfoDTO.FoodId
            };
            await dbContext.AddAsync(newBillInfo);
            await dbContext.SaveChangesAsync();
            return newBillInfo;
        }

        public async Task<BillInfo> DeleteBillInfoAsync(int id)
        {
            var exist = await dbContext.BillsInfo.FirstOrDefaultAsync(x=>x.Id==id);
            if (exist == null) { return null; }
            dbContext.BillsInfo.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<BillInfo>> GetAllBillInfoAsync()
        {
            return await dbContext.BillsInfo.ToListAsync();
        }

        public async Task<List<BillInfo>> GetBillInfoByBillIdAsync(int BillId)
        {
            var exist= await dbContext.BillsInfo.Where(x=>x.BillId==BillId).ToListAsync();          
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<BillInfo> UpdateBillInfoAsync(int BillId, UpdateBillInfoDTO updateBillInfoDTO)
        {
            var exist = await dbContext.BillsInfo.FirstOrDefaultAsync(x => x.BillId == BillId);
            if (exist == null) { return null; }
            exist.count = updateBillInfoDTO.count;
            //exist.BillId = updateBillInfoDTO.BillId;
            exist.FoodId= updateBillInfoDTO.FoodId;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
