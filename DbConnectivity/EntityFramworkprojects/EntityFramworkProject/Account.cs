//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramworkProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Account
    {
        public int AcId { get; set; }
        public string AcType { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string BankName { get; set; }
        public int AcNumber { get; set; }
    
        public virtual Customer Customer { get; set; }
    }
}
