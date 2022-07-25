using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Identity;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Employee.Validators;
using UDPATaskV2.Application.Features.Employee.Requests.Commands;
using UDPATaskV2.Application.Responses;

namespace UDPATaskV2.Application.Features.Department.Handlers.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authenticationService;

        public CreateEmployeeCommandHandler(
           IUnitOfWork unitOfWork,
            IMapper mapper, IAuthService authenticationService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<BaseCommandResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEmployeeDtoValidator(_unitOfWork.EmployeeRepository);
            var validationResult = await validator.ValidateAsync(request.CreateNewEmployeeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = " Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                Domain.Entities.Employee Emp = _mapper.Map<Domain.Entities.Employee>(request.CreateNewEmployeeDto);
                var user = await _authenticationService.Register(new Models.Identity.RegistrationRequest
                {
                    Email = request.CreateNewEmployeeDto.Email,
                    Password = request.CreateNewEmployeeDto.Password,
                    RoleId = request.CreateNewEmployeeDto.RoleId,
                    UserName = request.CreateNewEmployeeDto.Email


                });
                if (user.Success)
                {
                    Emp.JoiningDate = DateTime.Now;
                    Emp.UserId = user.UserId;
                    Emp.ImageUrl = await SaveImageAsync(request.CreateNewEmployeeDto.Image);
                    var Employee = await _unitOfWork.EmployeeRepository.Add(Emp);
                    await _unitOfWork.Save();
                    response.Success = true;
                    response.Message = "Employee created";
                    response.Id = Employee.ID;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Failed";

                }
            }


            return response;
        }
        private async Task<string> SaveImageAsync(IFormFile Image)
        {
            string imageUrl = null;
            if (Image != null)
            {
                var extensionFile = Path.GetExtension(Image.FileName);
                var newFileName = Guid.NewGuid().ToString() + extensionFile;
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), @"img\");
                string fullPath = Path.Combine(uploads, newFileName);
                imageUrl = newFileName;
                using (var stream = File.Create(fullPath))
                {
                    await Image.CopyToAsync(stream);
                }
            }
            return imageUrl;
        }



    }
}
