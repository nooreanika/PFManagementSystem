using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.DAL;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.BLL
{
    public class RejectManager
    {
        RejectGateway aGateway=new RejectGateway();
        public List<Application> ShowReject()
        {

            return aGateway.ShowReject();
        }
    }
}