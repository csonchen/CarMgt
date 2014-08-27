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
    public partial class car_return_recorddal
    {
        public car_return_recorddal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from car_return_record");
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
            strSql.Append("select count(1) from car_return_record");
            strSql.Append(" where Code=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCarReturnCost(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM (select crr.Return_Time Return_Time,crr.Cost Cost,crr.BridgeCost BridgeCost,car.Dept_Pros from car_return_record crr left join car_info car on crr.Car_Number=car.Car_Number) t ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 按月取得,每月项目数,没有的项目的月份不为一行
        /// </summary>
        public DataSet GetMonthItems(string startDate, string endDate, string date, string strWhere)
        {
            //select (datepart(year,Return_Time)-year('2013/4/1 0:00:00'))*12+datepart(month,Return_Time)-month('2013/4/1 0:00:00') as months ,count(*) as total from car_return_record crr left join car_info car on car.Car_Number=crr.Car_Number where Return_Time>'2013/4/1 0:00:00' and Return_Time<'2014/8/1 0:00:00' group by datepart(year,Return_Time),datepart(month,Return_Time)
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select (datepart(year,");
            strSql.Append(date);
            strSql.Append(")-year('");
            strSql.Append(startDate);
            strSql.Append("'))*12+datepart(month,");
            strSql.Append(date);
            strSql.Append(")-month('");
            strSql.Append(startDate);
            strSql.Append("') as months ,count(*) as total from car_return_record crr left join car_info car on car.Car_Number=crr.Car_Number");
            strSql.Append(" where ");
            strSql.Append(date);
            strSql.Append(">'");
            strSql.Append(startDate);
            strSql.Append("' and ");
            strSql.Append(date);
            strSql.Append("<'");
            strSql.Append(endDate);
            if (strWhere != "")
            {
                strSql.Append("' and ");
                strSql.Append(strWhere);
            }
            else
                strSql.Append("'");
            strSql.Append(" group by datepart(year,");
            strSql.Append(date);
            strSql.Append("),datepart(month,");
            strSql.Append(date);
            strSql.Append(")");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.car_return_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into car_return_record(");
            strSql.Append("Code,Car_Number,Source_Code,Return_Time,Mileage_End,User_Time_Number,Kilometer,Cost,BridgeCost,Item_Code)");
            strSql.Append(" values (");
            strSql.Append("@code,@carnumber,@sourcecode,@returntime,@mileageend,@usertimenumber,@kilometer,@cost,@bridgecost,@itemcode)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,26),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@sourcecode", SqlDbType.NVarChar,26),
					new SqlParameter("@returntime", SqlDbType.NVarChar,26),
					new SqlParameter("@mileageend", SqlDbType.Int,10),
					new SqlParameter("@usertimenumber", SqlDbType.Int,10),
					new SqlParameter("@kilometer", SqlDbType.Int,10),
					new SqlParameter("@cost", SqlDbType.Decimal,10),
					new SqlParameter("@bridgecost", SqlDbType.Decimal,10),
                    new SqlParameter("@itemcode",SqlDbType.NVarChar,25)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Car_Number;
            parameters[2].Value = model.Source_Code;
            parameters[3].Value = model.Return_Time;
            parameters[4].Value = model.Mileage_End;
            parameters[5].Value = model.User_Time_Number;
            parameters[6].Value = model.Kilometer;
            parameters[7].Value = model.Cost;
            parameters[8].Value = model.BridgeCost;
            parameters[9].Value = model.Item_Code;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                StringBuilder sqlcar = new StringBuilder("update car_info set Status=0 where Car_Number='" + model.Car_Number + "'");
                DbHelperSQL.ExecuteSql(sqlcar.ToString());//更改车辆使用状态
                StringBuilder sqlcaruse = new StringBuilder("update car_use_record set Status=5 where Car_Number='" + model.Car_Number + "' and Code='" + model.Source_Code + "'");
                DbHelperSQL.ExecuteSql(sqlcaruse.ToString());//更改车辆使用单状态
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update car_return_record set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.car_return_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update car_return_record set ");
            strSql.Append("Car_Number=@carnumber");
            strSql.Append(",Source_Code=@sourcecode");
            strSql.Append(",Return_Time=@returntime");
            strSql.Append(",Mileage_End=@mileageend");
            strSql.Append(",User_Time_Number=@usertimenumber");
            strSql.Append(",Kilometer=@kilometer");
            strSql.Append(",Cost=@cost");
            strSql.Append(",BridgeCost=@bridgecost");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@sourcecode", SqlDbType.NVarChar,26),
					new SqlParameter("@returntime", SqlDbType.NVarChar,26),
					new SqlParameter("@mileageend", SqlDbType.NVarChar,26),
					new SqlParameter("@usertimenumber", SqlDbType.Int,10),
					new SqlParameter("@kilometer", SqlDbType.Int,10),
					new SqlParameter("@cost", SqlDbType.Int,10),
					new SqlParameter("@bridgecost", SqlDbType.Int,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Car_Number;
            parameters[1].Value = model.Source_Code;
            parameters[2].Value = model.Return_Time;
            parameters[3].Value = model.Mileage_End;
            parameters[4].Value = model.User_Time_Number;
            parameters[5].Value = model.Kilometer;
            parameters[6].Value = model.Cost;
            parameters[7].Value = model.BridgeCost;
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
            strSql.Append("delete from car_return_record ");
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
        public Model.car_return_recordinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from car_return_record ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.car_return_recordinfo model = new Model.car_return_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Source_Code = ds.Tables[0].Rows[0]["Source_Code"] + "";
                model.Return_Time = ds.Tables[0].Rows[0]["Return_Time"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage_End"] + "";
                model.Mileage_End = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["User_Time_Number"] + "";
                model.User_Time_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Kilometer"] + "";
                model.Kilometer = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["BridgeCost"] + "";
                model.BridgeCost = decimal.Parse(s.Trim() == "" ? "0" : s);
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
        public Model.car_return_recordinfo GetModel(string code,string car_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_return_record");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Code='" + code + "'");
            }
            if (car_name.Trim() != "")
            {
                strSql.Append(" and Type_Name='" + car_name + "'");
            }
            Model.car_return_recordinfo model = new Model.car_return_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Source_Code = ds.Tables[0].Rows[0]["Source_Code"] + "";
                model.Return_Time = ds.Tables[0].Rows[0]["Return_Time"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage_End"] + "";
                model.Mileage_End = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["User_Time_Number"] + "";
                model.User_Time_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Kilometer"] + "";
                model.Kilometer = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["BridgeCost"] + "";
                model.BridgeCost = decimal.Parse(s.Trim() == "" ? "0" : s);
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
            strSql.Append(" FROM car_return_record ");
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
        public DataSet GetCarUseReturnReport(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM (select cur.*,crr.Return_Time Return_Times,crr.Mileage_End,cd.Driver_Name,car.Dept_Pros from car_return_record crr left join car_use_record cur on cur.Code=crr.Source_Code left join dbo.car_driver cd on cd.Driver_Code=cur.Driver_Code left join car_info car on car.Car_Number=cur.Car_Number) t ");
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
        public DataSet GetCarDrivers(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM (select distinct cd.Driver_Code,cd.Driver_Name,crr.Return_Time Return_Times,car.Dept_Pros from car_return_record crr left join car_use_record cur on cur.Code=crr.Source_Code left join dbo.car_driver cd on cd.Driver_Code=cur.Driver_Code left join car_info car on car.Car_Number=cur.Car_Number) t ");
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
            strSql.Append("select * FROM car_return_record");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        public Model.car_return_recordinfo GetItemCodes(string sourcecode,string where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_return_record");
            strSql.Append(" where 1=1");
            if (sourcecode.Trim() != "")
            {
                strSql.Append(" and Source_Code='" + sourcecode + "'");
            }
            if (where.Trim() != "")
            {
                strSql.Append(" and " + where);
            }
            //DataSet ds = DbHelperSQL.Query(strSql.ToString());
            //string itemCode = "";
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    itemCode = ds.Tables[0].Rows[0]["Item_Code"] + "";
            //}

            Model.car_return_recordinfo model = new Model.car_return_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Source_Code = ds.Tables[0].Rows[0]["Source_Code"] + "";
                model.Return_Time = ds.Tables[0].Rows[0]["Return_Time"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage_End"] + "";
                model.Mileage_End = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["User_Time_Number"] + "";
                model.User_Time_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Kilometer"] + "";
                model.Kilometer = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["BridgeCost"] + "";
                model.BridgeCost = decimal.Parse(s.Trim() == "" ? "0" : s);
                //
                model.Item_Code = ds.Tables[0].Rows[0]["Item_Code"] + "";
                return model;
            }
            else
            {
                return null;
            }
            return null;

            //return itemCode;
        }

        /// <summary>
        /// 根据回车时间求该回车记录的最终里程
        /// </summary>
        /// <param name="returnTime"></param>
        /// <returns></returns>
        public string GetMileageEnd(string returnTime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_return_record");
            strSql.Append(" where 1=1");
            if (returnTime.Trim() != "")
            {
                strSql.Append(" and Return_Time = '" + returnTime + "'");
            }
            Model.car_return_recordinfo model = new Model.car_return_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string s = ds.Tables[0].Rows[0]["Mileage_End"] + "";
                model.Mileage_End = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                return model.Mileage_End + "";
            }
            else 
            {
                return "";
            }
        }
        #endregion  Method  
    }
}