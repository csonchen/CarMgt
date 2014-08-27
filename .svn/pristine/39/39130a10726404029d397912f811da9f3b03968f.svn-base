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
    public partial class car_use_recorddal
    {
        public car_use_recorddal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from car_use_record");
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
            strSql.Append("select count(1) from car_use_record");
            strSql.Append(" where Code=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.car_use_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into car_use_record(");
            strSql.Append("Code,Use_Time,Dept_Code,User_Code,Car_Number,Driver_Code,Start_Address,Mileage_First,User_Number,UContent,End_Address,Return_Time,Connecter,Tel,Status,Checker_Code,Check_Time,Update_Time,Create_Time,OnCity)");
            strSql.Append(" values (");
            strSql.Append("@code,@use_time,@dept_code,@user_code,@car_number,@driver_code,@start_address,@mileage_first,@user_number,@ucontent,@end_address,@return_time,@connecter,@tel,@status,@checker_code,getdate(),getdate(),getdate(),@oncity)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100),
					new SqlParameter("@use_time", SqlDbType.NVarChar,26),
					new SqlParameter("@dept_code", SqlDbType.NVarChar,26),
					new SqlParameter("@user_code", SqlDbType.NVarChar,26),
					new SqlParameter("@car_number", SqlDbType.NVarChar,26),
					new SqlParameter("@driver_code", SqlDbType.NVarChar,26),
					new SqlParameter("@start_address", SqlDbType.NVarChar,200),
					new SqlParameter("@mileage_first", SqlDbType.Int,10),
					new SqlParameter("@user_number", SqlDbType.Int,10),
					new SqlParameter("@ucontent", SqlDbType.NVarChar,1000),
					new SqlParameter("@end_address", SqlDbType.NVarChar,200),
					new SqlParameter("@return_time", SqlDbType.NVarChar,26),
					new SqlParameter("@connecter", SqlDbType.NVarChar,26),
					new SqlParameter("@tel", SqlDbType.NVarChar,26),
					new SqlParameter("@status", SqlDbType.Int,10),
					new SqlParameter("@checker_code", SqlDbType.NVarChar,26),
					new SqlParameter("@oncity", SqlDbType.Int,10)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Use_Time;
            parameters[2].Value = model.Department.Dept_Code;
            parameters[3].Value = model.User.user_name;
            parameters[4].Value = model.Car.Car_Number;
            parameters[5].Value = model.Driver.Driver_Code;
            parameters[6].Value = model.Start_Address;
            parameters[7].Value = model.Mileage_First;
            parameters[8].Value = model.User_Number;
            parameters[9].Value = model.UContent;
            parameters[10].Value = model.End_Address;
            parameters[11].Value = model.Return_Time;
            parameters[12].Value = model.Connecter;
            parameters[13].Value = model.Tel;
            parameters[14].Value = model.Status;
            parameters[15].Value = model.Checker.user_name;
            parameters[16].Value = model.OnCity;

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
            strSql.Append("update car_use_record set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.car_use_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update car_use_record set ");
            strSql.Append("Use_Time=@use_time");
            strSql.Append(",Dept_Code=@dept_code");
            strSql.Append(",User_Code=@user_code");
            strSql.Append(",Car_Number=@car_number");
            strSql.Append(",Driver_Code=@driver_code");
            strSql.Append(",Start_Address=@start_address");
            strSql.Append(",Mileage_First=@mileage_first");
            strSql.Append(",User_Number=@user_number");
            strSql.Append(",UContent=@ucontent");
            strSql.Append(",End_Address=@end_address");
            strSql.Append(",Return_Time=@return_time");
            strSql.Append(",Connecter=@connecter");
            strSql.Append(",Tel=@tel");
            strSql.Append(",Update_Time=getdate()");
            strSql.Append(",OnCity=@oncity");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@use_time", SqlDbType.NVarChar,26),
					new SqlParameter("@dept_code", SqlDbType.NVarChar,26),
					new SqlParameter("@user_code", SqlDbType.NVarChar,26),
					new SqlParameter("@car_number", SqlDbType.NVarChar,26),
					new SqlParameter("@driver_code", SqlDbType.NVarChar,26),
					new SqlParameter("@start_address", SqlDbType.NVarChar,26),
					new SqlParameter("@mileage_first", SqlDbType.Int,10),
					new SqlParameter("@user_number", SqlDbType.Int,10),
					new SqlParameter("@ucontent", SqlDbType.NVarChar,1000),
					new SqlParameter("@end_address", SqlDbType.NVarChar,200),
					new SqlParameter("@return_time", SqlDbType.NVarChar,26),
					new SqlParameter("@connecter", SqlDbType.NVarChar,26),
					new SqlParameter("@tel", SqlDbType.NVarChar,26),
					new SqlParameter("@oncity", SqlDbType.Int,4),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Use_Time;
            parameters[1].Value = model.Department.Dept_Code;
            parameters[2].Value = model.User.user_name;
            parameters[3].Value = model.Car.Car_Number;
            parameters[4].Value = model.Driver.Driver_Code;
            parameters[5].Value = model.Start_Address;
            parameters[6].Value = model.Mileage_First;
            parameters[7].Value = model.User_Number;
            parameters[8].Value = model.UContent;
            parameters[9].Value = model.End_Address;
            parameters[10].Value = model.Return_Time;
            parameters[11].Value = model.Connecter;
            parameters[12].Value = model.Tel;
            parameters[13].Value = model.OnCity;
            parameters[14].Value = model.ID;

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
            strSql.Append("delete from car_use_record ");
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
        public Model.car_use_recordinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from car_use_record ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.car_use_recordinfo model = new Model.car_use_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Use_Time = ds.Tables[0].Rows[0]["Use_Time"] + "";
                model.Department = new Model.user_deptinfo();
                model.Department.Dept_Code = ds.Tables[0].Rows[0]["Dept_Code"] + "";
                model.User = new Model.users();
                model.User.user_name = ds.Tables[0].Rows[0]["User_Code"] + "";
                model.Car = new Model.carinfo();
                model.Car.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.Start_Address = ds.Tables[0].Rows[0]["Start_Address"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage_First"] + "";
                model.Mileage_First = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["User_Number"] + "";
                model.User_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                model.UContent = ds.Tables[0].Rows[0]["UContent"] + "";
                model.End_Address = ds.Tables[0].Rows[0]["End_Address"] + "";
                model.Return_Time = ds.Tables[0].Rows[0]["Return_Time"] + "";
                model.Connecter = ds.Tables[0].Rows[0]["Connecter"] + "";
                model.Tel = ds.Tables[0].Rows[0]["Tel"] + "";
                s = ds.Tables[0].Rows[0]["Status"] + "";
                model.Status = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                model.Checker = new Model.users();
                model.Checker.user_name = ds.Tables[0].Rows[0]["Checker_Code"] + "";
                model.Check_Time = ds.Tables[0].Rows[0]["Check_Time"] + "";
                model.Update_Time = ds.Tables[0].Rows[0]["Update_Time"] + "";
                model.Create_Time = ds.Tables[0].Rows[0]["Create_Time"] + "";
                s = ds.Tables[0].Rows[0]["OnCity"] + "";
                model.OnCity = Convert.ToInt32(s.Trim() == "" ? "0" : s);
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
        public Model.car_use_recordinfo GetModel(string code,string car_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_use_record");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Code='" + code + "'");
            }
            if (car_name.Trim() != "")
            {
                strSql.Append(" and Type_Name='" + car_name + "'");
            }
            Model.car_use_recordinfo model = new Model.car_use_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Use_Time = ds.Tables[0].Rows[0]["Use_Time"] + "";
                model.Department = new Model.user_deptinfo();
                model.Department.Dept_Code = ds.Tables[0].Rows[0]["Dept_Code"] + "";
                model.User = new Model.users();
                model.User.user_name = ds.Tables[0].Rows[0]["User_Code"] + "";
                model.Car = new Model.carinfo();
                model.Car.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.Start_Address = ds.Tables[0].Rows[0]["Start_Address"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage_First"] + "";
                model.Mileage_First = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["User_Number"] + "";
                model.User_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                model.UContent = ds.Tables[0].Rows[0]["UContent"] + "";
                model.End_Address = ds.Tables[0].Rows[0]["End_Address"] + "";
                model.Return_Time = ds.Tables[0].Rows[0]["Return_Time"] + "";
                model.Connecter = ds.Tables[0].Rows[0]["Connecter"] + "";
                model.Tel = ds.Tables[0].Rows[0]["Tel"] + "";
                s = ds.Tables[0].Rows[0]["Status"] + "";
                model.Status = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                model.Checker = new Model.users();
                model.Checker.user_name = ds.Tables[0].Rows[0]["Checker_Code"] + "";
                model.Check_Time = ds.Tables[0].Rows[0]["Check_Time"] + "";
                model.Update_Time = ds.Tables[0].Rows[0]["Update_Time"] + "";
                model.Create_Time = ds.Tables[0].Rows[0]["Create_Time"] + "";
                s = ds.Tables[0].Rows[0]["OnCity"] + "";
                model.OnCity = Convert.ToInt32(s.Trim() == "" ? "0" : s);
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
            strSql.Append(" FROM car_use_record ");
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
        public DataSet GetCarUseRecord(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM car_use_record cau left join car_driver dri on dri.Driver_Code=cau.Driver_Code left join car_info car on car.Car_Number=cau.Car_Number");
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
        public DataSet GetUserCarUseRecord(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" cau.*,crr.Return_Time eReturn_Time,crr.Kilometer,crr.Mileage_End,car.Car_Name,dept.Dept_Name,dri.Driver_Name,mana1.real_name username,mana2.real_name checkername ");
            strSql.Append(" from car_return_record crr left join car_use_record cau on cau.Code=crr.Source_Code left join car_driver dri on dri.Driver_Code=cau.Driver_Code left join car_info car on car.Car_Number=cau.Car_Number left join department dept on cau.Dept_Code=dept.Dept_Code left join dt_manager mana1 on mana1.user_name=cau.User_Code left join dt_manager mana2 on mana2.user_name=cau.Checker_Code");
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
        public DataSet GetCarUseCost(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" from car_return_record crr left join car_info car on car.Car_Number=crr.Car_Number");
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
            strSql.Append("select * FROM car_use_record");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        #endregion  Method
    }
}