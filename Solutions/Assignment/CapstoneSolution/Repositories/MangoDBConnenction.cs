using MongoDB.Driver;
namespace Repositories;
public static class MongoDbConnection
{
    public static MongoClient CreateClient(string connectionString)
    {
        // Using the static Create method of MongoUrl
        var mongoUrl = MongoUrl.Create(connectionString);
        var client = new MongoClient(mongoUrl);
        return client;
    }
}