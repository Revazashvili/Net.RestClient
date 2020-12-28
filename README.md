# Net.RestClient
package to send http requests 

## Instalation
Use the Nuget package manager [Nuget](https://www.nuget.org/packages/Net.RestClient/) to install net.RabbitMQ

```bash
Install-Package Net.RestClient -Version 1.0.0
```
## Usage

appsettings.json

```json
"RestClientConfiguration":{
    "BaseAddress":"https://localhost:44304/api/",
    "GetRequestUri":"WeatherForecast/GetWeather",
    "GetByIdRequestUri":"WeatherForecast/GetWeatherById",
    "PostRequestUri":"WeatherForecast/PostWeather",
    "PutRequestUri":"WeatherForecast/PutWeather",
    "DeleteRequestUri":"WeatherForecast/DeleteWeather"
}

```
DI Registration

```csharp
var config = _configuration.GetSection("RestClientConfiguration").Get<RestClientConfiguration>();
services.AddRestClient(config);
```

Example Code 
```csharp

public class WeatherService
    {
        private readonly IRestClient _restClient;

        public WeatherService(IRestClient restClient)
        {
            _restClient = restClient;
        }
        
        public async void GetWeathers()
        {
            // Need Response Type
            var response =  await _restClient.GetAsync<IEnumerable<Weather>>();
            if (response.Succeeded)
            {
                foreach (var item in response.Data)
                {
                    Console.WriteLine(item); 
                }
            }
            else
            {
                Console.WriteLine(response.ErrorMessage.First());
            }
        }
        
        public async void GetWeatherById(int id)
        {
            // Need Type that will be sent : int and Type to return : Weather
            var response = await _restClient.GetAsync<int,Weather>(id);
            if (response.Succeeded)
            {
                Console.WriteLine(response.Data);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage.First());
            }
        }

        public async void PostWeather(Weather weather)
        {
            // Need Type that will be sent : Weather and Type to return : int
            var response = await _restClient.PostAsync<Weather,int>(weather);
            if (response.Succeeded)
            {
                Console.WriteLine(response.Data);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage.First());
            }
        }
        
        public async void PutWeather(Weather weather)
        {
            // Need Type that will be sent : Weather and Type to return : int
            var response = await _restClient.PutAsync<Weather,int>(weather);
            if (response.Succeeded)
            {
                Console.WriteLine(response.Data);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage.First());
            }
        }
        
        public async void DeleteWeather(int id)
        {
            // Need Type that will be sent : int
            var response = await _restClient.DeleteAsync<int>(id);
            if (response.Succeeded)
            {
                Console.WriteLine(response.Data);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage.First());
            }
        }
    }

```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
