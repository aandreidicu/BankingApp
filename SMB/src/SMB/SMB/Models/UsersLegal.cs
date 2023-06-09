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
    
    public  class UsersLegal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsersLegal()
        {
            this.CurrentAccounts = new HashSet<CurrentAccount>();
            this.Deposits = new HashSet<Deposit>();
        }
    
        public System.Guid userID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string personalCode { get; set; }
        public System.DateTime birthDate { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string HomeAddress { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurrentAccount> CurrentAccounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deposit> Deposits { get; set; }
    }
}
