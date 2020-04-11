using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using eKarton.Models;

namespace eKarton.Services
{
    public class VisitService : IService<Visit>
    {
        private readonly IMongoCollection<Visit> _visits;

        public VisitService(IVisitArchiveDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _visits = database.GetCollection<Visit>(settings.VisitsCollectionName);
        }

        public List<Visit> GetAll() =>
            _visits.Find(visit => true).ToList();

        public Visit GetByGuid(string guid) =>
            _visits.Find<Visit>(visit => visit.Guid == guid).FirstOrDefault();

        public void Create(Visit visit)
        {
            _visits.InsertOne(visit);
        }

        public void Update(string id, Visit visitIn) =>
            _visits.ReplaceOne(visit => visit.Guid == id, visitIn);

        public void Remove(Visit visitIn) =>
            _visits.DeleteOne(visit => visit.Guid == visitIn.Guid);

        public void Delete(string id) =>
            _visits.DeleteOne(visit => visit.Guid == id);

        public List<Visit> GetByCondition(Visit entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(string guid, Visit obj, Visit objToUpdate)
        {
            throw new System.NotImplementedException();
        }
    }
}

