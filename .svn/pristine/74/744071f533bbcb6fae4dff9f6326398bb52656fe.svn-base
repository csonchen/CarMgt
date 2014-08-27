using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.cars.driver
{
    public partial class car_driver_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            BLL.user_deptbll bll = new BLL.user_deptbll();
            DataTable tb = bll.GetList(1000," 1=1 "," id").Tables[0];
            this.ddlDept_Code.Items.Clear();
            foreach (DataRow dr in tb.Rows)
            {
                this.ddlDept_Code.Items.Add(new ListItem(dr["Dept_Name"].ToString(), dr["Dept_Code"].ToString()));
            }
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.car_driverbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.car_driverbll bll = new BLL.car_driverbll();
            Model.car_driverinfo model = bll.GetModel(_id);

            txtDriver_Code.Text = model.Driver_Code;
            txtDriver_Code.ReadOnly = true;
            txtDriver_Name.Text = model.Driver_Name;
            rblSex.SelectedValue = model.Sex;
            txtBirthday.Text = model.Birthday.Replace("0:00:00", "").Trim();
            txtIdentity_Num.Text = model.Identity_Num;
            txtCollarDate.Text = model.CollarDate.Replace("0:00:00", "").Trim();
            txtAddress.Text = model.Address;
            txtDriving_License_Num.Text = model.Driving_License_Num;
            ddlLicense_Type.SelectedValue = model.License_Type;
            txtTelehone.Text = model.Telehone;
            ddlDept_Code.SelectedValue = model.Dept_Code;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_driverinfo model = new Model.car_driverinfo();
            BLL.car_driverbll bll = new BLL.car_driverbll();
            model.Driver_Code = txtDriver_Code.Text;
            model.Driver_Name = txtDriver_Name.Text;
            model.Sex = rblSex.SelectedValue;
            model.Birthday = txtBirthday.Text;
            model.Identity_Num = txtIdentity_Num.Text;
            model.CollarDate = txtCollarDate.Text;
            model.Address = txtAddress.Text;
            model.Driving_License_Num = txtDriving_License_Num.Text;
            model.License_Type = ddlLicense_Type.SelectedValue;
            model.Telehone = txtTelehone.Text;
            model.Dept_Code = ddlDept_Code.SelectedValue;

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
            BLL.car_driverbll bll = new BLL.car_driverbll();
            Model.car_driverinfo model = bll.GetModel(_id);

            model.Driver_Code = txtDriver_Code.Text;
            model.Driver_Name = txtDriver_Name.Text;
            model.Sex = rblSex.SelectedValue;
            model.Birthday = txtBirthday.Text;
            model.Identity_Num = txtIdentity_Num.Text;
            model.CollarDate = txtCollarDate.Text;
            model.Address = txtAddress.Text;
            model.Driving_License_Num = txtDriving_License_Num.Text;
            model.License_Type = ddlLicense_Type.SelectedValue;
            model.Telehone = txtTelehone.Text;
            model.Dept_Code = ddlDept_Code.SelectedValue;

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
                JscriptMsg("修改司机成功啦！", "car_driver_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.car_driverbll().Exists(txtDriver_Code.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加司机成功啦！", "car_driver_list.aspx", "Success");
            }
        }

    }
}