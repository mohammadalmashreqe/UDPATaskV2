using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly UDPATaskV2DbContext _dbContext;

        public EmployeeRepository(UDPATaskV2DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
   
    }
}
