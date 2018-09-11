using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tms.Controllers
{
    public class AccountListViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            ViewBag.gpsuserid = id;
            return View();
        }
    }
}
