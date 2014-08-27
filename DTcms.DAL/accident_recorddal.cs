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
    public partial class accident_recorddal
    {
        public accident_recorddal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from accident_record");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
//        ID
//Code
//Car_Number
//Driver_Code
//Dept_Code
//Accident_Time
//Address
//Injured
//LostCost
//Duty
//Fine
//PayCost
//NoPayCost
//Accident_Reason
//Image1
//Image2
//Image3
//Image4
        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string code)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from accident_record");
            strSql.Append(" where Code=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.accident_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into accident_record(");
            strSql.Append("Code,Car_Number,Driver_Code,Dept_Code,Accident_Time,Address,Injured,LostCost,Duty,Fine,PayCost,NoPayCost,Accident_Reason,Image1,Image2,Image3,Image4)");
            strSql.Append(" values (");
            strSql.Append("@code,@carnumber,@drivercode,@deptcode,@accidenttime,@address,@injured,@lostcost,@duty,@fine,@paycost,@nopaycost,@accidentreason,@image1,@image2,@image3,@image4)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,26),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@drivercode", SqlDbType.NVarChar,26),
					new SqlParameter("@deptcode", SqlDbType.NVarChar,26),
					new SqlParameter("@accidenttime", SqlDbType.NVarChar,26),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@injured", SqlDbType.NVarChar,200),
					new SqlParameter("@lostcost", SqlDbType.Decimal,10),
					new SqlParameter("@duty", SqlDbType.NVarChar,26),
					new SqlParameter("@fine", SqlDbType.Decimal,10),
					new SqlParameter("@paycost", SqlDbType.Decimal,10),
					new SqlParameter("@nopaycost", SqlDbType.Decimal,10),
					new SqlParameter("@accidentreason", SqlDbType.NVarChar,1000),
					new SqlParameter("@image1", SqlDbType.NVarChar,100),
					new SqlParameter("@image2", SqlDbType.NVarChar,100),
					new SqlParameter("@image3", SqlDbType.NVarChar,100),
					new SqlParameter("@image4", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Car_Number;
            parameters[2].Value = model.Driver.Driver_Code;
            parameters[3].Value = model.Department.Dept_Code;
            parameters[4].Value = model.Accident_Time;
            parameters[5].Value = model.Address;
            parameters[6].Value = model.Injured;
            parameters[7].Value = model.LostCost;
            parameters[8].Value = model.Duty;
            parameters[9].Value = model.Fine;
            parameters[10].Value = model.PayCost;
            parameters[11].Value = model.NoPayCost;
            parameters[12].Value = model.Accident_Reason;
            parameters[13].Value = model.Image1;
            parameters[14].Value = model.Image2;
            parameters[15].Value = model.Image3;
            parameters[16].Value = model.Image4;

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
            strSql.Append("update accident_record set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.accident_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update accident_record set ");
            strSql.Append("Car_Number=@carnumber,");
            strSql.Append("Driver_Code=@drivercode,");
            strSql.Append("Dept_Code=@deptcode,");
            strSql.Append("Accident_Time=@accidenttime,");
            strSql.Append("Address=@address,");
            strSql.Append("Injured=@injured,");
            strSql.Append("LostCost=@lostcost,");
            strSql.Append("Duty=@duty,");
            strSql.Append("Fine=@fine,");
            strSql.Append("PayCost=@paycost,");
            strSql.Append("NoPayCost=@nopaycost,");
            strSql.Append("Accident_Reason=@accidentreason,");
            strSql.Append("Image1=@image1,");
            strSql.Append("Image2=@image2,");
            strSql.Append("Image3=@image3,");
            strSql.Append("Image4=@image4");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@drivercode", SqlDbType.NVarChar,26),
					new SqlParameter("@deptcode", SqlDbType.NVarChar,26),
					new SqlParameter("@accidenttime", SqlDbType.NVarChar,26),
					new SqlParameter("@address", SqlDbType.NVarChar,200),
					new SqlParameter("@injured", SqlDbType.NVarChar,200),
					new SqlParameter("@lostcost", SqlDbType.Decimal,10),
					new SqlParameter("@duty", SqlDbType.NVarChar,26),
					new SqlParameter("@fine", SqlDbType.Decimal,10),
					new SqlParameter("@paycost", SqlDbType.Decimal,10),
					new SqlParameter("@nopaycost", SqlDbType.Decimal,10),
					new SqlParameter("@accidentreason", SqlDbType.NVarChar,1000),
					new SqlParameter("@image1", SqlDbType.NVarChar,100),
					new SqlParameter("@image2", SqlDbType.NVarChar,100),
					new SqlParameter("@image3", SqlDbType.NVarChar,100),
					new SqlParameter("@image4", SqlDbType.NVarChar,100),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Car_Number;
            parameters[1].Value = model.Driver.Driver_Code;
            parameters[2].Value = model.Department.Dept_Code;
            parameters[3].Value = model.Accident_Time;
            parameters[4].Value = model.Address;
            parameters[5].Value = model.Injured;
            parameters[6].Value = model.LostCost;
            parameters[7].Value = model.Duty;
            parameters[8].Value = model.Fine;
            parameters[9].Value = model.PayCost;
            parameters[10].Value = model.NoPayCost;
            parameters[11].Value = model.Accident_Reason;
            parameters[12].Value = model.Image1;
            parameters[13].Value = model.Image2;
            parameters[14].Value = model.Image3;
            parameters[15].Value = model.Image4;
            parameters[16].Value = model.ID;

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
            strSql.Append("delete from accident_record ");
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
        public Model.accident_recordinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from accident_record ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.accident_recordinfo model = new Model.accident_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.Department = new Model.user_deptinfo();
                model.Department.Dept_Code = ds.Tables[0].Rows[0]["Dept_Code"] + "";
                model.Accident_Time = ds.Tables[0].Rows[0]["Accident_Time"] + "";
                model.Address = ds.Tables[0].Rows[0]["Address"] + "";
                model.Injured = ds.Tables[0].Rows[0]["Injured"] + "";
                string s = ds.Tables[0].Rows[0]["LostCost"] + "";
                model.LostCost = decimal.Parse(s == "" ? "0" : s);
                model.Duty = ds.Tables[0].Rows[0]["Duty"] + "";
                s = ds.Tables[0].Rows[0]["Fine"] + "";
                model.Fine = decimal.Parse(s == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["PayCost"] + "";
                model.PayCost = decimal.Parse(s == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["NoPayCost"] + "";
                model.NoPayCost = decimal.Parse(s == "" ? "0" : s);
                model.Accident_Reason = ds.Tables[0].Rows[0]["Accident_Reason"] + "";
                model.Image1 = ds.Tables[0].Rows[0]["Image1"] + "";
                model.Image2 = ds.Tables[0].Rows[0]["Image2"] + "";
                model.Image3 = ds.Tables[0].Rows[0]["Image3"] + "";
                model.Image4 = ds.Tables[0].Rows[0]["Image4"] + "";
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
        public Model.accident_recordinfo GetModel(string code,string car_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from accident_record");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Code='" + code + "'");
            }
            if (car_name.Trim() != "")
            {
                strSql.Append(" and Car_Number='" + car_name + "'");
            }
            Model.accident_recordinfo model = new Model.accident_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.Department = new Model.user_deptinfo();
                model.Department.Dept_Code = ds.Tables[0].Rows[0]["Dept_Code"] + "";
                model.Accident_Time = ds.Tables[0].Rows[0]["Accident_Time"] + "";
                model.Address = ds.Tables[0].Rows[0]["Address"] + "";
                model.Injured = ds.Tables[0].Rows[0]["Injured"] + "";
                string s = ds.Tables[0].Rows[0]["LostCost"] + "";
                model.LostCost = decimal.Parse(s == "" ? "0" : s);
                model.Duty = ds.Tables[0].Rows[0]["Duty"] + "";
                s = ds.Tables[0].Rows[0]["Fine"] + "";
                model.Fine = decimal.Parse(s == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["PayCost"] + "";
                model.PayCost = decimal.Parse(s == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["NoPayCost"] + "";
                model.NoPayCost = decimal.Parse(s == "" ? "0" : s);
                model.Accident_Reason = ds.Tables[0].Rows[0]["Accident_Reason"] + "";
                model.Image1 = ds.Tables[0].Rows[0]["Image1"] + "";
                model.Image2 = ds.Tables[0].Rows[0]["Image2"] + "";
                model.Image3 = ds.Tables[0].Rows[0]["Image3"] + "";
                model.Image4 = ds.Tables[0].Rows[0]["Image4"] + "";
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
            strSql.Append(" FROM accident_record ");
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
            strSql.Append("select * FROM accident_record");
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
            strSql.Append("select * FROM accident_record");
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