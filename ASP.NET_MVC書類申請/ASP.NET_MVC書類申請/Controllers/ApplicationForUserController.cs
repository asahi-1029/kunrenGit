using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC追加機能.Models;

namespace ASP.NET_MVC追加機能.Controllers
{
    public class ApplicationForUserController : Controller
    {
        //
        // GET: /ApplicationForUser/
        public ActionResult Index()
        {
            return View("ApplicationManage");
        }
        [HttpPost]
        public ActionResult Find(ApplicationInfoConditionModel condition)
        {
        ApplicationInfoModel ApplicationinfoModel = new ApplicationInfoModel();

        ApplicationinfoModel.Find(condition.状態);
        return PartialView("_ApplicationList", ApplicationinfoModel);
        }
	}
}