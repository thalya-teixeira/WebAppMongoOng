namespace WebAppMongoOng.Utils
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string PersonCollectionName { get ; set ; }
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set ; }
        public string AnimalCollectionName { get ; set ; }

    }
}
