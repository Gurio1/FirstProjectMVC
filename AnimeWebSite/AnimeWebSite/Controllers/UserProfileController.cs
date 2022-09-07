using AnimeWebSite.Contracts.User;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AnimeWebSite.Services;
using AnimeWebSite.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AnimeWebSite.Controllers
{
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IFileSystemService _fileSystem;
        private readonly ILogger<UserProfileController> _logger;

        public UserProfileController(UserManager<ApplicationUser> userManager,
                                     IMapper mapper,
                                     IFileSystemService fileSystem,
                                     ILogger<UserProfileController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _fileSystem = fileSystem;
            _logger = logger;
        }

        [HttpGet("[controller]/MyProfile")]
        public async Task<IActionResult> UserProfile()
        {
            var user = await _userManager.GetUserAsync(User);
            var userVM = _mapper.Map<UpdateUserViewModel>(user);
            return View(userVM);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(UpdateUserViewModel userVM)
        {
            var t = await _userManager.GetUserAsync(User);
            var user = _mapper.Map(userVM, t);
            if(userVM.UploadedImage is not null)
            {
                var deleteResult = _fileSystem.DeleteFile(user.ImagePath);
                if (!deleteResult)
                {
                    _logger.LogError($"Can not delete user image-{user.ImagePath}");
                }
                user.ImagePath = _fileSystem.Create(userVM.UploadedImage, FileSystemService.userImages,t.Id);
            }

            var result = await _userManager.UpdateAsync(user);

            return RedirectToAction(nameof(UserProfile));

        }
    }
}