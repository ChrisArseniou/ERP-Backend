using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

public class TokenService
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<string> FetchAccessTokenAsync()
    {
        var clientId = _configuration["VivaPayments:ClientId"];
        var clientSecret = _configuration["VivaPayments:ClientSecret"];
        var url = "https://demo-accounts.vivapayments.com/connect/token";

        var credentials = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}"));

        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Headers = { { "Authorization", $"Basic {credentials}" } },
            Content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("grant_type", "client_credentials") })
        };

        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        // Deserialize the string into a Dictionary<string, string>
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
        if (dictionary != null && dictionary.ContainsKey("access_token"))
        {
            return dictionary["access_token"].ToString();
        }
        else
        {
            return string.Empty;
        }

    }
}
