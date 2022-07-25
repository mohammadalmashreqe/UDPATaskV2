using System;
using System.Threading.Tasks;
using UDPATaskV2.Application.Models.Identity;

namespace UDPATaskV2.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<BaseIdentityResponse> DeleteUserWithRoles(Guid UserId);


    }
}
