using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
    /// <summary>
    /// Sys_PowerLevel
    /// </summary>
    public partial class Sys_PowerLevelBLL
    {
        private readonly DAL.Sys_PowerLevelDAL dal = new DAL.Sys_PowerLevelDAL();
        public Sys_PowerLevelBLL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PowerLevelID)
        {
            return dal.Exists(PowerLevelID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Sys_PowerLevel model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Sys_PowerLevel model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int PowerLevelID)
        {

            return dal.Delete(PowerLevelID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string PowerLevelIDlist)
        {
            return dal.DeleteList(PowerLevelIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.Sys_PowerLevel GetModel(int PowerLevelID)
        {

            return dal.GetModel(PowerLevelID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Model.Sys_PowerLevel GetModelByCache(int PowerLevelID)
        {

            string CacheKey = "Sys_PowerLevelModel-" + PowerLevelID;
            object objModel = Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(PowerLevelID);
                    if (objModel != null)
                    {
                        int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
                        Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Model.Sys_PowerLevel)objModel;
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
        public DataSet GetPowerLevelList(string strWhere)
        {
            return dal.GetPowerLevelList(strWhere);
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
        public List<Model.Sys_PowerLevel> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.Sys_PowerLevel> DataTableToList(DataTable dt)
        {
            List <Model.Sys_PowerLevel > modelList = new List<Model.Sys_PowerLevel>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
				Model.Sys_PowerLevel model;
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
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

