using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// 保养信息
    /// </summary>
    public partial class car_maintenance_itembll
    {
        private readonly DAL.car_maintenance_itemdal dal = new DAL.car_maintenance_itemdal();
        public car_maintenance_itembll()
        { }
        #region  Method
        public string GetMaxCode()
        {
            return dal.GetMaxCode();
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 检查保养名是否存在
        /// </summary>
        public bool Exists(string typecode)
        {
            return dal.Exists(typecode);
        }

        /// <summary>
        /// 返回一个随机保养名
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
        public int Add(DTcms.Model.car_maintenance_iteminfo model)
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
        public bool Update(DTcms.Model.car_maintenance_iteminfo model)
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
        public DTcms.Model.car_maintenance_iteminfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据保养名返回一个实体
        /// </summary>
        public Model.car_maintenance_iteminfo GetModel(string code,string typename)
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
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public string GetTitleByCode(string code) {
            return dal.GetTitleByCode(code);
        }
        #endregion  Method
    }
}