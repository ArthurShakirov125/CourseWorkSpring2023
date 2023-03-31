using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CourseWorkSpring2023.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CourseWorkSpring2023.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<CustomUser> _userManager;
        private readonly SignInManager<CustomUser> _signInManager;

        public IndexModel(
            UserManager<CustomUser> userManager,
            SignInManager<CustomUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Display(Name = "Имя пользователя")]
            public string Nickname { get; set; }

            [Display(Name = "Дата регистрации")]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
            public DateTime RegistrationDay { get; set; }
        }

        private async Task LoadAsync(CustomUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var nickname = user.NickName;
            var CakeDay = user.RegistrationDay;
            Username = userName;

            Input = new InputModel
            {
                Nickname = nickname,
                RegistrationDay = CakeDay
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            if (Request.Form.Files.Any())
            {
                var file = Request.Form.Files["avatar"];
                string pathToSave;

                if (user.AvatarImgName == null)
                {
                    string ImageName = file.FileName;
                    string uniqueName = Guid.NewGuid().ToString() + ImageName;

                    pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Users\\UsersAvatarsImages", uniqueName);
                    user.AvatarImgName = uniqueName;
                }
                else
                {
                    pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Users\\UsersAvatarsImages", user.AvatarImgName);
                }

                using (var stream = System.IO.File.Create(pathToSave))
                {
                    file.CopyTo(stream);
                }

            }

            var OldNickname = user.NickName;
            if (Input.Nickname != OldNickname)
            {
                user.NickName = Input.Nickname;
            }

            await _userManager.UpdateAsync(user);

          //  await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Ваш профиль был обновлён";
            return RedirectToPage();
        }
    }
}
