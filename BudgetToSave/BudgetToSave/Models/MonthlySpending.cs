//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BudgetToSave.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonthlySpending
    {
        public int MonthlySpendingID { get; set; }
        public Nullable<double> FoodAmount { get; set; }
        public Nullable<double> ClothesAmount { get; set; }
        public Nullable<double> AlcoholAmount { get; set; }
        public Nullable<double> OtherAmount { get; set; }
        public System.DateTime Date { get; set; }
    }
}
