using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using UDPATaskV2.Application.Constants;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly UDPATaskV2DbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IDepartmentsRepository _DepartmentsRepository;
        private IEmployeeRepository _EmplpoyeeRepository;




        public UnitOfWork(UDPATaskV2DbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this._httpContextAccessor = httpContextAccessor;
        }



        public IDepartmentsRepository DepartmentsRepository => _DepartmentsRepository ??= new DepartmentRepository(_context);

        public IEmployeeRepository EmployeeRepository => _EmplpoyeeRepository ??= new EmployeeRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            var username = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            await _context.SaveChangesAsync(username);
        }
    }
}
