using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Pockets
{
    public class PocketsModel
    {
        public int Id { get; set; }
        public string PocketSize { get; set; }
        public bool IsActive { get; set; }
    }
}
