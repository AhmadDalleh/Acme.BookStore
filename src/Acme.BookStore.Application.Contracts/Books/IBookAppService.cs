using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Books
{
    public interface IBookAppService  : ICrudAppService<//Defines CRUD methods 
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto>
    {
    }
}
