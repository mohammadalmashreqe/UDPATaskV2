using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Departments;

namespace UDPATaskV2.Application.Features.Department.Requests.Queries
{
   public class GetDepartmentListRequest: IRequest<List<GetDepartmentDetailListDto>>
    {
        public GetDepartmentDetailListDto DepartmentDetailListDto { get; set; }
    }
}
