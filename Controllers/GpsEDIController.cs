using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tms.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tms.Controllers
{
    /// <summary>
    /// EDI信息
    /// </summary>
    public class GpsEDIController : Controller
    {
        BaseRepository<GpsEdi> RepGpsedi = new BaseRepository<GpsEdi>();

        // GET: /<controller>/
        public IActionResult List()
        {
            return View();
        }

        /// <summary>
        /// 查询分页数据集
        /// </summary>
        /// <param name="param">DataTables 页面参数</param>
        /// <returns>返回Json数据集</returns>
        public JsonResult GetList(DataTableParam param, string keyword)
        {
            try
            {
                Expression<Func<GpsEdi, bool>> where = w => w.UserId != "";

                int _total = 0;
                var _data = RepGpsedi.ListOffSet(param.Start, param.Length, out _total, where, false, o => o.GpsEdiTime).ToList();
                DataTablesResult<GpsEdi> dtr = new DataTablesResult<GpsEdi>(param.Draw, _total, _total, _data);
                return Json(dtr);
            }
            catch
            {
                return Json(new DataTablesResult<GpsEdi>(0, 0, 0, new List<GpsEdi>()));
            }
        }
    }
}
