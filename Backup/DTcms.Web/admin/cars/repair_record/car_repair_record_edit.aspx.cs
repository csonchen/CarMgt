using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.Model;

namespace DTcms.Web.admin.cars.repair_record
{
    public partial class car_repair_record_edit : Web.UI.ManagePage
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
                BLL.car_repair_recordbll bll1 = new BLL.car_repair_recordbll();
                DataTable tb1 = bll1.GetList(1000, " 1=1 and Status=0", " id").Tables[0];
                this.ddlCar_Number.Items.Clear();
                foreach (DataRow dr in tb1.Rows)
                {
                    this.ddlCar_Number.Items.Add(new ListItem(dr["Car_Number"].ToString(), dr["Car_Number"].ToString()));
                }
                this.ddlCode.Items.Clear();
                foreach (DataRow dr in tb1.Rows)
                {
                    this.ddlCode.Items.Add(new ListItem(dr["Code"].ToString(), dr["Code"].ToString()));
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

            ddlCode.SelectedValue = model.Code;
            txtRepare_Time_Finish.Text = model.Repare_Time_Finish;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_repair_recordinfo model = new Model.car_repair_recordinfo();
            BLL.car_repair_recordbll bll = new BLL.car_repair_recordbll();
            model.Code = ddlCode.Text;
            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;

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
            BLL.car_repair_recordbll bll = new BLL.car_repair_recordbll();
            Model.car_repair_recordinfo model = bll.GetModel(_id);
            string strcode = codelist.Value;
            string strcost = costlist.Value;
            string[] scodelist = null;
            string[] scostlist = null;
            if (strcode.Contains(",")) { scodelist = strcode.Split(new string[] { "," }, StringSplitOptions.None); }
            else { scodelist = new string[] { strcode }; }
            if (strcost.Contains(",")) { scostlist = strcost.Split(new string[] { "," }, StringSplitOptions.None); }
            else { scostlist = new string[] { strcost }; }
            for (int i = 0; i < scodelist.Length; i++)
            {
                car_repair_iteminfo iteminfo = new car_repair_iteminfo();
                iteminfo.Code = scodelist[i];
                try
                {
                    iteminfo.Cost = decimal.Parse(scostlist[i]);
                }
                catch { }
                model.Car_Repair_Items.Add(iteminfo);
            }

            model.Code = ddlCode.Text;
            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;
            try
            {
                model.Cost = decimal.Parse(txtCost.Text);
            }
            catch { }
            model.Report = txtReport.Text;
            int iresult = bll.UpdateField(model.ID, " Repare_Time_Finish='" + model.Repare_Time_Finish + "',Report='" + model.Report + "',Cost=" + model.Cost + ",Status=1");
            if (iresult <= 0)
            {
                result = false;
            }
            else
            {
                if (bll.AddItem(model) <= 0)
                {
                    result = false;
                }
                else
                {
                    BLL.carbll carbl = new BLL.carbll();
                    carbl.UpdateField(model.Car.Car_Number, " Status=0");
                }
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            action = "Edit";
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                string strid = txtid.Text;
                if (strid == "") {
                    string s = ddlCode.Text;
                    BLL.car_repair_recordbll bll = new BLL.car_repair_recordbll();
                    DataTable tb = bll.GetList(1000, " code='" + s + "'", "code").Tables[0];
                    if (tb != null && tb.Rows.Count > 0) { strid = tb.Rows[0]["ID"] + ""; }
                }
                this.id = Convert.ToInt32(strid);
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
                if (new BLL.car_repair_recordbll().Exists(ddlCode.Text))
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

        protected void ddlCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectitem = ddlCode.SelectedValue;
            if (selectitem == null) { selectitem = ""; }
            BLL.car_repair_recordbll bll1 = new BLL.car_repair_recordbll();
            DataTable tb1 = bll1.GetList(1000, " 1=1 and Code='" + selectitem + "'", " id").Tables[0];
            string carnumber = "";
            if (tb1 != null && tb1.Rows.Count > 0) {
                carnumber = tb1.Rows[0]["Car_Number"] + "";
                ddlCar_Number.SelectedValue = carnumber;
                txtid.Text = tb1.Rows[0]["ID"] + "";
            }
        }

        protected void ddlCar_Number_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectitem = ddlCar_Number.SelectedValue;
            if (selectitem == null) { selectitem = ""; }
            BLL.car_repair_recordbll bll1 = new BLL.car_repair_recordbll();
            DataTable tb1 = bll1.GetList(1000, " 1=1 and Car_Number='" + selectitem + "'", " id").Tables[0];
            string code = "";
            if (tb1 != null && tb1.Rows.Count > 0)
            {
                code = tb1.Rows[0]["Code"] + "";
                ddlCar_Number.SelectedValue = code;
                txtid.Text = tb1.Rows[0]["ID"] + "";
            }
        }

    }
}