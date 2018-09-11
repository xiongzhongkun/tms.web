using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using tms.Common;
using tms.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tms.Controllers
{
    public class GpsUserController : Controller
    {
        BaseRepository<GpsUser> RepGpsUser = new BaseRepository<GpsUser>();
        BaseRepository<Pcctv> RepPcctv = new BaseRepository<Pcctv>();
        
        // GET: /<controller>/
        public IActionResult List()
        {
            return View();
        }

        public IActionResult Edit(string id){
            if(string.IsNullOrEmpty(id)){
                return RedirectToAction("list");
            }
            var model = RepGpsUser.Find(id);

            var listpcctv = RepPcctv.List(w => w.Pcctvlevel == 1);
            ViewData["ddlprovince"] = new SelectList(listpcctv, "Id", "Pcctvname");
            ViewData["ddlcity"] = null;
            if (model != null && !string.IsNullOrEmpty(model.UserAddP))
            {
                listpcctv = RepPcctv.List(w => w.Pid == model.UserAddP);
                ViewData["ddlcity"] = new SelectList(listpcctv, "Id", "Pcctvname");
            }
            else
            {
                listpcctv = RepPcctv.List(w => w.Pid == "110000000000");
                ViewData["ddlcity"] = new SelectList(listpcctv, "Id", "Pcctvname");
            }

            return View(model);
        }

        /// <summary>
        /// 新增或编辑保存数据
        /// </summary>
        /// <param name="model">要保存的实体</param>
        /// <returns>返回Msg</returns>
        public JsonResult Save(GpsUser model, ReqParam reqParam)
        {
            Msg _msg = new Msg();
            try
            {
                #region 验证判断
                if(string.IsNullOrEmpty(model.UserName)){
                    _msg.msg = "单位全称不能为空";
                    return Json(_msg);
                }
                if(string.IsNullOrEmpty(model.UserShortname)){
                    _msg.msg = "单位简称不能为空";
                    return Json(_msg);
                }
                if (string.IsNullOrEmpty(model.UserCode))
                {
                    _msg.msg = "单位信用代码不能为空";
                    return Json(_msg);
                }
                #endregion

                if (!string.IsNullOrEmpty(model.UserId))
                {
                    if (RepGpsUser.Update(model))
                    {
                        _msg.flag = true;
                        _msg.msg = "更新成功";
                    }
                    else
                    {
                        _msg.other = "不跳转";
                        _msg.msg = "更新失败";
                    }
                }
                else
                {
                    model.UserId = Utils.GetGUID();
                    model.AddTime = DateTime.Now;
                    if (RepGpsUser.Add(model) != null)
                    {
                        _msg.flag = true;
                        _msg.msg = "新增成功";
                    }
                }

                if (_msg.flag)
                {
                    _msg.data = reqParam.hdn_target;
                    _msg.msg = reqParam.hdn_msg;
                    _msg.other = reqParam.hdn_targetType;
                }
            }
            catch
            {

            }
            return Json(_msg);
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
                Expression<Func<GpsUser, bool>> where = w => w.UserId != "";
                if(!string.IsNullOrEmpty(keyword)){
                    where = where.AndAlso(w => w.UserName.Contains(keyword) || w.UserShortname.Contains(keyword) || w.UserCode.Contains(keyword));
                }

                int _total = 0;
                var _data = RepGpsUser.ListOffSet(param.Start, param.Length, out _total,where, false, o => o.AddTime).ToList();
                DataTablesResult<GpsUser> dtr = new DataTablesResult<GpsUser>(param.Draw, _total, _total, _data);
                return Json(dtr);
            }
            catch
            {
                return Json(new DataTablesResult<GpsUser>(0, 0, 0, new List<GpsUser>()));
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>成功返回Msg.flag=true，失败Msg.flag=false</returns>
        public JsonResult Delete(string id)
        {
            Msg _msg = new Msg();
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    _msg.msg = "找不到内容";
                }
                else
                {
                    _msg.flag = RepGpsUser.Delete(id);
                }
            }
            catch
            {
            }
            return Json(_msg);
        }

    }
}
