using DAY1;

namespace DAY3.Interfaces
{
    public interface IOpenWeather
    {
        public OpenWeatherClass GetWeather(float longitude, float latitude);
    }
}
