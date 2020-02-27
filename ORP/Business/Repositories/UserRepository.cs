using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ORP.Model;
using ORP.Models;

namespace ORP.Business.Repositories
{
    public class UserRepository
    {
        public User GetUser(User user)
        {
            using (var context = new OrpContext())
            {
                return context.Users.FirstOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            }
        }
    }
}