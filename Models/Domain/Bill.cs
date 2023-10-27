using Microsoft.EntityFrameworkCore;

namespace QuanLiQuanCafe.Models.Domain
{
    public class Bill
    {
        public int Id { get; set; }
        public int status { get; set; } = 0;
        public int TableFoodId { get; set; }
        public TableFood TableFood { get; set; }
           
    }
}
