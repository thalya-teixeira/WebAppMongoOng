namespace WebAppMongoOng.Utils
{
    public interface IDatabaseSettings
    {
        string PersonCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string AnimalCollectionName { get; set; }
    }
}
