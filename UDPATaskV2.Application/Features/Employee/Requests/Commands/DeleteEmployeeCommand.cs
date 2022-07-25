using MediatR;
using UDPATaskV2.Application.DTOs.Employee;
using UDPATaskV2.Application.Responses;

namespace UDPATaskV2.Application.Features.Employee.Requests.Commands
{
    public class DeleteEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public DeleteEmployeeDto DeleteEmployeeDto { set; get; } 
    }
}
