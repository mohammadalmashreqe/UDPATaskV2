using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Identity;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Employee.Validators;
using UDPATaskV2.Application.Features.Employee.Requests.Commands;
using UDPATaskV2.Application.Responses;
using UDPATaskV2.Application.Exceptions;


namespace UDPATaskV2.Application.Features.Department.Handlers.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authenticationService;

        public UpdateEmployeeCommandHandler(
           IUnitOfWork unitOfWork,
            IMapper mapper, IAuthService authenticationService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticationService = authenticationService;
        }

        public async Task<BaseCommandResponse> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();
            var validator = new UpdateEmployeeDtoValidator(_unitOfWork.EmployeeRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateEmployeeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Employee = await _unitOfWork.EmployeeRepository.Get(request.UpdateEmployeeDto.ID);

            if (Employee is null)
                throw new NotFoundException(nameof(Employee), request.UpdateEmployeeDto.ID);

            _mapper.Map(request.UpdateEmployeeDto, Employee);

            Employee.ImageUrl= await SaveImageAsync(request.UpdateEmployeeDto.Image, Employee.ImageUrl);

            await _unitOfWork.EmployeeRepository.Update(Employee);
            await _unitOfWork.Save();
            response.Id = Employee.ID;
            response.Message = "Employee Updated";
            response.Success = true;
            return response;
        }
        private async Task<string> SaveImageAsync(IFormFile Image, string OldImageUrl)
        {
            string imageUrl = null;
            if (Image != null)
            {
                string fullPathToDel = Path.Combine(Directory.GetCurrentDirectory(), @"img\", OldImageUrl);
                if (System.IO.File.Exists(fullPathToDel))
                {
                    System.IO.File.Delete(fullPathToDel);
                }


                var extensionFile = Path.GetExtension(Image.FileName);
                var newFileName = Guid.NewGuid().ToString() + extensionFile;
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), @"img\");
                string fullPath = Path.Combine(uploads, newFileName);
                imageUrl = newFileName;
                using (var stream = System.IO.File.Create(fullPath))
                {
                    await Image.CopyToAsync(stream);
                }
            }
            return imageUrl;
        }



    }
}
