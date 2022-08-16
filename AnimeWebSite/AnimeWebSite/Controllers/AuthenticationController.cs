using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AnimeWebSite.Identity.Domain.Entities.Users;
using AnimeWebSite.Contracts;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Facebook;
using AutoMapper;

namespace AnimeWebSite.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthenticationController(ILogger<AuthenticationController> logger,
                                        UserManager<ApplicationUser> userManager,
                                        SignInManager<ApplicationUser> signInManager,
                                        IMapper mapper)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult SignIn(string? ReturnUrl)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model,string? ReturnUrl)
        {
            ReturnUrl = ReturnUrl ?? Url.Content("~/");

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("SignIn model is not valid");
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if(user is null)
            {
                ModelState.AddModelError("","User not found");
                _logger.LogInformation("User not found");
                return View(model);
            }

           var result = await _signInManager.PasswordSignInAsync(user, model.Password,false,false);

            if (result.Succeeded)
            {
                return Redirect(ReturnUrl);
            }

            return View(model);
        }

        public IActionResult SignUp(string? returnUrl)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel model,string? returnUrl = "/")
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser() { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var claimsList = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, model.UserName),
                        new Claim(ClaimTypes.Email,model.Email),
                        new Claim(ClaimTypes.Role, "User")
                    };

                    _userManager.AddClaimsAsync(user, claimsList).GetAwaiter().GetResult();

                    await _signInManager.SignInAsync(user, isPersistent: false);
            
                    return Redirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

            }
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();

            return Redirect("/");
        }

        public IActionResult SignInFacebook()
        {
            var provider = FacebookDefaults.AuthenticationScheme;
            var returnUrl = "/";
            var redirectUrl = Url.Action(nameof(ExternalLoginCallBack),"Authentication", new { returnUrl });

            var props = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(props,provider);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl = "/")
        {
            var info =  await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToAction(nameof(SignIn));
            }

            var signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey,false,false);
            if (signInResult.Succeeded)
            {
                return Redirect(returnUrl);
            }

            var user = _mapper.Map<ApplicationUser>(info);
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                 result = await _userManager.AddLoginAsync(user, info);
                if (result.Succeeded)
                {
                    signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, false);
                    return Redirect(returnUrl);
                }
            }

            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError("", error.Description);
            }

            return Redirect(nameof(SignIn));
        }

        public IActionResult Reject()
        {
            return View();
        }
    }
}