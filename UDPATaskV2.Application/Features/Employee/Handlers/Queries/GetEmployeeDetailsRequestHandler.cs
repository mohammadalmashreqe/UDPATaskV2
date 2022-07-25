using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Employee;
using UDPATaskV2.Application.Features.Employee.Requests.Queries;

namespace UDPATaskV2.Application.Features.Department.Handlers.Queries
{
    public class GetEmployeeDetailsRequestHandler : IRequestHandler<GetEmployeesDetailsRequest, GetEmployeeDetailDto>
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsRequestHandler(IEmployeeRepository employeeRepository,
            IMapper mapper)
        {

            _mapper = mapper;
            _EmployeeRepository = employeeRepository;
        }

        public async Task<GetEmployeeDetailDto> Handle(GetEmployeesDetailsRequest request, CancellationToken cancellationToken)
        {

            var Employee = await _EmployeeRepository.Get(request.Id);
            return _mapper.Map<GetEmployeeDetailDto>(Employee);

        }
    }
}
