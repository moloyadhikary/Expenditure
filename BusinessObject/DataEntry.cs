//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessObject
{
    using System;
    using System.Collections.Generic;
    
    public partial class DataEntry
    {
        public int Id { get; set; }
        public Nullable<int> ItemTypeId { get; set; }
        public Nullable<int> ItemSubTypeId { get; set; }
        public decimal Amount { get; set; }
        public System.DateTime DataDate { get; set; }
        public string Remarks { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime EntryDate { get; set; }
        public Nullable<int> UserId { get; set; }
    
        public virtual ItemSubType ItemSubType { get; set; }
        public virtual ItemType ItemType { get; set; }
        public virtual UserData UserData { get; set; }
    }
}
