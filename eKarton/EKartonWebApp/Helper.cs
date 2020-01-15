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
            throw new NotImplementedException();
        }

        public void GetOne(int id, string path)
        {
            throw new NotImplementedException();
        }
    }

    public class KartonDTO
    {
        public int KartonID { get; set; }

        public LekarDTO Lekar { get; set; }

        public PacijentDTO Pacijent { get; set; }

        public KartonDTO KartonOca { get; set; }

        public KartonDTO KartonMajke { get; set; }

        public List<PregledEntityDTO> PreglediLista { get; set; }

        public KartonAlergenaDTO KartonAlergena { get; set; }

        public KartonVakcinacijeDTO KartonVakcinacije { get; set; }

        public List<SlikaDTO> SlikeLista { get; set; }

    }

    //public class AlergenDTO
    //{
    //    public int AlergenID { get; set; }
    //    public string ImeAlergena { get; set; }
    //    public bool Alergican { get; set; }
    //}
    public class KartonAlergenaDTO
    {
        public int KartonAlergenaID { get; set; }
        public ICollection<string> AlergeniLista { get; set; }
        public ICollection<string> OstaloLista { get; set; }
        public ICollection<LekDTO> LekoviLista { get; set; }
    }
    public class KartonVakcinacijeDTO
    {
        public int KartonVakcinacijeID { get; set; }
        public ICollection<VakcinaDTO> VakcineLista { get; set; }
    }
    public class LekDTO
    {
        public int LekID { get; set; }
        public string ImeLeka { get; set; }
        public bool Alergican { get; set; }
    }
    public class OsobaDTO
    {
        public int OsobaID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public DateTime DatumRodjenja { get; set; }

    }
    public class LekarDTO : OsobaDTO
    {
        public string Specijalizacija { get; set; }

        //public UstanovaDTO Ustanova { get; set; }
        public string Ordinacija { get; set; }
        public int BrFaksimila { get; set; }
    }

    public class PacijentDTO : OsobaDTO
    {
        public string ImeOca { get; set; }
        public string ImeMajke { get; set; }
        public int LBO { get; set; }
    }
    public class PregledEntityDTO
    {
        public int ID { get; set; }

        public DateTime Datum { get; set; }

    }
    public class VakcinaDTO
    {
        public int VakcinaID { get; set; }
        public string ImeVakcine { get; set; }

        //if trajanje==null then neograniceno else dani
        public int Trajanje { get; set; }
        public DateTime DatumVakcinacije { get; set; }
    }
    public class SlikaDTO
    {
        public int SlikaID { get; set; }

        public string ImagePath { get; set; }

        public DateTime Datum { get; set; }

        public string TipSlike { get; set; }
    }

    public class AlergoloskeProbeDTO : SlikaDTO
    {

    }

    public class LaboratorijaDTO : SlikaDTO
    {

    }
    public class SpirometrijaDTO : SlikaDTO
    {

    }
    public class UputDTO : SlikaDTO
    {

    }

    public class SnimakDTO : SlikaDTO
    {
        public string DeoTela { get; set; }
    }
}

