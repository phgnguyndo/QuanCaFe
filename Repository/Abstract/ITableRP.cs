using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.TableFoodDto;

namespace QuanLiQuanCafe.Repository.Abstract
{
    public interface ITableRP
    {
        Task<List<TableFood>> GetAllTableAsync();
        Task<TableFood> GetTableByNameAsync(int name);
        Task<TableFood> CreateTableAsync(AddTableDTO addTableDTO);
        Task<TableFood> UpdateTableAsync(int id,UpdateTableDTO updateTableDTO);
        Task<TableFood> DeleteTableAsync(int id);
    }
}
