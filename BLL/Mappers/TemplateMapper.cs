using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DAL.Models;
using ViewModels.Entities;

namespace BLL.Mappers
{
    public static class TemplateMapper
    {
        public static TemplateEntityViewModel ToViewModel(this TemplateEntity templateEntity, IEnumerable<SelectListItem> countriesDdl)
        {
            return new TemplateEntityViewModel
            {
                Id = templateEntity.Id,
                DateTime = templateEntity.DateTime,
                Name = templateEntity.Name,
                IsActive = templateEntity.IsActive,
                CountryId = templateEntity.Country.Id,
                CountriesDdl = countriesDdl
            };
        }

        public static IEnumerable<TemplateEntityViewModel> ToViewModel(this IEnumerable<TemplateEntity> templateEntity)
        {
            return templateEntity.Select(entity => new TemplateEntityViewModel
            {
                Id = entity.Id,
                DateTime = entity.DateTime,
                Name = entity.Name,
                IsActive = entity.IsActive,
                Country = entity.Country
            }).ToList();
        }

        public static TemplateEntity ToModel(this TemplateEntityViewModel templateEntity)
        {
            return new TemplateEntity
            {
                Id = templateEntity.Id,
                Name = templateEntity.Name,
                DateTime = templateEntity.DateTime,
                IsActive = templateEntity.IsActive,
                CountryId = templateEntity.CountryId
            };
        }
    }
}