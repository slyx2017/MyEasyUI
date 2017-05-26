using Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MyEasyUI.Ashx
{
    /// <summary>
    /// mainmenu 的摘要说明
    /// </summary>
    public class mainmenu : IHttpHandler
    {
        BLL.Sys_MenuBLL bll = new BLL.Sys_MenuBLL();
        public void ProcessRequest(HttpContext context)
        {
            string action = context.Request.Params["action"];
            switch (action)
            {
                case "init":
                    InitMenu(context);
                    break;
                case "getlist":
                    QueryAssetRegister(context);
                    break;
                default:
                    break;
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #region 初始化树形菜单 MenuInit(HttpContext context)
        /// <summary>
        /// 初始化树形菜单
        /// </summary>
        /// <param name="context"></param>
        private void InitMenu(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            DataSet ds = new DataSet();
            ds = bll.GetMenuListByParentID(0, 0);
            DataTable dt = ds.Tables[0];
            string parentJson = "[";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string menuname = dt.Rows[i]["MenuName"].ToString();
                int pid = int.Parse(dt.Rows[i]["ID"].ToString());
                parentJson += "{\"id\": \"" + pid + "\",\"text\": \"" + menuname + "\", \"state\": \"closed\", \"children\": [";
                DataTable dt_child = bll.GetMenuListByParentID(pid, 0).Tables[0];
                for (int j = 0; j < dt_child.Rows.Count; j++)
                {
                    string menuchildname = dt_child.Rows[j]["MenuName"].ToString();
                    string childurl = dt_child.Rows[j]["MenuUrl"].ToString();
                    int cid = int.Parse(dt_child.Rows[j]["ID"].ToString());
                    parentJson += "{\"id\": \"" + cid + "\",\"text\": \"" + menuchildname + "\", \"attributes\": {\"url\": \"" + childurl + "\"} },";
                }
                if (parentJson.EndsWith(","))
                {
                    parentJson = parentJson.Remove(parentJson.Length - 1, 1);
                }
                parentJson += "]},";
            }
            if (parentJson.EndsWith(","))
            {
                parentJson = parentJson.Remove(parentJson.Length - 1, 1);
            }
            parentJson += "]";
            string strJson = parentJson;
            context.Response.Write(parentJson);
            context.Response.End();
        }
        #endregion
        private void QueryAssetRegister(HttpContext context)
        {
            //不让浏览器缓存
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.ContentType = "application/json";
            int pageIndex = int.Parse(context.Request.Params["page"]);
            int pageSize = int.Parse(context.Request.Params["rows"]);
            string strWhere = " 1=1 ";
            DataSet ds = new DataSet();
            ds = bll.GetPageList(pageSize, pageIndex, strWhere);
            DataTable dt = ds.Tables[0];
            DataTable dt1 = ds.Tables[1];
            int total = int.Parse(dt1.Rows[0]["Total"].ToString());
            if (dt.Rows.Count > 0)
            {
                string jsonData = DataTableToJsonHelper.DataTableToJsonAll(dt, total, 0);
                context.Response.Write(jsonData);
            }
            else
            {
                context.Response.Write("{\"failure\":\"no\"}");
            }
            context.Response.End();
        }
    }
}