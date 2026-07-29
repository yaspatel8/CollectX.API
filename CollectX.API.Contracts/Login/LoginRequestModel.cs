using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollectX.API.Contracts.Login
{
    public class LoginRequestModel
    {
        [Required(ErrorMessage = "Email id required."), EmailAddress(ErrorMessage = "Invalid email address.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Password required.")]
        public required string Password { get; set; }
    }
    public class ChangePasswordRequestModel
    {
        [Required(ErrorMessage = "User id required.")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Old password required.")]
        public required string OldPassword { get; set; }
        [Required(ErrorMessage = "New password required.")]
        public required string NewPassword { get; set; }
    }
}
