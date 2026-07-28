using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Common.Enum
{
    public class CommonEnums
    {
        public enum ResponseStatus
        {
            Failure = 0,
            Success = 1,
            AlreadyExists = -1
        }
    }
}
