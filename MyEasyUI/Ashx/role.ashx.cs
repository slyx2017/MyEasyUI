using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEasyUI.Ashx
{
    /// <summary>
    /// role 的摘要说明
    /// </summary>
    public class role : IHttpHandler
    {
       
        BLL.Sys_RoleInfoBLL bll_role = new BLL.Sys_RoleInfoBLL();
        string strWhere = " 1=1 ";
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["action"];
            switch (action)
            {
                case "getlist":
                    GetRoleList(context);
                    break;
                case "add":
                    AddRole(context);
                    break;
                case "edit":
                    EditRole(context);
                    break;
                case "del":
                    DelRole(context);
                    break;
                default:
                    break;
            }
        }


        private void GetRoleList(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            int PageIndex = int.Parse(context.Request.Params["page"].ToString());
            int PageSize = int.Parse(context.Request.Params["rows"].ToString());
            DataSet ds = new DataSet();
            ds = bll_role.GetPageList(PageSize,PageIndex, strWhere);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            int total = int.Parse(dt1.Rows[0]["Total"].ToString());
            string jsonData = DataTableToJsonHelper.DataTableToJsonAll(dt, total, 0);
            context.Response.Write(jsonData);
            context.Response.End();
        }

        private void AddRole(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void EditRole(HttpContext context)
        {
            throw new NotImplementedException();
        }

        private void DelRole(HttpContext context)
        {
            throw new NotImplementedException();
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