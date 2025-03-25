namespace Management.Service.Dtos;
public class CreatePositionRequest
{
  public int PositionNumber { get; set; }
  public string Title { get; set; } = string.Empty;
  public decimal Budget { get; set; }
  public int RecruiterId { get; set; }
  public int DepartmentId { get; set; }
}