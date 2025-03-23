using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Management.Service.Dtos;
public class CreatePositionRequest
{
  [Required]
  public int PositionNumber { get; set; }
  [Required]
  public string Title { get; set; } = string.Empty;
  [Required]
  [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
  public decimal Budget { get; set; }

  [Required]
  public int RecruiterId { get; set; }
  [Required]
  public int DepartmentId { get; set; }
}