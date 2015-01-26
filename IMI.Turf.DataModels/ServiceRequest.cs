//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IMI.Turf.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class ServiceRequest
    {
        public ServiceRequest()
        {
            this.Bids = new HashSet<Bid>();
            this.Messages = new HashSet<Message>();
        }
    
        public int ServiceRequestId { get; set; }
        public int CreatedBy { get; set; }
        public string RequestName { get; set; }
        public string RequestDescription { get; set; }
        public int RequestCategoryid { get; set; }
        public Nullable<int> RequestAddressId { get; set; }
        public Nullable<System.DateTime> ServiceDate { get; set; }
        public Nullable<System.DateTime> MinDate { get; set; }
        public Nullable<System.DateTime> MaxDate { get; set; }
        public Nullable<decimal> ServiceBudget { get; set; }
        public Nullable<decimal> MinBudget { get; set; }
        public Nullable<decimal> MaxBudget { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<short> RateId { get; set; }
    
        public virtual ICollection<Bid> Bids { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }
        public virtual ServiceRequest ServiceRequest1 { get; set; }
        public virtual ServiceRequest ServiceRequest2 { get; set; }
        public virtual UserProfile UserProfile { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
