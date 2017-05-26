using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
	/// <summary>
	/// 数据访问类:Sys_Menu
	/// </summary>
	public partial class Sys_MenuDAL
	{
		public Sys_MenuDAL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ID", "Sys_Menu"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Sys_Menu");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Model.Sys_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Sys_Menu(");
			strSql.Append("MenuCode,MenuName,ParentID,Description,MenuUrl,Sequence,IsInUse,AddTime,AddUser,AddUserID)");
			strSql.Append(" values (");
			strSql.Append("@MenuCode,@MenuName,@ParentID,@Description,@MenuUrl,@Sequence,@IsInUse,@AddTime,@AddUser,@AddUserID)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuCode", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@IsInUse", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@AddUserID", SqlDbType.Int,4)};
			parameters[0].Value = model.MenuCode;
			parameters[1].Value = model.MenuName;
			parameters[2].Value = model.ParentID;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.MenuUrl;
			parameters[5].Value = model.Sequence;
			parameters[6].Value = model.IsInUse;
			parameters[7].Value = model.AddTime;
			parameters[8].Value = model.AddUser;
			parameters[9].Value = model.AddUserID;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
        /// <summary>
        /// 菜单模块添加
        /// </summary>
        public int AddMenuBlock(Model.Sys_Menu model, int roleId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuCode", SqlDbType.Int,4),
                    new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@Description", SqlDbType.NVarChar,500),
                    new SqlParameter("@MenuUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sequence", SqlDbType.Int,4),
                    new SqlParameter("@IsInUse", SqlDbType.Int,4),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddUserID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuCode;
            parameters[1].Value = model.MenuName;
            parameters[2].Value = model.ParentID;
            parameters[3].Value = model.Description;
            parameters[4].Value = model.MenuUrl;
            parameters[5].Value = model.Sequence;
            parameters[6].Value = model.IsInUse;
            parameters[7].Value = model.AddTime;
            parameters[8].Value = model.AddUser;
            parameters[9].Value = model.AddUserID;
            parameters[10].Value = roleId;
            int result = 0;
            object obj = DbHelperSQL.RunProcedure("AddNewMenu", parameters, out result);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 获取菜单
        /// </summary>
        /// <returns></returns>
        public DataSet GetMenuListByParentID(int ParentID,int roleId)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@RoleID", SqlDbType.Int,4)};
            parameters[0].Value = ParentID;
            parameters[1].Value = roleId;
            return DbHelperSQL.RunProcedure("GetMenuListByParentID", parameters,"ds");
        }
        /// <summary>
        /// 设置主页
        /// </summary>
        /// <returns></returns>
        public int SetHomePage(int id, int MenuCode)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@MenuCode", SqlDbType.Int,4)};
            parameters[0].Value = id;
            parameters[1].Value = MenuCode;
            int result = 0;
            return DbHelperSQL.RunProcedure("SetHomePage", parameters, out result);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int UpdateMenuBlock(Model.Sys_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Menu set ");
            strSql.Append("MenuName=@MenuName,");
            strSql.Append("Description=@Description,");
            strSql.Append("Sequence=@Sequence,");
            strSql.Append("IsInUse=@IsInUse");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@Description", SqlDbType.NVarChar,500),
                    new SqlParameter("@Sequence", SqlDbType.Int,4),
                    new SqlParameter("@IsInUse", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.Description;
            parameters[2].Value = model.Sequence;
            parameters[3].Value = model.IsInUse;
            parameters[4].Value = model.ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int EidtChildMenu(Model.Sys_Menu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_Menu set ");
            strSql.Append("MenuName=@MenuName,");
            strSql.Append("ParentID=@ParentID,");
            strSql.Append("Description=@Description,");
            strSql.Append("MenuUrl=@MenuUrl,");
            strSql.Append("Sequence=@Sequence,");
            strSql.Append("IsInUse=@IsInUse");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
                    new SqlParameter("@ParentID", SqlDbType.Int,4),
                    new SqlParameter("@Description", SqlDbType.NVarChar,500),
                    new SqlParameter("@MenuUrl", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sequence", SqlDbType.Int,4),
                    new SqlParameter("@IsInUse", SqlDbType.Int,4),
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MenuName;
            parameters[1].Value = model.ParentID;
            parameters[2].Value = model.Description;
            parameters[3].Value = model.MenuUrl;
            parameters[4].Value = model.Sequence;
            parameters[5].Value = model.IsInUse;
            parameters[6].Value = model.ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Sys_Menu model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Sys_Menu set ");
			strSql.Append("MenuCode=@MenuCode,");
			strSql.Append("MenuName=@MenuName,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("Description=@Description,");
			strSql.Append("MenuUrl=@MenuUrl,");
			strSql.Append("Sequence=@Sequence,");
			strSql.Append("IsInUse=@IsInUse,");
			strSql.Append("AddTime=@AddTime,");
			strSql.Append("AddUser=@AddUser,");
			strSql.Append("AddUserID=@AddUserID");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@MenuCode", SqlDbType.Int,4),
					new SqlParameter("@MenuName", SqlDbType.NVarChar,50),
					new SqlParameter("@ParentID", SqlDbType.Int,4),
					new SqlParameter("@Description", SqlDbType.NVarChar,500),
					new SqlParameter("@MenuUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@Sequence", SqlDbType.Int,4),
					new SqlParameter("@IsInUse", SqlDbType.Int,4),
					new SqlParameter("@AddTime", SqlDbType.DateTime),
					new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
					new SqlParameter("@AddUserID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4)};
			parameters[0].Value = model.MenuCode;
			parameters[1].Value = model.MenuName;
			parameters[2].Value = model.ParentID;
			parameters[3].Value = model.Description;
			parameters[4].Value = model.MenuUrl;
			parameters[5].Value = model.Sequence;
			parameters[6].Value = model.IsInUse;
			parameters[7].Value = model.AddTime;
			parameters[8].Value = model.AddUser;
			parameters[9].Value = model.AddUserID;
			parameters[10].Value = model.ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Menu ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
        /// <summary>
        /// 删除子菜单
        /// </summary>
        /// <returns></returns>
        public int DeleteMenuChild(int ID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            int result = 0;
            return DbHelperSQL.RunProcedure("DeleteMenuChild", parameters, out result);
        }
        /// <summary>
        /// 删除模块菜单
        /// </summary>
        /// <returns></returns>
        public int DeleteMenuBlock(int ID, int ParentID)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@ParentID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            parameters[1].Value = ParentID;
            int result = 0;
            return DbHelperSQL.RunProcedure("DeleteMenuBlock", parameters, out result);
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Sys_Menu ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Menu GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,MenuCode,MenuName,ParentID,Description,MenuUrl,Sequence,IsInUse,AddTime,AddUser,AddUserID from Sys_Menu ");
			strSql.Append(" where ID=@ID");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
			parameters[0].Value = ID;

			Model.Sys_Menu model=new Model.Sys_Menu();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Model.Sys_Menu DataRowToModel(DataRow row)
		{
			Model.Sys_Menu model=new Model.Sys_Menu();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=int.Parse(row["ID"].ToString());
				}
				if(row["MenuCode"]!=null && row["MenuCode"].ToString()!="")
				{
					model.MenuCode=int.Parse(row["MenuCode"].ToString());
				}
				if(row["MenuName"]!=null)
				{
					model.MenuName=row["MenuName"].ToString();
				}
				if(row["ParentID"]!=null && row["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(row["ParentID"].ToString());
				}
				if(row["Description"]!=null)
				{
					model.Description=row["Description"].ToString();
				}
				if(row["MenuUrl"]!=null)
				{
					model.MenuUrl=row["MenuUrl"].ToString();
				}
				if(row["Sequence"]!=null && row["Sequence"].ToString()!="")
				{
					model.Sequence=int.Parse(row["Sequence"].ToString());
				}
				if(row["IsInUse"]!=null && row["IsInUse"].ToString()!="")
				{
					model.IsInUse=int.Parse(row["IsInUse"].ToString());
				}
				if(row["AddTime"]!=null && row["AddTime"].ToString()!="")
				{
					model.AddTime=DateTime.Parse(row["AddTime"].ToString());
				}
				if(row["AddUser"]!=null)
				{
					model.AddUser=row["AddUser"].ToString();
				}
				if(row["AddUserID"]!=null && row["AddUserID"].ToString()!="")
				{
					model.AddUserID=int.Parse(row["AddUserID"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MenuCode,MenuName,ParentID,Description,MenuUrl,Sequence,IsInUse,AddTime,AddUser,AddUserID ");
			strSql.Append(" FROM Sys_Menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得页面地址
        /// </summary>
        public DataSet GetPagePath(int menucode)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@MenuCode", SqlDbType.Int)
            };
            parameters[0].Value = menucode;
            return DbHelperSQL.RunProcedure("GetIndexPath", parameters, "ds");
        }
        /// <summary>
        /// 根据用户加载菜单
        /// </summary>
        public DataSet GetMenuListByUser(int uId, string strWhere)
        {
            SqlParameter[] parameters = {
            new SqlParameter("@UserID", SqlDbType.Int),
            new SqlParameter("@fldName", SqlDbType.VarChar, 500),
            new SqlParameter("@OrderType", SqlDbType.Bit),
            new SqlParameter("@strWhere", SqlDbType.VarChar,100)
            };
            parameters[0].Value = uId;
            parameters[1].Value = "Sequence";
            parameters[2].Value = 0;
            parameters[3].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetMenuListByUser", parameters, "ds");
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ID,MenuCode,MenuName,ParentID,Description,MenuUrl,Sequence,IsInUse,AddTime,AddUser,AddUserID ");
			strSql.Append(" FROM Sys_Menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Sys_Menu ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from Sys_Menu T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
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
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000)
                    };
            parameters[0].Value = "Sys_Menu";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 1;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetPageList", parameters, "ds");
        }

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

