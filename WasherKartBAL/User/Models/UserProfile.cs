using WasherKartUtility.Models;
using WasherKartUtility.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasherKartBAL.User.Models
{
    public class UserProfile
    {
        public int? inUserProfileId { get; set; }
        public Guid? unUserProfileId { get; set; }
        public int? inUserId { get; set; }
        
        [Required(ErrorMessage = "Please enter refer code.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Refer Code cannot be blank or whitespace")]
        public int inSponserId { get; set; }
        public int? inDownlineId { get; set; }

        [Required(ErrorMessage = "Please enter name.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Name cannot be blank or whitespace")]
        public string stName { get; set; }

        [Required(ErrorMessage = "Please enter email.")]
        [RegularExpression(CommonFunctions.gsEmailValidationRegex, ErrorMessage = "Invalid email address.")]
        public string stEmail { get; set; }

        [Required(ErrorMessage = "Please enter password.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Password cannot be blank or whitespace")]
        public string stPassword { get; set; }

        [Required(ErrorMessage = "Please enter mobile.")]
        [RegularExpression(@".*\S+.*$", ErrorMessage = "Mobile cannot be blank or whitespace")]
        public string stMobile { get; set; }
        public DateTime? dtDateOfBirth { get; set; }
        public string stAddress { get; set; }
        public string stCity { get; set; }
        public string stState { get; set; } 
        public string stPincode { get; set; }
        public string stCountry { get; set; }
        public string stSecurityQuestion { get; set; }
        public string stSecurityAnswer { get; set; }
        public int? inBalance { get; set; }
        public int? inStatus { get; set; }
    }

    public class UserProfileDetails
    {
        public int? inUserProfileId { get; set; }
        public Guid? unUserProfileId { get; set; }
        public int? inUserId { get; set; }
        public int inSponserId { get; set; }
        public int? inDownlineId { get; set; }
        public string stName { get; set; }
        public string stEmail { get; set; }
        public string stPassword { get; set; }
        public string stMobile { get; set; }
        public DateTime? dtDateOfBirth { get; set; }
        public string stAddress { get; set; }
        public string stCity { get; set; }
        public string stState { get; set; }
        public string stPincode { get; set; }
        public string stCountry { get; set; }
        public string stSecurityQuestion { get; set; }
        public string stSecurityAnswer { get; set; }
        public int? inStatus { get; set; }
        public double? inBalance { get; set; }
    }

    public class UserTranscationLog
    {
        public int inTranscationId { get; set; }
        public Guid unTranscationId { get; set; }
        public string stDescription { get; set; }
        public decimal inAmount { get; set; }
        public int inStatus { get; set; }
        public DateTime dtDate { get; set; }
        public int inAvaiBalance { get; set; }
        public string stTranType { get; set; }
    }
}
