namespace studentTamu.Models
{
    public class AccountsModel
    {
        public int intUserId { get; set; }
        public int intdeptid { get; set; }
        public int intRoleid { get; set; }
        public string username { get; set; }
        public string role { get; set; }        
        public string password { get; set; }       
        public bool rememberMe { get; set; }        
        public string profileImage { get; set; }
        public string imageuser { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string sqlkey { get; set; }
        public string roleName { get; set; }
        public string status { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        
    }
    public class LoginStatusModel
    {
        public int UserId { get; set; }
        public string StatusMessage { get; set; }
        public bool Status { get; set; }
    }
}
