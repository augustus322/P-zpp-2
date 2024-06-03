using DatabaseService.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace UserManagerService.Controllers;

[ApiController]
[Route("[controller]")]
public class UserManagementController : ControllerBase
{
    const string baseAddress = "DatabaseService";

    private readonly IHttpClientFactory _httpClientFactory;

    public UserManagementController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IQueryable<Employee>> GetUsers()
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(baseAddress+"/EmployeeController/GetAll");

        var list = JsonConvert.DeserializeObject<IQueryable<Employee>>(response.Content.ToString());
        return list;
    }

    [HttpPost]
    public void AddUser([FromBody] HttpContent content)
    {
        
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.PostAsync(baseAddress + "/EmployeeController/Add", content);
    }

    [HttpPut("{id}")]
    public void EditUser([FromBody] HttpContent content)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.PutAsync(baseAddress + "/EmployeeController/Add", content);
    }

    [HttpDelete("{id}")]
    public void DeleteUser()
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DeleteAsync(baseAddress + "/EmployeeController/GetAll");
    }
}
