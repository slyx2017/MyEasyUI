using System;
using System.Data;
using System.Collections.Generic;
using Common;
using Model;
namespace BLL
{
	/// <summary>
	/// Sys_RoleMenuMapping
	/// </summary>
	public partial class Sys_RoleMenuMappingBLL
	{
		private readonly DAL.Sys_RoleMenuMappingDAL dal=new DAL.Sys_RoleMenuMappingDAL();
		public Sys_RoleMenuMappingBLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Model.Sys_RoleMenuMapping model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Model.Sys_RoleMenuMapping model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_RoleMenuMapping GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Model.Sys_RoleMenuMapping GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "Sys_RoleMenuMappingModel-" ;
			object objModel = Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Common.ConfigHelper.GetConfigInt("ModelCache");
						Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Model.Sys_RoleMenuMapping)objModel;
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
		public DataSet GetPagePath(int roleId)
        {
            return dal.GetPagePath(roleId);
        }
        /// <summary>
        /// 获得角色列表 "roleId=0":查询角色表;"roleId=-1":查询角色菜单映射表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="roleId">"roleId=0":查询角色表;"roleId=-1":查询角色菜单映射表</param>
        /// <returns></returns>
        public DataSet GetRoleList(string strWhere, int roleId)
        {
            return dal.GetRoleList(strWhere, roleId);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Sys_RoleMenuMapping> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Model.Sys_RoleMenuMapping> DataTableToList(DataTable dt)
		{
			List<Model.Sys_RoleMenuMapping> modelList = new List<Model.Sys_RoleMenuMapping>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Model.Sys_RoleMenuMapping model;
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
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
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

