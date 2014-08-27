using System;
namespace DTcms.Model
{
    /// <summary>
    /// 管理员信息
    /// </summary>
    [Serializable]
    public partial class manager
    {
        public manager()
        { }
        #region Model
        private int _id;
        private int _role_id;
        private int _role_type = 1;
        private string _user_name;
        private string _user_pwd;
        private string _real_name;
        private string _telephone;
        private string _email;
        private user_deptinfo _DeptInfo = new user_deptinfo();
        private user_roleinfo _RoleInfo = new user_roleinfo();
        private int _is_lock = 0;
        private DateTime _add_time = DateTime.Now;
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 系统标识
        /// </summary>
        public int role_id
        {
            set { _role_id = value; }
            get { return _role_id; }
        }
        /// <summary>
        /// 角色类型
        /// </summary>
        public int role_type
        {
            set { _role_type = value; }
            get { return _role_type; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string user_pwd
        {
            set { _user_pwd = value; }
            get { return _user_pwd; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string real_name
        {
            set { _real_name = value; }
            get { return _real_name; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 部门
        /// </summary>
        public user_deptinfo DeptInfo
        {
            set { _DeptInfo = value; }
            get { return _DeptInfo; }
        }
        /// <summary>
        /// 角色
        /// </summary>
        public user_roleinfo RoleInfo
        {
            set { _RoleInfo = value; }
            get { return _RoleInfo; }
        }
        /// <summary>
        /// 是否禁用
        /// </summary>
        public int is_lock
        {
            set { _is_lock = value; }
            get { return _is_lock; }
        }
        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime add_time
        {
            set { _add_time = value; }
            get { return _add_time; }
        }
        #endregion Model

    }
}