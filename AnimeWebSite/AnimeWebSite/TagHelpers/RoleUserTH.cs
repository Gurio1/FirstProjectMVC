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
            var user = await  _userManager.FindByIdAsync(UserId);

            IList<string> roles = new List<string>();
            if (user != null)
            {
                 roles = await _userManager.GetRolesAsync(user);
            }
            
            output.Content.SetContent(roles.Count ==0 ? "" : roles.First());
        }

    }
}
