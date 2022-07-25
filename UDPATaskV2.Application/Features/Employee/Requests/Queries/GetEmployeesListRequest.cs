using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Employee;

namespace UDPATaskV2.Application.Features.Employee.Requests.Queries
{
    public class GetEmployeesListRequest:IRequest<List<GetEmployeeDetailListDto>>
    {
        public GetEmployeeDetailListDto GetEmployeeDetailListDto { get; set; }
    }
}
