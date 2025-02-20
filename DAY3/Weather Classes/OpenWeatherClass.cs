using DAY3.Interfaces;

namespace DAY1
{
    public class OpenWeatherClass : IOpenWeather
    {
        public string? Country { get; set; }
        public string? Station { get; set; }
       
        public OpenWeatherClass GetWeather(float longitude, float latitude)
        {
            if (!OpenWeather.StationDictionary.TryGetClosestStation(latitude, longitude, out var stationInfo))
            {
                Console.WriteLine("Could not find a station.");
                return null;
            }

            var openWeatherClass = new OpenWeatherClass
            {
                Station = stationInfo.Name,
                Country = stationInfo.Country
            };

            if (openWeatherClass.Station != "AHMADABAD")
            {
                Console.WriteLine("ENTER VALID COORDINATES");
                return null;
            }
            return openWeatherClass;
        }
    }
}
