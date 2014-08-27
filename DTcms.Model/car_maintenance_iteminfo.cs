using System;
namespace DTcms.Model
{
    /// <summary>
    /// 保养项目信息
    /// </summary>
    [Serializable]
    public partial class car_maintenance_iteminfo
    {
        public car_maintenance_iteminfo()
        { }
        #region Model
        private int _ID;
        private string _Code;
        private string _Maintenance_Item_Name;
        private decimal _Cost = 0;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }

        /// <summary>
        /// 
        /// </summary>
        public decimal Cost
        {
            set { _Cost = value; }
            get { return _Cost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _Code = value; }
            get { return _Code; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Maintenance_Item_Name
        {
            set { _Maintenance_Item_Name = value; }
            get { return _Maintenance_Item_Name; }
        }
        #endregion Model
    }
}