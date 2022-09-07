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
                ModelState.AddModelError("", "Invalid email");
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
                var user = _mapper.Map<ApplicationUser>(model);
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user,"User");

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

        public IActionResult SignInFacebook(string returnUrl = "/")
        {
            var provider = FacebookDefaults.AuthenticationScheme;
            var redirectUrl = Url.Action(nameof(ExternalLoginCallBack),"Authentication", new { returnUrl });

            var props = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);

            return Challenge(props,provider);
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallBack(string returnUrl)
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

            var user = await _userManager.FindByEmailAsync(info.Principal.Claims.First(x => x.Type == ClaimTypes.Email).Value);

            if (user is not null)
            {
                 var resul = await _userManager.AddLoginAsync(user, info);
                if (resul.Succeeded)
                {
                    signInResult = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, false, false);
                    return Redirect(returnUrl);
                }
            }

             user = _mapper.Map<ApplicationUser>(info);

            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                 result = await _userManager.AddToRoleAsync(user, "User");

                if (!result.Succeeded)
                {
                    _logger.LogError($"Cant add {nameof(user)} to role");
                }


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