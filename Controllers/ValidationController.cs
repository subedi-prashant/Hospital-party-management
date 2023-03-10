using CareLab.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CareLab.Models;

namespace CareLab.Controllers
{
    public class ValidationController : Controller
    {
        DAL db = new DAL();
        public JsonResult IsCodenoAvailable(int Codeno)
        {
            var user = db.GetDataList().FirstOrDefault(x => x.Codeno == Codeno);
            // Check if the userId is already in use
            if (user != null)
            {
                return Json(string.Format("The Codeno '{0}' is already in use by {1}.", Codeno, user.Name), JsonRequestBehavior.AllowGet);
            }
            //bool isCodenoAvailable = !db.GetDataList().Any(x => x.Codeno == Codeno);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        //return Json(isCodeNoAvailable, JsonRequestBehavior.AllowGet);
        //This line returns the result of the remote validation as a JSON object.
        //The first parameter is the value of isCodeNoAvailable, which is true if the codeno is available and false if it's not.
        //The second parameter, JsonRequestBehavior.AllowGet, specifies that the remote validation method can be called using an HTTP GET request.
        //This is necessary because remote validation is typically called from client-side code, which uses an AJAX request to check the validation status of a field.
    }
}

