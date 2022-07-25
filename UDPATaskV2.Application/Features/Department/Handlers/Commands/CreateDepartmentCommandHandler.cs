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
using UDPATaskV2.Application.Features.Department.Requests.Commands;
using UDPATaskV2.Application.Responses;
using UDPATaskV2.Domain.Entities;

namespace UDPATaskV2.Application.Features.Department.Handlers.Commands
{
    class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDepartmentCommandHandler(
           IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDepartmentDtoValidator(_unitOfWork.DepartmentsRepository);
            var validationResult = await validator.ValidateAsync(request.CreateNewDepartmentDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                Departments departments = _mapper.Map<Departments>(request.CreateNewDepartmentDto);
                var res=await _unitOfWork.DepartmentsRepository.Add(departments);
                await _unitOfWork.Save();
                response.Id = res.ID;
                response.Success = true;
                response.Message = "Department Created";
            }


            return response;
        }
    }
}
