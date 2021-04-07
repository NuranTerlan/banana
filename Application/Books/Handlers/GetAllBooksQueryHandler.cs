using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Books.Queries;
using Application.Commons.Interfaces;
using Application.Wrappers;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Books.Handlers
{
    public class GetAllBooksQueryHandler : IHandlerWrapper<GetAllBooksQuery, IEnumerable<Book>>
    {
        private readonly IApplicationDbContext _context;

        public GetAllBooksQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<Book>>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var books = await _context.Books.ToListAsync(cancellationToken);
                return await Task.FromResult(Response.Success<IEnumerable<Book>>(books, "Books are fetched successfully"));
            }
            catch (Exception e)
            {
                return await Task.FromResult(Response.Fail<IEnumerable<Book>>(e.Message));
            }
        }
    }
}