using Contacts.AppService;
using Contacts.AppService.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class NaturalPersonController : BaseController
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
                if (ModelState.IsValid)
                {
                    naturalPersonAppService.Save(model);
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