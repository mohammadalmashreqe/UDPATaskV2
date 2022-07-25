using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.DTOs.Employee.Validators
{
    public class UpdateEmployeeDtoValidator:AbstractValidator<UpdateEmployeeDto>
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public UpdateEmployeeDtoValidator(IEmployeeRepository EmployeeRepository)
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
