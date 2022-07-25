using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Departments.Validators;
using UDPATaskV2.Application.Exceptions;
using UDPATaskV2.Application.Features.Department.Requests.Commands;
using UDPATaskV2.Application.Responses;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.Features.Department.Handlers.Commands
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(
           IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new UpdateDepartmentDtoValidator(_unitOfWork.DepartmentsRepository);
            var validationResult = await validator.ValidateAsync(request.updateDepartmentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Department = await _unitOfWork.DepartmentsRepository.Get(request.updateDepartmentDto.ID);

            if (Department is null)
                throw new NotFoundException(nameof(Department), request.updateDepartmentDto.ID);
            _mapper.Map(request.updateDepartmentDto, Department);
            
            await _unitOfWork.DepartmentsRepository.Update(Department);
            await _unitOfWork.Save();
            response.Id = Department.ID;
            response.Message = "Department Updated";
            response.Success = true;
            return response;
        }
    }
}
