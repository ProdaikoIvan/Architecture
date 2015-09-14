using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Extensions.Pager;
using ViewModels.Entities;

namespace BLL.IService
{
    public interface ITemplateService
    {
        Task<IPagedList<TemplateEntityViewModel>> GetAsync(int? page, int pageSize);
        Task<IEnumerable<SelectListItem>> GetCountriesDropdownAsync();
        Task<TemplateEntityViewModel> GetByIdAsync(int id);
        Task<bool> AddOrUpdateAsync(TemplateEntityViewModel template);
        Task<bool> DeleteAsync(int id);
    }
}