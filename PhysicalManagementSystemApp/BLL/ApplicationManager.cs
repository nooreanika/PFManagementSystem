using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.DAL;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.BLL
{
    public class ApplicationManager
    {
        ApplicationGateway aGateway = new ApplicationGateway();
        public List<Application> GetAllAppliction(string appid)
        {

            return aGateway.GetAllApplication(appid);

        }
        public int UpdateStatus(Model.Application newApplication)
        {
            return aGateway.UpdateStatus(newApplication);
        }
        public int UpdateRejectStatus(Model.Application newApplication)
        {
            return aGateway.UpdateRejectStatus(newApplication);
        }
       
        
        
    }
}