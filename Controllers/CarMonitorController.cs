using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tms.Common;
using tms.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tms.Controllers
{
    public class CarMonitorController : Controller
    {
        BaseRepository<GpsCharge> RepGpsCharge = new BaseRepository<GpsCharge>();
        BaseRepository<GpsEdi> RepGpsEdi = new BaseRepository<GpsEdi>();
        BaseRepository<GpsUser> RepUser = new BaseRepository<GpsUser>();
        BaseRepository<VihiclePP> RepVihiclepp = new BaseRepository<VihiclePP>();
        BaseRepository<VihicleData> RepVihicledata = new BaseRepository<VihicleData>();

        // GET: /<controller>/
        public IActionResult List(string id,string vihicle)
        {
            
            GetCarInfo(id,vihicle);
            return View();
        }

        public JsonResult GetCarPositionData(LigerGridParam param,string id,string vihicle){
            int total = 0;
            Expression<Func<VihicleData, bool>> where = w => w.GpsEdiVihicle == vihicle;
            var list = RepVihicledata.ListPage(param.pageSize, param.page, out total, where,false, o => o.EdiTimes);
            var data = new
            {
                Rows = list,
                Total = total
            };
            return Json(data);
        }

        private void GetCarInfo(string id,string vihicle){
            if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(vihicle))
            {
                var GpsUser = RepUser.Find(id);
                if (GpsUser.UserBalance > 1)
                {
                    RepGpsCharge.Add(new GpsCharge() { Id = Utils.GetGUID(), UserId = id, GpsEdiType = "接口类型", GpsEdiStatus = "接口状态", GpsEdiTime = DateTime.Now, GpsEdiCharge = 1, GpsEdiVihicle = vihicle, GpsEdiId = "接口编号" });
                    RepGpsEdi.Add(new GpsEdi() { Id = Utils.GetGUID(), UserId = id, GpsEdiType = "接口类型", GpsEdiStatus = "接口状态", GpsEdiTime = DateTime.Now, GpsEdiCharge = 1, GpsEdiVihicle = vihicle, GpsEdiId = "接口编号" });
                    GpsUser.UserBalance = GpsUser.UserBalance - 1;
                    RepUser.Update(GpsUser);
                }

                RepVihiclepp.Add(new VihiclePP()
                {
                    Id = Utils.GetGUID(),
                    GpsEdiVihicle=vihicle,
                    VihiclePPT=DateTime.Now
                });

                RepVihicledata.Add(new VihicleData()
                {
                    Id = Utils.GetGUID(),
                    GpsEdiVihicle = vihicle,
                    EdiTimes=DateTime.Now,
                    EdiUpdate=DateTime.Now
                });
            }
        }
    }
}
