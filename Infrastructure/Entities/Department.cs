using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

#nullable disable
public class Department : TrackingData
{
    [Key]
    public int Id { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    [MaxLength(300)]
    public string Description { get; set; }
}