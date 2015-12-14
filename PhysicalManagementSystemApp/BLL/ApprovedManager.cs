using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.DAL
{
    public class ApprovedManager
    {
        ApprovedGateway aGateway=new ApprovedGateway();
        public List<Application> ApproveDetail()
        {
            return aGateway.ApproveDetail();
        }
    }
}