using eKarton.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var indexOptions = new CreateIndexOptions();
            var indexKeys = Builders<Visit>.IndexKeys.Ascending(x => x.PatientUCIN);
            var indexModel = new CreateIndexModel<Visit>(indexKeys, indexOptions);
            _visits.Indexes.CreateOne(indexModel);

            var indexOptions1 = new CreateIndexOptions();
            var indexKeys1 = Builders<Visit>.IndexKeys.Ascending(x => x.MedicalRecordGuid);
            var indexModel1 = new CreateIndexModel<Visit>(indexKeys1, indexOptions1);
            _visits.Indexes.CreateOne(indexModel1);
        }

        public List<Visit> GetAll() =>
            _visits.Find(visit => true).ToList();

        public Visit GetByGuid(string guid) =>
            _visits.Find<Visit>(visit => visit.Guid == guid).FirstOrDefault();

        public void Create(Visit visit)
        {
            _visits.InsertOne(visit);
        }

        public void Remove(Visit visitIn) =>
            _visits.DeleteOne(visit => visit.Id == visitIn.Id);

        public void Delete(string guid) =>
            _visits.DeleteOne(visit => visit.Guid == guid);

        public void Update(string guid, Visit obj, Visit objToUpdate)
        {
            objToUpdate.Id = obj.Id;
            objToUpdate.Guid = guid;
            if(obj.MedicalRecordGuid != null)
            {
                objToUpdate.MedicalRecordGuid = obj.MedicalRecordGuid;
            }
            objToUpdate.CreatedOn = obj.CreatedOn;
           _visits.ReplaceOne(visit => visit.Guid == guid, objToUpdate);
        }

        public List<Visit> GetAllByRecordGuid(string guid)
        {
            return _visits.Find<Visit>(visit => visit.MedicalRecordGuid == guid).ToList();
        }

        public List<Visit> GetAllByPatientUCIN(string ucin)
        {
            return _visits.Find<Visit>(visit => visit.PatientUCIN == ucin).ToList();
        }
    }
}

