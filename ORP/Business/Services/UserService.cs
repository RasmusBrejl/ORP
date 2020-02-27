using ORP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ORP.Buisness.Services
{
    public class UserService
    {
        // private readonly UserRepository _userRepository;

        // public UserService(UserRepository userRepository)
        public UserService()
        {
            // _userRepository = userRepository;
        }

        public bool UserHasClearance(User user, String ClearanceName)
        {
            return user.Clearance.Name.Equals(ClearanceName);
        }

        public bool TryLogIn(User user, out string errMsg)
        {
            errMsg = "";
            if (true)
            {
                return true;
            }
            errMsg = "Error during login attempt";
            return false;
        }
    }
}