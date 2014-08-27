using System;
namespace DTcms.Model
{
    /// <summary>
    /// 车型信息
    /// </summary>
    [Serializable]
    public partial class car_return_recordinfo
    {
        public car_return_recordinfo()
        { }
        #region Model
        private int _ID;
        private string _Code;
        private string _Car_Number;
        private string _Source_Code;
        private string _Return_Time;
        private int _Mileage_End = 0;
        private int _User_Time_Number = 0;
        private int _Kilometer = 0;
        private decimal _Cost = 0;
        private decimal _BridgeCost = 0;
        private int _Car_Status = 0;
        private string _Item_Code;
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
        public string Source_Code
        {
            set { _Source_Code = value; }
            get { return _Source_Code; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Return_Time
        {
            set { _Return_Time = value; }
            get { return _Return_Time; }
        }
        /// <summary>
        ///
        /// </summary>
        public int Mileage_End
        {
            set { _Mileage_End = value; }
            get { return _Mileage_End; }
        }
        /// <summary>
        ///用车时长
        /// </summary>
        public int User_Time_Number
        {
            set { _User_Time_Number = value; }
            get { return _User_Time_Number; }
        }
        /// <summary>
        ///行驶公里
        /// </summary>
        public int Kilometer
        {
            set { _Kilometer = value; }
            get { return _Kilometer; }
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
        public decimal BridgeCost
        {
            set { _BridgeCost = value; }
            get { return _BridgeCost; }
        }
        /// <summary>
        ///
        /// </summary>
        public int Car_Status
        {
            set { _Car_Status = value; }
            get { return _Car_Status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Item_Code
        {
            set { _Item_Code = value; }
            get { return _Item_Code; }
        }
        #endregion Model
    }
}