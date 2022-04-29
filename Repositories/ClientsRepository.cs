using API_FF6.Models;
using API_FF6.Models.Entities.Clients;

namespace API_FF6.Repositories
{
    public interface IClientsRepository
    {
        public bool Create(PostClients client);

        public Clients Read(int id);

        public bool Update(PutClients client);

        public bool Delete(int id);
    }

    public class ClientsRepository : IClientsRepository
    {
        public readonly _DbContext db;

        public ClientsRepository(_DbContext _db)
        {
            db = _db;
        }

        public bool Create(PostClients client)
        {
            try
            {
                var client_db = new Clients()
                {
                    Name = client.Name,
                    BirthDate = client.BirthDate
                };
                db.clients.Add(client_db);
                db.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public Clients Read(int id)
        {
            try
            {
                var client_db = db.clients.Find(id);
                var age = DateTime.Today.Year - client_db.BirthDate.Year;
                client_db.Age = age.ToString();
                return client_db;
            }
            catch
            {
                return new Clients();
            }
        }

        public bool Update(PutClients client)
        {
            try
            {
                var client_db = db.clients.Find(client.Id);
                client_db.Name = client.Name;
                client_db.BirthDate = client.BirthDate;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var client_db = db.clients.Find(id);
                db.clients.Remove(client_db);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
