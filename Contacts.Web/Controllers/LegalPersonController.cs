using Contacts.AppService;
using Contacts.AppService.Models;
using System;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class LegalPersonController : Controller
    {
        private readonly ILegalPersonAppService legalPersonAppService;
        public LegalPersonController(ILegalPersonAppService legalPersonAppService)
        {
            this.legalPersonAppService = legalPersonAppService ?? throw new ArgumentNullException("Legal Person AppService not found!");
        }

        public ActionResult Index(long id)
        {
            var model = new LegalPersonModel();
            if (id > 0)
                model = legalPersonAppService.GetById(id);

            return View(model);
        }

        public ActionResult List()
        {
            var models = legalPersonAppService.GetAll();
            return View(models);
        }

        public ActionResult Save(LegalPersonModel model)
        {
            try
            {
                legalPersonAppService.Save(model);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
    }
}