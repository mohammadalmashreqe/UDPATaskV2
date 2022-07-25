using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Employee;
using UDPATaskV2.Application.Responses;

namespace UDPATaskV2.Application.Features.Employee.Requests.Commands
{
    public class UpdateEmployeeCommand:IRequest<BaseCommandResponse>
    {
        public UpdateEmployeeDto UpdateEmployeeDto { get; set; }
    }
}
