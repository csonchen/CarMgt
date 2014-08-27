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
    public partial class car_other_costdal
    {
        public car_other_costdal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from car_other_cost");
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
            strSql.Append("select count(1) from car_other_cost");
            strSql.Append(" where Code=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.car_other_costinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into car_other_cost(");
            strSql.Append("Code,Tittle,Car_Number,Cost,Type_Code)");
            strSql.Append(" values (");
            strSql.Append("@code,@tittle,@carnumber,@cost,@typecode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,26),
					new SqlParameter("@tittle", SqlDbType.NVarChar,200),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@cost", SqlDbType.Decimal,10),
					new SqlParameter("@typecode", SqlDbType.NVarChar,26)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Tittle;
            parameters[2].Value = model.Car.Car_Number;
            parameters[3].Value = model.Cost;
            parameters[4].Value = model.Type_Code;

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
            strSql.Append("update car_other_cost set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.car_other_costinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update car_other_cost set ");
            strSql.Append("Tittle=@tittle,");
            strSql.Append("Car_Number=@carnumber,");
            strSql.Append("Cost=@cost,");
            strSql.Append("Type_Code=@typecode");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@tittle", SqlDbType.NVarChar,200),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@cost", SqlDbType.Decimal,10),
					new SqlParameter("@typecode", SqlDbType.NVarChar,26),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Tittle;
            parameters[1].Value = model.Car.Car_Number;
            parameters[2].Value = model.Cost;
            parameters[3].Value = model.Type_Code;
            parameters[4].Value = model.ID;

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
            strSql.Append("delete from car_other_cost ");
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
        public Model.car_other_costinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from car_other_cost ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.car_other_costinfo model = new Model.car_other_costinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Tittle = ds.Tables[0].Rows[0]["Tittle"] + "";
                model.Car = new Model.carinfo();
                model.Car.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                string s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s == "" ? "0" : s);
                model.Type_Code = ds.Tables[0].Rows[0]["Type_Code"] + "";
                s = ds.Tables[0].Rows[0]["Status"] + "";
                model.Status = Convert.ToInt32(s == "" ? "0" : s);
                model.Checker_Code = ds.Tables[0].Rows[0]["Checker_Code"] + "";
                model.Check_Time = ds.Tables[0].Rows[0]["Check_Time"] + "";
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
        public Model.car_other_costinfo GetModel(string code,string car_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_other_cost");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Code='" + code + "'");
            }
            if (car_name.Trim() != "")
            {
                strSql.Append(" and Tittle='" + car_name + "'");
            }
            Model.car_other_costinfo model = new Model.car_other_costinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Tittle = ds.Tables[0].Rows[0]["Tittle"] + "";
                model.Car = new Model.carinfo();
                model.Car.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                string s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s == "" ? "0" : s);
                model.Type_Code = ds.Tables[0].Rows[0]["Type_Code"] + "";
                s = ds.Tables[0].Rows[0]["Status"] + "";
                model.Status = Convert.ToInt32(s == "" ? "0" : s);
                model.Checker_Code = ds.Tables[0].Rows[0]["Checker_Code"] + "";
                model.Check_Time = ds.Tables[0].Rows[0]["Check_Time"] + "";
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
            strSql.Append(" FROM car_other_cost ");
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
            strSql.Append("select * FROM car_other_cost");
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
            strSql.Append("select * FROM car_other_cost");
            if (code.Trim() != "")
            {
                strSql.Append(" where Code='" + code + "'");
            }
            DataTable tb = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (tb != null && tb.Rows.Count > 0) { value = tb.Rows[0]["Tittle"] + ""; }
            return value;
        }

        #endregion  Method
    }
}