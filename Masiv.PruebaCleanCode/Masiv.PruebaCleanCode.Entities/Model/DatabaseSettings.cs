namespace Masiv.PruebaCleanCode.Entities.Model
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string RouletteCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}