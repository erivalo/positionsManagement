namespace Management.Service.Dtos;
public record CreatePositionRequest(int PositionNumber, string Title, decimal Budget, int RecruiterId, int DepartmentId);