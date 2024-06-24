using RecruitmentService.Dtos;
using RecruitmentService.Model;

namespace RecruitmentService.Connectors;
public interface IDatabaseConnector
{
	Task<ResultObject<IEnumerable<RecruitmentReadDto>>> GetRecruitmentsAsync();
	Task<ResultObject<RecruitmentReadDto>> GetRecruitmentAsync(int recruitmentId);
	Task<ResultObject<RecruitmentReadDto>> CreateRecruitmentAsync(RecruitmentCreateDto recruitment);
	Task<ResultObject<RecruitmentReadDto>> UpdateRecruitmentAsync(RecruitmentCreateDto recruitment, int recruitmentId);
	Task<ResultObject<RecruitmentReadDto>> DeleteRecruitmentAsync(int recruitmentId);
}