using DatabaseService.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RecruitmentService.Controllers;

[Route("[controller]")]
[ApiController]
public class RecruitmentController : ControllerBase
{
    private readonly IHttpClientFactory _httpClientFactory;

    const string baseAddress = "DatabaseService";

    public RecruitmentController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<string> GetRecruitments()
    {
        var targetService = baseAddress + "/RecruitmentController/GetAll";

        var httpclient = _httpClientFactory.CreateClient();
        var response = await httpclient.GetAsync(targetService);
        var result = await response.Content.ReadAsStringAsync();

        return result;
    }

    [HttpPost]
    public async Task<ActionResult> PostRecruitment([FromBody] HttpContent data)
    {
        var targetService = baseAddress + "/RecruitmentController/Add";

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

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateRecruitment(int id, Recruitment recruitment)
    {
        var targetService = baseAddress + "/RecruitmentController/Update" + id;
        var httpclient = _httpClientFactory.CreateClient();

        var content = JsonSerializer.Serialize(recruitment);

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
