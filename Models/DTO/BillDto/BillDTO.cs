using QuanLiQuanCafe.Models.Domain;

namespace QuanLiQuanCafe.Models.DTO.BillDto
{
    public class BillDTO
    {
        public int Id { get; set; }
        public int status { get; set; } = 0;
        public int TableFoodId { get; set; }
    }
}
