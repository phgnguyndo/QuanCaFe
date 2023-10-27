using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.BillInfoDto;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface IBillInfoRP
    {
        Task<List<BillInfo>> GetAllBillInfoAsync();
        Task<List<BillInfo>> GetBillInfoByBillIdAsync(int BillId);
        Task<BillInfo> CreateBillInfoAsync(AddBillInfoDTO addBillInfoDTO);
        Task<BillInfo> UpdateBillInfoAsync(int BillId, UpdateBillInfoDTO updateBillInfoDTO);
        Task<BillInfo> DeleteBillInfoAsync(int id);
    }
}
