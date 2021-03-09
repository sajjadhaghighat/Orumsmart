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

    public partial class OrderAddress
    {
        [Display(Name = "کد آدرس سفارش")]
        public int AID { get; set; }
        [Display(Name = "نام سفارش دهنده")]
        public string Name { get; set; }
        [Display(Name = "استان")]
        public string Ostan { get; set; }
        [Display(Name = "شهر")]
        public string City { get; set; }
        [Display(Name = "آدرس")]
        public string Address { get; set; }
        [Display(Name = "شماره تلفن")]
        public string Phone { get; set; }
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = "کدپستی")]
        public string Codeposti { get; set; }
        [Display(Name = "کد سبد")]
        public Nullable<int> Cartid { get; set; }
        [Display(Name = "کد سفارش")]
        public Nullable<int> OID { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
