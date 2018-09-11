using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using tms.Common;
using tms.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tms.Controllers
{
    public class LoginController : Controller
    {
        BaseRepository<UserAccount> RepUserAccount=new BaseRepository<UserAccount>();

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult doLogin(string userName, string pwd)
        {
            try
            {
                pwd=Utils.GetMD5(pwd);
                var datasource = RepUserAccount.List(w => w.Account == userName && w.Pwd == pwd);
                if (datasource.Count() > 0)
                {
                    UserAccount model = datasource.First();
                    if (model != null && !string.IsNullOrEmpty(model.Id))
                    {
                        HttpContext.Session.SetString("abc","1");
                        Common.SessionExtensions.Set<UserAccount>(HttpContext.Session,Keys.ADMINUSERINFO,model);
                        HttpContext.Session.SetString(Keys.ADMINUSERNAME,model.Account);
                        return RedirectToAction("Index", "Home");
                    }
                }
                
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }


        #region 用户注销
        public IActionResult LogOut()
        {
            Common.SessionExtensions.Set<UserAccount>(HttpContext.Session,Keys.ADMINUSERINFO,new UserAccount());
            HttpContext.Session.Set(Keys.ADMINUSERNAME,"");
            return RedirectToAction("Index");
        }
        #endregion
    }
}
