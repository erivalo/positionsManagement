namespace Management.Service.Models;
internal class Position
{
  public int Id { get; set; }
  public int PositionNumber { get; set; }
  public string Title { get; set; } = string.Empty;
  public decimal Budget { get; set; }
  public required int PositionStatusId { get; set; }
  public PositionStatus? PositionStatus { get; set; }
  public required int RecruiterId { get; set; }
  public Recruiter? Recruiter { get; set; }
  public required int DepartmentId { get; set; }
  public Department? Department { get; set; }

}