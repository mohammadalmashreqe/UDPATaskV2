using System;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDepartmentsRepository DepartmentsRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
    
        Task Save();
    }
}
