
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Jwt
    {
        public Jwt(string key, string issuer,string audience,string subject)
        {
            Key = key;
            Issuer = issuer;
            Audience = audience;
            Subject = subject;
        }

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subject { get; set; }

      
    }
}
