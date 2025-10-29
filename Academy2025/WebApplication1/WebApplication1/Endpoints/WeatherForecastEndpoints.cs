namespace WebApplication1.Endpoints
{
    public static class WeatherForecastEndpoints
    {
        static readonly string[] summaries = new[]
{
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
        public static void MapWeatherForecastEndpoints(this IEndpointRouteBuilder app)
        {
            var endpoints = app.MapGroup("/weatherforecast");

            endpoints.MapGet("/", Get);
        }

        static WeatherForecast[] Get()
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                    new WeatherForecast
                    {
                        Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = summaries[Random.Shared.Next(summaries.Length)]
                    })
                    .ToArray();
            return forecast;
        }
    }
}
