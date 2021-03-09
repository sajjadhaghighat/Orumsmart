﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Ourmsmart.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class FAProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FAProduct()
        {
            this.Orders = new HashSet<Order>();
        }

        [Display(Name = "کد محصول")]
        public int PID { get; set; }
        [Display(Name = "عنوان محصول")]
        public string Title { get; set; }
        [Display(Name = "معرفی کوتاه")]
        public string Summary { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "قیمت به ریال")]
        public string Price { get; set; }
        [Display(Name = "وضعیت محصول")]
        public string Status { get; set; }
        [Display(Name = "تعداد موجودی")]
        public int Qty { get; set; }
        [Display(Name = "آدرس عکس اصلی")]
        public string Imagepath { get; set; }
        [Display(Name = "نوع محصول")]
        public string Ptype { get; set; }
        [Display(Name = "دسته محصول")]
        public string Pmodel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
