using System.Text;
using System.Text.Json;

public class OrderService
{
    private readonly TokenService _tokenService;

    public OrderService(TokenService tokenService)
    {
        _tokenService = tokenService;
    }

    public async Task<Dictionary<string, object>> CreateOrderAsync(object orderData)
    {
        var accessToken = await _tokenService.FetchAccessTokenAsync();
        var url = "https://demo-api.vivapayments.com/checkout/v2/orders";

        using var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Headers = { { "Authorization", $"Bearer {accessToken}" } },
            Content = new StringContent(JsonSerializer.Serialize(orderData), Encoding.UTF8, "application/json")
        };


        var response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        // Deserialize the string into a Dictionary<string, string>
        var dictionary = JsonSerializer.Deserialize<Dictionary<string, object>>(content);
        if (dictionary != null)
        {
            return dictionary;
        }
        else
        {
            return new Dictionary<string, object>();
        }
    }
}
