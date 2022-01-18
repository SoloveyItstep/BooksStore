using Books.Domain.Core.DbEntities;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Books.Infrastructure.Data.DBContexts
{
    public class MongoContext
    {
        readonly IMongoDatabase db;
        IMongoCollection<Favorites> collection;
        public MongoContext(string connectionString)
        {
            MongoUrl uri = new(connectionString);
            db = new MongoClient(uri).GetDatabase(uri.DatabaseName);
            collection = db.GetCollection<Favorites>(nameof(Favorites));
        }

        public async Task Test()
        {
            var data = await collection.FindAsync(x => x.UserID != null).ConfigureAwait(false);
            var res = await data.ToListAsync();
        }
    }
}
