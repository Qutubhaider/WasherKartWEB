using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WasherKartBAL.User.Models
{
    public class MobileRecharge
    {
        public string api_token { get; set; }
        public string mobile_no { get; set; }
        public decimal amount { get; set; }
        public int company_id { get; set; }
        public string order_id { get; set; }
        public bool is_stv { get; set; }
    }

    public class SuccessMobileRecharge
    {
        public string lapu_no { get; set; }
        public decimal balance { get; set; }
        public int roffer { get; set; }
        public string status { get; set; }
        public DateTime recharge_date { get; set; }
        public string id { get; set; }
        public int lapu_id { get; set; }
        public int user_id { get; set; }
        public int company_id { get; set; }
        public string mobile_no { get; set; }
        public decimal amount { get; set; }
        public string order_id { get; set; }
        public string ip_address { get; set; }
        public DateTime updatedAt { get; set; }
        public DateTime createdAt { get; set; }
        public string response { get; set; }
        public string tnx_id { get; set; }
    }

    public class TranscationDetails
    {
        public DateTime recharge_date { get; set; }
        public string mobile_no { get; set; }
        public string amount { get; set; }
        public string order_id { get; set; }
        public string ip_address { get; set; }
        public string tnx_id { get; set; }
    }
}

