using QuanLiQuanCafe.Models.Domain;

namespace QuanLiQuanCafe.Models.DTO.FoodDto
{
    public class FoodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string imageUrl { get; set; }
        public int FoodCategoryId { get; set; }

        public FoodCategory FoodCategory { get; set; }
    }
}
