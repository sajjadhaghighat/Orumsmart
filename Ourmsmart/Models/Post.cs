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

    public partial class Post
    {
        [Display(Name = "کد پست")]
        public int PostID { get; set; }
        [Display(Name = "عنوان پست")]
        public string Title { get; set; }
        [Display(Name = "خلاصه")]
        public string Summary { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "آدرس عکس اصلی")]
        public string Imagepath { get; set; }
        [Display(Name = "نام نویسنده")]
        public string AuthorName { get; set; }
        [Display(Name = "زمان")]
        public string Timestamp { get; set; }
    }
}
