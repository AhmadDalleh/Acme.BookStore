using Microsoft.AspNetCore.Authorization;

namespace Acme.BookStore.Web.Pages;

[Authorize]
public class IndexModel : BookStorePageModel
{
    public void OnGet()
    {

    }
}
