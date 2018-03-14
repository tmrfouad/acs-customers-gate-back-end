using System;
using System.Collections.Generic;
using acscustomersgatebackend.Models.Enumerations;

namespace acscustomersgatebackend.Models
{
    public class RFQ
    {
        public int RFQId { get; set; }
        public string RFQCode { get; set; }
        public string CompanyEnglishName { get; set; }
        public string ContactPersonEnglishName { get; set; }
        public string ContactPersonEmail { get; set; }
        public string ContactPersonMobile { get; set; }
        public string PhoneNumber { get; set; }
        public string TargetedProduct { get; set; }
        public string SelectedBundle { get; set; }
        public string CompanyArabicName { get; set; }
        public string Website { get; set; }
        public string Location { get; set; }
        public string Address { get; set; }
        public string ContactPersonArabicName { get; set; }
        public string ContactPersonPosition { get; set; }
        public Status Status { get; set; }
        public DateTime SubmissionTime { get; set; }
        public string UniversalIP { get; set; }

        // Navigation Properties
        public ICollection<RFQAction> RFQActions { get; set; }

        // Not Mapped Properties
        public bool SendEmail { get; set; } = false;
    }
}