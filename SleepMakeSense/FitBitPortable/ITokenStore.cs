using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SleepMakeSense.Controllers
{
    public interface ITokenStore 
    { 
        string Read();  
 
        void Write(string bearerToken, string refreshToken, DateTime expiration); // Maybe a TimeSpan instead? 
    } 
}