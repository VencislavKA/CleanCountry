namespace CleanCountry.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CleanCountry.Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        public UserManager<ApplicationUser> UserManager { get; }

        public ProfileController(UserManager<ApplicationUser> userManager)
        {
            this.UserManager = userManager;
        }

        public IActionResult Index()
        {
            var user = this.UserManager.GetUserAsync(this.User);
            return this.View(user.Result);
        }
    }
}
