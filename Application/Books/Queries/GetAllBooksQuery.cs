using System.Collections;
using System.Collections.Generic;
using Application.Wrappers;
using Domain.Entities;

namespace Application.Books.Queries
{
    public class GetAllBooksQuery : IRequestWrapper<IEnumerable<Book>>
    {
        
    }
}