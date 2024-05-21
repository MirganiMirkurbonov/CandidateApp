using System.ComponentModel.DataAnnotations.Schema;
using Domain.Context.Base;

namespace Domain.Context.Tables;

[Table("candidate")]
public class Candidate : BaseEntity
{
    [Column("first_name")]
    public string FirstName { get; set; } = null!;
    
    [Column("last_name")]
    public string LastName { get; set; } = null!;
    
    [Column("phone_number")]
    public string? PhoneNumber { get; set; }

    [Column("start_time_interval")]
    public DateTime? StartTimeInterval { get; set; }
    
    [Column("end_time_interval")]
    public DateTime? EndTimeInterval { get; set; }
    
    [Column("email")]
    public string Email { get; set; } = null!;
    
    [Column("github_profile_url")]
    public string? GithubProfileUrl { get; set; }
    
    [Column("linkedin_profile_url")]
    public string? LinkedinProfileUrl { get; set; }
    
    [Column("comment")]
    public string Comment { get; set; } = null!;
}