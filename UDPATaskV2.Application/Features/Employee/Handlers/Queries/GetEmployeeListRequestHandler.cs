using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Employee;
using UDPATaskV2.Application.Features.Employee.Requests.Queries;

namespace UDPATaskV2.Application.Features.Department.Handlers.Queries
{
    public class GetEmployeeListRequestHandler : IRequestHandler<GetEmployeesListRequest, List<GetEmployeeDetailListDto>>
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeListRequestHandler(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {

            _mapper = mapper;
            _EmployeeRepository = employeeRepository;
        }

        public async Task<List<GetEmployeeDetailListDto>> Handle(GetEmployeesListRequest request, CancellationToken cancellationToken)
        {

            var Employees = await _EmployeeRepository.GetAll();
            return _mapper.Map<List<GetEmployeeDetailListDto>>(Employees);

        }
    }
}
