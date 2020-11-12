namespace Masiv.PruebaCleanCode.Entities.Model
{
    public interface IDatabaseSettings
    {
        string RouletteCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}