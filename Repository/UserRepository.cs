using System.Collections.Generic;
using System.Linq;
using Models;
using Raven.Client;

namespace Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IDocumentStore _documentStore;

        public UserRepository(IDocumentStore documentStore) : base(documentStore, "Users")
        {
            _documentStore = documentStore;
        }

        public List<User> GetUsers()
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Load<User>().ToList();
            }
        }

        public void AddUser(User user)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                session.Store(user);
            }
        }

        public User GetUser(string email)
        {
            using (IDocumentSession session = _documentStore.OpenSession())
            {
                return session.Query<User>("ByEmail")
                                        .FirstOrDefault(m => m.Email == email);
            }
        }
    }
}