//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Activity
    {
        public int ActivityId { get; set; }
        public string ActivityDescription { get; set; }
        public Nullable<int> ProjectId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> TaskId { get; set; }
        public string ProjectStatus { get; set; }
        public string TaskStatus { get; set; }
        public System.DateTime ActivityDate { get; set; }
        public string ActivityStatus { get; set; }
    }
}