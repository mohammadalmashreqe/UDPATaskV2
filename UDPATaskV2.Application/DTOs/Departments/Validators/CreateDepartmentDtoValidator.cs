using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.DTOs.Departments.Validators
{
    public class CreateDepartmentDtoValidator:AbstractValidator<CreateNewDepartmentDto>
    {
        private readonly IDepartmentsRepository _DepartmentRepository;
        public CreateDepartmentDtoValidator(IDepartmentsRepository DepartmentsRepository)
        {
            _DepartmentRepository = DepartmentsRepository;

            RuleFor(p => p.Code)
                .NotNull().NotEmpty();
            RuleFor(p => p.Name)
              .NotNull().NotEmpty();


        }
    }
}
