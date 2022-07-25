using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Departments;
using UDPATaskV2.Application.Responses;

namespace UDPATaskV2.Application.Features.Department.Requests.Commands
{
    public class DeleteDepartmentCommand: IRequest<BaseCommandResponse>
    {
       public DeleteDepartmentDto DeleteDepartmentDto { set; get; }
    }
}
