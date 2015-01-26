using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using IMI.Turf.Repository;
using IMI.Turf.DataModels;

namespace IMI.Turf.Web.Models
{
    public class ServiceRequestViewModel
    {
        public ServiceRequestViewModel(ServiceRequest r) {
                ServiceRequestId = r.ServiceRequestId;
                RequestName = r.RequestName;
                ServiceBudget = r.ServiceBudget;
                MaxBudget = r.MaxBudget;
                MinBudget = r.MinBudget;
                RequestCategoryId = r.RequestCategoryid;
                RequestDescription = r.RequestDescription;
                ServiceDate = r.ServiceDate;
                MaxDate = r.MinDate;
                MinDate = r.MaxDate;
                ServiceCategoryName = r.ServiceCategory.CategoryName;
                DateCreated = r.CreatedDate;
                RateId = r.RateId;
        }
 
        public IEnumerable<ServiceCategory> ServiceCategories { get; set; }

        public IEnumerable<Bid> Bids { get; set; }

        public int ServiceRequestId{ get; set; }

        [Display(Name = "Quick description of service you need (e.g Mawn My Lawn, or Paint My Fence)")]
        [Required]
        public string RequestName { get; set; }

        [Display(Name = "Select Category Your Service Falls Into")]
        [Required]
        public int RequestCategoryId { get; set; }

        [Display(Name="Describe Service You Need in Detail")]
        public string RequestDescription{get;set;}

        [DisplayName("If You Have Set Budget Specify It Here")]
        public Decimal? ServiceBudget { get; set; }

        [DisplayName("Minimum Budget")]
        public Decimal? MinBudget { get; set; }

        [DisplayName("Maximum Budget")]
        public Decimal? MaxBudget { get; set; }

        [DisplayName("Date Needed")]
        public DateTime? ServiceDate { get; set; }

        [DisplayName("From Date")]
        public DateTime? MinDate { get; set; }

        [DisplayName("To Date")]
        public DateTime? MaxDate { get; set; }

        [Editable(false)]
        public DateTime? ServiceRequestExpires { get; set; }

        public short? RateId { get; set; }

        public int CreatedBy { get; set; }

        private string ServiceCategoryName = string.Empty;

        private DateTime DateCreated;

        //Display properties

        public string BudgetDisplay
        {
            get
            {
                
                var budget = ServiceBudget != null ? Convert.ToDecimal(ServiceBudget).ToString("C") : Convert.ToDecimal(MinBudget).ToString("C") + " - " + Convert.ToDecimal(MaxBudget).ToString("C");
                return budget + " per " + RateTypeDisplay;
            }

        }

        public string DateNeededDisplay
        {
            get
            {
                if(ServiceDate != null) 
                    return ((DateTime)ServiceDate).ToShortDateString();
                if(MinDate!=null && MaxDate!=null)
                    return ((DateTime)MinDate).ToShortDateString() + " - " + ((DateTime)MaxDate).ToShortDateString();
                return string.Empty;
            }

        }

        public string RequestCategoryDisplay
        {
            get
            {
                return ServiceCategoryName;
            }
        }

        public string RateTypeDisplay
        {
            get
            {
                string rateDisplay = string.Empty;
                switch (RateId)
                {
                    case 0:
                        rateDisplay = "";
                        break;
                    case 1:
                        rateDisplay = "Entire Task";
                        break;
                    case 2:
                        rateDisplay = "Hour";
                        break;
                    default:
                        break;
                }
                return rateDisplay;
            }

        }

        public int NumberOfBidsDisplay { get; set; }

        public string CreatedDisplay
        {
            get { return DateCreated.ToShortDateString(); }
        }
    }
}