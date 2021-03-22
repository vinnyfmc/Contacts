using Contacts.AppService;
using Contacts.AppService.Models;
using System;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class NaturalPersonController : Controller
    {
        private readonly INaturalPersonAppService naturalPersonAppService;
        public NaturalPersonController(INaturalPersonAppService naturalPersonAppService)
        {
            this.naturalPersonAppService = naturalPersonAppService ?? throw new ArgumentNullException("Natural Person AppService not found!");
        }

        public ActionResult Index(long id)
        {
            var model = new NaturalPersonModel();
            if(id > 0)
                model = naturalPersonAppService.GetById(id);

            return View(model);
        }

        public ActionResult List()
        {
            var models = naturalPersonAppService.GetAll();
            return View(models);
        }

        public ActionResult Save(NaturalPersonModel model)
        {
            try
            {
                naturalPersonAppService.Save(model);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
    }
}