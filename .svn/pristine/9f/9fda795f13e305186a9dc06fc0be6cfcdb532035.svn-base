using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.cars.car_use_record
{
    public partial class car_use_record_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.car_use_recordbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //绑定类别
                BindDept_Code("");
                BindUser_Code("");
                BindCar_Number("");
                BindDriver_Code("");


                txtCode.Text = System.DateTime.Now.ToString("yyyyMMddHHmmsss");
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }
            }
        }

        #region 绑定类别=================================
        private void BindDept_Code(string strwhere)
        {
            BLL.user_deptbll bll = new BLL.user_deptbll();
            DataTable tb = bll.GetList(1000, strwhere, " id").Tables[0];
            this.ddlDept_Code.Items.Clear();
            this.ddlDept_Code.Items.Add(new ListItem("请选择部门...", ""));
            foreach (DataRow dr in tb.Rows)
            {
                this.ddlDept_Code.Items.Add(new ListItem(dr["Dept_Name"].ToString(), dr["Dept_Code"].ToString()));
            }
        }

        private void BindUser_Code(string strwhere)
        {
            BLL.manager userbll = new BLL.manager();
            DataTable usertb = userbll.GetList(1000, strwhere, " id").Tables[0];
            this.ddlUser_Code.Items.Clear();
            this.ddlUser_Code.Items.Add(new ListItem("请选择用车人...", ""));
            foreach (DataRow dr in usertb.Rows)
            {
                this.ddlUser_Code.Items.Add(new ListItem(dr["real_name"].ToString(), dr["user_name"].ToString()));
            }
        }
        private void BindCar_Number(string strwhere)
        {
            BLL.carbll carbll = new BLL.carbll();
            DataTable cartb = carbll.GetList(1000, strwhere, " id").Tables[0];
            BLL.car_use_recordbll carusebll = new BLL.car_use_recordbll();
            DataTable carusedtb = carusebll.GetList(1000, " Status not in(5)", " id").Tables[0];

            this.ddlCar_Number.Items.Clear();
            this.ddlCar_Number.Items.Add(new ListItem("请选择车牌...", ""));
            foreach (DataRow dr in cartb.Rows)
            {
                bool add = true;
                string car_number = dr["Car_Number"].ToString();
                foreach (DataRow ro in carusedtb.Rows)
                {
                    string carnumber = ro["Car_Number"].ToString();
                    if (carnumber == car_number) { add = false; break; }
                }
                if (!add) { continue; }
                this.ddlCar_Number.Items.Add(new ListItem(car_number, car_number));
            }
        }
        private void BindDriver_Code(string strwhere)
        {
            BLL.car_driverbll driverbll = new BLL.car_driverbll();
            DataTable drivertb = driverbll.GetList(1000, strwhere, " id").Tables[0];
            this.ddlDriver_Code.Items.Clear();
            this.ddlDriver_Code.Items.Add(new ListItem("请选择驾驶员...", ""));
            foreach (DataRow dr in drivertb.Rows)
            {
                this.ddlDriver_Code.Items.Add(new ListItem(dr["Driver_Name"].ToString(), dr["Driver_Code"].ToString()));
            }
        }


        #endregion



        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            Model.car_use_recordinfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            txtUse_Time.Text = model.Use_Time;
            ddlDept_Code.SelectedValue = model.Department.Dept_Code;
            ddlUser_Code.SelectedValue = model.User.user_name;
            ddlCar_Number.SelectedValue = model.Car.Car_Number;
            ddlDriver_Code.SelectedValue = model.Driver.Driver_Code;
            txtStart_Address.Text = model.Start_Address;
            txtMileage_First.Text = model.Mileage_First.ToString();
            txtUser_Number.Text = model.User_Number.ToString();
            txtUContent.Text = model.UContent;
            txtEnd_Address.Text = model.End_Address;
            txtReturn_Time.Text = model.Return_Time;
            txtConnecter.Text = model.Connecter;
            txtTel.Text = model.Tel;
            if (model.OnCity == 1) { Range1.Checked = true; Range2.Checked = false; }
            else if (model.OnCity == 0) { Range1.Checked = false; Range2.Checked = true; }
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_use_recordinfo model = new Model.car_use_recordinfo();
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            model.Code = txtCode.Text.Trim();
            model.Use_Time = txtUse_Time.Text.Trim();
            model.Department.Dept_Code = ddlDept_Code.SelectedValue;
            model.User.user_name = ddlUser_Code.SelectedValue;
            model.Car.Car_Number = ddlCar_Number.SelectedValue;
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;
            model.Start_Address = txtStart_Address.Text.Trim();
            string s = txtMileage_First.Text.Trim();
            model.Mileage_First = Convert.ToInt32(s == "" ? "0" : s);
            s = txtUser_Number.Text.Trim();
            model.User_Number = Convert.ToInt32(s == "" ? "0" : s);
            model.UContent = txtUContent.Text.Trim();
            model.End_Address = txtEnd_Address.Text.Trim();
            model.Return_Time = txtReturn_Time.Text.Trim();
            model.Connecter = txtConnecter.Text.Trim();
            model.Tel = txtTel.Text.Trim();
            model.Status = 1;   //申请 1
            if (Range1.Checked) { model.OnCity = 1; }
            else if (Range2.Checked) { model.OnCity = 0; }

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            Model.car_use_recordinfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Use_Time = txtUse_Time.Text.Trim();
            model.Department.Dept_Code = ddlDept_Code.SelectedValue;
            model.User.user_name = ddlUser_Code.SelectedValue;
            model.Car.Car_Number = ddlCar_Number.SelectedValue;
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;
            model.Start_Address = txtStart_Address.Text.Trim();
            string s = txtMileage_First.Text.Trim();
            model.Mileage_First = Convert.ToInt32(s == "" ? "0" : s);
            s = txtUser_Number.Text.Trim();
            model.User_Number = Convert.ToInt32(s == "" ? "0" : s);
            model.UContent = txtUContent.Text.Trim();
            model.End_Address = txtEnd_Address.Text.Trim();
            model.Return_Time = txtReturn_Time.Text.Trim();
            model.Connecter = txtConnecter.Text.Trim();
            model.Tel = txtTel.Text.Trim();
            if (Range1.Checked) { model.OnCity = 1; }
            else if (Range2.Checked) { model.OnCity = 0; }

            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改车辆使用成功啦！", "car_use_record_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.car_use_recordbll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加车辆使用成功啦！", "car_use_record_list.aspx", "Success");
            }
        }

        protected void ddlDept_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string deptcode = ddlDept_Code.SelectedValue;
            
            BindUser_Code(" Dept_Code='" + deptcode + "'");
        }

        protected void ddlUser_Code_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}