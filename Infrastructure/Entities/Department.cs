using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Entities;

    #nullable disable
    public class Department : TrackingData
    {
        [Key]
        public int Id { get; set; }


        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Description { get; set; }
    }


