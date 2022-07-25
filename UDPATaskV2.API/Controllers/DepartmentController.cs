using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Departments;
using UDPATaskV2.Application.Features.Department.Requests.Commands;
using UDPATaskV2.Application.Features.Department.Requests.Queries;

namespace UDPATaskV2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<DepartmentController>
        [HttpGet]
        public async Task<ActionResult<List<GetDepartmentDetailListDto>>> Get()
        {
            var Departments = await _mediator.Send(new GetDepartmentListRequest());
            return Ok(Departments);
        }

        // GET api/<DepartmentController>/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDepartmentDetailDto>> Get(Guid id)
        {
            var Department = await _mediator.Send(new GetDepartmentDetailRequest { Id = id });
            return Ok(Department);
        }
        [HttpPost]
        public async Task<ActionResult<GetDepartmentDetailDto>> Post([FromBody] CreateNewDepartmentDto model)
        {
            var Department = await _mediator.Send(new CreateDepartmentCommand { CreateNewDepartmentDto = model });
            return Ok(Department);
        }

        // PUT api/<DepartmentController>/{id}
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateDepartmentDto model)
        {
            var command = new UpdateDepartmentCommand { updateDepartmentDto = model };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // DELETE api/<DepartmentController>/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteDepartmentCommand { DeleteDepartmentDto = new DeleteDepartmentDto { ID = id } };
            var response=await _mediator.Send(command);
            return Ok(response);
        }
    }
}
