//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DepositType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DepositType()
        {
            this.Deposits = new HashSet<Deposit>();
        }
    
        public int ID { get; set; }
        public string dName { get; set; }
        public int noMonths { get; set; }
        public decimal intRate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
