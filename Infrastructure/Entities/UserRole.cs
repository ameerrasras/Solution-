using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Entities;

#nullable disable

    public class UserRole : TrackingData
    {
        [Key]
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }

