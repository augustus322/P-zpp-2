using DatabaseService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecruitmentService.Controllers;

[Route("[controller]")]
[ApiController]
public class SalaryServiceController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    const string baseAddress = "DatabaseService";

    public SalaryServiceController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<string> GetRecruitments()
    {
        var targetService = baseAddress + "/SalaryController/GetAll";

        var httpclient = _httpClientFactory.CreateClient();
        var response = await httpclient.GetAsync(targetService);
        var result = await response.Content.ReadAsStringAsync();

        return result;
    }

    // dodanie nowego
    [HttpPost]
    public async Task<ActionResult> PostRecruitment([FromBody] HttpContent data)
    {
        var targetService = baseAddress + "/SalaryController/Add";

        var httpclient = _httpClientFactory.CreateClient();
        var response = await httpclient.PostAsync(targetService, data);

        if (response.IsSuccessStatusCode)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }

    // do zatwierdzenia/odrzucenia
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRecruitment(int id, Salary salary)
    {
        var targetService = baseAddress + "/SalaryController/Update" + id;
        var httpclient = _httpClientFactory.CreateClient();

        var content = JsonSerializer.Serialize(salary);

        var response = httpclient.PutAsync(targetService, new StringContent(content));

        if (response.IsCompleted)
        {
            return Ok();
        }
        else
        {
            return BadRequest();
        }
    }
}
