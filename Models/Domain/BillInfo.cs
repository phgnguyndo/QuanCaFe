using Microsoft.EntityFrameworkCore;

namespace QuanLiQuanCafe.Models.Domain
{
    public class BillInfo
    {
        public int Id { get; set; }
        public int count { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }

        public Bill Bill { get; set; }
        public Food Food { get; set; }
    }
}
