//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCKUTUPHANE.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBL_PERSONELLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBL_PERSONELLER()
        {
            this.TBL_HAREKETLER = new HashSet<TBL_HAREKETLER>();
        }
    
        public int ID { get; set; }
        public string PERSONEL { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBL_HAREKETLER> TBL_HAREKETLER { get; set; }
    }
}
