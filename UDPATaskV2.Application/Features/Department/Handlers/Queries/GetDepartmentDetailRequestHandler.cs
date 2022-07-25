using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Identity;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Departments;
using UDPATaskV2.Application.DTOs.Departments.Validators;
using UDPATaskV2.Application.Features.Department.Requests.Queries;
using UDPATaskV2.Application.Responses;

namespace UDPATaskV2.Application.Features.Department.Handlers.Queries
{
   public  class GetDepartmentDetailRequestHandler : IRequestHandler<GetDepartmentDetailRequest, GetDepartmentDetailDto>
    {
        private readonly IDepartmentsRepository _DepartmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentDetailRequestHandler(IDepartmentsRepository departmentsRepository,
            IMapper mapper)
        {
            
            _mapper = mapper;
            _DepartmentRepository = departmentsRepository;
        }

        public async Task<GetDepartmentDetailDto> Handle(GetDepartmentDetailRequest request, CancellationToken cancellationToken)
        {
            var Department = await _DepartmentRepository.Get(request.Id);
            return _mapper.Map<GetDepartmentDetailDto>(Department);
        }
    }
}
