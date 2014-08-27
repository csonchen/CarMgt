using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// 车辆回车登记信息
    /// </summary>
    public partial class car_return_recordbll
    {
        private readonly DAL.car_return_recorddal dal = new DAL.car_return_recorddal();
        public car_return_recordbll()
        { }
        #region  Method

        /// <summary>
        /// 根据回车时间求该回车记录的最终里程
        /// </summary>
        /// <param name="returnTime"></param>
        /// <returns></returns>
        public string GetMileageEnd(string returnTime)
        {
            return dal.GetMileageEnd(returnTime);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        public bool Exists(string code)
        {
            return dal.Exists(code);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCarReturnCost(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarReturnCost(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 按月取得,每月项目数,没有的项目的月份不为一行
        /// </summary>
        public DataSet GetMonthItems(string startDate, string endDate, string date, string strWhere)
        {
            return dal.GetMonthItems(startDate, endDate, date, strWhere);
        }

        /// <summary>
        /// 返回一个随机用户名
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
        public int Add(DTcms.Model.car_return_recordinfo model)
        {
            return dal.Add(model);
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
        public bool Update(DTcms.Model.car_return_recordinfo model)
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
        public DTcms.Model.car_return_recordinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据用户名返回一个实体
        /// </summary>
        public Model.car_return_recordinfo GetModel(string code, string carnumnber)
        {
            return dal.GetModel(code, carnumnber);
        }

        /// <summary>
        /// 根据出车编码获取补助项编码字串
        /// </summary>
        /// <param name="sourcecode"></param>
        /// <returns></returns>
        public Model.car_return_recordinfo GetItemCodes(string sourcecode,string where)
        {
            return dal.GetItemCodes(sourcecode,where);
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
        public DataSet GetCarUseReturnReport(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarUseReturnReport(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetCarDrivers(int Top, string strWhere, string filedOrder)
        {
            return dal.GetCarDrivers(Top, strWhere, filedOrder);
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