using System;
namespace DTcms.Model
{
    /// <summary>
    /// 维修项目信息
    /// </summary>
    [Serializable]
    public partial class car_repair_iteminfo
    {
        public car_repair_iteminfo()
        { }
        #region Model
        private int _ID;
        private string _Code;
        private string _Repair_Item_Name;
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
        public string Code
        {
            set { _Code = value; }
            get { return _Code; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Repair_Item_Name
        {
            set { _Repair_Item_Name = value; }
            get { return _Repair_Item_Name; }
        }
        /// <summary>
        ///
        /// </summary>
        public decimal Cost
        {
            set { _Cost = value; }
            get { return _Cost; }
        }
        #endregion Model
    }
}