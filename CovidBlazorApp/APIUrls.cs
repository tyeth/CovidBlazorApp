namespace CovidBlazorApp
{
    public static class APIUrls
    {
        public static string GetCountryPopulationDataUrl()
        {
            return "https://restcountries.eu/rest/v2/alpha/*";
        }

        public static string GetCountryDailyCases() => "https://api.covid19api.com/country/*/status/#";

        public static string GetCountryList()
        {
            return "https://api.covid19api.com/countries";
        }
    }
}
