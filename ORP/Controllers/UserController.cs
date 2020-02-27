using ORP.Business.Repositories;
using System.Web.Mvc;

namespace ORP.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public bool CreateUser()
        {
            var repo = new TestRepository();
            repo.AddUser();
            return true;
        }

        public ActionResult Login()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
    }
}