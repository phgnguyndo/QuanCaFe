using Microsoft.EntityFrameworkCore;

namespace QuanLiQuanCafe.Models.Domain
{
    public class Acount
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string displayName { get; set; }
        public string password { get; set; }
        public int type { get; set; } = 0;
    }
}
