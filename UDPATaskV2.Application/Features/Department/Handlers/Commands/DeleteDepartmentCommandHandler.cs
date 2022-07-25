using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Identity;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Departments.Validators;
using UDPATaskV2.Application.Exceptions;
using UDPATaskV2.Application.Features.Department.Requests.Commands;
using UDPATaskV2.Application.Responses;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.Features.Department.Handlers.Commands
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(
           IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new DeleteDepartmentDtoValidator(_unitOfWork.DepartmentsRepository);
            var validationResult = await validator.ValidateAsync(request.DeleteDepartmentDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var department = await _unitOfWork.DepartmentsRepository.Get(request.DeleteDepartmentDto.ID);

                if (department == null)
                    throw new NotFoundException(nameof(department), request.DeleteDepartmentDto.ID);

                await _unitOfWork.DepartmentsRepository.Delete(department);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Department Deleted";

            }

             

            return response;
        }
    }
}
