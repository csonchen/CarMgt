using System;
namespace DTcms.Model
{
    /// <summary>
    /// 车型信息
    /// </summary>
    [Serializable]
    public partial class car_typeinfo
    {
        public car_typeinfo()
        { }
        #region Model
        private int _ID;
        private string _Type_Code;
        private string _Type_Name;
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
        public string Type_Code
        {
            set { _Type_Code = value; }
            get { return _Type_Code; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Type_Name
        {
            set { _Type_Name = value; }
            get { return _Type_Name; }
        }
        #endregion Model
    }
}