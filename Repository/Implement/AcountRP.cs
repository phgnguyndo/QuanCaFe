using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Data;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.AcoutDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Repository.Implement
{
    public class AcountRP : IAcountRP
    {
        private readonly QLQuanCfDbContext dbContext;

        public AcountRP(QLQuanCfDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        public async Task<Acount> CreateAcountAsync(AddAcountDTO addAcountDTO)
        {
            var newAcount = new Acount
            {
                username = addAcountDTO.username,
                displayName = addAcountDTO.displayName,
                password = addAcountDTO.password,
                type = addAcountDTO.type
            };
            dbContext.Acounts.Add(newAcount);
            await dbContext.SaveChangesAsync();
            return newAcount;
        }

        public async Task<Acount> DeleteAcountAsync(int id)
        {
            var exist = await dbContext.Acounts.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return null;
            }
            dbContext.Acounts.Remove(exist);
            await dbContext.SaveChangesAsync(); 
            return exist;
        }

        public async Task<Acount> GetAcountByIdAsync(int id)
        {
            var exist= await dbContext.Acounts.FirstOrDefaultAsync(x=>x.Id==id);
            if (exist == null)
            {
                return null;
            }
            return exist;
        }

        public async Task<List<Acount>> GetAllAcountAsync()
        {
            return await dbContext.Acounts.ToListAsync();
        }

        public async Task<Acount> UpdateAcountAsync(int id, UpdateAcountDTO updateAcountDTO)
        {
            var exist = await dbContext.Acounts.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null)
            {
                return null;
            }
            exist.username=updateAcountDTO.username;
            exist.password=updateAcountDTO.password;
            exist.displayName=updateAcountDTO.displayName;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
