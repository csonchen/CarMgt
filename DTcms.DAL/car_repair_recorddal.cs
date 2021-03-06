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
    public partial class car_repair_recorddal
    {
        public car_repair_recorddal()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from car_repair_record");
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
            strSql.Append("select count(1) from car_repair_record");
            strSql.Append(" where Code=@code ");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,100)};
            parameters[0].Value = code;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.car_repair_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into car_repair_record(");
            strSql.Append("Code,Repare_Time,Car_Number,Mileage,Next_Mileage,Maintenance_Item_Code,Reason,Repair_Plant_Code,Driver_Code,Choice,Repare_Time_Finish,Cost,Report)");
            strSql.Append(" values (");
            strSql.Append("@code,@reparetime,@carnumber,@mileage,@nextmileage,@maintenanceitemcode,@reason,@repairplantcode,@drivercode,@choice,@reparetimefinish,@cost,@report)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@code", SqlDbType.NVarChar,26),
					new SqlParameter("@reparetime", SqlDbType.NVarChar,26),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@mileage", SqlDbType.Int,10),
					new SqlParameter("@nextmileage", SqlDbType.Int,10),
					new SqlParameter("@maintenanceitemcode", SqlDbType.NVarChar,26),
					new SqlParameter("@reason", SqlDbType.NVarChar,1000),
					new SqlParameter("@repairplantcode", SqlDbType.NVarChar,26),
					new SqlParameter("@drivercode", SqlDbType.NVarChar,26),
                    new SqlParameter("@choice",SqlDbType.NVarChar,10),
                    new SqlParameter("@reparetimefinish", SqlDbType.NVarChar,26),
                    new SqlParameter("@cost",SqlDbType.Decimal,18),
                    new SqlParameter("@report", SqlDbType.NVarChar,1000)};
            parameters[0].Value = model.Code;
            parameters[1].Value = model.Repare_Time;
            parameters[2].Value = model.Car.Car_Number;
            parameters[3].Value = model.Mileage;
            parameters[4].Value = model.Next_Mileage;
            parameters[5].Value = model.Maintenance_Item.Code;
            parameters[6].Value = model.Reason;
            parameters[7].Value = model.Repair_Plant_Code;
            parameters[8].Value = model.Driver.Driver_Code;
            parameters[9].Value = model.Choice;
            parameters[10].Value = model.Repare_Time_Finish;
            parameters[11].Value = model.Cost;
            parameters[12].Value = model.Report;

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

        //插入维修项
        public int AddItem(Model.car_repair_recordinfo model)
        {
            int value = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from car_repair_record_items where Repair_Record_Code='" + model.Code + "'");
            value = DbHelperSQL.ExecuteSql(strSql.ToString());
            for (int i = 0; i < model.Car_Repair_Items.Count; i++)
            {
                Model.car_repair_iteminfo iteminfo = model.Car_Repair_Items[i];
                strSql = new StringBuilder();
                strSql.Append("insert into car_repair_record_items(Repair_Record_Code,Repair_Item_Code,Cost)");
                strSql.Append(" values('" + model.Code + "','" + iteminfo.Code + "'," + iteminfo.Cost + ")");
                value += DbHelperSQL.ExecuteSql(strSql.ToString());
            }
            return value;
        }

        //插入保养项
        public int AddMaintenanceItem(Model.car_repair_recordinfo model)
        {
            int value = 0;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from car_maintenance_record_items where Repair_Record_Code='" + model.Code + "'");
            value = DbHelperSQL.ExecuteSql(strSql.ToString());
            for (int i = 0; i < model.Car_Maintenance_Items.Count; i++)
            {
                Model.car_maintenance_iteminfo iteminfo = model.Car_Maintenance_Items[i];
                strSql.Append("insert into car_maintenance_record_items(Repair_Record_Code,Maintenance_Item_Code,Cost)");
                strSql.Append(" values('" + model.Code + "','" + iteminfo.Code + "'," + iteminfo.Cost + ")");
                value += DbHelperSQL.ExecuteSql(strSql.ToString());
            }
            return value;
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update car_repair_record set " + strValue);
            strSql.Append(" where id=" + id);
            return DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.car_repair_recordinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update car_repair_record set ");
            strSql.Append("Repare_Time=@reparetime");
            strSql.Append(",Car_Number=@carnumber");
            strSql.Append(",Mileage=@mileage");
            strSql.Append(",Next_Mileage=@nextmileage");
            strSql.Append(",Maintenance_Item_Code=@maintenanceitemcode");
            strSql.Append(",Reason=@reason");
            strSql.Append(",Repair_Plant_Code=@repairplantcode");
            strSql.Append(",Driver_Code=@drivercode");
            strSql.Append(",Repare_Time_Finish=@reparetimefinish");
            strSql.Append(",Cost=@cost");
            strSql.Append(",Report=@report");
            strSql.Append(",Choice=@choice");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@reparetime", SqlDbType.NVarChar,26),
					new SqlParameter("@carnumber", SqlDbType.NVarChar,26),
					new SqlParameter("@mileage", SqlDbType.Int,10),
					new SqlParameter("@nextmileage", SqlDbType.Int,10),
					new SqlParameter("@maintenanceitemcode", SqlDbType.NVarChar,26),
					new SqlParameter("@reason", SqlDbType.NVarChar,1000),
					new SqlParameter("@repairplantcode", SqlDbType.NVarChar,26),
					new SqlParameter("@drivercode", SqlDbType.NVarChar,26),
                    new SqlParameter("@reparetimefinish", SqlDbType.NVarChar,26),
					new SqlParameter("@cost", SqlDbType.Decimal,18),
					new SqlParameter("@report", SqlDbType.NVarChar,1000),
                    new SqlParameter("@choice",SqlDbType.NVarChar,10),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.Repare_Time;
            parameters[1].Value = model.Car.Car_Number;
            parameters[2].Value = model.Mileage;
            parameters[3].Value = model.Next_Mileage;
            parameters[4].Value = model.Maintenance_Item.Code;
            parameters[5].Value = model.Reason;
            parameters[6].Value = model.Repair_Plant_Code;
            parameters[7].Value = model.Driver.Driver_Code;
            parameters[8].Value = model.Repare_Time_Finish;
            parameters[9].Value = model.Cost;
            parameters[10].Value = model.Report;
            parameters[11].Value = model.Choice;
            parameters[12].Value = model.ID;

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
            strSql.Append("delete from car_repair_record ");
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
        public Model.car_repair_recordinfo GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from car_repair_record ");
            strSql.Append(" where ID=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.car_repair_recordinfo model = new Model.car_repair_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Repare_Time = ds.Tables[0].Rows[0]["Repare_Time"] + "";
                model.Car = new Model.carinfo();
                model.Car.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage"] + "";
                model.Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Next_Mileage"] + "";
                model.Next_Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                model.Maintenance_Item = new Model.car_maintenance_iteminfo();
                model.Maintenance_Item.Code = ds.Tables[0].Rows[0]["Maintenance_Item_Code"] + "";
                model.Reason = ds.Tables[0].Rows[0]["Reason"] + "";
                model.Repair_Plant_Code = ds.Tables[0].Rows[0]["Repair_Plant_Code"] + "";
                model.Repare_Time_Finish = ds.Tables[0].Rows[0]["Repare_Time_Finish"] + "";
                model.Report = ds.Tables[0].Rows[0]["Report"] + "";
                s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.Choice = ds.Tables[0].Rows[0]["Choice"] + "";
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
        public Model.car_repair_recordinfo GetModel(string code, string reparetime)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_repair_record");
            strSql.Append(" where 1=1");
            if (code.Trim() != "")
            {
                strSql.Append(" and Code='" + code + "'");
            }
            if (reparetime.Trim() != "")
            {
                strSql.Append(" and Repare_Time='" + reparetime + "'");
            }
            Model.car_repair_recordinfo model = new Model.car_repair_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                string strid = ds.Tables[0].Rows[0]["ID"] + "";
                model.ID = Convert.ToInt32(strid == "" ? "0" : strid);
                model.Code = ds.Tables[0].Rows[0]["Code"] + "";
                model.Repare_Time = ds.Tables[0].Rows[0]["Repare_Time"] + "";
                model.Car = new Model.carinfo();
                model.Car.Car_Number = ds.Tables[0].Rows[0]["Car_Number"] + "";
                string s = ds.Tables[0].Rows[0]["Mileage"] + "";
                model.Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                s = ds.Tables[0].Rows[0]["Next_Mileage"] + "";
                model.Next_Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
                model.Maintenance_Item = new Model.car_maintenance_iteminfo();
                model.Maintenance_Item.Code = ds.Tables[0].Rows[0]["Maintenance_Item_Code"] + "";
                model.Reason = ds.Tables[0].Rows[0]["Reason"] + "";
                model.Repair_Plant_Code = ds.Tables[0].Rows[0]["Repair_Plant_Code"] + "";
                model.Repare_Time_Finish = ds.Tables[0].Rows[0]["Repare_Time_Finish"] + "";
                model.Report = ds.Tables[0].Rows[0]["Report"] + "";
                s = ds.Tables[0].Rows[0]["Cost"] + "";
                model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
                model.Driver = new Model.car_driverinfo();
                model.Driver.Driver_Code = ds.Tables[0].Rows[0]["Driver_Code"] + "";
                model.Choice = ds.Tables[0].Rows[0]["Choice"] + "";
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
            strSql.Append(" FROM car_repair_record ");
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
        public DataSet GetListItems(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM car_repair_record_items ");
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
        public DataSet GetCarRepairCost(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM car_repair_record crr left join car_info car on car.Car_Number=crr.Car_Number ");
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
            strSql.Append("select * FROM car_repair_record");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 根据维修单编码查找维修项记录
        /// </summary>
        /// <param name="repairRecordCode"></param>
        /// <returns></returns>
    
        public DataSet GetRepairItemList(string repairRecordCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from car_repair_record_items");
            if (repairRecordCode.Trim() != "")
            {
                strSql.Append(" where Repair_Record_Code = " + repairRecordCode);
            }
            return DbHelperSQL.Query(strSql.ToString()) ;
        }

        /// <summary>
        /// 根据维修单编码查找保养项记录
        /// </summary>
        /// <param name="repairRecordCode"></param>
        /// <returns></returns>
        public DataSet GetMaintenanceItemList(string repairRecordCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from car_maintenance_record_items");
            if (repairRecordCode.Trim() != "")
            {
                strSql.Append(" where Repair_Record_Code = " + repairRecordCode);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新一条数据（维修项）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateItem(Model.car_repair_recordinfo model)
        {
            int value = 0;
            StringBuilder strSql = new StringBuilder();
            for (int i = 0; i < model.Car_Repair_Items.Count; i++)
            {
                Model.car_repair_iteminfo iteminfo = model.Car_Repair_Items[i];
                strSql = new StringBuilder();
                strSql.Append("update car_repair_record_items set ");
                strSql.Append("Repair_Item_Code=@repairitemcode");
                strSql.Append(",Cost=@cost");
                strSql.Append(" where id=@id");
                SqlParameter[] parameters = { 
                    new SqlParameter("@repairitemcode",SqlDbType.VarChar,26),
                    new SqlParameter("@cost",SqlDbType.Decimal,18),
                    new SqlParameter("@id",SqlDbType.Int,4)};
                parameters[0].Value = iteminfo.Code;
                parameters[1].Value = iteminfo.Cost;
                parameters[2].Value = iteminfo.ID;
                value += DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            }
            return value;
        }
        #endregion  Method

        /// <summary>
        /// 根据维修单编码返回结果集
        /// </summary>
        /// <param name="repairRecordCode"></param>
        /// <returns></returns>
        public DataSet GetRepairItemsID(string repairRecordCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from car_repair_record_items");
            if(repairRecordCode.Trim() != "")
            {
                strSql.Append(" where Repair_Record_Code = " + repairRecordCode);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据id返回保养维修项编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetChoiceByCode(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 * from car_repair_record where ID=@id");
            SqlParameter[] parameters = { new SqlParameter("@id",SqlDbType.Int,8)};
            parameters[0].Value = id;
            Model.car_repair_recordinfo model = new Model.car_repair_recordinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(),parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string choice = ds.Tables[0].Rows[0]["Choice"] + "";
                return choice;
            }
            else
            {
                return "";
            }
        }
    }
}