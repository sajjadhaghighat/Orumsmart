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
    
    public partial class ENCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ENCategory()
        {
            this.ENProducts = new HashSet<ENProduct>();
        }
    
        public int CATID { get; set; }
        public string family { get; set; }
        public string @class { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ENProduct> ENProducts { get; set; }
    }
}
