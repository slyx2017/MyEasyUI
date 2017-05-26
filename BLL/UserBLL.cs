using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class UserBLL
    {
        private readonly DAL.UserDAL dal = new DAL.UserDAL();
        public UserBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int uId)
        {
            return dal.Exists(uId);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Users model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddNewUser(Model.Users model,int roleId)
        {
            return dal.AddNewUser(model,roleId);
        }
       
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Users model)
        {
            return dal.Update(model);
        }
        public int EditUser(Model.Users model,int roleId)
        {
            return dal.EditUser(model,roleId);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int uId)
        {

            return dal.Delete(uId);
        }
        /// <summary>
        /// 冻结一条数据
        /// </summary>
        public int FreezeUser(int uId,int state)
        {

            return dal.FreezeUser(uId,state);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteUserByID(int uId,int uIsDel)
        {
            return dal.DeleteUserByID(uId, uIsDel);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string uIdlist)
        {
            return dal.DeleteList(uIdlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Users GetModel(int uId)
        {

            return dal.GetModel(uId);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetUserList(string strWhere)
        {
            return dal.GetUserList(strWhere);
        }
        /// <summary>
        /// 获取登录用户信息
        /// </summary>
        /// <param name="uLoginName">用户名</param>
        /// <param name="uPwd">密码</param>
        /// <returns></returns>
        public DataSet GetUserByLoginName(string uLoginName, string uPwd)
        {
            return dal.GetUserByLoginName(uLoginName, uPwd);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Users> DataTableToList(DataTable dt)
        {
            List <Model.Users > modelList = new List<Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
				Model.Users model;
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

        #endregion  BasicMethod
        #region  ExtensionMethod
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
        #endregion  ExtensionMethod
    }
}

