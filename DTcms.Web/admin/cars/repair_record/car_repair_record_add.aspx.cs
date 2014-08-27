using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using DTcms.Common;
using DTcms.Model;

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
                //DataTable tb = bll.GetList(1000, " 1=1 and Status in(0,1)", " id").Tables[0];
                DataTable tb = bll.GetList(0, " 1=1", " id").Tables[0];
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
                //绑定修理厂项
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
                //绑定维修项
                BLL.car_repair_itembll bll4 = new BLL.car_repair_itembll();
                DataTable tb4 = bll4.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlRepair_Item.Items.Clear();
                foreach (DataRow dr in tb4.Rows)
                {
                    this.ddlRepair_Item.Items.Add(new ListItem(dr["Repair_Item_Name"].ToString(),dr["Code"].ToString()));
                }
                //绑定保养项
                BLL.car_maintenance_itembll bll5 = new BLL.car_maintenance_itembll();
                DataTable tb5 = bll5.GetList(1000, " 1=1 ", " id").Tables[0];
                this.ddlMaintenance_Items.Items.Clear();
                foreach(DataRow dr in tb5.Rows)
                {
                    this.ddlMaintenance_Items.Items.Add(new ListItem(dr["Maintenance_Item_Name"].ToString(), dr["Code"].ToString()));
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
            BLL.car_repair_itembll crbll = new BLL.car_repair_itembll();
            BLL.car_maintenance_itembll cmbll = new BLL.car_maintenance_itembll();

            txtCode.Text = model.Code;
            txtRepare_Time.Text = model.Repare_Time;
            ddlCar_Number.SelectedValue = model.Car.Car_Number;
            txtMileage.Text = model.Mileage.ToString();
            txtNext_Mileage.Text = model.Next_Mileage.ToString();
            ddlMaintenance_Item.SelectedValue = model.Maintenance_Item.Code;
            ddlRepair_Plant.SelectedValue = model.Repair_Plant_Code;
            txtReason.Text = model.Reason;
            ddlDriver_Code.SelectedValue = model.Driver.Driver_Code;
            //
            txtRepare_Time_Finish.Text = model.Repare_Time_Finish;
            choice.SelectedValue = model.Choice;
            txtCost.Text = model.Cost.ToString();
            txtReport.Text = model.Report;

            //绑定附加项
            //接收维修单的编码
            string repairCode = model.Code;
            //接收选择项(1：保养项；2：维修项；3：保养+维修)
            string choiceSel = model.Choice.Trim();
            if ("1".Equals(choiceSel))
            { 
                //查找保养记录项记录
                DataTable dt = bll.GetMaintenanceItemList(repairCode).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    //维修项编码
                    string code = dr["Maintenance_Item_Code"].ToString().Trim();
                    //根据保养项编码查找保养项名字
                    string itemName = cmbll.GetModel(code, "").Maintenance_Item_Name;
                    //保养项费用
                    string cost = dr["Cost"] + "";
                    //操作
                    string operate = "<a href=\"javascript:delitem2('" + code + "')\">删除</a>";
                    //行id
                    string id = "code2" + code;
                    //增加一行
                    HtmlTableRow itemrow = new HtmlTableRow();
                    itemrow.ID = id;
                    //增加四个单元格
                    HtmlTableCell itemcell1 = new HtmlTableCell();
                    HtmlTableCell itemcell2 = new HtmlTableCell();
                    HtmlTableCell itemcell3 = new HtmlTableCell();
                    HtmlTableCell itemcell4 = new HtmlTableCell();
                    //
                    itemcell1.Style.Add("text-align", "center");
                    itemcell1.InnerHtml = code;
                    HtmlGenericControl input = new HtmlGenericControl("input");
                    input.Attributes.Add("type", "hidden");
                    input.Attributes.Add("id", "itemcode2_" + code);
                    input.Attributes.Add("name", "itemcode2" + code);
                    input.Attributes.Add("class", "itemcode2");
                    input.Attributes.Add("value", code);
                    itemcell1.Controls.Add(input);
                    //
                    itemcell2.Style.Add("text-align", "center");
                    itemcell2.InnerHtml = itemName;
                    //
                    itemcell3.Style.Add("text-align", "center");
                    itemcell3.InnerHtml = cost;
                    HtmlGenericControl input3 = new HtmlGenericControl("input");
                    input3.Attributes.Add("type", "hidden");
                    input3.Attributes.Add("id", "itemcose2_" + code);
                    input3.Attributes.Add("name", "itemcose2" + code);
                    input3.Attributes.Add("class", "itemcost2");
                    input3.Attributes.Add("value", cost);
                    itemcell3.Controls.Add(input3);
                    //
                    itemcell4.Style.Add("text-align", "center");
                    itemcell4.InnerHtml = operate;
                    //添加到行中
                    itemrow.Controls.Add(itemcell1);
                    itemrow.Controls.Add(itemcell2);
                    itemrow.Controls.Add(itemcell3);
                    itemrow.Controls.Add(itemcell4);
                    //金额项处理
                    this.txt_maintenance_cost.Text = cost;
                    //添加到表格中
                    this.maintenance_itemshtml.Controls.Add(itemrow);
                }
            }
            else if("2".Equals(choiceSel))
            {
                //查找维修记录项记录
                DataTable dt = bll.GetRepairItemList(repairCode).Tables[0];
                foreach(DataRow dr in dt.Rows)
                {
                    //维修项编码
                    string code = dr["Repair_Item_Code"].ToString().Trim();
                    //根据维修项编码查找维修项名字
                    string itemName = crbll.GetModel(code, "").Repair_Item_Name;
                    //维修项费用
                    string cost = dr["Cost"] + "";
                    //操作
                    string operate = "<a href=\"javascript:delitem('" + code + "')\">删除</a>";
                    //行id
                    string id = "code" + code;
                    //增加一行
                    HtmlTableRow itemrow = new HtmlTableRow();
                    itemrow.ID = id;
                    //增加四个单元格
                    HtmlTableCell itemcell1 = new HtmlTableCell();
                    HtmlTableCell itemcell2 = new HtmlTableCell();
                    HtmlTableCell itemcell3 = new HtmlTableCell();
                    HtmlTableCell itemcell4 = new HtmlTableCell();
                    //
                    itemcell1.Style.Add("text-align","center");
                    itemcell1.InnerHtml = code;
                    HtmlGenericControl input = new HtmlGenericControl("input");
                    input.Attributes.Add("type","hidden");
                    input.Attributes.Add("id","itemcode_" + code);
                    input.Attributes.Add("name","itemcode" + code);
                    input.Attributes.Add("class","itemcode");
                    input.Attributes.Add("value",code);
                    itemcell1.Controls.Add(input);
                    //
                    itemcell2.Style.Add("text-align", "center");
                    itemcell2.InnerHtml = itemName;
                    //
                    itemcell3.Style.Add("text-align", "center");
                    itemcell3.InnerHtml = cost;
                    HtmlGenericControl input3 = new HtmlGenericControl("input");
                    input3.Attributes.Add("type","hidden");
                    input3.Attributes.Add("id","itemcose_" + code);
                    input3.Attributes.Add("name","itemcose" + code);
                    input3.Attributes.Add("class","itemcost");
                    input3.Attributes.Add("value",cost);
                    itemcell3.Controls.Add(input3);
                    //
                    itemcell4.Style.Add("text-align", "center");
                    itemcell4.InnerHtml = operate;
                    //添加到行中
                    itemrow.Controls.Add(itemcell1);
                    itemrow.Controls.Add(itemcell2);
                    itemrow.Controls.Add(itemcell3);
                    itemrow.Controls.Add(itemcell4);
                    //金额项处理
                    this.txtaddcost.Text = cost;
                    //添加到表格中
                    this.itemshtml.Controls.Add(itemrow);
                }
            }
            else if ("3".Equals(choiceSel))
            {
                #region==查找保养记录项记录
                DataTable dt = bll.GetMaintenanceItemList(repairCode).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    //保养项编码
                    string code = dr["Maintenance_Item_Code"].ToString().Trim();
                    //根据保养项编码查找保养项名字
                    string itemName = cmbll.GetModel(code, "").Maintenance_Item_Name;
                    //保养项费用
                    string cost = dr["Cost"] + "";
                    //操作
                    string operate = "<a href=\"javascript:delitem2('" + code + "')\">删除</a>";
                    //行id
                    string id = "code2" + code;
                    //增加一行
                    HtmlTableRow itemrow = new HtmlTableRow();
                    itemrow.ID = id;
                    //增加四个单元格
                    HtmlTableCell itemcell1 = new HtmlTableCell();
                    HtmlTableCell itemcell2 = new HtmlTableCell();
                    HtmlTableCell itemcell3 = new HtmlTableCell();
                    HtmlTableCell itemcell4 = new HtmlTableCell();
                    //
                    itemcell1.Style.Add("text-align", "center");
                    itemcell1.InnerHtml = code;
                    HtmlGenericControl input = new HtmlGenericControl("input");
                    input.Attributes.Add("type", "hidden");
                    input.Attributes.Add("id", "itemcode2_" + code);
                    input.Attributes.Add("name", "itemcode2" + code);
                    input.Attributes.Add("class", "itemcode2");
                    input.Attributes.Add("value", code);
                    itemcell1.Controls.Add(input);
                    //
                    itemcell2.Style.Add("text-align", "center");
                    itemcell2.InnerHtml = itemName;
                    //
                    itemcell3.Style.Add("text-align", "center");
                    itemcell3.InnerHtml = cost;
                    HtmlGenericControl input3 = new HtmlGenericControl("input");
                    input3.Attributes.Add("type", "hidden");
                    input3.Attributes.Add("id", "itemcose2_" + code);
                    input3.Attributes.Add("name", "itemcose2" + code);
                    input3.Attributes.Add("class", "itemcost2");
                    input3.Attributes.Add("value", cost);
                    itemcell3.Controls.Add(input3);
                    //
                    itemcell4.Style.Add("text-align", "center");
                    itemcell4.InnerHtml = operate;
                    //添加到行中
                    itemrow.Controls.Add(itemcell1);
                    itemrow.Controls.Add(itemcell2);
                    itemrow.Controls.Add(itemcell3);
                    itemrow.Controls.Add(itemcell4);
                    //金额项处理
                    this.txt_maintenance_cost.Text = cost;
                    //添加到表格中
                    this.maintenance_itemshtml.Controls.Add(itemrow);
                }
                #endregion

                #region==查找维修记录项记录
                //查找维修记录项记录
                DataTable dt2 = bll.GetRepairItemList(repairCode).Tables[0];
                foreach (DataRow dr in dt2.Rows)
                {
                    //维修项编码
                    string code = dr["Repair_Item_Code"].ToString().Trim();
                    //根据维修项编码查找维修项名字
                    string itemName = crbll.GetModel(code, "").Repair_Item_Name;
                    //维修项费用
                    string cost = dr["Cost"] + "";
                    //操作
                    string operate = "<a href=\"javascript:delitem('" + code + "')\">删除</a>";
                    //行id
                    string id = "code" + code;
                    //增加一行
                    HtmlTableRow itemrow = new HtmlTableRow();
                    itemrow.ID = id;
                    //增加四个单元格
                    HtmlTableCell itemcell1 = new HtmlTableCell();
                    HtmlTableCell itemcell2 = new HtmlTableCell();
                    HtmlTableCell itemcell3 = new HtmlTableCell();
                    HtmlTableCell itemcell4 = new HtmlTableCell();
                    //
                    itemcell1.Style.Add("text-align", "center");
                    itemcell1.InnerHtml = code;
                    HtmlGenericControl input = new HtmlGenericControl("input");
                    input.Attributes.Add("type", "hidden");
                    input.Attributes.Add("id", "itemcode_" + code);
                    input.Attributes.Add("name", "itemcode" + code);
                    input.Attributes.Add("class", "itemcode");
                    input.Attributes.Add("value", code);
                    itemcell1.Controls.Add(input);
                    //
                    itemcell2.Style.Add("text-align", "center");
                    itemcell2.InnerHtml = itemName;
                    //
                    itemcell3.Style.Add("text-align", "center");
                    itemcell3.InnerHtml = cost;
                    HtmlGenericControl input3 = new HtmlGenericControl("input");
                    input3.Attributes.Add("type", "hidden");
                    input3.Attributes.Add("id", "itemcose_" + code);
                    input3.Attributes.Add("name", "itemcose" + code);
                    input3.Attributes.Add("class", "itemcost");
                    input3.Attributes.Add("value", cost);
                    itemcell3.Controls.Add(input3);
                    //
                    itemcell4.Style.Add("text-align", "center");
                    itemcell4.InnerHtml = operate;
                    //添加到行中
                    itemrow.Controls.Add(itemcell1);
                    itemrow.Controls.Add(itemcell2);
                    itemrow.Controls.Add(itemcell3);
                    itemrow.Controls.Add(itemcell4);
                    //金额项处理
                    this.txtaddcost.Text = cost;
                    //添加到表格中
                    this.itemshtml.Controls.Add(itemrow);
                }
                #endregion
            }
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
            //
            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;
            model.Choice = choice.SelectedValue;//1：保养；2：维修；3：保养+维修
            string cost = txtCost.Text;
            model.Cost = Convert.ToDecimal(cost.Trim() == "" ? "0" : cost);
            model.Report = txtReport.Text;

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            else {
                BLL.carbll carbl = new BLL.carbll();
                carbl.UpdateField(model.Car.Car_Number, " Status=2");
            }

            //接收标示符1:保养；2：维修；3：保养+维修
            string flag = choice.SelectedValue.Trim();
            if ("1".Equals(flag))//保养项目
            {
                result = AddMaintenanceRecordItems(result, model, bll);
            }
            else if ("2".Equals(flag))//维修项目
            {
                result = AddRepairRecordItems(result, model, bll);
            }
            else if ("3".Equals(flag))//保养+维修
            {
                result = AddMaintenanceRecordItems(result, model, bll);
                result = AddRepairRecordItems(result, model, bll);
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
            //
            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;
            model.Choice = choice.SelectedValue;//1：保养；2：维修；3：保养+维修
            string cost = txtCost.Text;
            model.Cost = Convert.ToDecimal(cost.Trim() == "" ? "0" : cost);
            model.Report = txtReport.Text;
            if (!bll.Update(model))
            {
                result = false;
            }
            //接收标示符1:保养；2：维修；3：保养+维修
            string flag = choice.SelectedValue.Trim();
            if ("1".Equals(flag))//保养项目
            {
                result = AddMaintenanceRecordItems(result, model, bll);
            }
            else if ("2".Equals(flag))//维修项目
            {
                result = AddRepairRecordItems(result, model, bll);
            }
            else if ("3".Equals(flag))//保养+维修
            {
                result = AddMaintenanceRecordItems(result, model, bll);
                result = AddRepairRecordItems(result, model, bll);
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

        //添加维修项目
        public bool AddRepairRecordItems(bool result,Model.car_repair_recordinfo model,BLL.car_repair_recordbll bll)
        {
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

            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;
            try
            {
                model.Cost = decimal.Parse(txtCost.Text);
            }
            catch { }
            model.Report = txtReport.Text;
            if (bll.AddItem(model) <= 0)
            {
                result = false;
            }
            else
            {
                BLL.carbll carbl = new BLL.carbll();
                carbl.UpdateField(model.Car.Car_Number, " Status=0");
            }
            return result;
        }
    
        //更新维修项目
        public bool UpdateRepairRecordItems(bool result, Model.car_repair_recordinfo model, BLL.car_repair_recordbll bll)
        {
            //接收维修记录项编码
            string rcode = model.Code;
            StringBuilder strsqlId = new StringBuilder();
            string strid = "";
            string[] sidlist = null;
            //根据维修记录项编码查找维修项id（可能多条）
            DataTable dt1 = bll.GetRepairItemsID(rcode).Tables[0]; 
            foreach(DataRow dr in dt1.Rows)
            {
                strsqlId.Append(dr["ID"].ToString() + ",");
            }
            //去末尾的逗号
            strid = Utils.DelLastComma(strsqlId.ToString());//获取存储有id的字串

            string strcode = codelist.Value;
            string strcost = costlist.Value;
            string[] scodelist = null;
            string[] scostlist = null;
            if (strcode.Contains(",")) { scodelist = strcode.Split(new string[] { "," }, StringSplitOptions.None); }
            else { scodelist = new string[] { strcode }; }
            if (strcost.Contains(",")) { scostlist = strcost.Split(new string[] { "," }, StringSplitOptions.None); }
            else { scostlist = new string[] { strcost }; }
            if (strid.Contains(",")) { sidlist = strid.Split(new string[] { "," }, StringSplitOptions.None); }
            else { sidlist = new string[] { strid }; }
            //
            for (int i = 0; i < scodelist.Length; i++)
            {
                car_repair_iteminfo iteminfo = new car_repair_iteminfo();
                iteminfo.Code = scodelist[i];
                try
                {
                    iteminfo.Cost = decimal.Parse(scostlist[i]);
                    //赋值id
                    iteminfo.ID = int.Parse(sidlist[i]);
                }
                catch { }
                model.Car_Repair_Items.Add(iteminfo);
            }

            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;
            try
            {
                model.Cost = decimal.Parse(txtCost.Text);
            }
            catch { }
            model.Report = txtReport.Text;
            if (bll.UpdateItem(model) <= 0)
            {
                result = false;
            }
            else
            {
                BLL.carbll carbl = new BLL.carbll();
                carbl.UpdateField(model.Car.Car_Number, " Status=0");
            }
            return result;
        }

        //添加保养项目
        public bool AddMaintenanceRecordItems(bool result, Model.car_repair_recordinfo model, BLL.car_repair_recordbll bll)
        {
            string strcode2 = codelist2.Value;
            string strcost2 = costlist2.Value;
            string[] scodelist2 = null;
            string[] scostlist2 = null;
            if (strcode2.Contains(",")) { scodelist2 = strcode2.Split(new string[] { "," }, StringSplitOptions.None); }
            else { scodelist2 = new string[] { strcode2 }; }
            if (strcost2.Contains(",")) { scostlist2 = strcost2.Split(new string[] { "," }, StringSplitOptions.None); }
            else { scostlist2 = new string[] { strcost2 }; }
            for (int i = 0; i < scodelist2.Length; i++)
            {
                car_maintenance_iteminfo iteminfo2 = new car_maintenance_iteminfo();
                iteminfo2.Code = scodelist2[i];
                try
                {
                    iteminfo2.Cost = decimal.Parse(scostlist2[i]);
                }
                catch { }
                model.Car_Maintenance_Items.Add(iteminfo2);
                //model.Car_Repair_Items.Add(iteminfo2);
            }

            model.Repare_Time_Finish = txtRepare_Time_Finish.Text;
            try
            {
                model.Cost = decimal.Parse(txtCost.Text);
            }
            catch { }
            model.Report = txtReport.Text;
            if (bll.AddMaintenanceItem(model) <= 0)
            {
                result = false;
            }
            else
            {
                BLL.carbll carbl = new BLL.carbll();
                carbl.UpdateField(model.Car.Car_Number, " Status=0");
            }
            return result;
        }
    }
}