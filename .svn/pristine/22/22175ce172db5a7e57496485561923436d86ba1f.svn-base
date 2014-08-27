using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.cars.repair_record
{
    public partial class car_repair_record_add : Web.UI.ManagePage
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
                if (!new BLL.car_repair_recordbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                txtCode.Text = DateTime.Now.ToString("yyyyMMddHHmmsss");
                BLL.carbll bll = new BLL.carbll();
                DataTable tb = bll.GetList(1000, " 1=1 and Status in(0,1)", " id").Tables[0];
                this.ddlCar_Number.Items.Clear();
                foreach (DataRow dr in tb.Rows)
                {
                    this.ddlCar_Number.Items.Add(new ListItem(dr["Car_Number"].ToString(), dr["Car_Number"].ToString()));
                }
                BLL.car_maintenance_itembll bll1 = new BLL.car_maintenance_itembll();
                DataTable tb1 = bll1.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlMaintenance_Item.Items.Clear();
                foreach (DataRow dr in tb1.Rows)
                {
                    this.ddlMaintenance_Item.Items.Add(new ListItem(dr["Maintenance_Item_Name"].ToString(), dr["Code"].ToString()));
                }
                BLL.car_repair_plantbll bll2 = new BLL.car_repair_plantbll();
                DataTable tb2 = bll2.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlRepair_Plant.Items.Clear();
                foreach (DataRow dr in tb2.Rows)
                {
                    this.ddlRepair_Plant.Items.Add(new ListItem(dr["Repair_Plant_Name"].ToString(), dr["Code"].ToString()));
                }
                BLL.car_driverbll bll3 = new BLL.car_driverbll();
                DataTable tb3 = bll3.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlDriver_Code.Items.Clear();
                foreach (DataRow dr in tb3.Rows)
                {
                    this.ddlDriver_Code.Items.Add(new ListItem(dr["Driver_Name"].ToString(), dr["Driver_Code"].ToString()));
                }
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.car_repair_recordbll bll = new BLL.car_repair_recordbll();
            Model.car_repair_recordinfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            txtRepare_Time.Text = model.Repare_Time;
            ddlCar_Number.SelectedValue = model.Car.Car_Number;
            txtMileage.Text = model.Mileage.ToString();
            txtNext_Mileage.Text = model.Next_Mileage.ToString();
            ddlMaintenance_Item.SelectedValue = model.Maintenance_Item.Code;
            ddlRepair_Plant.SelectedValue = model.Repair_Plant_Code;
            txtReason.Text = model.Reason;
            ddlDriver_Code.SelectedValue = model.Driver.Driver_Code;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_repair_recordinfo model = new Model.car_repair_recordinfo();
            BLL.car_repair_recordbll bll = new BLL.car_repair_recordbll();
            model.Code = txtCode.Text.Trim();
            model.Repare_Time = txtRepare_Time.Text;
            model.Car = new Model.carinfo();
            model.Car.Car_Number = ddlCar_Number.SelectedValue;
            string s = txtMileage.Text;
            model.Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtNext_Mileage.Text;
            model.Next_Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            model.Maintenance_Item = new Model.car_maintenance_iteminfo();
            model.Maintenance_Item.Code = ddlMaintenance_Item.SelectedValue;
            model.Repair_Plant_Code = ddlRepair_Plant.SelectedValue;
            model.Reason = txtReason.Text;
            model.Driver = new Model.car_driverinfo();
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            else {
                BLL.carbll carbl = new BLL.carbll();
                carbl.UpdateField(model.Car.Car_Number, " Status=2");
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            BLL.car_repair_recordbll bll = new BLL.car_repair_recordbll();
            Model.car_repair_recordinfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Repare_Time = txtRepare_Time.Text;
            model.Car = new Model.carinfo();
            model.Car.Car_Number = ddlCar_Number.SelectedValue;
            string s = txtMileage.Text;
            model.Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtNext_Mileage.Text;
            model.Next_Mileage = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            model.Maintenance_Item = new Model.car_maintenance_iteminfo();
            model.Maintenance_Item.Code = ddlMaintenance_Item.SelectedValue;
            model.Repair_Plant_Code = ddlRepair_Plant.SelectedValue;
            model.Reason = txtReason.Text;
            model.Driver = new Model.car_driverinfo();
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;

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
                JscriptMsg("修改维修信息成功啦！", "car_repair_record_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.car_repair_recordbll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加维修信息成功啦！", "car_repair_record_list.aspx", "Success");
            }
        }

    }
}