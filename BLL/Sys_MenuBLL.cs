
using System;
using System.Data;
using System.Collections.Generic;
namespace BLL
{
    /// <summary>
    /// Sys_Menu
    /// </summary>
    public partial class Sys_MenuBLL
    {
        private readonly DAL.Sys_MenuDAL dal = new DAL.Sys_MenuDAL();
        public Sys_MenuBLL()
        { }
        #region  BasicMethod

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Sys_Menu model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 菜单模块添加
        /// </summary>
        /// <param name="model">菜单对象Model</param>
        /// <returns></returns>
        public int AddMenuBlock(Model.Sys_Menu model, int roleId)
        {
            return dal.AddMenuBlock(model, roleId);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateMenuBlock(Model.Sys_Menu model)
        {
            return dal.UpdateMenuBlock(model);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int EidtChildMenu(Model.Sys_Menu model)
        {
            return dal.EidtChildMenu(model);
        }
        /// <summary>
        /// 设置主页
        /// </summary>
        public int SetHomePage(int id, int MenuCode)
        {
            return dal.SetHomePage(id, MenuCode);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Sys_Menu model)
        {
            return dal.Update(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID);
        }
        /// <summary>
        /// 删除子菜单
        /// </summary>
        public int DeleteMenuChild(int ID)
        {

            return dal.DeleteMenuChild(ID);
        }
        /// <summary>
        /// 删除模块菜单
        /// </summary>
        /// <returns></returns>
        public int DeleteMenuBlock(int ID, int ParentID)
        {
            return dal.DeleteMenuBlock(ID, ParentID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Sys_Menu GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得页面地址
        /// </summary>
        public DataSet GetPagePath(int menucode)
        {
            return dal.GetPagePath(menucode);
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        public DataSet GetMenuListByParentID(int ParentID, int roleId)
        {
            return dal.GetMenuListByParentID(ParentID, roleId);
        }
        /// <summary>
        /// 根据用户加载菜单
        /// </summary>
        public DataSet GetMenuListByUser(int uId, string strWhere)
        {
            return dal.GetMenuListByUser(uId, strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Sys_Menu> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Sys_Menu> DataTableToList(DataTable dt)
        {
            List<Model.Sys_Menu> modelList = new List<Model.Sys_Menu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Model.Sys_Menu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }
        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="PageSize"></param>
        /// <param name="PageIndex"></param>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetPageList(int PageSize, int PageIndex, string strWhere)
        {
            return dal.GetPageList(PageSize, PageIndex, strWhere);
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

