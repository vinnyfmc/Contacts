using Contacts.AppService;
using Contacts.AppService.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class LegalPersonController : BaseController
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
                if (ModelState.IsValid)
                {
                    legalPersonAppService.Save(model);
                    return GetJsonSimpleSuccess();
                }
                else
                    return GetJsonErrorFromModalState();
            }
            catch (Exception ex)
            {
                var errors = new List<string>();
                errors.Add("You can not save this person!");
                errors.Add(ex.Message);
                return GetJsonSimpleErrorToSwal(errors);
            }
        }
    }
}