namespace QuanLiQuanCafe.Models.DTO.AcoutDto
{
    public class AddAcountDTO
    {
        public string username { get; set; }
        public string displayName { get; set; }
        public string password { get; set; }
        public int type { get; set; } = 0;
    }
}
