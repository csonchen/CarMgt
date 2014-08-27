using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 车型信息
    /// </summary>
    public partial class work_itemsdal
    {
        public work_itemsdal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from work_items");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string itemcode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from work_items");
            strSql.Append(" where Item_Code=@itemcode ");
            SqlParameter[] parameters = {
					new SqlParameter("@itemcode", SqlDbType.NVarChar,100)};
            parameters[0].Value = itemcode;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.work_itemsinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into work_items(");
            strSql.Append("Item_Code,Item_Name,Item_Cost)");
            strSql.Append(" values (");
            strSql.Append("@itemcode,@itemname,@itemcost)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@itemcode", SqlDbType.NVarChar,100),
					new SqlParameter("@itemname", SqlDbType.NVarChar,100),
					new SqlParameter("@itemcost", SqlDbType.Decimal,10)};
            parameters[0].Value = model.Item_Code;
            parameters[1].Value = model.Item_Name;
            parameters[2].Value = model.Item_Cost;

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
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update work_items set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.work_itemsinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update work_items set ");
            strSql.Append("Item_Name=@itemname");
            strSql.Append(",Item_Cost=@itemcost");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@itemname", SqlDbType.NVarChar,100),
					new SqlParameter("@itemcost", SqlDbType.Decimal,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Item_Name;
            parameters[1].Value = model.Item_Cost;
            parameters[2].Value = model.ID;

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
        public bool Delete(int id)
        {
            List<CommandInfo> sqllist = new List<CommandInfo>();
            //删除登录日志
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from work_items ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql.ToString(), parameters);
            sqllist.Add(cmd);

            int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
            if (rowsAffected > 0)
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
        public Model.work_itemsinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from work_items ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.work_itemsinfo model = new Model.work_itemsinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Item_Code = ds.Tables[0].Rows[0]["Item_Code"] + "";
                model.Item_Name = ds.Tables[0].Rows[0]["Item_Name"] + "";
                string s = ds.Tables[0].Rows[0]["Item_Cost"] + "";
                model.Item_Cost = decimal.Parse(s == "" ? "0" : s);
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.work_itemsinfo GetModel(string code,string car_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from work_items");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Item_Code='" + code + "'");
            }
            if (car_name.Trim() != "")
            {
                strSql.Append(" and Item_Name='" + car_name + "'");
            }
            Model.work_itemsinfo model = new Model.work_itemsinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Item_Code = ds.Tables[0].Rows[0]["Item_Code"] + "";
                model.Item_Name = ds.Tables[0].Rows[0]["Item_Name"] + "";
                string s = ds.Tables[0].Rows[0]["Item_Cost"] + "";
                model.Item_Cost = decimal.Parse(s == "" ? "0" : s);
                return model;
            }
            else
            {
                return null;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Model.work_itemsinfo GetModel(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from work_items where Item_Code = '" + code + "'");
            Model.work_itemsinfo model = new Model.work_itemsinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Item_Code = ds.Tables[0].Rows[0]["Item_Code"] + "";
                model.Item_Name = ds.Tables[0].Rows[0]["Item_Name"] + "";
                string s = ds.Tables[0].Rows[0]["Item_Cost"] + "";
                model.Item_Cost = decimal.Parse(s == "" ? "0" : s);
                return model;
            }
            else
            {
                return null;
            }
            return null;
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
            strSql.Append(" * ");
            strSql.Append(" FROM work_items ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM work_items");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public string GetTitleByCode(string code)
        {
            string value = "";
            if (code == "") { return value; }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM work_items");
            if (code.Trim() != "")
            {
                strSql.Append(" where Item_Code='" + code + "'");
            }
            DataTable tb = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (tb != null && tb.Rows.Count > 0) { value = tb.Rows[0]["Item_Name"] + ""; }
            return value;
        }

        #endregion  Method

        public string GetMaxCode()
        {
            StringBuilder strSql = new StringBuilder();
            strSql = strSql.Append("select top 1 * from work_items order by ID desc");
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string roleCode = ds.Tables[0].Rows[0]["Item_Code"] + "";
                return roleCode;
            }
            else
            {
                return "10000";
            }
        }
    }
}