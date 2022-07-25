using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Common;

using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.DTOs.Departments
{
   public class GetDepartmentDetailDto: BaseDto
    {
        public string Name { get; set; }
        
        public string Code { get; set; }
        public virtual ICollection<Domain.Entities.Employee> Employees { get; set; }
    }
}
