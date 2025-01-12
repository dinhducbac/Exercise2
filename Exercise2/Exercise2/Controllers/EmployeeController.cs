﻿using EmployeeManagerment.Models;
using Exercise2.Models;
using Exercise2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagerment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IEmployeeService EmployeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            EmployeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await EmployeeService.GetEmployee(id);
            if(result.ResultObject != null)
            {
                return Ok(result.ResultObject);
            }
            return BadRequest(result);
        }
        [HttpPost("create")]
        public async Task<IActionResult> Create(EmployeeCreateRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await EmployeeService.Create(request);
            if(result.ResultObject != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(int id, EmployeeUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await EmployeeService.Update(id, request);
            if (result.ResultObject != null)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await EmployeeService.Delete(id);
            if (result.Success == true)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await EmployeeService.GetAll();
            return Ok(result.ResultObject);
        }
    }
}
