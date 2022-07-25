using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Departments;
using UDPATaskV2.Application.Features.Department.Requests.Queries;

namespace UDPATaskV2.Application.Features.Department.Handlers.Queries
{
    public class GetDepartmentListRequestHandler : IRequestHandler<GetDepartmentListRequest, List<GetDepartmentDetailListDto>>
    {
        private readonly IDepartmentsRepository _DepartmentRepository;
        private readonly IMapper _mapper;

        public GetDepartmentListRequestHandler(IDepartmentsRepository departmentsRepository,
            IMapper mapper)
        {

            _mapper = mapper;
            _DepartmentRepository = departmentsRepository;
        }

        public async Task<List<GetDepartmentDetailListDto>> Handle(GetDepartmentListRequest request, CancellationToken cancellationToken)
        {
           
                var Department = await _DepartmentRepository.GetAll();
                return _mapper.Map<List<GetDepartmentDetailListDto>>(Department);
            
        }
    }
}
