using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tms.Common
{
    public class Keys
    {
        /// <summary>
        /// 数据库表中英文对应
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetDBTables()
        {
            Dictionary<string, string> dbTables = new Dictionary<string, string>();
            
            return dbTables;
        }

        #region 管理后台信息
        /// <summary>
        /// 系统菜单列表
        /// </summary>
        public const string ADMINNAVDATA = "ADMINNAVDATAfsgwrtweklAVsdjfsljfoiwejpoiINNAVDATA";


        /// <summary>
        /// 用户权限存储
        /// </summary>
        public const string ADMINUSEROLE = "ADMINUSEROLEfsgwrtweklsdjfsljfoiwejpoiOUSEROLE";

        /// <summary>
        /// 前台验证码
        /// </summary>
        public const string ADMINLOGINIMGVALID = "ADMINLsdfsgwrtweklsdjfsljfoiwejpoiOGINIMGVALID";
        /// <summary>
        /// 用户信息
        /// </summary>
        public const string ADMINUSERINFO = "3456ADMIN789bnmdfvio4e2prni";

        /// <summary>
        /// 用户密码
        /// </summary>
        public const string ADMINUSERPWD = "USERPWADMIND12434hkxvkxfkhguidruti";

        /// <summary>
        /// 用户名
        /// </summary>
        public const string ADMINUSERNAME = "USERNAADMINME14fvdsfgwe4523df";

        /// <summary>
        /// 是否记住密码
        /// </summary>
        public const string ADMINUSERID = "USERID35ADMINhu4huidhfiu23huif";

        #endregion
    }
}
