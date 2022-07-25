using MediatR;
using System;
using UDPATaskV2.Application.DTOs.Employee;

namespace UDPATaskV2.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeesDetailsRequest : IRequest<GetEmployeeDetailDto>
    {
        public Guid Id { get; set; }
    }
}
