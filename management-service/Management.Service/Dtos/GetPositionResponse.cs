namespace Management.Service.Dtos;
public record GetPositionResponse(int Id, string Title, decimal Budget, int RecruiterId, int DepartmentId, int StatusId, int PositionNumber);