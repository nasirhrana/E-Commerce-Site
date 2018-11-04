using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class RegistrationManager
    {
        private RegistrationGateway aRegistrationGateway=new RegistrationGateway();
        public string Registration(Registration registration)
        {
            if (aRegistrationGateway.Registration(registration) > 0)
            {
                return "Registration has been completed successfully";
            }
            else
            {
                return "Failed to complete Registration";
            }
        }

        public bool IsEmailExists(Registration registration)
        {
            return aRegistrationGateway.IsEmailExists(registration);
        }
    }
}