using MediatR;

namespace Books.Domain.Core.Queries.Users
{
    public class DeleteUserQuery: IRequest<bool>
    {
        public DeleteUserQuery(string email)
        {
            this.Email = email;
        }
        public string Email { get; set; }
    }
}
