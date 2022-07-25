using AutoMapper;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UDPATaskV2.Application.Contracts.Persistence;
using UDPATaskV2.Application.DTOs.Employee.Validators;
using UDPATaskV2.Application.Features.Employee.Requests.Commands;
using UDPATaskV2.Application.Responses;
using UDPATaskV2.Application.Exceptions;
using UDPATaskV2.Application.Contracts.Identity;
using System.IO;

namespace UDPATaskV2.Application.Features.Department.Handlers.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAuthService _authenticationService;

        public DeleteEmployeeCommandHandler(
           IUnitOfWork unitOfWork,
            IAuthService authenticationService,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            _mapper = mapper;
            _authenticationService = authenticationService;

        }

        public async Task<BaseCommandResponse> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new DeleteEmployeeDtoValidator(_unitOfWork.EmployeeRepository);
            var validationResult = await validator.ValidateAsync(request.DeleteEmployeeDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Employee = await _unitOfWork.EmployeeRepository.Get(request.DeleteEmployeeDto.ID);

                if (Employee == null)
                    throw new NotFoundException(nameof(Employee), request.DeleteEmployeeDto.ID);

                //Delete User 
                var IsUserDeleted = await _authenticationService.DeleteUserWithRoles(Employee.UserId);


                //Delete Image 
                DeleteEmployeeImage(Employee.ImageUrl);

                await _unitOfWork.EmployeeRepository.Delete(Employee);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Employee Deleted";

            }



            return response;
        }

        private  bool DeleteEmployeeImage(string ImageUrl)
        {

            string fullPathToDel = Path.Combine(Directory.GetCurrentDirectory(), @"img\", ImageUrl);
            if (File.Exists(fullPathToDel))
            {
                File.Delete(fullPathToDel);
                return true; 
            }
            return false; 
        }

    }
}
