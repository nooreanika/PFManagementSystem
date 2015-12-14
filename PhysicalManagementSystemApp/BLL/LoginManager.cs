using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhysicalManagementSystemApp.DAL;

namespace PhysicalManagementSystemApp.BLL
{
    public class LoginManager
    {
        LoginGateway loginGateway=new LoginGateway();
        public bool Login(string userName, string password)
        {
            return loginGateway.Login(userName, password);

        }
    }
}