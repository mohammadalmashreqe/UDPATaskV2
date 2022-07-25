using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.Contracts.Persistence
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
       
    }
}
