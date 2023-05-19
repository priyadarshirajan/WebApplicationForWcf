using Microsoft.AspNetCore.Mvc;
using Test.Service.Wcf;
using WCFClientTest;

namespace WebApplicationForWcf.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        Service1Client _client;
        TestServiceClient _testServiceClient;

        public WeatherForecastController(Service1Client client, TestServiceClient testServiceClient)
        {
            this._client = client;
            this._testServiceClient = testServiceClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int value)
        {
            _client.ClientCredentials.UserName.UserName = "ytyt";
            _client.ClientCredentials.UserName.Password = "ytyt";
            var result = await _client.GetDataAsync(value);
            return Ok(result);
        }

        [HttpGet("{a}/{b}")]
        public async Task<IActionResult> Data(int a, int b)
        {
            var result = await _client.AddNumbersAsync(a, b);
            return Ok(result);
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetSecondClientValue()
        {
            var result = await _testServiceClient.DoWorkAsync();
            return Ok(result);
        }
    }
}