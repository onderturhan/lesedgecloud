using Microsoft.AspNetCore.Mvc;

namespace EdgeCloud.LES.API.TestDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get([FromBody] FileRequest requestData)
        {

            var decodedData = requestData.RequestData.ToBase64Decode();
            var testClass = System.Text.Json.JsonSerializer.Deserialize<TestClass>(decodedData);




            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
    public class TestClass
    {
        public string RequestXml { get; set; }
        public string ResponseXml { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    public static class Base64Helper
    {
        public static string ToBase64Encode(this string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string ToBase64Decode(this string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
    public class FileRequest : RequestBase
    {
        public string RequestData { get; set; } = string.Empty;
        public string ServiceType { get; set; } = string.Empty;
        public UserAPIServiceType EnumServiceType
        {
            get
            {
                Enum.TryParse(ServiceType, true, out UserAPIServiceType value);
                return value;
            }
        }
    }
    public class RequestBase
    {
        public string TokenData { get; set; } = string.Empty;
    }
    public enum UserAPIServiceType
    {
        Interaction,
        Network,
        Authentication,
        ApiRequest
    }
}