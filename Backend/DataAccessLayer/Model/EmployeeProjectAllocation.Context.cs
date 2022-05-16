﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Karan_SatvaEntities : DbContext
    {
        public Karan_SatvaEntities()
            : base("name=Karan_SatvaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ProjectAllocation> ProjectAllocations { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskAllocation> TaskAllocations { get; set; }
    
        [DbFunction("Karan_SatvaEntities", "CheckProjectStatsus")]
        public virtual IQueryable<CheckProjectStatsus_Result> CheckProjectStatsus(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<CheckProjectStatsus_Result>("[Karan_SatvaEntities].[CheckProjectStatsus](@ProjectId)", projectIdParameter);
        }
    
        public virtual int DeleteProject(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteProject", projectIdParameter);
        }
    
        public virtual ObjectResult<EmaployeeByProjectID_Result> EmaployeeByProjectID(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmaployeeByProjectID_Result>("EmaployeeByProjectID", projectIdParameter);
        }
    
        public virtual ObjectResult<GetActivityHistory_Result> GetActivityHistory(Nullable<int> employeeId, Nullable<int> projectId)
        {
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetActivityHistory_Result>("GetActivityHistory", employeeIdParameter, projectIdParameter);
        }
    
        public virtual ObjectResult<GetAllEmployee_Result> GetAllEmployee(Nullable<bool> employeeStatus)
        {
            var employeeStatusParameter = employeeStatus.HasValue ?
                new ObjectParameter("EmployeeStatus", employeeStatus) :
                new ObjectParameter("EmployeeStatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllEmployee_Result>("GetAllEmployee", employeeStatusParameter);
        }
    
        public virtual ObjectResult<GetAllProject_Result> GetAllProject(Nullable<bool> projectStatus)
        {
            var projectStatusParameter = projectStatus.HasValue ?
                new ObjectParameter("ProjectStatus", projectStatus) :
                new ObjectParameter("ProjectStatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetAllProject_Result>("GetAllProject", projectStatusParameter);
        }
    
        public virtual ObjectResult<GetProjectById_Result> GetProjectById(Nullable<int> projectId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetProjectById_Result>("GetProjectById", projectIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateDepartment(Nullable<int> departmentId, string departmentName)
        {
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("DepartmentId", departmentId) :
                new ObjectParameter("DepartmentId", typeof(int));
    
            var departmentNameParameter = departmentName != null ?
                new ObjectParameter("DepartmentName", departmentName) :
                new ObjectParameter("DepartmentName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateDepartment", departmentIdParameter, departmentNameParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateEmployee(Nullable<int> employeeId, string employeeName, string emailAddress, Nullable<long> phone, Nullable<System.DateTime> joinDate, Nullable<decimal> totalExperience, Nullable<decimal> salary, Nullable<bool> isActive, Nullable<bool> isDelete, Nullable<int> departmentId)
        {
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var employeeNameParameter = employeeName != null ?
                new ObjectParameter("EmployeeName", employeeName) :
                new ObjectParameter("EmployeeName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var phoneParameter = phone.HasValue ?
                new ObjectParameter("Phone", phone) :
                new ObjectParameter("Phone", typeof(long));
    
            var joinDateParameter = joinDate.HasValue ?
                new ObjectParameter("JoinDate", joinDate) :
                new ObjectParameter("JoinDate", typeof(System.DateTime));
    
            var totalExperienceParameter = totalExperience.HasValue ?
                new ObjectParameter("TotalExperience", totalExperience) :
                new ObjectParameter("TotalExperience", typeof(decimal));
    
            var salaryParameter = salary.HasValue ?
                new ObjectParameter("Salary", salary) :
                new ObjectParameter("Salary", typeof(decimal));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            var isDeleteParameter = isDelete.HasValue ?
                new ObjectParameter("IsDelete", isDelete) :
                new ObjectParameter("IsDelete", typeof(bool));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("DepartmentId", departmentId) :
                new ObjectParameter("DepartmentId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateEmployee", employeeIdParameter, employeeNameParameter, emailAddressParameter, phoneParameter, joinDateParameter, totalExperienceParameter, salaryParameter, isActiveParameter, isDeleteParameter, departmentIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateProject(Nullable<int> projectId, string projectName, string projectDescription, Nullable<System.DateTime> startDate, string projectStatus, Nullable<bool> isDelete, Nullable<bool> isActive)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            var projectNameParameter = projectName != null ?
                new ObjectParameter("ProjectName", projectName) :
                new ObjectParameter("ProjectName", typeof(string));
    
            var projectDescriptionParameter = projectDescription != null ?
                new ObjectParameter("ProjectDescription", projectDescription) :
                new ObjectParameter("ProjectDescription", typeof(string));
    
            var startDateParameter = startDate.HasValue ?
                new ObjectParameter("StartDate", startDate) :
                new ObjectParameter("StartDate", typeof(System.DateTime));
    
            var projectStatusParameter = projectStatus != null ?
                new ObjectParameter("ProjectStatus", projectStatus) :
                new ObjectParameter("ProjectStatus", typeof(string));
    
            var isDeleteParameter = isDelete.HasValue ?
                new ObjectParameter("IsDelete", isDelete) :
                new ObjectParameter("IsDelete", typeof(bool));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateProject", projectIdParameter, projectNameParameter, projectDescriptionParameter, startDateParameter, projectStatusParameter, isDeleteParameter, isActiveParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateProjectAllocation(Nullable<int> projectAllocationId, Nullable<int> employeeId, Nullable<int> projectId)
        {
            var projectAllocationIdParameter = projectAllocationId.HasValue ?
                new ObjectParameter("ProjectAllocationId", projectAllocationId) :
                new ObjectParameter("ProjectAllocationId", typeof(int));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateProjectAllocation", projectAllocationIdParameter, employeeIdParameter, projectIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateTask(Nullable<int> taskId, string taskName, string taskDescription, string taskStatus, Nullable<int> projectId)
        {
            var taskIdParameter = taskId.HasValue ?
                new ObjectParameter("TaskId", taskId) :
                new ObjectParameter("TaskId", typeof(int));
    
            var taskNameParameter = taskName != null ?
                new ObjectParameter("TaskName", taskName) :
                new ObjectParameter("TaskName", typeof(string));
    
            var taskDescriptionParameter = taskDescription != null ?
                new ObjectParameter("TaskDescription", taskDescription) :
                new ObjectParameter("TaskDescription", typeof(string));
    
            var taskStatusParameter = taskStatus != null ?
                new ObjectParameter("TaskStatus", taskStatus) :
                new ObjectParameter("TaskStatus", typeof(string));
    
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateTask", taskIdParameter, taskNameParameter, taskDescriptionParameter, taskStatusParameter, projectIdParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> InsertUpdateTaskAllocation(Nullable<int> taskAllocation, Nullable<int> taskId, Nullable<int> employeeId)
        {
            var taskAllocationParameter = taskAllocation.HasValue ?
                new ObjectParameter("TaskAllocation", taskAllocation) :
                new ObjectParameter("TaskAllocation", typeof(int));
    
            var taskIdParameter = taskId.HasValue ?
                new ObjectParameter("TaskId", taskId) :
                new ObjectParameter("TaskId", typeof(int));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("InsertUpdateTaskAllocation", taskAllocationParameter, taskIdParameter, employeeIdParameter);
        }
    
        public virtual ObjectResult<ProjectsByEmployeeID_Result> ProjectsByEmployeeID(Nullable<int> employeeId)
        {
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProjectsByEmployeeID_Result>("ProjectsByEmployeeID", employeeIdParameter);
        }
    
        public virtual ObjectResult<ProjectStatus_Result> ProjectStatus(Nullable<int> projectId, string projectStatus)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            var projectStatusParameter = projectStatus != null ?
                new ObjectParameter("ProjectStatus", projectStatus) :
                new ObjectParameter("ProjectStatus", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProjectStatus_Result>("ProjectStatus", projectIdParameter, projectStatusParameter);
        }
    
        public virtual ObjectResult<TaskByProjectAndFilterByEmployee_Result> TaskByProjectAndFilterByEmployee(Nullable<int> projectId, Nullable<int> employeeId)
        {
            var projectIdParameter = projectId.HasValue ?
                new ObjectParameter("ProjectId", projectId) :
                new ObjectParameter("ProjectId", typeof(int));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<TaskByProjectAndFilterByEmployee_Result>("TaskByProjectAndFilterByEmployee", projectIdParameter, employeeIdParameter);
        }
    
        public virtual int UpdateEmployeeStatus(Nullable<int> employeeId, Nullable<bool> isActive)
        {
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            var isActiveParameter = isActive.HasValue ?
                new ObjectParameter("IsActive", isActive) :
                new ObjectParameter("IsActive", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateEmployeeStatus", employeeIdParameter, isActiveParameter);
        }
    }
}