using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.BillDto;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface IBillRP
    {
        Task<List<Bill>> GetAllBillAsync();
        Task<Bill> GetBillByTableIdAsync(int TableId);
        Task<Bill> CreateBillAsync(AddBillDTO addBillDTO);
        Task<Bill> UpdateBillAsync(int id, UpdateBillDTO updateBillDTO);
        Task<Bill> DeleteBillAsync(int id);

    }
}
