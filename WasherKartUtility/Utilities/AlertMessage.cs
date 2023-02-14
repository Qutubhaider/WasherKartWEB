using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasherKartUtility.Utilities
{
    public static class AlertMessage
    {
        public const string RecordCreated = "{0} created.";
        public const string RecordAdded = "{0} saved successfully.";
        public const string RecordUpdated = "{0} updated successfully.";
        public const string RecordDeleted = "{0} deleted successfully.";
        public const string OperationalError = "Error : {0}.";
        public const string MobileExist = "Mobile already exists.";

        #region Project

        public const string SaveProject = "Project saved successfully.";

        #endregion
        #region Login
        public const string CredentialMisMatch = "Password does not match";
        public const string UserNotFound = "User does not exist.";
        public const string UserDeleted = "User deleted.";
        public const string UserInactive = "User inactive.";
        public const string PasswordUpdate = "Password is updated successfully.";
        #endregion
    }
}
