﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BudgetDBEntities : DbContext
    {
        public BudgetDBEntities()
            : base("name=BudgetDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BudgetLimit> BudgetLimits { get; set; }
        public virtual DbSet<Donation> Donations { get; set; }
        public virtual DbSet<Income> Incomes { get; set; }
        public virtual DbSet<IncomeType> IncomeTypes { get; set; }
        public virtual DbSet<InterestPeriod> InterestPeriods { get; set; }
        public virtual DbSet<InterestType> InterestTypes { get; set; }
        public virtual DbSet<Investment> Investments { get; set; }
        public virtual DbSet<InvestmentType> InvestmentTypes { get; set; }
        public virtual DbSet<MonthlySpending> MonthlySpendings { get; set; }
        public virtual DbSet<NetWorth> NetWorths { get; set; }
    }
}
