using System.Threading.Tasks;
using System.Web.Mvc;
using BLL.IService;
using ViewModels.Entities;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITemplateService _templateService;

        public HomeController(ITemplateService templateService)
        {
            _templateService = templateService;
        }

        public async Task<ActionResult> Index(int? page)
        {
            var model = await _templateService.GetWithPagingAsync(page, 3);
            return View(model);
        }

        public async Task<ActionResult> AddOrUpdate(int id = 0)
        {
            var model = new TemplateEntityViewModel();

            if (id != 0)
            {
                model = await _templateService.GetByIdAsync(id);
                return View("AddOrUpdate", model);
            }

            model.CountriesDdl = await _templateService.GetCountriesDropdownAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> AddOrUpdate(TemplateEntityViewModel templateEntity)
        {
            if (ModelState.IsValid)
            {
                await _templateService.AddOrUpdateAsync(templateEntity);
                return RedirectToAction("Index");
            }
            templateEntity.CountriesDdl = await _templateService.GetCountriesDropdownAsync();
            return View(templateEntity);
        }

        public async Task<ActionResult> Delete(int id)
        {
            await _templateService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}