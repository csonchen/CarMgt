using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.cars.car_return_record
{
    public partial class car_return_record_edit : Web.UI.ManagePage
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
                //if (!new BLL.car_return_recordbll().Exists(this.id))
                //{
                //    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                //    return;
                //}
            }
            if (!Page.IsPostBack)
            {
                //BLL.carbll carbll = new BLL.carbll();
                //DataTable cartb = carbll.GetList(1000, "", " id").Tables[0];
                //this.ddlCar_Number.Items.Clear();
                //foreach (DataRow dr in cartb.Rows)
                //{
                //    this.ddlCar_Number.Items.Add(new ListItem(dr["Car_Name"].ToString(), dr["Car_Number"].ToString()));
                //}
                //绑定补助项
                BLL.work_itemsbll workbll = new BLL.work_itemsbll();
                DataTable workdt = workbll.GetList(1000, "", "ID").Tables[0];
                foreach (DataRow dr in workdt.Rows)
                {
                    //获取补助编号
                    string itemCode = dr["Item_Code"].ToString();
                    //获取补助项说明
                    string itemName = dr["Item_Name"].ToString();
                    ListItem li = new ListItem();
                    if (!("10001".Equals(itemCode)))
                    {
                        li = new ListItem(itemName, itemCode);
                        this.workItem.Items.Add(li);
                    }
                }

                BLL.car_use_recordbll carusebll = new BLL.car_use_recordbll();
                DataTable carusetb = carusebll.GetList(1000, " Status in(4)", " id").Tables[0];
                this.ddlCar_Number.Items.Clear();
                this.ddlCar_Number.Items.Add(new ListItem("请选择车牌...", ""));
                this.ddlSource_Code.Items.Clear();
                this.ddlSource_Code.Items.Add(new ListItem("请选择单号...", ""));
                foreach (DataRow dr in carusetb.Rows)
                {
                    this.ddlCar_Number.Items.Add(new ListItem(dr["Car_Number"].ToString(), dr["Car_Number"].ToString()));
                    this.ddlSource_Code.Items.Add(new ListItem(dr["Code"].ToString(), dr["Code"].ToString()));
                }
                txtCode.Text = System.DateTime.Now.ToString("yyyyMMddHHmmsss");
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.car_return_recordbll bll = new BLL.car_return_recordbll();
            Model.car_return_recordinfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            ddlCar_Number.SelectedValue = model.Car_Number;
            txtReturn_Time.Text = model.Return_Time;
            ddlSource_Code.SelectedValue = model.Source_Code;
            txtKilometer.Text = model.Kilometer.ToString();
            txtUser_Time_Number.Text = model.User_Time_Number.ToString();
            txtMileage_End.Text = model.Mileage_End.ToString();
            txtCost.Text = model.Cost.ToString();
            txtBridgeCost.Text = model.BridgeCost.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_return_recordinfo model = new Model.car_return_recordinfo();
            BLL.car_return_recordbll bll = new BLL.car_return_recordbll();
            model.Code = txtCode.Text.Trim();
            model.Car_Number = ddlCar_Number.SelectedValue;
            model.Return_Time = txtReturn_Time.Text;
            model.Source_Code = ddlSource_Code.SelectedValue;
            string s = txtKilometer.Text;
            model.Kilometer = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtUser_Time_Number.Text;
            model.User_Time_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtMileage_End.Text;
            model.Mileage_End = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtCost.Text;
            model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
            s = txtBridgeCost.Text;
            model.BridgeCost = decimal.Parse(s.Trim() == "" ? "0" : s);
            //获取多选框的内容
            for (int i = 0; i < this.workItem.Items.Count; i++) 
            {
                if (workItem.Items[i].Selected == true)
                {
                    model.Item_Code = model.Item_Code + workItem.Items[i].Value + ",";
                }
            }
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
            BLL.car_return_recordbll bll = new BLL.car_return_recordbll();
            Model.car_return_recordinfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Car_Number = ddlCar_Number.SelectedValue;
            model.Return_Time = txtReturn_Time.Text;
            model.Source_Code = ddlSource_Code.SelectedValue;
            string s = txtKilometer.Text;
            model.Kilometer = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtUser_Time_Number.Text;
            model.User_Time_Number = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtMileage_End.Text;
            model.Mileage_End = Convert.ToInt32(s.Trim() == "" ? "0" : s);
            s = txtCost.Text;
            model.Cost = decimal.Parse(s.Trim() == "" ? "0" : s);
            s = txtBridgeCost.Text;
            model.BridgeCost = decimal.Parse(s.Trim() == "" ? "0" : s);

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
                JscriptMsg("修改车辆回车成功啦！", "car_return_record_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.car_return_recordbll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加车辆回车成功啦！", "car_return_record_list.aspx", "Success");
            }
        }

    }
}