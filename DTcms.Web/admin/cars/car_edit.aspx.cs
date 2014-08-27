using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;
using DTcms.Web.admin.handle;

namespace DTcms.Web.admin.cars
{
    public partial class car_edit : Web.UI.ManagePage
    {
        protected Model.manager admin_info;
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //接收车牌号
            string carNum = DTRequest.GetQueryString("carNum");
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
                if (!new BLL.carbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            admin_info = GetAdminInfo();
            if (!Page.IsPostBack)
            {
                car_typebll cartypebll = new car_typebll();
                DataTable tb = cartypebll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlCar_Type.Items.Clear();
                foreach (DataRow dr in tb.Rows)
                {
                    this.ddlCar_Type.Items.Add(new ListItem(dr["Type_Name"].ToString(), dr["Type_Code"].ToString()));
                }
                car_driverbll cardriverbll = new car_driverbll();
                DataTable tbdriver = cardriverbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlDriver.Items.Clear();
                foreach (DataRow dr in tbdriver.Rows)
                {
                    this.ddlDriver.Items.Add(new ListItem(dr["Driver_Name"].ToString(), dr["Driver_Code"].ToString()));
                }
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

                BLL.carbll bll = new BLL.carbll();
                //根据车牌号查询是否存在
                if (carNum.Trim().Length > 0) {
                    Model.carinfo car = bll.GetModel(carNum, "");
                    if (car != null)
                    {
                        Response.Write("车牌号已存在，请重新输入！");
                    }
                    else
                    {
                        Response.Write("OK！");
                    }
                }
            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.carbll bll = new BLL.carbll();
            Model.carinfo model = bll.GetModel(_id);

            txtCar_Number.Text = model.Car_Number;
            txtCar_Name.Text = model.Car_Name;
            ddlDept_Pros.SelectedValue = model.Dept_Pros;
            ddlCar_Type.SelectedValue = model.Car_Type.Type_Code;
            ddlDriver.SelectedValue = model.Driver.Driver_Code;
            txtBuy_Date.Text = model.Buy_Date.Replace(" 0:00:00", "");
            txtPrice.Text = model.Price.ToString();
            txtMileage_First.Text = model.Mileage_First.ToString();
            //ddlStatus.SelectedValue = model.Status.ToString();
            txtOil_Consumption.Text = model.Oil_Consumption.ToString();
            txtEngine_Number.Text = model.Engine_Number;
            txtFrame_Number.Text = model.Frame_Number;
            txtWeight.Text = model.Weight.ToString();
            txtSeat.Text = model.Seat.ToString();
            txtcContent.Text = model.cContent;
            string s1 = model.Image1;
            string s2 = model.Image2;
            Image1.ImageUrl = "~/" + s1.Replace("~/","");
            Image2.ImageUrl = "~/" + s2.Replace("~/", "");
            //FileUpload1.FileName=model.Image1;
            //FileUpload2.FileName = model.Image2;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.carinfo model = new Model.carinfo();
            BLL.carbll bll = new BLL.carbll();
            model.Car_Number = txtCar_Number.Text.Trim();
            model.Car_Name = txtCar_Name.Text;
            model.Dept_Pros = ddlDept_Pros.SelectedValue;
            model.Car_Type.Type_Code = ddlCar_Type.SelectedValue;
            model.Driver.Driver_Code = ddlDriver.SelectedValue;
            model.Buy_Date = txtBuy_Date.Text;
            model.Price = Convert.ToDouble(txtPrice.Text.Trim() == "" ? "0" : txtPrice.Text.Trim());
            model.Mileage_First = Convert.ToInt32(txtMileage_First.Text.Trim() == "" ? "0" : txtMileage_First.Text.Trim());
            //model.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            model.Status = 0;
            model.Oil_Consumption =float.Parse(txtOil_Consumption.Text.Trim() == "" ? "0" : txtOil_Consumption.Text.Trim());
            model.Engine_Number = txtEngine_Number.Text;
            model.Frame_Number = txtFrame_Number.Text;
            model.Weight = float.Parse(txtWeight.Text.Trim() == "" ? "0" : txtWeight.Text.Trim());
            model.Seat = Convert.ToInt32(txtSeat.Text.Trim() == "" ? "0" : txtSeat.Text.Trim());
            model.cContent = txtcContent.Text;
            model.Image1 = Image1.ImageUrl;
            model.Image2 = Image2.ImageUrl;
            model.Image1 = model.Image1.Replace("~/", "");
            model.Image2 = model.Image2.Replace("~/", "");
            string savepath = HttpRuntime.AppDomainAppPath + "upload";
            List<string> files = new List<string>();
            bool b = ControlCenter.saveFile(savepath, ref files, Request.Files, admin_info.user_name);
            if (b)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string s = files[i];
                    if (s.Contains("FileUpload1"))
                    {
                        model.Image1 = s;
                        Image1.ImageUrl = s;
                    }
                    else if (s.Contains("FileUpload2"))
                    {
                        model.Image2 = s;
                        Image2.ImageUrl = s;
                    }
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
            BLL.carbll bll = new BLL.carbll();
            Model.carinfo model = bll.GetModel(_id);

            model.Car_Number = txtCar_Number.Text.Trim();
            model.Car_Name = txtCar_Name.Text;
            model.Dept_Pros = ddlDept_Pros.SelectedValue;
            model.Car_Type.Type_Code = ddlCar_Type.SelectedValue;
            model.Driver.Driver_Code = ddlDriver.SelectedValue;
            model.Buy_Date = txtBuy_Date.Text;
            model.Price = Convert.ToDouble(txtPrice.Text.Trim() == "" ? "0" : txtPrice.Text.Trim());
            model.Mileage_First = Convert.ToInt32(txtMileage_First.Text.Trim() == "" ? "0" : txtMileage_First.Text.Trim());
            //model.Status = Convert.ToInt32(ddlStatus.SelectedValue);
            
            model.Oil_Consumption = float.Parse(txtOil_Consumption.Text.Trim() == "" ? "0" : txtOil_Consumption.Text.Trim());
            model.Engine_Number = txtEngine_Number.Text;
            model.Frame_Number = txtFrame_Number.Text;
            model.Weight = float.Parse(txtWeight.Text.Trim() == "" ? "0" : txtWeight.Text.Trim());
            model.Seat = Convert.ToInt32(txtSeat.Text.Trim() == "" ? "0" : txtSeat.Text.Trim());
            model.cContent = txtcContent.Text;
            model.Image1 = Image1.ImageUrl;
            model.Image2 = Image2.ImageUrl;
            model.Image1 = model.Image1.Replace("~/", "");
            model.Image2 = model.Image2.Replace("~/", "");
            string savepath = HttpRuntime.AppDomainAppPath + "upload";
            List<string> files = new List<string>();
            bool b = ControlCenter.saveFile(savepath, ref files, Request.Files, admin_info.user_name);
            if (b)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string s = files[i];
                    if (s.Contains("FileUpload1"))
                    {
                        model.Image1 = s;
                        Image1.ImageUrl = s;
                    }
                    else if (s.Contains("FileUpload2"))
                    {
                        model.Image2 = s;
                        Image2.ImageUrl = s;
                    }
                }
            }
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
                JscriptMsg("修改车辆成功啦！", "car_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.carbll().Exists(txtCar_Number.Text.Trim()))
                {
                    JscriptMsg("车牌号已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加车辆成功啦！", "car_list.aspx", "Success");
            }
        }

        decimal oldPrice = 0;
        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try { oldPrice = Convert.ToInt32(txtPrice.Text); }
            catch { txtPrice.Text = oldPrice.ToString(); }
        }

        int oldmileage = 0;
        protected void txtMileage_First_TextChanged(object sender, EventArgs e)
        {
            try { oldmileage = Convert.ToInt32(txtMileage_First.Text); }
            catch { txtMileage_First.Text = oldmileage.ToString(); }
        }

        float oldoil = 0;
        protected void txtOil_ConsumptionChanged(object sender, EventArgs e)
        {
            try { oldoil = float.Parse(txtOil_Consumption.Text); }
            catch { txtOil_Consumption.Text = oldoil.ToString(); }
        }

        float oldWeight = 0;
        protected void txtWeightChanged(object sender, EventArgs e)
        {
            try { oldWeight = float.Parse(txtWeight.Text); }
            catch { txtWeight.Text = oldWeight.ToString(); }
        }

        int oldSeat = 0;
        protected void txtSeatChanged(object sender, EventArgs e)
        {
            try { oldSeat = Convert.ToInt32(txtSeat.Text); }
            catch { txtSeat.Text = oldSeat.ToString(); }
        }

    }
}