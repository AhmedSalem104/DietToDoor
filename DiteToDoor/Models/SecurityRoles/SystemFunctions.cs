using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPWeb.Models.SecurityRoles
{
    public enum SystemFunctions
    {
        RequestType = 1,
        AgencyType = 2,
        RequestStatus = 3
    }

    public enum Roles
    {
        View = 1,
        Add = 2,
        Edit = 3,
        Delete = 4
    }
}