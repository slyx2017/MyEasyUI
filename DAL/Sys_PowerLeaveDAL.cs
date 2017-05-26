using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace DAL
{
    /// <summary>
    /// 数据访问类:Sys_PowerLevel
    /// </summary>
    public partial class Sys_PowerLevelDAL
    {
        public Sys_PowerLevelDAL()
        { }
        #region  BasicMethod
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PowerLevelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Sys_PowerLevel");
            strSql.Append(" where PowerLevelID=@PowerLevelID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PowerLevelID", SqlDbType.Int,4)
            };
            parameters[0].Value = PowerLevelID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.Sys_PowerLevel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Sys_PowerLevel(");
            strSql.Append("PowerName,AddTime,AddUser,PowerState)");
            strSql.Append(" values (");
            strSql.Append("@PowerName,@AddTime,@AddUser,@PowerState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PowerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@PowerState", SqlDbType.TinyInt,1)};
            parameters[0].Value = model.PowerName;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.AddUser;
            parameters[3].Value = model.PowerState;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.Sys_PowerLevel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Sys_PowerLevel set ");
            strSql.Append("PowerName=@PowerName,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("AddUser=@AddUser,");
            strSql.Append("PowerState=@PowerState");
            strSql.Append(" where PowerLevelID=@PowerLevelID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PowerName", SqlDbType.NVarChar,50),
                    new SqlParameter("@AddTime", SqlDbType.DateTime),
                    new SqlParameter("@AddUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@PowerState", SqlDbType.TinyInt,1),
                    new SqlParameter("@PowerLevelID", SqlDbType.Int,4)};
            parameters[0].Value = model.PowerName;
            parameters[1].Value = model.AddTime;
            parameters[2].Value = model.AddUser;
            parameters[3].Value = model.PowerState;
            parameters[4].Value = model.PowerLevelID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int PowerLevelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_PowerLevel ");
            strSql.Append(" where PowerLevelID=@PowerLevelID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PowerLevelID", SqlDbType.Int,4)
            };
            parameters[0].Value = PowerLevelID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string PowerLevelIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Sys_PowerLevel ");
            strSql.Append(" where PowerLevelID in (" + PowerLevelIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Model.Sys_PowerLevel GetModel(int PowerLevelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PowerLevelID,PowerName,AddTime,AddUser,PowerState from Sys_PowerLevel ");
            strSql.Append(" where PowerLevelID=@PowerLevelID");
            SqlParameter[] parameters = {
                    new SqlParameter("@PowerLevelID", SqlDbType.Int,4)
            };
            parameters[0].Value = PowerLevelID;

			Model.Sys_PowerLevel model = new Model.Sys_PowerLevel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public Model.Sys_PowerLevel DataRowToModel(DataRow row)
        {
			Model.Sys_PowerLevel model = new Model.Sys_PowerLevel();
            if (row != null)
            {
                if (row["PowerLevelID"] != null && row["PowerLevelID"].ToString() != "")
                {
                    model.PowerLevelID = int.Parse(row["PowerLevelID"].ToString());
                }
                if (row["PowerName"] != null)
                {
                    model.PowerName = row["PowerName"].ToString();
                }
                if (row["AddTime"] != null && row["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(row["AddTime"].ToString());
                }
                if (row["AddUser"] != null)
                {
                    model.AddUser = row["AddUser"].ToString();
                }
                if (row["PowerState"] != null && row["PowerState"].ToString() != "")
                {
                    model.PowerState = int.Parse(row["PowerState"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select PowerLevelID,PowerName,AddTime,AddUser,PowerState ");
            strSql.Append(" FROM Sys_PowerLevel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" PowerLevelID,PowerName,AddTime,AddUser,PowerState ");
            strSql.Append(" FROM Sys_PowerLevel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetPowerLevelList(string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@strWhere", SqlDbType.NVarChar,1000),
                    };
            parameters[0].Value = strWhere;
            return DbHelperSQL.RunProcedure("GetPowerLevelList", parameters, "ds");
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Sys_PowerLevel ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.PowerLevelID desc");
            }
            strSql.Append(")AS Row, T.*  from Sys_PowerLevel T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Sys_PowerLevel";
			parameters[1].Value = "PowerLevelID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}



