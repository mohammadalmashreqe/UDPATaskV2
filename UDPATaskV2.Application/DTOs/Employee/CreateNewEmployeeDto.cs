using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UDPATaskV2.Application.DTOs.Employee
{
    public class CreateNewEmployeeDto
    {
      
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public Guid DepartmentId { set; get; }
       
        public Guid RoleId { set; get; }
       

        public DateTime DateofBirth { set; get; }
        

        public string Address { get; set; }
       
        public IFormFile Image { get; set; }

    }
}
