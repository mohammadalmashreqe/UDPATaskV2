using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.DTOs.Departments.Validators
{
    public class UpdateDepartmentDtoValidator : AbstractValidator<UpdateDepartmentDto>
    {
        private readonly IDepartmentsRepository _DepartmentRepository;
        public UpdateDepartmentDtoValidator(IDepartmentsRepository DepartmentsRepository)
        {
            _DepartmentRepository = DepartmentsRepository;

            RuleFor(p => p.ID)
                .NotNull()
                .NotEmpty()
                .MustAsync(async (id, token) =>
                {
                    var IsExists = await _DepartmentRepository.Exists(id);
                    return IsExists;
                });
            RuleFor(p => p.Name)
               .NotNull()
               .NotEmpty();
            RuleFor(p => p.Code)
               .NotNull()
               .NotEmpty();



        }
    }
    
    
}
