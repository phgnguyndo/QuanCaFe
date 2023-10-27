using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.FoodCategoryDto;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface IFoodCategoryRP
    {
        Task<List<FoodCategory>> GetAllAsync();
        Task<FoodCategory> GetByIdAsync(int id);
        Task<FoodCategory> CreateFoodCategoryAsync(FoodCategoryDTO foodCategoryDTO);
        Task<FoodCategory> UpdateFoodCategoryAsync(int id, FoodCategoryDTO foodCategoryDTO);
        Task<FoodCategory> DeleteFoodCategoryAsync(int id);
    }
}
