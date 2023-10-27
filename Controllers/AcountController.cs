using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiQuanCafe.Models.DTO.AcoutDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcountController : ControllerBase
    {
        private readonly IAcountRP acountRP;
        private readonly IMapper mapper;

        public AcountController(IAcountRP acountRP, IMapper mapper)
        {
            this.acountRP = acountRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAcount() 
        {
            var acounts= await acountRP.GetAllAcountAsync();
            if (acounts == null) { return NotFound(); }
            return Ok(mapper.Map<List<AcountDTO>>(acounts));
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetAcountById([FromRoute] int id)
        {
            var acount = await acountRP.GetAcountByIdAsync(id);
            if (acount == null) { return NotFound(); }
            return Ok(mapper.Map<AcountDTO>(acount));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAcount(AddAcountDTO addAcountDTO)
        {
            var acount = await acountRP.CreateAcountAsync(addAcountDTO);
            return Ok(mapper.Map<AcountDTO>(acount));
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAcount([FromRoute]int id, UpdateAcountDTO updateAcountDTO)
        {
            var acount = await acountRP.UpdateAcountAsync(id, updateAcountDTO);
            if (acount == null) { return NotFound(); }
            return Ok(mapper.Map<AcountDTO>(acount));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAcount([FromRoute] int id)
        {
            var acount = await acountRP.DeleteAcountAsync(id);
            if (acount == null) { return NotFound(); }
            return Ok(mapper.Map<AcountDTO>(acount));
        }
    }
}
