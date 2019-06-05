using MongoDB.Driver;

namespace MinhaApi.Services.Config 
{
    public class ConnectDatabase<T> 
    {
        private readonly IMongoCollection<T> _entity;

        public ConnectDatabase(string connString,string db,string collection)
        {
            var client = new MongoClient(connString);
            var database = client.GetDatabase(db);
            _entity = database.GetCollection<T>($"{collection}");
        }

        public IMongoCollection<T> GetConn()
        {
            return this._entity;
        }

    }
}