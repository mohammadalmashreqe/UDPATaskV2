using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.DTOs.Employee.Validators
{
    public class CreateEmployeeDtoValidator : AbstractValidator<CreateNewEmployeeDto>
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        public CreateEmployeeDtoValidator(IEmployeeRepository EmployeeRepository)
        {
            _EmployeeRepository = EmployeeRepository;


            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(p => p.DepartmentId)
           .NotNull()
           .NotEmpty();

            RuleFor(p => p.DateofBirth)
           .NotNull()
           .NotEmpty();


        }
    }
}
