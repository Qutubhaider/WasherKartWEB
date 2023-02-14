using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasherKartUtility.Utilities
{
    public class CommonConstant
    {
        public class SessionConstant
        {
            public const string Id = "Id";
            public const string unUserId = "unUserId";
            public const string stUserName = "stUserName";
            public const string stEmail = "stEmail";
            public const string RoleId = "RoleId";
            public const string stName = "stName";
            public const string Balance = "Balance";
        }

        public class RoleConstants
        {

            public const string Admin = "Admin";
            public const string User = "User";
        }

        public enum UserType
        {
            Admin = 1,
            User = 2,
            Distributor = 3,
            Retailer = 4
        }
    }
}