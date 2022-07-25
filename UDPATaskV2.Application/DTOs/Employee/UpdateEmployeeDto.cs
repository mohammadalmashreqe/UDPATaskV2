﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.DTOs.Common;

namespace UDPATaskV2.Application.DTOs.Employee
{
    public class UpdateEmployeeDto: BaseDto
    {
   



        public string Name { get; set; }



        public Guid DepartmentId { set; get; }

        

        public DateTime DateofBirth { set; get; }
        
        public string Address { get; set; }
      



        public IFormFile Image { get; set; }
    }
}
 