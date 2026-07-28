using CollectX.API.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Login
{
    public class LoginResponseModel : ResponseModel
    {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
    }
}
