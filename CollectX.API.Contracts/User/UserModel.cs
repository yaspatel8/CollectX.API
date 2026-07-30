using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace CollectX.API.Contracts.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int UpdatedBy { get; set; }
        public string ImagePath { get; set; }
        public IFormFile? ProfileImage { get; set; }

    }
}
