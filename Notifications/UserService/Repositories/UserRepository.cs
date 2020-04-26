using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.Models;

namespace UserService.Repositories
{
    public class UserRepository : IUserRepository
    {

        private readonly NotificationDbContext _context;
        public UserRepository(NotificationDbContext context)
        {
            _context = context;

        }
        public UserDetails UserLogin(string uname, string pswd)
        {
            return _context.UserDetails.SingleOrDefault(p => p.Username == uname && p.Password == pswd);

        }

        public void UserRegister(UserDetails uobj)
        {
            _context.Add(uobj);
            _context.SaveChanges();
        }



        public void UpdateProfile(UserDetails bobj)
        {
            _context.UserDetails.Update(bobj);
            _context.SaveChanges();
        }

        public UserDetails ViewProfile(string bid)
        {
            return _context.UserDetails.Find(bid);
        }

    }
}
