using System;
using WasherKartBAL.User.Models;
using System.Collections.Generic;
using WasherKartUtility.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasherKartBAL.Repository.IRepository
{
    public interface IUserRepository
    {
        public User.Models.UserEmailResult GetUserByEmail(string stEmail);
        public void InserUserProfile(UserProfile foUserProfile, int fiUserId, out int fiSuccess);
        public void UpdateUserStatus(int fiUserId, int inBalance,string fsDesc, out int fiSuccess);
        public User.Models.UserProfileDetails GetUserProfileDetail(int fiUserId);
        public List<User.Models.UserTranscationLog> GetUserTranscationLog(int fiUserId);
        public void UpdateUserTranscation(SuccessMobileRecharge foSuccessMobileRecharge, int fiUserId, out int fiSuccess);
        public User.Models.TranscationDetails GetTranscationDetails(int fiinTranscationId);
    }
}

