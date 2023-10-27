using AutoMapper;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.AcoutDto;
using QuanLiQuanCafe.Models.DTO.BillDto;
using QuanLiQuanCafe.Models.DTO.BillInfoDto;
using QuanLiQuanCafe.Models.DTO.FoodCategoryDto;
using QuanLiQuanCafe.Models.DTO.FoodDto;
using QuanLiQuanCafe.Models.DTO.TableFoodDto;

namespace QuanLiQuanCafe.Mapping
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles() 
        {
         CreateMap<FoodCategory, FoodCategoryDTO>().ReverseMap();
         CreateMap<Food, FoodDTO>().ReverseMap();
         CreateMap<Food, AddFoodDTO>().ReverseMap();
         CreateMap<Food, UpdateFoodDTO>().ReverseMap();
         CreateMap<TableFood, UpdateTableDTO>().ReverseMap();
         CreateMap<TableFood, AddTableDTO>().ReverseMap();
         CreateMap<TableFood, TableDTO>().ReverseMap();
         CreateMap<Bill, BillDTO>().ReverseMap();
         CreateMap<Bill, UpdateBillDTO>().ReverseMap();
         CreateMap<Bill, AddBillDTO>().ReverseMap();
         CreateMap<BillInfo, AddBillInfoDTO>().ReverseMap();
         CreateMap<BillInfo, UpdateBillInfoDTO>().ReverseMap();
         CreateMap<BillInfo, BillInfoDTO>().ReverseMap();
         CreateMap<Acount, AddAcountDTO>().ReverseMap();
         CreateMap<Acount, UpdateAcountDTO>().ReverseMap();
         CreateMap<Acount, AcountDTO>().ReverseMap();
        }
    }
}
