using Microsoft.EntityFrameworkCore;

namespace QuanLiQuanCafe.Models.Domain
{
    public class TableFood
    {   
        public int Id { get; set; }
        public int Name { get; set; }
        public int status { get; set; } = 0;
    }
}
