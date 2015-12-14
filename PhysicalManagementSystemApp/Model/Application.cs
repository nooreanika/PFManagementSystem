using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicalManagementSystemApp.Model
{
    public class Application
    {
        public int SlNo { get; set; }
        public string AppId { get; set; }
        public string Category { get; set; }
        public string CatName { get; set; }
        public string Asubject { get; set; }
        public string OrgName { get; set; }
        public string Appdetails { get; set; }
        public string TimeSlot { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string BookingStatus { get; set; }
        public string FaciId { get; set; }

        public DateTime prrocessingTime { get; set; }
        public string Remark { get; set; }
        public string UserName { get; set; }
    }
}