using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiQuanCafe.Models.DTO.FoodDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodRP foodRP;
        private readonly IMapper mapper;

        public FoodsController(IFoodRP foodRP, IMapper mapper)
        {
            this.foodRP = foodRP;
            this.mapper = mapper;
        }
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllFood()
        {
            var foods = await foodRP.GetAllFoodAsync();
            var allFoodDto= mapper.Map<List<FoodDTO>>(foods);
            return Ok(allFoodDto);            
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetFoodById([FromRoute] int id)
        {
            var food = await foodRP.GetByIdFoodAsync(id);
            if (food == null) { return NotFound(); }
            var FoodDto = mapper.Map<FoodDTO>(food);
            return Ok(FoodDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood([FromForm] AddFoodDTO addFoodDTO)
        {
            var newFood= await foodRP.CreateFoodAsync(addFoodDTO);
            return Ok(newFood);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateFood([FromRoute] int id, [FromForm] UpdateFoodDTO updateFoodDTO)
        {
            var updateFood = await foodRP.UpdateFoodAsync(id,updateFoodDTO);
            if (updateFood == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<FoodDTO>(updateFood));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteFood([FromRoute] int id)
        {
            var deleteFood = await foodRP.DeleteFoodAsync(id);
            if(deleteFood == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<FoodDTO>(deleteFood));
        }
    }
}
