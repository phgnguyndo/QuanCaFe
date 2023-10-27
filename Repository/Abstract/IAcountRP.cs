using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.AcoutDto;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface IAcountRP
    {
        Task<List<Acount>> GetAllAcountAsync();
        Task<Acount> GetAcountByIdAsync(int id);
        Task<Acount> CreateAcountAsync(AddAcountDTO addAcountDTO);
        Task<Acount> UpdateAcountAsync(int id, UpdateAcountDTO updateAcountDTO);
        Task<Acount> DeleteAcountAsync(int id);
        
    }
}
