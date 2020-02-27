using System;
using System.Threading.Tasks;
using ORP.Business.Repositories;
using System.Web.Mvc;
using ORP.Buisness.Services;
using ORP.Models;

namespace ORP.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController()
        {
            _userService = new UserService(new UserRepository());
        }

        [HttpGet]
        public bool CreateUser()
        {
            var repo = new TestRepository();
            repo.AddUser();
            return true;
        }

        [HttpGet]
        public async Task<ActionResult> GetUser(string username, string password)
        {
            var user = new User
            {
                Name = username,
                Password = password
            };
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}