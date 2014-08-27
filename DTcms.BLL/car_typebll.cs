using System;
using System.Data;
using System.Collections.Generic;
using DTcms.Common;

namespace DTcms.BLL
{
    /// <summary>
    /// �û���Ϣ
    /// </summary>
    public partial class car_typebll
    {
        private readonly DAL.car_typedal dal = new DAL.car_typedal();
        public car_typebll()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        public string GetMaxCode()
        {
            return dal.GetMaxCode();
        }

        /// <summary>
        /// ����û����Ƿ����
        /// </summary>
        public bool Exists(string typecode)
        {
            return dal.Exists(typecode);
        }

        /// <summary>
        /// ����һ������û���
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
        /// ����һ������
        /// </summary>
        public int Add(DTcms.Model.car_typeinfo model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// �޸�һ������
        /// </summary>
        public int UpdateField(int id, string strValue)
        {
            return dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(DTcms.Model.car_typeinfo model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public DTcms.Model.car_typeinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// �����û�������һ��ʵ��
        /// </summary>
        public Model.car_typeinfo GetModel(string code,string typename)
        {
            return dal.GetModel(code, typename);
        }

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// ��ò�ѯ��ҳ����
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