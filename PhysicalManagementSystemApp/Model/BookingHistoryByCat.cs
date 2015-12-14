using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicalManagementSystemApp.Model
{
    public class BookingHistoryByCat
    {
        //public string CatId { set; get; }
        //public string AppId { set; get; }
        public string Category { set; get; }
        public string Subject { get; set; }
        public string CatName { set; get; }
        public string OrgName { set; get; }
        public string StartDate { set; get; }
        public string EndDate { set; get; }
        public string BookingDate{ set; get; }
        public string TimeSlot { set; get; }

        public string Logistic { set; get; }
       

    }
}