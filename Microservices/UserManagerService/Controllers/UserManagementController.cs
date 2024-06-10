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

    [HttpGet("{id}")]
    public async Task<Employee> GetUser(int id)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var response = await httpClient.GetAsync(baseAddress + "/EmployeeController/GetById?id=" + id);

        var user = JsonConvert.DeserializeObject<Employee>(response.Content.ToString());
        return user;
    }

    [HttpPost]
    public void AddUser([FromBody] HttpContent data)
    {
        var httpClient = _httpClientFactory.CreateClient();

        httpClient.PostAsync(baseAddress + "/EmployeeController/Add", data);
    }

    [HttpPut("{id}")]
    public void EditUser([FromBody] Employee employee)
    {
        var httpClient = _httpClientFactory.CreateClient();
        var content = System.Text.Json.JsonSerializer.Serialize(employee);
        httpClient.PutAsync(baseAddress + "/EmployeeController/Add", new StringContent(content));
    }

    [HttpDelete("{id}")]
    public void DeleteUser()
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DeleteAsync(baseAddress + "/EmployeeController/GetAll");
    }
}
