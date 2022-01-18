using Books.Domain.Core.DbEntities;
using System.Threading.Tasks;

namespace Books.Domain.Interfaces.MongoDB
{
    public interface IFavoritesRepository: IRepository<Favorites>
    {
        Task<int> GetUserFavoritesCount(string userID);
    }
}
