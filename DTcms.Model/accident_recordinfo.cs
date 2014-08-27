using System;
namespace DTcms.Model
{
    /// <summary>
    /// 车型信息
    /// </summary>
    [Serializable]
    public partial class accident_recordinfo
    {
        public accident_recordinfo()
        { }
        #region Model
        private int _ID;
        private string _Code;
        private string _Car_Number;
        private car_driverinfo _Driver = new car_driverinfo();
        private user_deptinfo _Department = new user_deptinfo();
        private string _Accident_Time;
        private string _Address;
        private string _Injured;
        private decimal _LostCost;
        private string _Duty;
        private decimal _Fine;
        private decimal _PayCost;
        private decimal _NoPayCost;
        private string _Accident_Reason;
        private string _Image1;
        private string _Image2;
        private string _Image3;
        private string _Image4;
        private string _CreateTime;
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
        public string Car_Number
        {
            set { _Car_Number = value; }
            get { return _Car_Number; }
        }
        /// <summary>
        ///
        /// </summary>
        public car_driverinfo Driver
        {
            set { _Driver = value; }
            get { return _Driver; }
        }
        /// <summary>
        ///
        /// </summary>
        public user_deptinfo Department
        {
            set { _Department = value; }
            get { return _Department; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Accident_Time
        {
            set { _Accident_Time = value; }
            get { return _Accident_Time; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Address
        {
            set { _Address = value; }
            get { return _Address; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Injured
        {
            set { _Injured = value; }
            get { return _Injured; }
        }
        /// <summary>
        ///
        /// </summary>
        public decimal LostCost
        {
            set { _LostCost = value; }
            get { return _LostCost; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Duty
        {
            set { _Duty = value; }
            get { return _Duty; }
        }
        /// <summary>
        ///
        /// </summary>
        public decimal Fine
        {
            set { _Fine = value; }
            get { return _Fine; }
        }
        /// <summary>
        ///
        /// </summary>
        public decimal PayCost
        {
            set { _PayCost = value; }
            get { return _PayCost; }
        }
        /// <summary>
        ///
        /// </summary>
        public decimal NoPayCost
        {
            set { _NoPayCost = value; }
            get { return _NoPayCost; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Accident_Reason
        {
            set { _Accident_Reason = value; }
            get { return _Accident_Reason; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Image1
        {
            set { _Image1 = value; }
            get { return _Image1; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Image2
        {
            set { _Image2 = value; }
            get { return _Image2; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Image3
        {
            set { _Image3 = value; }
            get { return _Image3; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Image4
        {
            set { _Image4 = value; }
            get { return _Image4; }
        }
        /// <summary>
        ///
        /// </summary>
        public string CreateTime
        {
            set { _CreateTime = value; }
            get { return _CreateTime; }
        }
        #endregion Model
    }
}