using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.DAL;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.BLL
{
    public class BookingManager
    {
        BookingGateway gateway=new BookingGateway();

        public List<BookingHistoryByCat> PopulateDropDownlist()
        {
            return gateway.PopulateDropDownlist();
        }

        public List<BookingHistoryByCat> PopulateNameDropDownlist(string categ)
        {
            return gateway.PopulateNameDropDownlist(categ);
        }

        public List<BookingHistoryByCat> PopulateGridview(string catg, string catName)
        {
            return gateway.PopulateGridview(catg, catName);
        }

        public List<BookingHistoryByCat> PopulateGridviewByAll()
        {
            return gateway.PopulateGridviewByAll();
        }

        public int CountNewApp()
        {
           
            return gateway.CountNewApp();
        }

        public List<Application> GetAllPendingApplication()
        {
            return gateway.GetAllPendingApplication();
        }

        public List<Application> GetApplicationDetails(string appId)
        {
            return gateway.GetApplicationDetails(appId);
        }

        public int StoreBookingInformation( Booking booking)
        {
            return gateway.StoreBookingInformation( booking);
        }

        public int UpdateBookingStatus(string bookingStatus)
        {
            return gateway.UpdateBookingStatus(bookingStatus);
        }
    }
}