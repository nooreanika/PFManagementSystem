using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.DAL;
using PhysicalManagementSystemApp.Model;

namespace PhysicalManagementSystemApp.BLL
{
    public class OrganizationManager
    {
        OrganizationGateway aGateway = new OrganizationGateway();
         public List<Organization> GetData()
        {
            return aGateway.GetData();
        }
         public bool SaveOrganization(string nam,string email)
         {
             return aGateway.SaveOrganization(nam, email);
         }
         public bool DeleteData(string name)
         {
            return  aGateway.DeleteData(name);
         }
         public bool UpdateData(string name, string email)
         {
            return  aGateway.UpdateData(name,email);
         }
    }
}