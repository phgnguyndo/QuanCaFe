using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLiQuanCafe.Models.DTO.BillDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly IBillRP billRP;
        private readonly IMapper mapper;

        public BillController(IBillRP billRP, IMapper mapper)
        {
            this.billRP = billRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBill() 
        {
            var bills= await billRP.GetAllBillAsync();
            if (bills == null) { return NotFound(); }
            var billDTO = mapper.Map<List<BillDTO>>(bills);
            return Ok(billDTO);
        }

        [HttpGet]
        [Route("{TableId:int}")]
        public async Task<IActionResult> GetBillById([FromRoute] int TableId)
        {
            var exist = await billRP.GetBillByTableIdAsync(TableId);
            if (exist == null) { return NotFound(); };
            return Ok(mapper.Map<BillDTO>(exist));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBill([FromBody] AddBillDTO addBillDTO)
        {
            var bill = await billRP.CreateBillAsync(addBillDTO);
            var billDTO = mapper.Map<BillDTO>(bill);
            return Ok(billDTO);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateBill([FromRoute] int id, UpdateBillDTO updateBillDTO)
        {
            var bill = await billRP.UpdateBillAsync(id, updateBillDTO);
            if (bill == null) { return NotFound(); }
            var billDTO = mapper.Map<BillDTO>(bill);
            return Ok(billDTO);
        }


        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBill(int id)
        {
            var bill = await billRP.DeleteBillAsync(id);
            if (bill == null) { return NotFound(); }
            var billDTO = mapper.Map<BillDTO>(bill);
            return Ok(billDTO);
        }

    }
}
