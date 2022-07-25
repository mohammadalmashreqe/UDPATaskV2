using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Employee;
using UDPATaskV2.Application.Features.Employee.Requests.Commands;
using UDPATaskV2.Application.Features.Employee.Requests.Queries;
using UDPATaskV2.Application.Responses;

namespace UDPATaskV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IWebHostEnvironment _hosting;

        public EmployeeController(IMediator mediator, IWebHostEnvironment hosting)
        {
            _mediator = mediator;
            _hosting = hosting;
        }
   
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromForm] CreateNewEmployeeDto model)
        {
            var Department = await _mediator.Send(new CreateEmployeeCommand { CreateNewEmployeeDto = model });
            return Ok(Department);
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<ActionResult<List<GetEmployeeDetailListDto>>> Get()
        {
            var Employees = await _mediator.Send(new GetEmployeesListRequest());
            return Ok(Employees);
        }
        // PUT api/<EmployeeController>/
        [HttpPut]
        public async Task<ActionResult> Put([FromForm] UpdateEmployeeDto model)
        {
            var command = new UpdateEmployeeCommand { UpdateEmployeeDto = model };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // GET: api/<EmployeeController>/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<GetEmployeeDetailDto>> Get(Guid id)
        {
            var Employees = await _mediator.Send(new GetEmployeesDetailsRequest() { Id = id });
            return Ok(Employees);
        }
        // DELETE api/<DepartmentController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteEmployeeCommand { DeleteEmployeeDto = new DeleteEmployeeDto { ID = id } };
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
