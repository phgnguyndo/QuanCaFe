using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.FoodCategoryDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodCategoryController : ControllerBase
    {
        private readonly IFoodCategoryRP foodCategoryRP;
        private readonly IMapper mapper;

        public FoodCategoryController(IFoodCategoryRP foodCategoryRP, IMapper mapper)
        {
            this.foodCategoryRP = foodCategoryRP;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFoodCategory() 
        {
            var allFoodCategory=await foodCategoryRP.GetAllAsync();
            var allFoodCategoryDto = mapper.Map<List<FoodCategoryDTO>>(allFoodCategory);
            return Ok(allFoodCategoryDto);
        }

        [HttpGet()]
        [Route("{id:int}")]
        public async Task<IActionResult> GetByIdFoodCategory([FromRoute] int id) 
        {
            var exist=await foodCategoryRP.GetByIdAsync(id);
            if (exist==null) { return NotFound(); }
            var existDto= mapper.Map<FoodCategoryDTO>(exist);
            return Ok(existDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFoodCategory([FromForm] FoodCategoryDTO foodCategoryDTO)
        {
            var newFoodCategory = await foodCategoryRP.CreateFoodCategoryAsync(foodCategoryDTO);
            return Ok(newFoodCategory);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateFoodCategory([FromRoute] int id, FoodCategoryDTO foodCategoryDTO)
        {
            var exist = await foodCategoryRP.UpdateFoodCategoryAsync(id, foodCategoryDTO);

            return Ok(mapper.Map<FoodCategoryDTO>(exist));
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteFoodCategory([FromRoute] int id)
        {
            var exist = await foodCategoryRP.DeleteFoodCategoryAsync(id);
            if(exist==null) { return NotFound(); }
            return Ok(mapper.Map<FoodCategoryDTO>(exist));
        }
    }
}
