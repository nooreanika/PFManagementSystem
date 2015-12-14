using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.DAL;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.BLL
{
    public class AllApplicationManager
    {
        ApplicationGateway aGateway=new ApplicationGateway();
        public List<Application> ViewAllAppliction()
        {

            return aGateway.ViewAllApplication();

        }
    }
}