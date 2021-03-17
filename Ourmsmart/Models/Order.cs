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

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderAddresses = new HashSet<OrderAddress>();
            this.OrderFeatures = new HashSet<OrderFeature>();
        }

        [Display(Name = "کد سفارش")]
        public int OID { get; set; }
        [Display(Name = "کد سبد")]
        public int Cartid { get; set; }
        [Display(Name = "تعداد کل")]
        public int Oqty { get; set; }
        [Display(Name = "زمان")]
        public string Timestamp { get; set; }
        [Display(Name = "قیمت")]
        public string Price { get; set; }
        [Display(Name = " وضعیت سفارش")]
        public string Status { get; set; }
        [Display(Name = "کد واریز")]
        public string Paycode { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "کد رهگیری")]
        public string Tracingcode { get; set; }
        [Display(Name = "کد محصول")]
        public Nullable<int> PID { get; set; }
        [Display(Name = "کد مشتری")]
        public Nullable<int> UserId { get; set; }
    
        public virtual FAProduct FAProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderAddress> OrderAddresses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderFeature> OrderFeatures { get; set; }
    }
}
