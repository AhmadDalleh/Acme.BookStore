using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Acme.BookStore.Web.Pages.Books
{
    public class EditModalModel : BookStorePageModel
    {
        [BindProperty(SupportsGet = true)]
        [HiddenInput]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateUpdateBookDto Book { get; set; }

        private readonly IBookAppService _bookAppService;
        public EditModalModel(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        public async Task OnGetAsync()
        {
           var bookDto = await _bookAppService.GetAsync(Id);
           Book =  ObjectMapper.Map<BookDto, CreateUpdateBookDto>(bookDto);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            await _bookAppService.UpdateAsync(Id,Book);
            return NoContent();
        }
    }
}
