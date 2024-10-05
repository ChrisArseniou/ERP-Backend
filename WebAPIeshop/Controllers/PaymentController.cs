using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class VivaController : ControllerBase
{
    private readonly TokenService _tokenService;
    private readonly OrderService _orderService;

    public VivaController(TokenService tokenService, OrderService orderService)
    {
        _tokenService = tokenService;
        _orderService = orderService;
    }

    [HttpPost("getAccessToken")]
    public async Task<IActionResult> GetAccessToken()
    {
        try
        {
            var token = await _tokenService.FetchAccessTokenAsync();
            return Ok(new { access_token = token });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPost("createOrder")]
    public async Task<IActionResult> CreateOrder([FromBody] object orderData)
    {
        try
        {
            var orderResponse = await _orderService.CreateOrderAsync(orderData);
            return Ok(orderResponse);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}
