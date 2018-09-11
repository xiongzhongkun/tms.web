using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tms.Common;
using tms.Models;


namespace tms.Controllers
{
    public class UserAccountController : Controller
    {
        BaseRepository<UserAccount> RepUserAccount = new BaseRepository<UserAccount>();
        
        /// <summary>
        /// 新增或编辑保存数据
        /// </summary>
        /// <param name="model">要保存的实体</param>
        /// <returns>返回Msg</returns>
        public JsonResult Save(UserAccount model, ReqParam reqParam)
        {
            Msg _msg = new Msg();
            try
            {
                #region 验证判断
                if (string.IsNullOrEmpty(model.Account))
                {
                    _msg.msg = "登录用户名不能为空";
                    return Json(_msg);
                }
                if (string.IsNullOrEmpty(model.Pwd))
                {
                    _msg.msg = "密码不能为空";
                    return Json(_msg);
                }
                if (string.IsNullOrEmpty(model.GpsUserId))
                {
                    _msg.msg = "数据不完整可能存在异常攻击";
                    return Json(_msg);
                }
                #endregion

                if (!string.IsNullOrEmpty(model.Id))
                {
                    if (RepUserAccount.Update(model))
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
                    model.Id = Utils.GetGUID();
                    model.AddTime = DateTime.Now;
                    model.Pwd = Utils.GetMD5(model.Pwd);
                    if (RepUserAccount.Add(model) != null)
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
        public JsonResult GetList(DataTableParam param,string gpsuserid)
        {
            try
            {
                Expression<Func<UserAccount, bool>> where = w => w.GpsUserId == gpsuserid;

                int _total = 0;
                var _data = RepUserAccount.ListOffSet(param.Start, param.Length, out _total, where, false, o => o.AddTime).ToList();
                DataTablesResult<UserAccount> dtr = new DataTablesResult<UserAccount>(param.Draw, _total, _total, _data);
                return Json(dtr);
            }
            catch
            {
                return Json(new DataTablesResult<UserAccount>(0, 0, 0, new List<UserAccount>()));
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
                _msg.flag = RepUserAccount.Delete(id);
            }
            catch
            {
                _msg.msg = "删除出现异常";
            }
            return Json(_msg);
        }

        public JsonResult ReSetPwd(string id,string pwd)
        {
            Msg _msg = new Msg();
            if (string.IsNullOrEmpty(pwd))
            {
                _msg.msg="密码不能为空";
                return Json(_msg);
            }
            var account = RepUserAccount.Find(id);
            account.Pwd = Utils.GetMD5(pwd);
            _msg.flag=RepUserAccount.Update(account);

            return Json(_msg);
        }
    }
}
