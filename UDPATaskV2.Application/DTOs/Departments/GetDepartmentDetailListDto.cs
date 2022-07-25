using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Common;

using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.DTOs.Departments
{
   public class GetDepartmentDetailListDto: BaseDto
    {
        public string Name { get; set; }
        
        public string Code { get; set; }
        public virtual ICollection<UDPATaskV2.Domain.Entities.Employee> Employees { get; set; }
    }
}
