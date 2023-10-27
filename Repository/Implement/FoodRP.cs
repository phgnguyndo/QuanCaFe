using Microsoft.EntityFrameworkCore;
using QuanLiQuanCafe.Data;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.FoodDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Repository.Implement
{
    public class FoodRP : IFoodRP
    {
        private readonly QLQuanCfDbContext dbContext;

        public FoodRP(QLQuanCfDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Food> CreateFoodAsync(AddFoodDTO addFoodDTO)
        {
            var newFood = new Food
            {
                Name = addFoodDTO.Name,
                Price = addFoodDTO.Price,
                FoodCategoryId = addFoodDTO.FoodCategoryId
            };
            if(addFoodDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images", addFoodDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await addFoodDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("Images", addFoodDTO.file.FileName);
                newFood.imageUrl= pathImage;
            }
            dbContext.Foods.Add(newFood);
            await dbContext.SaveChangesAsync();
            return newFood;
        }

        public async Task<Food> DeleteFoodAsync(int id)
        {
            var exist = await dbContext.Foods.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null) { return null; }
            dbContext.Foods.Remove(exist);
            await dbContext.SaveChangesAsync();
            return exist;
        }

        public async Task<List<Food>> GetAllFoodAsync()
        {
            return await dbContext.Foods.ToListAsync(); 
        }

        public async Task<Food> GetByIdFoodAsync(int id)
        {
            var exist= await dbContext.Foods.FirstOrDefaultAsync(x=>x.Id==id);
            if (exist == null) { return null; }
            return exist;
        }

        public async Task<Food> UpdateFoodAsync(int id, UpdateFoodDTO updateFoodDTO)
        {
            var exist = await dbContext.Foods.FirstOrDefaultAsync(x => x.Id == id);
            if (exist == null) { return null; }
            exist.Name = updateFoodDTO.Name;
            exist.Price = updateFoodDTO.Price;
            exist.FoodCategoryId = updateFoodDTO.FoodCategoryId;
            if (updateFoodDTO.file != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot/Images", updateFoodDTO.file.FileName);
                using (FileStream ms = new FileStream(filePath, FileMode.Create))
                {
                    await updateFoodDTO.file.CopyToAsync(ms);
                }
                var pathImage = Path.Combine("Images", updateFoodDTO.file.FileName);
                exist.imageUrl = pathImage;
            }
            await dbContext.SaveChangesAsync();
            return exist;
        }
    }
}
