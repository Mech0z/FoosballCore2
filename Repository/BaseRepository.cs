﻿using Microsoft.Extensions.Options;
using Models;
using MongoDB.Driver;

namespace Repository
{
    public class BaseRepository<T> where T : IKey
    {
        protected static IMongoClient Client;
        protected static IMongoDatabase Database;
        private readonly string _collectionName;

        public BaseRepository(IOptions<MongoDbSettings> settings, string collectionName)
        {
            Client = new MongoClient(settings.Value.ConnectionString);

            Database = Client.GetDatabase(settings.Value.DatabaseName);
            _collectionName = collectionName;
        }

        public IMongoCollection<T> Collection => Database.GetCollection<T>(_collectionName);

        public void Upsert(T item)
        {
            Collection.ReplaceOne(i => i.Id == item.Id, item,
                            new UpdateOptions { IsUpsert = true });
        }
    }
}