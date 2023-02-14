using WasherKartBAL.Data;
using WasherKartBAL.Repository.IRepository;
using WasherKartBAL.User.Models;
using WasherKartUtility.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasherKartBAL.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext moDatabaseContext;

        public UserRepository(DatabaseContext foDatabaseContext)
        {
            moDatabaseContext = foDatabaseContext;
        }

        public UserEmailResult GetUserByEmail(string stEmail)
        {
            return moDatabaseContext.Set<UserEmailResult>().FromSqlInterpolated($"EXEC getUserByEmail @stUserEmail={stEmail}").AsEnumerable().FirstOrDefault();
        }

        public void InserUserProfile(UserProfile foUserProfile, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC insertUserProfile @inUserProfileId={foUserProfile.inUserProfileId},@inUserId={foUserProfile.inUserId},@inSponserId={foUserProfile.inSponserId},@inDownlineId={foUserProfile.inDownlineId},@stName={foUserProfile.stName},@stEmail={foUserProfile.stEmail},@stPassword={foUserProfile.stPassword},@stMobile={foUserProfile.stMobile},@dtDateOfBirth={foUserProfile.dtDateOfBirth},@stAddress={foUserProfile.stAddress},@stCity={foUserProfile.stCity},@stState={foUserProfile.stState},@stPincode={foUserProfile.stPincode},@stCountry={foUserProfile.stCountry},@stSecurityQuestion={foUserProfile.stSecurityQuestion},@stSecurityAnswer={foUserProfile.stSecurityAnswer},@inBalance={foUserProfile.inBalance},@inStatus={foUserProfile.inStatus}, @inCreatedBy ={fiUserId},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public void UpdateUserStatus(int fiUserId,int inBalance,string fsDesc, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC UpdateUserStatus @inUserId={fiUserId},@inBalance={inBalance},@stDescription={fsDesc},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public UserProfileDetails GetUserProfileDetail(int fiUserId)
        {
           return moDatabaseContext.Set<UserProfileDetails>().FromSqlInterpolated($"EXEC getUserProfileDetails @inUserId={fiUserId}").AsEnumerable().FirstOrDefault();
        }

        public List<UserTranscationLog> GetUserTranscationLog(int fiUserId)
        {
            return moDatabaseContext.Set<UserTranscationLog>().FromSqlInterpolated($"EXEC getUserTranscationLog @inUserId={fiUserId}").AsEnumerable().ToList();
        }

        public void UpdateUserTranscation(SuccessMobileRecharge foSuccessMobileRecharge, int fiUserId, out int fiSuccess)
        {
            SqlParameter loSuccess = new SqlParameter("@inSuccess", SqlDbType.Int) { Direction = ParameterDirection.Output };
            moDatabaseContext.Database.ExecuteSqlInterpolated($"EXEC UpdateUserTranscation @inUserId={fiUserId},@lapu_no={foSuccessMobileRecharge.lapu_no},@balance={foSuccessMobileRecharge.balance},@roffer={foSuccessMobileRecharge.roffer},@status={foSuccessMobileRecharge.status},@recharge_date={foSuccessMobileRecharge.recharge_date},@id={foSuccessMobileRecharge.id},@lapu_id={foSuccessMobileRecharge.lapu_id},@user_id={foSuccessMobileRecharge.user_id},@company_id={foSuccessMobileRecharge.company_id},@mobile_no={foSuccessMobileRecharge.mobile_no},@amount={foSuccessMobileRecharge.amount},@order_id={foSuccessMobileRecharge.order_id},@ip_address={foSuccessMobileRecharge.ip_address},@updatedAt={foSuccessMobileRecharge.updatedAt},@createdAt={foSuccessMobileRecharge.createdAt},@response={foSuccessMobileRecharge.response},@tnx_id={foSuccessMobileRecharge.tnx_id},@inSuccess={loSuccess} OUT");
            fiSuccess = Convert.ToInt32(loSuccess.Value);
        }

        public TranscationDetails GetTranscationDetails(int fiinTranscationId)
        {
            return moDatabaseContext.Set<TranscationDetails>().FromSqlInterpolated($"EXEC getTranscationDetails @inTranscationId={fiinTranscationId}").AsEnumerable().FirstOrDefault();
        }
    }
}
