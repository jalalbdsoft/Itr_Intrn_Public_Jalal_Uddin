using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CustomisableFormsApp.Utility
{
    public class SalesforceService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<SalesforceService> _logger;
        private readonly IConfiguration _configuration;

        // Constructor with dependencies
        public SalesforceService(HttpClient httpClient, ILogger<SalesforceService> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task<string> Authenticate()
        {
            try
            {
                var salesforceConfig = _configuration.GetSection("Salesforce");

                var clientId = _configuration["Salesforce:ClientId"];
                var clientSecret = _configuration["Salesforce:ClientSecret"];
                var username = _configuration["Salesforce:Username"];
                var password = _configuration["Salesforce:Password"] + _configuration["Salesforce:SecurityToken"];

                var ApiUrl = "https://dhrupaditechnoconsortiumltd-dev-ed.develop.my.salesforce.com/services/oauth2/token?grant_type=password&client_id=" + clientId + "&client_secret=" + clientSecret + "&username=" + username + "&password=" + password + "";

                var response = await _httpClient.PostAsync(ApiUrl, default);
                response.EnsureSuccessStatusCode();
                var responseString = await response.Content.ReadAsStringAsync();
                var authData = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseString);

                return authData["access_token"];
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace + ex.Message);
                _logger.LogError(ex.StackTrace + ex.Message);
                throw;
            }
        }

        public async Task<bool> CreateAccount(string name, string contactNumber, string accessToken)
        {
            try
            {                
                var accountData = new
                {
                    Name = name,
                    Phone = contactNumber
                };
                var jsonContent = JsonConvert.SerializeObject(accountData);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                var response = await _httpClient.PostAsync("https://dhrupaditechnoconsortiumltd-dev-ed.develop.my.salesforce.com/services/data/v62.0/sobjects/Account", content);

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.StackTrace + ex.Message);
                _logger.LogError(ex.StackTrace + ex.Message);
                throw;
            }
        }
    }
}
