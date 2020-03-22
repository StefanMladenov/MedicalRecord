using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using eKarton.Models;

namespace eKarton.Services
{
    public class VisitService
    {
        private readonly IMongoCollection<Visit> _visits;

        public VisitService(IVisitArchiveDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _visits = database.GetCollection<Visit>(settings.VisitsCollectionName);
        }

        public List<Visit> Get() =>
            _visits.Find(visit => true).ToList();

        public Visit Get(string id) =>
            _visits.Find<Visit>(visit => visit.Guid == id).FirstOrDefault();

        public Visit Create(Visit visit)
        {
            _visits.InsertOne(visit);
            return visit;
        }

        public void Update(string id, Visit visitIn) =>
            _visits.ReplaceOne(visit => visit.Guid == id, visitIn);

        public void Remove(Visit visitIn) =>
            _visits.DeleteOne(visit => visit.Guid == visitIn.Guid);

        public void Remove(string id) =>
            _visits.DeleteOne(visit => visit.Guid == id);
    }
}

