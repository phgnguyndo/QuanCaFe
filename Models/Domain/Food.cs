using Microsoft.EntityFrameworkCore;

namespace QuanLiQuanCafe.Models.Domain
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string imageUrl { get; set; }
        public int FoodCategoryId { get; set; }

        public FoodCategory FoodCategory{ get; set; }
    }
}
