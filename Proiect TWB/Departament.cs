//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Proiect_TWB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Departament
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Departament()
        {
            this.Angajats = new HashSet<Angajat>();
        }
    
        public int IdDep { get; set; }
        public string DenumireDep { get; set; }
        public Nullable<int> MarcaSef { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Angajat> Angajats { get; set; }
        public virtual Angajat Angajat { get; set; }
    }
}
