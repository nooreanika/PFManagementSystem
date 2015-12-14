using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicalManagementSystemApp.Model
{
    public class Booking
    {
        public string  BookID { get; set; }
        public string AppID { get; set; }
        public string FaciID { get; set; }

        public string TimeSlot { get; set; }

        public DateTime BookDate{ get; set; }
        public string BookStatus { get; set; }

        public string  UserName { get; set; }



    }
}