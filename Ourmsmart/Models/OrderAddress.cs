//------------------------------------------------------------------------------
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
    
    public partial class OrderAddress
    {
        public int AID { get; set; }
        public string Name { get; set; }
        public string Ostan { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<int> OID { get; set; }
        public string Codeposti { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
