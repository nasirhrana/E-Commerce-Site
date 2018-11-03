using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using E_CommerceSite.Gateway;
using E_CommerceSite.Models;

namespace E_CommerceSite.Manager
{
    public class AdminManager
    {
        private AdminGateway adminGateway=new AdminGateway();
        public string SaveCompany(Company company)
        {
            if (adminGateway.SaveCompany(company)>0)
            {
                return "Company has been saved successfully";
            }
            else
            {
                return "Failed to save company";
            }
        }

        public bool IsCompanyNameExists(string name)
        {
            return adminGateway.IsCompanyNameExists(name);
        }
    }
}