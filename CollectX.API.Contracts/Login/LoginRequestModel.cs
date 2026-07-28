using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollectX.API.Contracts.Login
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email id required.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public required string Password { get; set; }
    }
}
