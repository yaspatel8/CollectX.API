using CollectX.API.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.User
{
    public class ProfileResponseModel : ResponseModel
    {
        public string? OldFileName { get; set; }
    }
}
