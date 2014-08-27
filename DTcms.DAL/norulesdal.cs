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
    public partial class norulesdal
    {
        public norulesdal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from no_rules");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from no_rules");
            strSql.Append(" where Code=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.norulesinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into no_rules(");
            strSql.Append("Code,Car_Number,Driver_Code,NoRules_Time,NoRules_Class_Code,Address,Cost,Score,cContent)");
            strSql.Append(" values (");
            strSql.Append("@code,@carnumber,@drivercode,@norulestime,@norulesclasscode,@address,@cost,@score,@ccontent)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,26),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@drivercode", SqlDbType.NVarChar,26),
					new SqlParameter("@norulestime", SqlDbType.NVarChar,26),
					new SqlParameter("@norulesclasscode", SqlDbType.NVarChar,26),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@cost", SqlDbType.Decimal,10),
					new SqlParameter("@score", SqlDbType.Decimal,10),
					new SqlParameter("@ccontent", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Car_Number;
            parameters[2].Value = model.Driver.Driver_Code;
            parameters[3].Value = model.NoRules_Time;
            parameters[4].Value = model.NoRules_Class.NRules_Code;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.Cost;
            parameters[7].Value = model.Score;
            parameters[8].Value = model.cContent;

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
            strSql.Append("update no_rules set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.norulesinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update no_rules set ");
            strSql.Append("Car_Number=@carnumber,");
            strSql.Append("Driver_Code=@drivercode,");
            strSql.Append("NoRules_Time=@norulestime,");
            strSql.Append("NoRules_Class_Code=@norulesclasscode,");
            strSql.Append("Address=@address,");
            strSql.Append("Cost=@cost,");
            strSql.Append("Score=@score,");
            strSql.Append("cContent=@ccontent");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@drivercode", SqlDbType.NVarChar,26),
					new SqlParameter("@norulestime", SqlDbType.NVarChar,26),
					new SqlParameter("@norulesclasscode", SqlDbType.NVarChar,26),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@cost", SqlDbType.Decimal,10),
					new SqlParameter("@score", SqlDbType.Decimal,10),
					new SqlParameter("@ccontent", SqlDbType.NVarChar,1000),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Car_Number;
            parameters[1].Value = model.Driver.Driver_Code;
            parameters[2].Value = model.NoRules_Time;
            parameters[3].Value = model.NoRules_Class.NRules_Code;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Cost;
            parameters[6].Value = model.Score;
            parameters[7].Value = model.cContent;
            parameters[8].Value = model.ID;

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
            strSql.Append("delete from no_rules ");
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
        public Model.norulesinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from no_rules ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.norulesinfo model = new Model.norulesinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.NoRules_Time = ds.Tables[0].Rows[0]["NoRules_Time"] + "";
                model.NoRules_Class = new Model.norules_classinfo();
                model.NoRules_Class.NRules_Code = ds.Tables[0].Rows[0]["NoRules_Class_Code"] + "";
                model.Address = ds.Tables[0].Rows[0]["Address"] + "";
                string s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Score"] + "";
                model.Score = Convert.ToInt64(s == "" ? "0" : s);
                model.cContent = ds.Tables[0].Rows[0]["cContent"] + "";
                model.CreateTime = ds.Tables[0].Rows[0]["CreateTime"] + "";
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
        public Model.norulesinfo GetModel(string code,string car_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from no_rules");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Code='" + code + "'");
            }
            if (car_name.Trim() != "")
            {
                strSql.Append(" and Car_Number='" + car_name + "'");
            }
            Model.norulesinfo model = new Model.norulesinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.NoRules_Time = ds.Tables[0].Rows[0]["NoRules_Time"] + "";
                model.NoRules_Class = new Model.norules_classinfo();
                model.NoRules_Class.NRules_Code = ds.Tables[0].Rows[0]["NoRules_Class_Code"] + "";
                model.Address = ds.Tables[0].Rows[0]["Address"] + "";
                string s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Score"] + "";
                model.Score = Convert.ToInt64(s == "" ? "0" : s);
                model.cContent = ds.Tables[0].Rows[0]["cContent"] + "";
                model.CreateTime = ds.Tables[0].Rows[0]["CreateTime"] + "";
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
            strSql.Append(" FROM no_rules ");
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
            strSql.Append("select * FROM no_rules");
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
            strSql.Append("select * FROM no_rules");
            if (code.Trim() != "")
            {
                strSql.Append(" where Code='" + code + "'");
            }
            DataTable tb = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (tb != null && tb.Rows.Count > 0) { value = tb.Rows[0]["Car_Number"] + ""; }
            return value;
        }

        #endregion  Method
    }
}