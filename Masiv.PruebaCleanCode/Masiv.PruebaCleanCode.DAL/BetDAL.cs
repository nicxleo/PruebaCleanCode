using MongoDB.Driver;
using System.Collections.Generic;
using Masiv.PruebaCleanCode.Entities.Database;
using Masiv.PruebaCleanCode.Entities.Model;

namespace Masiv.PruebaCleanCode.DAL
{
    public class BetDAL
    {
        private readonly IMongoCollection<BetEntity> _bet;

        public BetDAL(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _bet = database.GetCollection<BetEntity>("bet");
        }

        public List<BetEntity> Get() => _bet.Find(x => true).ToList();

        public List<BetEntity> Get(string pRouletteId) => _bet.Find(x => x.RouletteId == pRouletteId).ToList();

        public BetEntity Create(BetEntity pObject)
        {
            _bet.InsertOne(pObject);
            return pObject;
        }

        public void Update(string id, BetEntity objIn) => _bet.ReplaceOne(x => x.Id == id, objIn);

        public void Remove(BetEntity objIn) => _bet.DeleteOne(x => x.Id == objIn.Id);

        public void Remove(string id) => _bet.DeleteOne(x => x.Id == id);
    }
}
