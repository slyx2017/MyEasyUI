using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Common;

namespace MyEasyUI.Ashx
{
    /// <summary>
    /// adduser 的摘要说明
    /// </summary>
    public class user : IHttpHandler
    {
        BLL.UserBLL bll_u = new BLL.UserBLL();
        BLL.Sys_PowerLevelBLL bll_pl = new BLL.Sys_PowerLevelBLL();
        Model.Users model_u = new Model.Users();
        string strWhere = " 1=1 ";
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["action"];
            switch (action)
            {
                case "getlist":
                    GetUserList(context);
                    break;
                case "getPosition":
                    GetPositionList(context);
                    break;
                case "add":
                    AddUser(context);
                    break;
                case "edit":
                    EditUser(context);
                    break;
                case "del":
                    DelUser(context);
                    break;
                case "freeze":
                    FreezeUser(context);
                    break;
                default:
                    break;
            }

        }

        private void GetPositionList(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            DataSet ds = bll_pl.GetPowerLevelList(strWhere);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0)
            {
                string jsonData = DataTableToJsonHelper.DataTableToJson(dt);
                context.Response.Write(jsonData);
            }
            else
            {
                context.Response.Write("{\"failure\":\"no\"}");
            }
            context.Response.End();
        }

        private void GetUserList(HttpContext context)
        {
            //不让浏览器缓存
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.ContentType = "application/json";
            string username = context.Request.Params["UserName"];
            string DateFrom = context.Request.Params["DateFrom"];
            string Level = context.Request.Params["Level"];
            string DateTo = context.Request.Params["DateTo"];
            int pageIndex = int.Parse(context.Request.Params["page"]);
            int pageSize = int.Parse(context.Request.Params["rows"]);
            if (!string.IsNullOrEmpty(username))
            {
                strWhere += " and uName like '%" + username + "%'";
            }
            if (!string.IsNullOrEmpty(DateFrom))
            {
                strWhere += " and Birthday >= '" + DateFrom + "'";
            }
            if (!string.IsNullOrEmpty(DateTo))
            {
                strWhere += " and Birthday <= '" + DateTo + "'";
            }
            if (!string.IsNullOrEmpty(Level))
            {
                strWhere += " and PowerLevelID = " + Level + "";
            }
            DataSet ds = new DataSet();
            ds = bll_u.GetPageList(pageSize, pageIndex, strWhere);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            int total = int.Parse(dt1.Rows[0]["Total"].ToString());
            //if (dt.Rows.Count > 0)
            //{
            string jsonData = DataTableToJsonHelper.DataTableToJsonAll(dt, total, 0);
            context.Response.Write(jsonData);
            //}
            //else
            //{
            //    context.Response.Write("{\"failure\":\"no\"}");
            //}
            context.Response.End();
        }

        private void FreezeUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            int state = int.Parse(context.Request.Params["state"].ToString());
            int isdel = bll_u.FreezeUser(uid, state);
            if (isdel > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        }

        private void DelUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            int uIsDel = int.Parse(context.Request.Params["uIsDel"].ToString());
            int isdel = bll_u.DeleteUserByID(uid, uIsDel);
            if (isdel > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                context.Response.End();
                return;
            }
        }

        private void EditUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int uid = int.Parse(context.Request.Params["uId"].ToString());
            int powerlevelID = int.Parse(context.Request.Params["powerlevelID"].ToString());
            string uLoginName = context.Request.Params["uLoginName"];
            int roleId = int.Parse(context.Request.Params["RoleID"].ToString());
            string telPhone = context.Request.Params["telPhone"];
            string password = context.Request.Params["password"];
            string email = context.Request.Params["email"];
            DateTime? birthday = DateTime.Parse(context.Request.Params["birthday"]);
            string sex = context.Request.Params["sex"];

            model_u.uId = uid;
            model_u.uLoginName = uLoginName;
            model_u.Telephone = telPhone;
            model_u.Sex = sex == "1" ? true : false;
            model_u.PowerLevelID = powerlevelID;
            model_u.Birthday = birthday;
            model_u.Email = email;
            model_u.uName = uLoginName;

            int codeNum = bll_u.EditUser(model_u, roleId);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                return;
            }
        }

        private void AddUser(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int powerlevelID = int.Parse(context.Request.Params["powerlevelID"].ToString());
            string uLoginName = context.Request.Params["uLoginName"];
            int roleId = int.Parse(context.Request.Params["RoleID"].ToString());
            string telPhone = context.Request.Params["telPhone"];
            string password = context.Request.Params["password"];
            string email = context.Request.Params["email"];
            DateTime? birthday = DateTime.Parse(context.Request.Params["birthday"]);
            string sex = context.Request.Params["sex"];
            bool uisdel = false;

            model_u.uLoginName = uLoginName;
            model_u.uPwd = password;
            model_u.Telephone = telPhone;
            model_u.Sex = sex == "1" ? true : false;
            model_u.PowerLevelID = powerlevelID;
            model_u.uAddtime = DateTime.Now;
            model_u.Birthday = birthday;
            model_u.Email = email;
            model_u.AccountState = 1;
            model_u.uName = uLoginName;
            model_u.uIsDel = uisdel;
            int codeNum = bll_u.AddNewUser(model_u, roleId);
            if (codeNum > 0)
            {
                context.Response.Write("ok");
                context.Response.End();
            }
            else
            {
                context.Response.Write("no");
                return;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}