using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Colors
{
    public class ColorsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string hex_code { get; set; }
        public bool IsActive { get; set; }
    }
}
