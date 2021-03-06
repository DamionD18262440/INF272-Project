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
    
    public partial class Income
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Income()
        {
            this.Users = new HashSet<User>();
        }
    
        public int IncomeID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> Amount { get; set; }
        public Nullable<int> IncomeTypeID { get; set; }
    
        public virtual IncomeType IncomeType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
