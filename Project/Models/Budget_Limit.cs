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
    
    public partial class Budget_Limit
    {
        public int LimitID { get; set; }
        public decimal LimitAmount { get; set; }
        public int CustomerID { get; set; }
        public int LimitTypeID { get; set; }
    
        public virtual Budget_Limit_Type Budget_Limit_Type { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
