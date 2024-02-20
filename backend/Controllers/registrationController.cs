

using Microsoft.AspNetCore.Mvc;
using RestSharp;

[Route("api/[controller]")]
[ApiController]
public class RegistrationController : ControllerBase
{
    private readonly string elasticEmailApiKey = "718BED00E5AEB6E524AF6A3885437FDB73DF89C8B2643D47BFB690A7FFF6701ABEAEFFB98172F68204BF128977359C26";

    [HttpPost]
    public IActionResult RegisterUser([FromBody] backend.Models.UserRegistrationModel model)
    {
  
        var client = new RestClient("https://api.elasticemail.com");
        var request = new RestRequest("/v2/email/send", Method.Post);
        request.AddParameter("apikey", elasticEmailApiKey);
        request.AddParameter("from", "mrahulmaity623@gmail.com");
        request.AddParameter("to", model.Email);
        request.AddParameter("subject", "Welcome to Our Website");
        request.AddParameter("bodyHtml", "<p>Thank you for registering!</p>");
        var response = client.Execute(request);
        if (response.IsSuccessful)
        {
            return Ok("User registered successfully and email sent.");
        }
        else
        {
            //  email sending failure
            return StatusCode(500, "Failed to send email.");
        }
    }
}