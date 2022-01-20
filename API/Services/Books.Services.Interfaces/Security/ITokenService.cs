using Books.Domain.Core.Identity;
using System.Threading.Tasks;

namespace Books.Services.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(ApplicationUser user);
    }
}
