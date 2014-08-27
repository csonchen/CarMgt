using System;
namespace DTcms.Model
{
    /// <summary>
    /// 车型信息
    /// </summary>
    [Serializable]
    public partial class work_itemsinfo
    {
        public work_itemsinfo()
        { }
        #region Model
        private int _ID;
        private string _Item_Code;
        private string _Item_Name;
        private decimal _Item_Cost = 0;
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
        public string Item_Code
        {
            set { _Item_Code = value; }
            get { return _Item_Code; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Item_Name
        {
            set { _Item_Name = value; }
            get { return _Item_Name; }
        }
        /// <summary>
        ///
        /// </summary>
        public decimal Item_Cost
        {
            set { _Item_Cost = value; }
            get { return _Item_Cost; }
        }
        #endregion Model
    }
}