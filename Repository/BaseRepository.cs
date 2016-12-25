using Raven.Client;
using Raven.Client.Indexes;

namespace Repository
{
    public class BaseRepository<T> : AbstractIndexCreationTask<T>
    {
        private readonly string _collectionName;

        public BaseRepository(IDocumentStore documentStore, string collectionName)
        {
            _collectionName = collectionName;
        }



    }
}