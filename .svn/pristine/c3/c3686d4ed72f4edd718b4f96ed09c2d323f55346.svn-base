using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// 维修信息
    /// </summary>
    public partial class car_repair_recordbll
    {
        private readonly DAL.car_repair_recorddal dal = new DAL.car_repair_recorddal();
        public car_repair_recordbll()
        { }
        #region  Method
        /// <summary>
        /// 根据id返回保养维修项编号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetChoiceByCode(int id)
        {
            return dal.GetChoiceByCode(id);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        

        /// <summary>
        /// 检查维修名是否存在
        /// </summary>
        public bool Exists(string typecode)
        {
            return dal.Exists(typecode);
        }

        /// <summary>
        /// 返回一个随机维修名
        /// </summary>
        public string GetRandomCode(int length)
        {
            string temp = Utils.Number(length, true);
            if (Exists(temp))
            {
                return GetRandomCode(length);
            }
            return temp;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.car_repair_recordinfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int AddItem(DTcms.Model.car_repair_recordinfo model)
        {
            return dal.AddItem(model);
        }

        /// <summary>
        /// 更新一条数据（维修项）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int UpdateItem(DTcms.Model.car_repair_recordinfo model)
        {
            return dal.UpdateItem(model);
        }

        /// <summary>
        /// 增加一条数据（保养项）
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddMaintenanceItem(DTcms.Model.car_repair_recordinfo model)
        {
            return dal.AddMaintenanceItem(model);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.car_repair_recordinfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.car_repair_recordinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据维修名返回一个实体
        /// </summary>
        public Model.car_repair_recordinfo GetModel(string code,string typename)
        {
            return dal.GetModel(code, typename);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetListItems(int Top, string strWhere, string filedOrder)
        {
            return dal.GetListItems(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCarRepairCost(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarRepairCost(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 根据维修单编码查找维修项记录
        /// </summary>
        /// <param name="repairRecodeCode"></param>
        /// <returns></returns>
        public DataSet GetRepairItemList(string repairRecordCode)
        {
            return dal.GetRepairItemList(repairRecordCode);
        }

        /// <summary>
        /// 根据维修单编码查找保养项记录
        /// </summary>
        /// <param name="repairRecordCode"></param>
        /// <returns></returns>
        public DataSet GetMaintenanceItemList(string repairRecordCode)
        {
            return dal.GetMaintenanceItemList(repairRecordCode);
        }

        /// <summary>
        /// 根据维修单编码查找维修项id
        /// </summary>
        /// <param name="repairRecordCode"></param>
        /// <returns></returns>
        public DataSet GetRepairItemsID(string repairRecordCode)
        {
            return dal.GetRepairItemsID(repairRecordCode);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }
        #endregion  Method
    }
}