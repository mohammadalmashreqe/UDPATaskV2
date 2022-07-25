using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Common;

namespace UDPATaskV2.Application.DTOs.Departments
{
    public class UpdateDepartmentDto: BaseDto
    {
       
        public string Name { get; set; }
        public string Code { get; set; }

    }
}
