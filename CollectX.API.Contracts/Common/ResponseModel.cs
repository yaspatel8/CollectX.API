using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Common
{
    public class ResponseModel
    {
        public int Success { get; set; }
        public string? Message { get; set; }
    }
}
