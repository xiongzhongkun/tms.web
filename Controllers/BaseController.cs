
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using tms.Common;
using tms.Models;

namespace tms.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var abc = HttpContext.Session.GetString("abc");
            //判断管理员是否登录
            if (!IsAdminLogin(context))
            {
                context.HttpContext.Response.Redirect(Url.Action("Index", "Login"), true);
                return;
            }
        }

        #region 管理员


        /// <summary>
        /// 判断管理员是否已经登录(解决Session超时问题)
        /// </summary>
        public bool IsAdminLogin(ActionExecutingContext filterContext)
        {

            try
            {
                //如果Session为Null
                if (HttpContext.Session.GetString(Keys.ADMINUSERNAME) !=null || Common.SessionExtensions.Get<UserAccount>(HttpContext.Session,Keys.ADMINUSERINFO) != null)
                {
                    return true;
                }
                // else
                // {
                    
                //     //检查Cookies
                //     string adminname = Utils.GetCookie(Keys.ADMINUSERNAME);
                //     string adminpwd = Utils.GetCookie(Keys.ADMINUSERPWD);
                //     if (adminname != "" && adminpwd != "")
                //     {
                //         BaseRepository<UserAccount> _repSysAdmUser = new BaseRepository<UserAccount>();
                //         UserAccount model = _repSysAdmUser.GetFirst(w => w.Account.Equals(adminname) && w.Pwd.Equals(adminpwd));
                //         if (model != null && HttpContext != null && HttpContext.Session != null)
                //         {
                //             filterContext.HttpContext.Session[Keys.ADMINUSERNAME] = model.Account;
                //             filterContext.HttpContext.Session[Keys.ADMINUSERINFO] = model;
                           
                //             return true;
                //         }
                //     }
                // }
            }
            catch
            {

            }
            return false;
        }

        /// <summary>
        /// 取得管理员信息
        /// </summary>
        public UserAccount GetAdminInfo()
        {
            UserAccount model = Common.SessionExtensions.Get<UserAccount>(HttpContext.Session,Keys.ADMINUSERINFO);
            if (model != null)
            {
                return model;
            }
            return null;
        }

        #endregion

        public string GetUserID()
        {
            return GetAdminInfo().Id;
        }
    }
}