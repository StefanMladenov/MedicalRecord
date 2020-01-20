using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EKartonWebApp
{
    public interface API
    {
        public void Create<T>(T t, string path);

        #region Read
        public List<T> GetAll<T>(string path);
        public void GetOne(int id, string path);
        public void GetBy<T>(T t, int index, string path); // kako drugacije da prosledim path 
        #endregion

        public void Update<T>(T t, string path);
        public void Delete(int id, string path);
    }

    public class eKartonAPI : API
    {
        private static string _apiBaseURI = "https://localhost:5001/api/";

        private HttpClient _client;

        private static eKartonAPI _instance;
        private eKartonAPI() { _client = InitializeClient(); }
        public static eKartonAPI GetInstance()
        {
            if (_instance == null)
            {
                _instance = new eKartonAPI();
            }
            return _instance;
        }

        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(_apiBaseURI);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }
        public StringContent SerializeContent<T>(T obj)
        {
            var myContent = JsonConvert.SerializeObject(obj);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            return content;
        }

        public void Create<T>(T t, string path)
        {
            var dd = _client.PostAsync(path, SerializeContent(t));
        }

        public List<T> GetAll<T>(string path)
        {
            List<T> model = new List<T>();
            HttpResponseMessage response = _client.GetAsync(path).Result;
            if (response.IsSuccessStatusCode)
            {
                var customerJsonString = response.Content.ReadAsStringAsync();
                var model1 = JsonConvert.DeserializeObject<List<T>>(customerJsonString.Result);
                return model1;
            }
            return model;
        }

        public T GetOne<T>(int id, string path)
        {
            //var k = _client.GetAsync(path).ContinueWith((taskwithresponse) =>
            //{
            //    var response = taskwithresponse.Result;
            //    var jsonString = response.Content.ReadAsStringAsync();
            //    jsonString.Wait();
            //    return JsonConvert.DeserializeObject<T>(jsonString.Result);
            //});
            //return ;
            throw new NotImplementedException();
        }

        public void GetBy<T>(T t,int index, string path)
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T t, string path)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id, string path)
        {
            //HttpContent content = new HttpContent();
            _client.DeleteAsync(path + "/" + id);
        }

        public void GetOne(int id, string path)
        {
            throw new NotImplementedException();
        }
    }

    public class MedicalRecordDTO
    {
        public int Id { get; set; }

        public DoctorDTO Doctor { get; set; }

        public PatientDTO Patient { get; set; }

        public MedicalRecordDTO FathersMedicalRecord { get; set; }

        public MedicalRecordDTO MothersMedicalRecord { get; set; }

        public List<VisitEntityDTO> VisitEntities { get; set; }

        public AllergyDTO Allergy { get; set; }

        public VaccinationStatusDTO VaccineStatus { get; set; }

        public List<ImageDTO> Images { get; set; }

    }

    public class AllergyDTO
    {
        public int Id { get; set; }
        public List<string> Food { get; set; }
        ICollection<MedicineDTO> Medicines { get; set; }
        public List<string> Other { get; set; }
    }

    public class AnamnesisDTO
    {
        public int Id { get; set; }
        public ICollection<DiseaseDTO> Diseases { get; set; }
        public string SocioEpidemiologicalStatus { get; set; }
    }
    public class DiseaseDTO
    {
        public int Id { get; set; }

        public string DiseaseCode { get; set; }

        public string DiseaseName { get; set; }

        public string Therapy { get; set; }

        public DiseaseDiscriminator DiseaseDiscriminator { get; set; }
    }
    public class ImageDTO
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public DateTime Date { get; set; }

        public ImageType ImageType { get; set; }
    }
    public class InstructionDTO : ImageDTO
    {
        public InstituteDTO Institute { get; set; }
        public DoctorDTO DoctorFrom { get; set; }
        public DoctorDTO DoctorTo { get; set; }
    }
    public class SnapshotDTO : ImageDTO
    {
        public string BodyPart { get; set; }

        public SnapshotType SnapshotType { get; set; }
    }
    public class InstituteDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<DoctorDTO> Doctors { get; set; }
    }
    public class MedicineDTO
    {
        public int Id { get; set; }

        public string NameOfMedicine { get; set; }

        public bool Allergic { get; set; }
    }

    public class PersonDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UniqueCitizensIdentityNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string EMail { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

    }
    public class DoctorDTO : PersonDTO
    {
        public string Specialization { get; set; }

        public InstituteDTO Institute { get; set; }

        public int FacsimileNumber { get; set; }
    }

    public class PatientDTO : PersonDTO
    {
        public string FathersName { get; set; }

        public string MothersName { get; set; }

        // 1 - male , 2 - female
        public int Gender { get; set; }

        public int HealthInsuranceNumber { get; set; }

        // 1 - public, 2 - private
        public int TypeOfInsurance { get; set; }
    }

    public class VaccinationStatusDTO
    {
        public int Id { get; set; }

        public ICollection<VaccineDTO> VaccineList { get; set; }
    }

    public class VisitEntityDTO
    {
        public int Id { get; set; }

        public DateTime Datum { get; set; }
    }
    public class VaccineDTO
    { 
        public int Id { get; set; }

        public string VaccineName { get; set; }

        //if trajanje==null then neograniceno else dani
        public int Duration { get; set; }

        public DateTime VaccinationDate { get; set; }
    }
    public enum ImageType
    {
        Laboratory,
        Spirometry,
        AllergologicalTests
    }

    public enum SnapshotType
    {
        XRay,
        Ultrasound,
        Scanner,
        NuclearMagneticResonance,
        Other
    }

    public enum DiseaseDiscriminator
    {
        Current,
        Moved,
        Family
    }

    //public class PacijentDTO : OsobaDTO
    //{
    //    public string ImeOca { get; set; }
    //    public string ImeMajke { get; set; }
    //    public int LBO { get; set; }
    //    public int VidOsiguranja { get; set; }
    //    public int Pol { get; set; }
    //}
    //public class PregledEntityDTO
    //{
    //    public int Id { get; set; }

    //    public DateTime Datum { get; set; }

    //}
    //public class VakcinaDTO
    //{
    //    public int Id { get; set; }
    //    public string ImeVakcine { get; set; }

    //    //if trajanje==null then neograniceno else dani
    //    public int Trajanje { get; set; }
    //    public DateTime DatumVakcinacije { get; set; }
    //}
    //public class SlikaDTO
    //{
    //    public int Id { get; set; }

    //    public string ImagePath { get; set; }

    //    public DateTime Datum { get; set; }

    //    public string TipSlike { get; set; }
    //}

    //public class AlergoloskeProbeDTO : SlikaDTO
    //{

    //}

    //public class LaboratorijaDTO : SlikaDTO
    //{

    //}
    //public class SpirometrijaDTO : SlikaDTO
    //{

    //}
    //public class UputDTO : SlikaDTO
    //{

    //}

    //public class SnimakDTO : SlikaDTO
    //{
    //    public string DeoTela { get; set; }
    //}
}

