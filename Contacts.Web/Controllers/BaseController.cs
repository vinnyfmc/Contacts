using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string GetListErrorFromStringList(IList<string> errors)
        {
            string li = string.Empty;

            foreach (var item in errors.Distinct().ToList())
                li += string.Format("<li>{0}</li>", item);

            var ul = string.Format("<ul>{0}</ul>", li);

            return ul;
        }

        protected JsonResult GetJsonErrorFromModalState()
        {
            var erros = GetListErrorFromModalState();
            return GetJsonSimpleErrorToSwal(erros);
        }

        protected JsonResult GetJsonSimpleErrorToSwal(IList<string> errors)
        {
            var ul = GetListErrorFromStringList(errors);

            return Json(new { success = false, msg = ul });
        }

        protected List<string> GetListErrorFromModalState()
        {
            List<string> errors = new List<string>();
            foreach (var modelState in ModelState.Values)
            {
                foreach (var erro in modelState.Errors)
                {
                    errors.Add(erro.ErrorMessage);
                }
            }

            return errors;
        }
        protected JsonResult GetJsonSimpleErrorToSwal(string erro)
        {
            IList<string> errors = new List<string>();

            errors.Add(erro);

            var ul = GetListErrorFromStringList(errors);

            return Json(new { success = false, msg = ul });
        }

        protected JsonResult GetJsonSimpleSuccess(string successMsg = null)
        {
            return Json(new { success = true, msg = successMsg }, JsonRequestBehavior.AllowGet);
        }

    }
}