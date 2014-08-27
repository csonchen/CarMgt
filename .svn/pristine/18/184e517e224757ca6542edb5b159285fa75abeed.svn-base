using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;

namespace DTcms.Web.admin.cars.cost
{
    public partial class car_other_cost_edit : Web.UI.ManagePage
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
                if (!new BLL.car_other_costbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                txtCode.Text = DateTime.Now.ToString("yyyyMMddHHmmsss");
                carbll carbll = new carbll();
                DataTable tbcar = carbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlCar_Number.Items.Clear();
                foreach (DataRow dr in tbcar.Rows)
                {
                    this.ddlCar_Number.Items.Add(new ListItem(dr["Car_Number"].ToString(), dr["Car_Number"].ToString()));
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
            BLL.car_other_costbll bll = new BLL.car_other_costbll();
            Model.car_other_costinfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            txtTittle.Text = model.Tittle;
            ddlCar_Number.SelectedValue = model.Car.Car_Number;
            txtCost.Text = model.Cost.ToString();
            ddlType_Code.SelectedValue = model.Type_Code;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_other_costinfo model = new Model.car_other_costinfo();
            BLL.car_other_costbll bll = new BLL.car_other_costbll();
            model.Code = txtCode.Text.Trim();
            model.Tittle = txtTittle.Text;
            model.Car = new Model.carinfo();
            model.Car.Car_Number = ddlCar_Number.SelectedValue;
            string s = txtCost.Text;
            model.Cost = decimal.Parse(s == "" ? "0" : s);
            model.Type_Code = ddlType_Code.SelectedValue;

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
            BLL.car_other_costbll bll = new BLL.car_other_costbll();
            Model.car_other_costinfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Tittle = txtTittle.Text;
            model.Car = new Model.carinfo();
            model.Car.Car_Number = ddlCar_Number.SelectedValue;
            string s = txtCost.Text;
            model.Cost = decimal.Parse(s == "" ? "0" : s);
            model.Type_Code = ddlType_Code.SelectedValue;

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
                JscriptMsg("修改其他费用成功啦！", "car_other_cost_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.car_other_costbll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加其他费用成功啦！", "car_other_cost_list.aspx", "Success");
            }
        }

    }
}