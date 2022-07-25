using FluentValidation;
using UDPATaskV2.Application.Contracts.Persistence;

namespace UDPATaskV2.Application.DTOs.Departments.Validators
{
    public class GetDepartmentDetailListDtoValidator : AbstractValidator<GetDepartmentDetailListDto>
    {
        private readonly IDepartmentsRepository _DepartmentRepository;
        public GetDepartmentDetailListDtoValidator(IDepartmentsRepository DepartmentsRepository)
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
