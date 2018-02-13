//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KeysOnboarding.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public partial class ProductSold
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int StoreId { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public Nullable<System.DateTime> DateSold { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }
        public IEnumerable<SelectListItem> Customers { get; set; }
        public IEnumerable<SelectListItem> Stores { get; set; }
    }
}