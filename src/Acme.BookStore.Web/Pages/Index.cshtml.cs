//using Microsoft.AspNetCore.Authorization;

//namespace Acme.BookStore.Web.Pages;

//[Authorize]
//public class IndexModel : BookStorePageModel
//{
//    public void OnGet()
//    {

//    }
//}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Users;
using IdentityUser = Volo.Abp.Identity.IdentityUser;

namespace Acme.BookStore.Web.Pages;

[Authorize]
public class IndexModel : BookStorePageModel
{
    private readonly UserManager<IdentityUser> _userManager;

    public IdentityUser CurrentUser { get; set; }

    public IndexModel(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public List<string> UserRoles { get; set; }

    public async Task OnGetAsync()
    {
        CurrentUser = await _userManager.GetUserAsync(User);
        UserRoles = (await _userManager.GetRolesAsync(CurrentUser)).ToList();
    }
}
