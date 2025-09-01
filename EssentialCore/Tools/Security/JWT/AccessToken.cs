using System;

namespace EssentialCore.Tools.Security.JWT
{
    public class AccessToken
    {
        public int Id { get; set; }

        public string Token { get; set; }

        public DateTime ExpireTime { get; set; }

        public int Person_Id { get; set; }

        public int Employee_Id { get; set; }
        
        public string DisplayName { get; set; }
    }
}