﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DCode.Data.DbContexts
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<applicantskill> applicantskills { get; set; }
        public virtual DbSet<approvedapplicant> approvedapplicants { get; set; }
        public virtual DbSet<daily_usage_statistics> daily_usage_statistics { get; set; }
        public virtual DbSet<elmah_error> elmah_error { get; set; }
        public virtual DbSet<log> logs { get; set; }
        public virtual DbSet<offering> offerings { get; set; }
        public virtual DbSet<portfolio> portfolios { get; set; }
        public virtual DbSet<service_line> service_line { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<suggestion> suggestions { get; set; }
        public virtual DbSet<task_type> task_type { get; set; }
        public virtual DbSet<taskapplicant> taskapplicants { get; set; }
        public virtual DbSet<task> tasks { get; set; }
        public virtual DbSet<taskskill> taskskills { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<notification_subscription> notification_subscription { get; set; }
    
        public virtual ObjectResult<elmah_GetErrorsXml_Result> elmah_GetErrorsXml(string app, Nullable<int> pageIndex, Nullable<int> pageSize, ObjectParameter totalCount)
        {
            var appParameter = app != null ?
                new ObjectParameter("App", app) :
                new ObjectParameter("App", typeof(string));
    
            var pageIndexParameter = pageIndex.HasValue ?
                new ObjectParameter("PageIndex", pageIndex) :
                new ObjectParameter("PageIndex", typeof(int));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("PageSize", pageSize) :
                new ObjectParameter("PageSize", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<elmah_GetErrorsXml_Result>("elmah_GetErrorsXml", appParameter, pageIndexParameter, pageSizeParameter, totalCount);
        }
    
        public virtual int elmah_LogError(string errorId, string application, string host, string type, string source, string message, string user, string allXml, Nullable<int> statusCode, Nullable<System.DateTime> timeUtc)
        {
            var errorIdParameter = errorId != null ?
                new ObjectParameter("ErrorId", errorId) :
                new ObjectParameter("ErrorId", typeof(string));
    
            var applicationParameter = application != null ?
                new ObjectParameter("Application", application) :
                new ObjectParameter("Application", typeof(string));
    
            var hostParameter = host != null ?
                new ObjectParameter("Host", host) :
                new ObjectParameter("Host", typeof(string));
    
            var typeParameter = type != null ?
                new ObjectParameter("Type", type) :
                new ObjectParameter("Type", typeof(string));
    
            var sourceParameter = source != null ?
                new ObjectParameter("Source", source) :
                new ObjectParameter("Source", typeof(string));
    
            var messageParameter = message != null ?
                new ObjectParameter("Message", message) :
                new ObjectParameter("Message", typeof(string));
    
            var userParameter = user != null ?
                new ObjectParameter("User", user) :
                new ObjectParameter("User", typeof(string));
    
            var allXmlParameter = allXml != null ?
                new ObjectParameter("AllXml", allXml) :
                new ObjectParameter("AllXml", typeof(string));
    
            var statusCodeParameter = statusCode.HasValue ?
                new ObjectParameter("StatusCode", statusCode) :
                new ObjectParameter("StatusCode", typeof(int));
    
            var timeUtcParameter = timeUtc.HasValue ?
                new ObjectParameter("TimeUtc", timeUtc) :
                new ObjectParameter("TimeUtc", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("elmah_LogError", errorIdParameter, applicationParameter, hostParameter, typeParameter, sourceParameter, messageParameter, userParameter, allXmlParameter, statusCodeParameter, timeUtcParameter);
        }
    }
}
