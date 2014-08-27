using System;
namespace DTcms.Model
{
    /// <summary>
    /// 车型信息
    /// </summary>
    [Serializable]
    public partial class carinfo
    {
        public carinfo()
        { }
        #region Model
        private int _ID;
        private string _Car_Number;
        private string _Car_Name;
        private car_typeinfo _Car_Type = new car_typeinfo();
        private car_driverinfo _Driver = new car_driverinfo();
        private string _Buy_Date;
        private double _Price = 0;
        private int _Mileage_First = 0;
        private int _Status = 0;
        private float _Oil_Consumption = 0;
        private string _Engine_Number;
        private string _Frame_Number;
        private float _Weight = 0;
        private int _Seat = 0;
        private string _cContent;
        private string _Image1;
        private string _Image2;
        private string _Dept_Pros;
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
        public string Car_Number
        {
            set { _Car_Number = value; }
            get { return _Car_Number; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Car_Name
        {
            set { _Car_Name = value; }
            get { return _Car_Name; }
        }
        /// <summary>
        ///
        /// </summary>
        public car_typeinfo Car_Type
        {
            set { _Car_Type = value; }
            get { return _Car_Type; }
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
        public string Buy_Date
        {
            set { _Buy_Date = value; }
            get { return _Buy_Date; }
        }
        /// <summary>
        ///
        /// </summary>
        public double Price
        {
            set { _Price = value; }
            get { return _Price; }
        }
        /// <summary>
        ///
        /// </summary>
        public int Mileage_First
        {
            set { _Mileage_First = value; }
            get { return _Mileage_First; }
        }
        /// <summary>
        ///0在库中,1使用中,2维修中
        /// </summary>
        public int Status
        {
            set { _Status = value; }
            get { return _Status; }
        }
        /// <summary>
        ///
        /// </summary>
        public float Oil_Consumption
        {
            set { _Oil_Consumption = value; }
            get { return _Oil_Consumption; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Engine_Number
        {
            set { _Engine_Number = value; }
            get { return _Engine_Number; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Frame_Number
        {
            set { _Frame_Number = value; }
            get { return _Frame_Number; }
        }
        /// <summary>
        ///
        /// </summary>
        public float Weight
        {
            set { _Weight = value; }
            get { return _Weight; }
        }
        /// <summary>
        ///
        /// </summary>
        public int Seat
        {
            set { _Seat = value; }
            get { return _Seat; }
        }
        /// <summary>
        ///
        /// </summary>
        public string cContent
        {
            set { _cContent = value; }
            get { return _cContent; }
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
        public string Dept_Pros
        {
            set { _Dept_Pros = value; }
            get { return _Dept_Pros; }
        }
        #endregion Model
    }
}