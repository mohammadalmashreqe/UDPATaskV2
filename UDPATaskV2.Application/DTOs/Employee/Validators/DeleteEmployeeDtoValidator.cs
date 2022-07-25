using FluentValidation;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.DTOs.Employee.Validators
{
    public class DeleteEmployeeDtoValidator : AbstractValidator<DeleteEmployeeDto>
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public DeleteEmployeeDtoValidator(IEmployeeRepository EmployeeRepository) 
        {
            _EmployeeRepository = EmployeeRepository;


            RuleFor(p => p.ID)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    var IsExists = await _EmployeeRepository.Exists(id);
                    return IsExists;
                });
        }
    }
}
