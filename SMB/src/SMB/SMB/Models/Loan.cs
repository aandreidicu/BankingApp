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
    
    public partial class Loan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loan()
        {
            this.LoanPays = new HashSet<LoanPay>();
        }
    
        public int ID { get; set; }
        public string accountIBAN { get; set; }
        public System.DateTime loanDate { get; set; }
        public int noMonths { get; set; }
        public decimal intRate { get; set; }
        public decimal amount { get; set; }
        public int currency { get; set; }
    
        public virtual Currency Currency1 { get; set; }
        public virtual CurrentAccount CurrentAccount { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanPay> LoanPays { get; set; }
    }
}
