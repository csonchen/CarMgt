using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.report
{
    public partial class car_use_report : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int group_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string task = Request.Params["task"];
            if (task == "exportReport")
            {
                exportReport();
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            //this.page = DTRequest.GetQueryInt("page", 1);
            //this.txtKeywords.Text = this.keywords;
            //BLL.car_typebll bll = new BLL.car_typebll();
            //this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            //this.rptList.DataBind();

            ////绑定页码
            //txtPageNum.Text = this.pageSize.ToString();
            //string pageUrl = Utils.CombUrlTxt("car_type_list.aspx", "group_id={0}&keywords={1}&page={2}",
            //    this.group_id.ToString(), this.keywords, "__id__");
            //PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Type_Name like '%" + _keywords + "%' or Type_Code like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("car_type_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //Response.Redirect(Utils.CombUrlTxt("car_type_list.aspx", "group_id={0}&keywords={1}",
            //    this.group_id.ToString(), txtKeywords.Text));
            string stime = txtStartTime.Text;
            string etime = txtEndTime.Text;
            bool bExport = true;
            try { stime = DateTime.Parse(stime).ToString("yyyy-MM-dd HH:mm:sss"); }
            catch { stime = ""; bExport = false; }
            try { etime = DateTime.Parse(etime).ToString("yyyy-MM-dd HH:mm:sss"); }
            catch { etime = ""; bExport = false; }
            if (!bExport)
            {
                JscriptMsg("时间格式不正确请检查后在导出！", "back", "Error");
                return;
            }

            exportReport();
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            //int _pagesize;
            //if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            //{
            //    if (_pagesize > 0)
            //    {
            //        Utils.WriteCookie("car_type_list_page_size", _pagesize.ToString(), 43200);
            //    }
            //}
            //Response.Redirect(Utils.CombUrlTxt("car_type_list.aspx", "group_id={0}&keywords={1}",
            //    this.group_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            //BLL.car_typebll bll = new BLL.car_typebll();
            //for (int i = 0; i < rptList.Items.Count; i++)
            //{
            //    int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
            //    CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
            //    if (cb.Checked)
            //    {
            //        bll.Delete(id);
            //    }
            //}
            //JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("car_type_list.aspx", "group_id={0}&keywords={1}",
            //    this.group_id.ToString(), this.keywords), "Success");
        }

        public void exportReport()
        {
            string stime = txtStartTime.Text;
            string etime = txtEndTime.Text;

            //string deptpros = "";//ddlDept_Pros.SelectedValue;
            if (stime == null || stime == "undifine" || stime == "") { stime = Request.Params["stime"]; }
            if (etime == null || etime == "undifine" || etime == "") { etime = Request.Params["etime"]; }


            //if (deptpros == null || deptpros == "undifine" || deptpros == "") { deptpros = Request.Params["deptpros"]; }
            //if (deptpros == "10000") { deptpros = ""; }
            if (stime == null || stime == "undifine" || stime == "") { return; }
            if (etime == null || etime == "undifine" || etime == "") { return; }
            DateTime sdatetime = new DateTime();
            DateTime edatetime = new DateTime();
            try
            {
                sdatetime = DateTime.Parse(stime);
                stime = sdatetime.ToString("yyyy-MM-dd HH:mm:sss");
            }
            catch { stime = ""; }
            try
            {
                edatetime = DateTime.Parse(etime);
                etime = edatetime.ToString("yyyy-MM-dd HH:mm:sss");
            }
            catch { etime = ""; }
            string where = "";
            if (stime != "") { where += " Use_Time>'" + stime + "'"; }
            if (etime != "")
            {
                if (where == "") { where += " Use_Time<'" + etime + "'"; }
                else { where += " and Use_Time<'" + etime + "'"; }
            }
            //if (deptpros != "")
            //{
            //    if (where == "") { where += " Dept_Pros='" + deptpros + "'"; }
            //    else { where += " and Dept_Pros='" + deptpros + "'"; }
            //}
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            DataTable tbcarcosted = bll.GetUserCarUseRecord(1000, where, "Use_Time").Tables[0];
            if (tbcarcosted == null || tbcarcosted.Rows.Count <= 0)
            {
                //JscriptMsg("0条记录，无法导出！", "back", "Error");

                //JscriptMsg("0条记录，无法导出！", "", "Error");
                outSuccess("N", "0条记录，无法导出！");
                return;
            }
            DataTable tbUseCost = new DataTable();
            tbUseCost.Columns.Add("序号");
            tbUseCost.Columns.Add("单号");
            tbUseCost.Columns.Add("部门");
            tbUseCost.Columns.Add("车牌");
            tbUseCost.Columns.Add("车名");
            tbUseCost.Columns.Add("用车人");
            tbUseCost.Columns.Add("人数");
            tbUseCost.Columns.Add("司机");
            tbUseCost.Columns.Add("审批人");
            tbUseCost.Columns.Add("用车时间起止");
            tbUseCost.Columns.Add("联系人");
            tbUseCost.Columns.Add("电话");
            tbUseCost.Columns.Add("发车地点");
            tbUseCost.Columns.Add("目的地");
            tbUseCost.Columns.Add("行驶里程");
            tbUseCost.Columns.Add("行驶公里");
            tbUseCost.Columns.Add("事由");
            for (int i = 0; i < tbcarcosted.Rows.Count; i++)
            {
                tbUseCost.Rows.Add();
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["序号"] = i + 1;
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["单号"] = tbcarcosted.Rows[i]["Code"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["部门"] = tbcarcosted.Rows[i]["Dept_Name"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["车牌"] = tbcarcosted.Rows[i]["Car_Number"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["车名"] = tbcarcosted.Rows[i]["Car_Name"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["用车人"] = tbcarcosted.Rows[i]["username"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["人数"] = tbcarcosted.Rows[i]["User_Number"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["司机"] = tbcarcosted.Rows[i]["Driver_Name"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["审批人"] = tbcarcosted.Rows[i]["checkername"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["用车时间起止"] = tbcarcosted.Rows[i]["Use_Time"] + "" + tbcarcosted.Rows[i]["eReturn_Time"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["联系人"] = tbcarcosted.Rows[i]["Connecter"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["电话"] = tbcarcosted.Rows[i]["Tel"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["发车地点"] = tbcarcosted.Rows[i]["Start_Address"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["目的地"] = tbcarcosted.Rows[i]["End_Address"] + "";
                string s1 = tbcarcosted.Rows[i]["Mileage_First"] + "";
                string s2 = tbcarcosted.Rows[i]["Mileage_End"] + "";
                int num1 = Convert.ToInt32(s1 == "" ? "0" : s1);
                int num2 = Convert.ToInt32(s2 == "" ? "0" : s2);
                num1 = num2 - num1;
                if (num1 < 0) { num1 = 0; }
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["行驶里程"] = num1;
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["行驶公里"] = tbcarcosted.Rows[i]["Kilometer"] + "";
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["事由"] = tbcarcosted.Rows[i]["UContent"] + "";
            }

            DataTable dt = tbUseCost;
            //object itemReport = HttpContext.Current.Session["itemReport"];

            //if (itemReport == null)
            //{
            //    JscriptMsg("请先查询！", "back", "Error");
            //    return;
            //}
            //DataTable dt = itemReport as DataTable;
            List<ExportEntity> list = new List<ExportEntity>();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string colname = dt.Columns[j].ColumnName;
                list.Add(new ExportEntity(colname, colname, colname, "", 15 * 256));//N2
            }

            DataToExcel.DataTableToExcel(dt, list, "car_use_report.xls", "派车单汇总列表");

            outSuccess("Y", "car_use_report.xls");
        }
    }
}