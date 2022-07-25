using System;
using System.ComponentModel.DataAnnotations;

namespace UDPATaskV2.Application.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        public Guid RoleId { set; get; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
