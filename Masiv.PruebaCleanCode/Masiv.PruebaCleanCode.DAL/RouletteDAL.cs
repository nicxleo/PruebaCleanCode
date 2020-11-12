using MongoDB.Driver;
using System.Collections.Generic;
using Masiv.PruebaCleanCode.Entities.Database;
using Masiv.PruebaCleanCode.Entities.Model;

namespace Masiv.PruebaCleanCode.DAL
{
    public class RouletteDAL
    {
        private readonly IMongoCollection<RouletteEntity> _roulette;

        public RouletteDAL(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _roulette = database.GetCollection<RouletteEntity>("roulette");
        }

        public List<RouletteEntity> Get() => _roulette.Find(x => true).ToList();

        public RouletteEntity Get(string id) => _roulette.Find(x => x.Id == id).FirstOrDefault();

        public RouletteEntity Create(RouletteEntity pObject)
        {
            _roulette.InsertOne(pObject);
            return pObject;
        }

        public void Update(string id, RouletteEntity objIn) => _roulette.ReplaceOne(x => x.Id == id, objIn);

        public void Remove(RouletteEntity objIn) => _roulette.DeleteOne(x => x.Id == objIn.Id);

        public void Remove(string id) => _roulette.DeleteOne(x => x.Id == id);
    }
}
