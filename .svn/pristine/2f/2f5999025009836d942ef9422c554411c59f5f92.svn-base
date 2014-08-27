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

namespace DTcms.Web.admin.cars.accident
{
    public partial class accident_record_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;
        protected Model.manager admin_info;

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
                if (!new BLL.accident_recordbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            admin_info = GetAdminInfo();
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
                user_deptbll deptbll = new user_deptbll();
                DataTable tbdept = deptbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlDept_Code.Items.Clear();
                foreach (DataRow dr in tbdept.Rows)
                {
                    this.ddlDept_Code.Items.Add(new ListItem(dr["Dept_Name"].ToString(), dr["Dept_Code"].ToString()));
                }
                car_driverbll driverbll = new car_driverbll();
                DataTable tbdriver = driverbll.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlDriver_Code.Items.Clear();
                foreach (DataRow dr in tbdriver.Rows)
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
            BLL.accident_recordbll bll = new BLL.accident_recordbll();
            Model.accident_recordinfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            ddlCar_Number.SelectedValue = model.Car_Number;
            ddlDept_Code.SelectedValue = model.Department.Dept_Code;
            ddlDriver_Code.SelectedValue = model.Driver.Driver_Code;
            txtAccident_Time.Text = model.Accident_Time;
            ddlDuty.SelectedValue = model.Duty;
            txtAddress.Text = model.Address;
            txtInjured.Text = model.Injured;
            txtLostCost.Text = model.LostCost.ToString();
            txtFine.Text = model.Fine.ToString();
            txtPayCost.Text = model.PayCost.ToString();
            txtNoPayCost.Text = model.NoPayCost.ToString();
            txtAccident_Reason.Text = model.Accident_Reason;
            string s1 = model.Image1;
            string s2 = model.Image2;
            string s3 = model.Image3;
            string s4 = model.Image4;
            Image1.ImageUrl = "~/" + s1.Replace("~/", "");
            Image2.ImageUrl = "~/" + s2.Replace("~/", "");
            Image3.ImageUrl = "~/" + s3.Replace("~/", "");
            Image4.ImageUrl = "~/" + s4.Replace("~/", "");
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.accident_recordinfo model = new Model.accident_recordinfo();
            BLL.accident_recordbll bll = new BLL.accident_recordbll();
            model.Code = txtCode.Text.Trim();
            model.Car_Number = ddlCar_Number.SelectedValue;
            model.Department.Dept_Code = ddlDept_Code.SelectedValue;
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;
            model.Accident_Time = txtAccident_Time.Text;
            model.Duty = ddlDuty.SelectedValue;
            model.Address = txtAddress.Text;
            model.Injured = txtInjured.Text;
            string s = txtLostCost.Text;
            model.LostCost = decimal.Parse(s == "" ? "0" : s);
            s = txtFine.Text;
            model.Fine = decimal.Parse(s == "" ? "0" : s);
            s = txtPayCost.Text;
            model.PayCost = decimal.Parse(s == "" ? "0" : s);
            s = txtNoPayCost.Text;
            model.NoPayCost = decimal.Parse(s == "" ? "0" : s);
            model.Accident_Reason = txtAccident_Reason.Text;
            model.Image1 = Image1.ImageUrl;
            model.Image2 = Image2.ImageUrl;
            model.Image3 = Image3.ImageUrl;
            model.Image4 = Image4.ImageUrl;
            model.Image1 = model.Image1.Replace("~/", "");
            model.Image2 = model.Image2.Replace("~/", "");
            model.Image3 = model.Image3.Replace("~/", "");
            model.Image4 = model.Image4.Replace("~/", "");
            string savepath = HttpRuntime.AppDomainAppPath + "upload";
            List<string> files = new List<string>();
            bool b = ControlCenter.saveFile(savepath, ref files, Request.Files, admin_info.user_name);
            if (b)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string simg = files[i];
                    if (simg.Contains("FileUpload1"))
                    {
                        model.Image1 = simg;
                        Image1.ImageUrl = simg;
                    }
                    else if (simg.Contains("FileUpload2"))
                    {
                        model.Image2 = simg;
                        Image2.ImageUrl = simg;
                    }
                    else if (simg.Contains("FileUpload3"))
                    {
                        model.Image3 = simg;
                        Image3.ImageUrl = simg;
                    }
                    else if (simg.Contains("FileUpload4"))
                    {
                        model.Image4 = simg;
                        Image4.ImageUrl = simg;
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
            BLL.accident_recordbll bll = new BLL.accident_recordbll();
            Model.accident_recordinfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Car_Number = ddlCar_Number.SelectedValue;
            model.Department.Dept_Code = ddlDept_Code.SelectedValue;
            model.Driver.Driver_Code = ddlDriver_Code.SelectedValue;
            model.Accident_Time = txtAccident_Time.Text;
            model.Duty = ddlDuty.SelectedValue;
            model.Address = txtAddress.Text;
            model.Injured = txtInjured.Text;
            string s = txtLostCost.Text;
            model.LostCost = decimal.Parse(s == "" ? "0" : s);
            s = txtFine.Text;
            model.Fine = decimal.Parse(s == "" ? "0" : s);
            s = txtPayCost.Text;
            model.PayCost = decimal.Parse(s == "" ? "0" : s);
            s = txtNoPayCost.Text;
            model.NoPayCost = decimal.Parse(s == "" ? "0" : s);
            model.Accident_Reason = txtAccident_Reason.Text;
            model.Image1 = Image1.ImageUrl;
            model.Image2 = Image2.ImageUrl;
            model.Image3 = Image3.ImageUrl;
            model.Image4 = Image4.ImageUrl;
            model.Image1 = model.Image1.Replace("~/", "");
            model.Image2 = model.Image2.Replace("~/", "");
            model.Image3 = model.Image3.Replace("~/", "");
            model.Image4 = model.Image4.Replace("~/", "");
            string savepath = HttpRuntime.AppDomainAppPath + "upload";
            List<string> files = new List<string>();
            bool b = ControlCenter.saveFile(savepath, ref files, Request.Files, admin_info.user_name);
            if (b)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string simg = files[i];
                    if (simg.Contains("FileUpload1"))
                    {
                        model.Image1 = simg;
                        Image1.ImageUrl = simg;
                    }
                    else if (simg.Contains("FileUpload2"))
                    {
                        model.Image2 = simg;
                        Image2.ImageUrl = simg;
                    }
                    else if (simg.Contains("FileUpload3"))
                    {
                        model.Image3 = simg;
                        Image3.ImageUrl = simg;
                    }
                    else if (simg.Contains("FileUpload4"))
                    {
                        model.Image4 = simg;
                        Image4.ImageUrl = simg;
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
                JscriptMsg("修改车型成功啦！", "accident_record_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.accident_recordbll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加车型成功啦！", "accident_record_list.aspx", "Success");
            }
        }

    }
}