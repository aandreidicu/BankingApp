using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMB.Models
{
    public class UserAccountModel
    {
        //I
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public byte[] ProfilePicture { get; set; }

        // II
        public decimal CurrentAccount_Balance { get; set; }
        public string STRCurrentAccount_Balance { get; set; }
        public string CurrentAccount_IBAN { get; set; }
        public string CurrentAccount_Currency { get; set; }
        public string Deposit_Balance { get; set; }
        public string Deposit_IBAN { get; set; }
        public string Deposit_Currency { get; set; }
        public List<Transaction> Lista_tranzactii { get; set; }
        public List<Transaction> Lista_tranzactiiPtOverview { get; set; }
        
    }
}
