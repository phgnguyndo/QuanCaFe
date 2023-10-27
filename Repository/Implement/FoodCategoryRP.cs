using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Data;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.FoodCategoryDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Repository.Implement
{
    public class FoodCategoryRP : IFoodCategoryRP
    {
        private readonly QLQuanCfDbContext dbContext;
        public FoodCategoryRP(QLQuanCfDbContext dbContext)
        {
            this.dbContext = dbContext;          
        }
        public async Task<FoodCategory> CreateFoodCategoryAsync(FoodCategoryDTO foodCategoryDTO)
        {
            var newFoodCategory = new FoodCategory
            {
                Name = foodCategoryDTO.Name
            };
            await dbContext.FoodCategories.AddAsync(newFoodCategory);
            await dbContext.SaveChangesAsync();
            return newFoodCategory;
        }

        public async Task<FoodCategory> DeleteFoodCategoryAsync(int id)
        {
            var exist= await dbContext.FoodCategories.FirstOrDefaultAsync(x=> x.Id == id);
            if (exist == null) { return null; }
            dbContext.FoodCategories.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<FoodCategory>> GetAllAsync()
        {
            return await dbContext.FoodCategories.ToListAsync();
        }

        public async Task<FoodCategory> GetByIdAsync(int id)
        {
            var exist= await dbContext.FoodCategories.FirstOrDefaultAsync(x=>x.Id==id);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<FoodCategory> UpdateFoodCategoryAsync(int id, FoodCategoryDTO foodCategoryDTO)
        {
            var exist= await dbContext.FoodCategories.FirstOrDefaultAsync(x=>x.Id==id);
            if (exist == null) { return null; }
            exist.Name=foodCategoryDTO.Name;
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
