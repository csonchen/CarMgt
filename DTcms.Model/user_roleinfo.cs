using System;
namespace DTcms.Model
{
    /// <summary>
    /// 角色信息
    /// </summary>
    [Serializable]
    public partial class user_roleinfo
    {
        public user_roleinfo()
        { }
        #region Model
        private int _ID;
        private string _Role_Code;
        private string _Role_Name;
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
        public string Role_Code
        {
            set { _Role_Code = value; }
            get { return _Role_Code; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Role_Name
        {
            set { _Role_Name = value; }
            get { return _Role_Name; }
        }
        #endregion Model
    }
}