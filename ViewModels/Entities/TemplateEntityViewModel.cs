using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using DAL.Models;

namespace ViewModels.Entities
{
    public class TemplateEntityViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Country")]
        public int CountryId { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy/MM/dd}")]
        public DateTime? DateTime { get; set; }

        public Country Country { get; set; }

        [DisplayName("Is active?")]
        public bool IsActive { get; set; }

        public IEnumerable<SelectListItem> CountriesDdl { get; set; }
    }
}