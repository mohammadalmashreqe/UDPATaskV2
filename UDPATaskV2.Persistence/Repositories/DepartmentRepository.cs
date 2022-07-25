using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Persistence.Repositories
{
    public class DepartmentRepository : GenericRepository<Departments>, IDepartmentsRepository
    {
        private readonly UDPATaskV2DbContext _dbContext;

        public DepartmentRepository(UDPATaskV2DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
      
    }
}
