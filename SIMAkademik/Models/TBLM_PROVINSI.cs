//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SIMAkademik.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLM_PROVINSI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLM_PROVINSI()
        {
            this.TBLM_KOTA = new HashSet<TBLM_KOTA>();
        }
    
        public int IDPROVINSI { get; set; }
        public string NAMA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLM_KOTA> TBLM_KOTA { get; set; }
    }
}
