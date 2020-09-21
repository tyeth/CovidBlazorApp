using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CovidBlazorApp.Shared
{
    public static class CovidStatic
    {

         public static async Task<List<CovidTimeStep>> GetCountryDailyDataByStatus(string country,string status) {
            return await GetCountryDailyDataByStatus(APIUrls.GetCountryDailyCases().Replace("*", country).Replace("#", status));
        }
            public static async Task<List<CovidTimeStep>> GetCountryDailyDataByStatus(string url)
            {
            var outputList = new List<CovidTimeStep>();
            var json = await new HttpClient().GetFromJsonAsync<List<RestCountry>>(new Uri(url));

            foreach (var c in json)
            {
                var timestep = new CovidTimeStep()
                {
                    Cases = c.Cases,
                    Country = c.Country,
                    CountryCode = c.CountryCode,
                    Date = Convert.ToDateTime(c.Date),
                    Province = c.Province,
                    Status = c.Status
                };
                outputList.Add(timestep);
            }
            return outputList;
        }
    }
    public class RestCountry
    {
         public string Country { get; set; } 
        public string CountryCode { get; set; } 
        public string Province { get; set; } 
        public string City { get; set; } 
        public string CityCode { get; set; } 
        public string Lat { get; set; } 
        public string Lon { get; set; } 
        public int Cases { get; set; } 
        public string Status { get; set; } 
        public DateTime Date { get; set; } 

    }

    public class CovidTimeStep
    {
        public Int32 Cases { get; internal set; }
        public string Country { get; internal set; }
        public string CountryCode { get; internal set; }
        public System.DateTime Date { get; internal set; }
        public string Province { get; internal set; }
        public string Status { get; internal set; }
    }

    public class CountryComparisonInformation
    {
        public string Name { get; set; }
        public int Population { get; set; }
        public int ConfirmedCases { get; set; }

        public List<CovidTimeStep> DeathTimeSteps { get; set; }
        public List<CovidTimeStep> ConfirmedTimeSteps { get; set; }
        public List<CovidTimeStep> DeathPer100kTimeSteps { get; set; }
        
    }


    public class ComboCountry
    {
        public string code { get; set; }
        public string name { get; set; }
    }

    public class APICountry
    {
        public string ISO2 { get; set; }
        public string Country { get; set; }
        public string Slug { get; set; }
    }
}
