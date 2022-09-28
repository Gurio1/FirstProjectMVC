using AnimeWebSite.Identity.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AnimeWebSite.TagHelpers
{
    [HtmlTargetElement("p", Attributes = "GetRole")]
    public class RoleUserTH : TagHelper
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RoleUserTH(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        [HtmlAttributeName("GetRole")]
        public string UserId { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            if(UserId is null)
            {
                throw new Exception("UserId can not be null");
            }

            var user = await  _userManager.FindByIdAsync(UserId);

            string role = string.Empty;
            if (user != null)
            {
                role =  _userManager.GetRolesAsync(user).Result.First();
            }
            
            if(role is null)
            {
                throw new Exception("Role is null");
            }

            output.Content.SetContent(role is null ? "" : role);
        }

    }
}
