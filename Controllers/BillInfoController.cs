using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update;
using QuanLiQuanCafe.Models.DTO.BillInfoDto;
using QuanLiQuanCafe.Repository.Abstract;

namespace QuanLiQuanCafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillInfoController : ControllerBase
    {
        private readonly IBillInfoRP billInfoRP;
        private readonly IMapper mapper;

        public BillInfoController(IBillInfoRP billInfoRP, IMapper mapper)
        {
            this.billInfoRP = billInfoRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBillinfo() 
        {
            var billsInfo = await billInfoRP.GetAllBillInfoAsync();
            if (billsInfo == null) { return NotFound(); }
            return Ok(mapper.Map<List<BillInfoDTO>>(billsInfo));
        }

        [HttpGet]
        [Route("{BillId:int}")]
        public async Task<IActionResult> GetBillinfoById([FromRoute] int BillId)
        {
            var billInfo = await billInfoRP.GetBillInfoByBillIdAsync(BillId);
            if (billInfo == null) { return NotFound(); }
            return Ok(mapper.Map<List<BillInfoDTO>>(billInfo));
        }

        [HttpPost]
        public async Task<IActionResult> CreateBillInfo(AddBillInfoDTO addBillInfoDTO)
        {
            var billInfo = await billInfoRP.CreateBillInfoAsync(addBillInfoDTO);
            return Ok(mapper.Map<BillInfoDTO>(billInfo));
        }

        [HttpPut]
        [Route("{BillId:int}")]
        public async Task<IActionResult> UpdateBillInfo([FromRoute]int BillId, UpdateBillInfoDTO updateBillInfoDTO)
        {
            var billsInfo = await billInfoRP.UpdateBillInfoAsync(BillId, updateBillInfoDTO);
            if (billsInfo == null) { return NotFound(); }
            return Ok(mapper.Map<BillInfoDTO>(billsInfo));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteBillInfo(int id)
        {
            var billInfo = await billInfoRP.DeleteBillInfoAsync(id);
            if (billInfo == null) { return NotFound(); }
            return Ok(mapper.Map<BillInfoDTO>(billInfo));
        }
    }
}
