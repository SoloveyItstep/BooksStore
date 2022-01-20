using MediatR;
using System;

namespace Books.Domain.Core.Queries.Users
{
    public class DeleteUserQuery: IRequest<bool>
    {
        public DeleteUserQuery(string id)
        {
            this.Id = id;
        }
        public string Id { get; set; }
    }
}
