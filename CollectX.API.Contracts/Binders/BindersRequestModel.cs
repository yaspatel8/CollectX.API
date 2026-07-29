using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CollectX.API.Contracts.Binders
{
    public class BindersRequestModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Binder name required.")]
        public string BinderName { get; set; }
        [Required(ErrorMessage = "Color id required.")]
        public int ColorId { get; set; }
        [Required(ErrorMessage = "Pocket id required.")]
        public int PocketId { get; set; }
        [Required(ErrorMessage = "Set id required.")]
        public int SetId { get; set; }
        [Required(ErrorMessage = "Sku required.")]
        public string Sku { get; set; }
        [Required(ErrorMessage = "IsNFC required.")]
        public bool IsNFC { get; set; }
        [Required(ErrorMessage = "Created by required.")]
        public int CreatedBy { get; set; }

    }
}
