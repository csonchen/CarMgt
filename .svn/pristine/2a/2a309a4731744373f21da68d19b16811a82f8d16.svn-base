using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;

namespace DTcms.Web.admin.cars.norules
{
    public partial class norules_edit : Web.UI.ManagePage
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
                if (!new BLL.norulesbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                carbll carbll = new carbll();
                DataTable tbcar = carbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlCar_Number.Items.Clear();
                foreach (DataRow dr in tbcar.Rows)
                {
                    this.ddlCar_Number.Items.Add(new ListItem(dr["Car_Number"].ToString(), dr["Car_Number"].ToString()));
                }
                car_driverbll driverbll = new car_driverbll();
                DataTable tbdriver = driverbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlDriver_Code.Items.Clear();
                foreach (DataRow dr in tbdriver.Rows)
                {
                    this.ddlDriver_Code.Items.Add(new ListItem(dr["Driver_Name"].ToString(), dr["Driver_Code"].ToString()));
                }
                norules_classbll rulesclassbll = new norules_classbll();
                DataTable tbrc = rulesclassbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlNoRules_Class_Code.Items.Clear();
                foreach (DataRow dr in tbrc.Rows)
                {
                    this.ddlNoRules_Class_Code.Items.Add(new ListItem(dr["NRules_Name"].ToString(), dr["NRules_Code"].ToString()));
                }
                txtCode.Text = DateTime.Now.ToString("yyyyMMddHHmmsss");
                txtCode.ReadOnly = true;
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.norulesbll bll = new BLL.norulesbll();
            Model.norulesinfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            ddlCar_Number.SelectedValue = model.Car_Number;
            ddlDriver_Code.SelectedValue = model.Driver.Driver_Code;
            txtNoRules_Time.Text = model.NoRules_Time;
            ddlNoRules_Class_Code.SelectedValue = model.NoRules_Class.NRules_Code;
            txtAddress.Text = model.Address;
            txtCost.Text = model.Cost.ToString();
            txtScore.Text = model.Score.ToString();
            txtcContent.Text = model.cContent;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.norulesinfo model = new Model.norulesinfo();
            BLL.norulesbll bll = new BLL.norulesbll();
            model.Code = txtCode.Text.Trim();
            model.Car_Number = ddlCar_Number.SelectedValue;
            model.Driver = new Model.car_driverinfo();
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;
            model.NoRules_Time = txtNoRules_Time.Text;
            model.NoRules_Class = new Model.norules_classinfo();
            model.NoRules_Class.NRules_Code = ddlNoRules_Class_Code.SelectedValue;
            model.Address = txtAddress.Text;
            string s = txtCost.Text;
            model.Cost = decimal.Parse(s == "" ? "0" : s);
            s = txtScore.Text;
            model.Score = Convert.ToInt64(s == "" ? "0" : s);
            model.cContent = txtcContent.Text;

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
            BLL.norulesbll bll = new BLL.norulesbll();
            Model.norulesinfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Car_Number = ddlCar_Number.SelectedValue;
            model.Driver = new Model.car_driverinfo();
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;
            model.NoRules_Time = txtNoRules_Time.Text;
            model.NoRules_Class = new Model.norules_classinfo();
            model.NoRules_Class.NRules_Code = ddlNoRules_Class_Code.SelectedValue;
            model.Address = txtAddress.Text;
            string s = txtCost.Text;
            model.Cost = decimal.Parse(s == "" ? "0" : s);
            s = txtScore.Text;
            model.Score = Convert.ToInt64(s == "" ? "0" : s);
            model.cContent = txtcContent.Text;

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
                JscriptMsg("修改违章成功啦！", "norules_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.norulesbll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加违章成功啦！", "norules_list.aspx", "Success");
            }
        }

    }
}