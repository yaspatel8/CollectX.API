using System;
using System.Collections.Generic;
using System.Text;

namespace CollectX.API.Contracts.Sets
{
    public class SetsModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string CardSize { get; set; }
        public bool IsActive { get; set; }
    }
}
