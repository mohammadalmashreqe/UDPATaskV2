using System;

namespace UDPATaskV2.Application.Models.Identity
{
    public class RegistrationResponse
    {
        public Guid UserId { get; set; }
        public bool Success { get; set; } = true;
    }
}
