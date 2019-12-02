using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EKartonWebApp
{
        public class eKartonAPI
        {
            private string _apiBaseURI = "http://localhost:27017/api";
            public HttpClient InitializeClient()
            {
                var client = new HttpClient();
                //Passing service base url  
                client.BaseAddress = new Uri(_apiBaseURI);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                return client;

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

    public class AlergenDTO
    {
        public int AlergenID { get; set; }
        public string ImeAlergena { get; set; }
        public bool Alergican { get; set; }
    }
    public class KartonAlergenaDTO
    {
        public int KartonAlergenaID { get; set; }
        public ICollection<AlergenDTO> AlergeniLista { get; set; }
        public ICollection<Lek> LekoviLista { get; set; }
    }
    public class KartonVakcinacijeDTO
    {
        public int KartonVakcinacijeID { get; set; }
        public ICollection<VakcinaDTO> VakcineLista { get; set; }
    }
    public class Lek
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
        public int GodineRadnogStaza { get; set; }
        public string Ustanova { get; set; }
        public string Ordinacija { get; set; }
        public int BrFaksimila { get; set; }
    }

    public class PacijentDTO : OsobaDTO
    {
        public string ImeOca { get; set; }
        public string ImeMajke { get; set; }
        public string KrvnaGrupa { get; set; }
        public int Tezina { get; set; }
        public int Visina { get; set; }
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

