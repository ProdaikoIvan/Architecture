using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class TemplateEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        public DateTime? DateTime { get; set; }
        public bool IsActive { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}