using Microsoft.Extensions.Options;
using RecruitmentService.Dtos;
using RecruitmentService.Model;
using RecruitmentService.Options;

namespace RecruitmentService.Connectors;

public class DatabaseConnector : IDatabaseConnector
{
	private readonly AppSettings _appSettings;

	private HttpClient _client { get; set; }

	public DatabaseConnector(HttpClient client,
		IOptions<AppSettings> appSettings)
	{
		_client = client;
		_appSettings = appSettings.Value;

		var databaseServiceAddress = _appSettings.HostAddresses.DatabaseService;

		_client.BaseAddress = new Uri(databaseServiceAddress);
	}

	public async Task<ResultObject<IEnumerable<RecruitmentReadDto>>> GetRecruitmentsAsync()
	{
		var recruitments = await _client.GetFromJsonAsync<List<RecruitmentReadDto>>("/api/recruitments");

		if (recruitments is null)
		{
			return ResultObject<IEnumerable<RecruitmentReadDto>>.Failure(new Exception("No recruitments found"));
		}

		return ResultObject<IEnumerable<RecruitmentReadDto>>.Success(recruitments);
	}

	public async Task<ResultObject<RecruitmentReadDto>> GetRecruitmentAsync(int recruitmentId)
	{
		var recruitment = await _client.GetFromJsonAsync<RecruitmentReadDto>($"/api/recruitments/{recruitmentId}");

		if (recruitment is null)
		{
			return ResultObject<RecruitmentReadDto>.Failure(new Exception("No recruitment found"));
		}

		return ResultObject<RecruitmentReadDto>.Success(recruitment);
	}

	public async Task<ResultObject<RecruitmentReadDto>> CreateRecruitmentAsync(RecruitmentCreateDto recruitment)
	{
		var response = await _client.PostAsJsonAsync<RecruitmentCreateDto>($"/api/recruitments", recruitment);

		if (response is null)
		{
			return ResultObject<RecruitmentReadDto>.Failure(new Exception("No response received"));
		}

		if (!response.IsSuccessStatusCode)
		{
			return ResultObject<RecruitmentReadDto>.Failure(new Exception("Not successful response"));
		}

		RecruitmentReadDto? createdRecruitment = await response.Content.ReadFromJsonAsync<RecruitmentReadDto>();

		return ResultObject<RecruitmentReadDto>.Success(createdRecruitment!);
	}

	public async Task<ResultObject<RecruitmentReadDto>> UpdateRecruitmentAsync(RecruitmentCreateDto recruitment, int recruitmentId)
	{
		var response = await _client.PutAsJsonAsync<RecruitmentCreateDto>($"/api/recruitments/{recruitmentId}", recruitment);

		if (response is null)
		{
			return ResultObject<RecruitmentReadDto>.Failure(new Exception("No response received"));
		}

		if (!response.IsSuccessStatusCode)
		{
			return ResultObject<RecruitmentReadDto>.Failure(new Exception("Not successful response"));
		}

		RecruitmentReadDto? updatedRecruitment = await response.Content.ReadFromJsonAsync<RecruitmentReadDto>();

		return ResultObject<RecruitmentReadDto>.Success(updatedRecruitment!);
	}

	public async Task<ResultObject<RecruitmentReadDto>> DeleteRecruitmentAsync(int recruitmentId)
	{
		var deletedRecruitment = await _client.DeleteFromJsonAsync<RecruitmentReadDto>($"/api/recruitments/{recruitmentId}");

		if (deletedRecruitment is null)
		{
			return ResultObject<RecruitmentReadDto>.Failure(new Exception("Recruitment was not deleted"));
		}

		return ResultObject<RecruitmentReadDto>.Success(deletedRecruitment);
	}
}
