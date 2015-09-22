using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.IService;
using BLL.Mappers;
using DAL.Models;
using DAL.UnitOfWork;
using Extensions.Pager;
using Extensions.WebExtensions;
using ViewModels.Entities;

namespace BLL.Service
{
    public class TemplateService : ITemplateService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TemplateService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IPagedList<TemplateEntityViewModel>> GetAsync(int? page, int pageSize)
        {
            var currentPageIndex = page - 1 ?? 0;
            var templateEntities = await _unitOfWork.Repository<TemplateEntity>().GetAsync(orderBy: x => x.OrderBy(o => o.Name).Skip(currentPageIndex * 3).Take(pageSize), includeProperties: x => x.Country);
            var entity = await templateEntities.ToViewModelAsync();
            var count = await _unitOfWork.Repository<TemplateEntity>().CountAsync();

            return count > pageSize ? entity.ToPagedList(currentPageIndex, pageSize, count) : entity.ToPagedList();
        }

        public async Task<TemplateEntityViewModel> GetByIdAsync(int id)
        {
            var templateEntity = await _unitOfWork.Repository<TemplateEntity>().GetByIdAsync(id);
            var countriesDdl = await GetCountriesDropdownAsync();

            return templateEntity.ToViewModel(countriesDdl);
        }

        public async Task<IEnumerable<SelectListItem>> GetCountriesDropdownAsync()
        {
            var countries = await _unitOfWork.Repository<Country>().GetAsync(orderBy: x => x.OrderBy(o => o.Name));
            return await countries.ToSelectListAsync(x => x.Name, x => x.Id.ToString());
        }

        public async Task<bool> AddOrUpdateAsync(TemplateEntityViewModel template)
        {
            try
            {
                await _unitOfWork.Repository<TemplateEntity>().AddOrUpdateAsync(template.ToModel());
                await _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                await _unitOfWork.Repository<TemplateEntity>().DeleteAsync(id);
                await _unitOfWork.Commit();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}