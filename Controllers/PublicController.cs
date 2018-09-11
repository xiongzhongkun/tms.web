using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tms.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tms.Controllers
{
    public class PublicController : Controller
    {
        BaseRepository<Pcctv> RepPcctv = new BaseRepository<Pcctv>();

        public JsonResult GetCityByID(string id){
            Msg res = new Msg();
            try
            {
                res.data = RepPcctv.List(w => w.Pid == id);
                res.flag = true;
            }
            catch
            {
                
            }
            return Json(res);
        }
    }
}
