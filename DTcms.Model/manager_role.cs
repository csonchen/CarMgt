using System;
using System.Collections.Generic;
namespace DTcms.Model
{
    /// <summary>
    /// ������ɫ:ʵ����
    /// </summary>
    [Serializable]
    public partial class manager_role
    {
        public manager_role()
        { }
        #region Model
        private int _id;
        private string _role_name;
        private int _role_type = 1;
        /// <summary>
        /// ����ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string role_name
        {
            set { _role_name = value; }
            get { return _role_name; }
        }
        /// <summary>
        /// ��ɫ����
        /// </summary>
        public int role_type
        {
            set { _role_type = value; }
            get { return _role_type; }
        }
        #endregion Model

        private List<manager_role_value> _manager_role_values;
        /// <summary>
        /// Ȩ������ 
        /// </summary>
        public List<manager_role_value> manager_role_values
        {
            set { _manager_role_values = value; }
            get { return _manager_role_values; }
        }
    }
}