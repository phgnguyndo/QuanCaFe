using QuanLiQuanCafe.Models.Domain;

namespace QuanLiQuanCafe.Models.DTO.FoodDto
{
    public class UpdateFoodDTO
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int FoodCategoryId { get; set; }

        public IFormFile? file { get; set; }
    }
}
