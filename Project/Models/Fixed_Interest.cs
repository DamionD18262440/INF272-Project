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
    
    public partial class Fixed_Interest
    {
        public string FixedInterest { get; set; }
        public string Annually { get; set; }
        public string Semi_Annually { get; set; }
        public string Quarterly { get; set; }
        public string Monthly { get; set; }
        public string InterestType { get; set; }
    
        public virtual Interest_Type Interest_Type { get; set; }
    }
}
