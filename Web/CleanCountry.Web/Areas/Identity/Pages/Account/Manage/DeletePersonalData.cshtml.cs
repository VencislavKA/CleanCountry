using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CleanCountry.Data.Common.Repositories;
using CleanCountry.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CleanCountry.Web.Areas.Identity.Pages.Account.Manage
{
    public class DeletePersonalDataModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<DeletePersonalDataModel> _logger;
        private readonly IRepository<ApplicationUser> Repository;
        private readonly IRepository<Project> ProjectRepository;
        private readonly IRepository<Project_User> P_Urepository;

        public DeletePersonalDataModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<DeletePersonalDataModel> logger,
            IRepository<ApplicationUser> repository,
            IRepository<Project> projectRepository,
            IRepository<Project_User> p_Urepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            this.Repository = repository;
            this.ProjectRepository = projectRepository;
            this.P_Urepository = p_Urepository;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        public bool RequirePassword { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            RequirePassword = await _userManager.HasPasswordAsync(user);
            if (RequirePassword)
            {
                if (!await _userManager.CheckPasswordAsync(user, Input.Password))
                {
                    ModelState.AddModelError(string.Empty, "Incorrect password.");
                    return Page();
                }
            }

            var u = this.Repository.All().FirstOrDefault(x => x.UserName == user.UserName);
            if (u == null)
            {
                return null;
            }

            var projects = this.ProjectRepository.All().Where(x => x.Creator == u);
            foreach (var project in projects)
            {
                this.ProjectRepository.Delete(project);
            }

            await this.ProjectRepository.SaveChangesAsync();

            var projectsIn = this.P_Urepository.All().Where(x => x.User == u).ToList();
            foreach (var project in projectsIn)
            {
                this.P_Urepository.Delete(project);
            }

            await this.P_Urepository.SaveChangesAsync();

            var result = await _userManager.DeleteAsync(u);
            var userId = await _userManager.GetUserIdAsync(u);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }
    }
}
