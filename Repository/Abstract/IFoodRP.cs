using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.FoodDto;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface IFoodRP
    {
        Task<List<Food>> GetAllFoodAsync();
        Task<Food> GetByIdFoodAsync(int id);
        Task<Food> CreateFoodAsync(AddFoodDTO addFoodDTO);
        Task<Food> UpdateFoodAsync(int id, UpdateFoodDTO UpdateFoodDTO);
        Task<Food> DeleteFoodAsync(int id);
    }
}
