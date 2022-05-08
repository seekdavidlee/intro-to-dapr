using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace DaprApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly ILogger<WeatherForecastController> _logger;
		private readonly DaprClient _daprClient;
		private readonly IConfiguration _configuration;

		public WeatherForecastController(
			ILogger<WeatherForecastController> logger,
			DaprClient daprClient,
			IConfiguration configuration)
		{
			_logger = logger;
			_daprClient = daprClient;
			_configuration = configuration;
		}

		[HttpPut(Name = "AddWeatherForecast")]
		public async Task Put(WeatherForecast weatherForecast)
		{
			_logger.LogDebug("Invoked AddWeatherForecast API");

			await _daprClient.PublishEventAsync(
				_configuration["PubsubName"],
				_configuration["PubsubTopic"],
				weatherForecast);
		}
	}
}