//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer_Networth
    {
        public int NetworthID { get; set; }
        public decimal NetworthAmount { get; set; }
        public int TransID { get; set; }
        public int IncomeID { get; set; }
        public int CustomerID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Income Income { get; set; }
        public virtual Spending_Transaction Spending_Transactions { get; set; }
    }
}