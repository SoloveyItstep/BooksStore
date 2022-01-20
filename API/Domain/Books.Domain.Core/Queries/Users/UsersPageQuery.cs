using Books.Domain.Core.DTOs;
using MediatR;
using System.Collections.Generic;

namespace Books.Domain.Core.Queries.Users
{
    public class UsersPageQuery: IRequest<List<UserShortDto>>
    {
        public UsersPageQuery(int currentPage, int pageSize)
        {
            CurrentPage = currentPage;
            PageSize = pageSize;
        }

        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
