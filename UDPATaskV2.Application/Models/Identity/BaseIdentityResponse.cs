using System;
using System.Collections.Generic;

namespace UDPATaskV2.Application.Models.Identity
{
    public class BaseIdentityResponse  
    {
        public Guid Id { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; }
        public List<string> Errors { get; set; }
    }
}
