using MyCode.Model;
using MyCode.Model.SearchModel;
using MyCode.Service;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyCode.Web.Controllers
{
    public class UserInfoController : Controller
    {
        private UserInfoService _UserInfoService = new UserInfoService();
        // GET: UserInfo
        public ActionResult Index(UserInfoSearch userInfoSearch,int? page)
        {
            int pageIndex = page ?? 1;
            int totalCount = 0;
           var dd= System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"];
            IEnumerable<UserInfo> list= _UserInfoService.GetPagedList(userInfoSearch, out totalCount);
            ViewBag.List = list.ToPagedList(1, 10);
            //var usersAsIPagedList = new StaticPagedList<UserInfo>(list, pageIndex, 10, totalCount);

            return View(userInfoSearch);
        }
    }
}