using System;

namespace DataAccessLayer.Model
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmailAddress { get; set; }
        public long Phone { get; set; }
        public System.DateTime JoinDate { get; set; }
        public Nullable<decimal> TotalExperience { get; set; }
        public Nullable<decimal> Salary { get; set; }
        public bool IsActive { get; set; }
        public bool IsDelete { get; set; }
        public Nullable<int> DepartmentId { get; set; }
    }
}
