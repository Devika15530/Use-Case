using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
   public  interface IUserRepository
    {
        UserDetails UserLogin(string uname, string pswd);

        void UserRegister(UserDetails sobj);
       
        void UpdateProfile(UserDetails uobj);

        UserDetails ViewProfile(string uid);
    }
}
