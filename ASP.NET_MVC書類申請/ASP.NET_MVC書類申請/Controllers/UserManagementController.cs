using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC追加機能.Models;

namespace ASP.NET_MVC追加機能.Controllers
{
    public class UserManagementController : Controller
    {
        //
        // GET: /UserManagement/
        public ActionResult Index()
        {
            return View("UserManage");
        }
        [HttpPost]
        public ActionResult Find(string 表示区分)
        {
            
            UserManagementModel usermanagementModel = new UserManagementModel();
            if (Session["ユーザー検索"] != null)
            {
                usermanagementModel = (UserManagementModel)Session["ユーザー検索"];
            }
            else
            {
                usermanagementModel.ソート順 = "▲";
                usermanagementModel.ソート列 = "氏名";
            }

            usermanagementModel.Find(表示区分);
            Session["ユーザー検索"] = usermanagementModel;
            return PartialView("_UserManageList", usermanagementModel);
        }
        [HttpPost]
        public ActionResult Getpage(int rowCount, int pageNum)
        {
            UserManagementModel usermanagementModel = (UserManagementModel)Session["ユーザー検索"];
            usermanagementModel.GetPage(rowCount, pageNum);
            return PartialView("_UserManageList", usermanagementModel);
        }
        [HttpPost]
        public ActionResult Sort(string colName, string sortOrder)
        {
            UserManagementModel usermanagementModel = (UserManagementModel)Session["ユーザー検索"];
            usermanagementModel.Sort(colName, sortOrder);
            return PartialView("_UserManageList", usermanagementModel);
        }


	}
}