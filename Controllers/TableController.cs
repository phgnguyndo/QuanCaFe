using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using QuanLiQuanCafe.Models.Domain;
using QuanLiQuanCafe.Models.DTO.TableFoodDto;
using QuanLiQuanCafe.Repository.Abstract;
using System.Collections.Generic;

namespace QuanLiQuanCafe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRP tableRP;
        private readonly IMapper mapper;

        public TableController(ITableRP tableRP, IMapper mapper)
        {
            this.tableRP = tableRP;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTable()
        {
            var tables= await tableRP.GetAllTableAsync();
            var tableDto= mapper.Map< List < TableDTO >> (tables);
            return Ok(tableDto);
        }

        [HttpGet]
        [Route("{name:int}")]
        public async Task<IActionResult> GetTableByName([FromRoute] int name)
        {
            var tables = await tableRP.GetTableByNameAsync(name);
            var tableDto = mapper.Map<TableDTO>(tables);
            return Ok(tableDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] AddTableDTO addTableDTO)
        {
            var newTable = await tableRP.CreateTableAsync(addTableDTO);
            var tableDto = mapper.Map<TableDTO>(newTable);
            return Ok(tableDto);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTable([FromRoute] int id, UpdateTableDTO updateTableDTO)
        {
            var tables = await tableRP.UpdateTableAsync(id,updateTableDTO);
            var tableDto = mapper.Map<TableDTO>(tables);
            return Ok(tableDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTable([FromRoute] int id)
        {
            var tables = await tableRP.DeleteTableAsync(id);
            var tableDto = mapper.Map<TableDTO>(tables);
            return Ok(tableDto);
        }
    }
}
