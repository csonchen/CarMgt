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
    public partial class car_workload_report : Web.UI.ManagePage
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
            string deptpros = "";//ddlDept_Pros.SelectedValue;
            if (stime == null || stime == "undifine" || stime == "") { stime = Request.Params["stime"]; }
            if (etime == null || etime == "undifine" || etime == "") { etime = Request.Params["etime"]; }
            if (deptpros == null || deptpros == "undifine" || deptpros == "") { deptpros = Request.Params["deptpros"]; }
            if (deptpros == "10000") { deptpros = ""; }
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
            if (stime != "") { where += " Return_Times>'" + stime + "'"; }
            if (etime != "")
            {
                if (where == "") { where += " Return_Times<'" + etime + "'"; }
                else { where += " and Return_Times<'" + etime + "'"; }
            }
            if (deptpros != "")
            {
                if (where == "") { where += " Dept_Pros='" + deptpros + "'"; }
                else { where += " and Dept_Pros='" + deptpros + "'"; }
            }
            BLL.car_return_recordbll bll = new BLL.car_return_recordbll();
            DataTable tbcaruserecord = bll.GetCarUseReturnReport(1000, where, "Driver_Name,Return_Time").Tables[0];
            DataTable tbdriver = bll.GetCarDrivers(1000, where, "Driver_Name,Return_Times").Tables[0];
            BLL.car_repair_recordbll bllrepair = new BLL.car_repair_recordbll();
            string rwhere = "";
            if (stime != "") { rwhere += " Repare_Time_Finish>'" + stime + "'"; }
            if (etime != "")
            {
                if (rwhere == "") { rwhere += " Repare_Time_Finish<'" + etime + "'"; }
                else { rwhere += " and Repare_Time_Finish<'" + etime + "'"; }
            }
            DataTable tbrepair = bllrepair.GetList(1000, rwhere, "Repare_Time_Finish desc").Tables[0];
            DataTable tbrepairitem = bllrepair.GetListItems(1000, "", "ID").Tables[0];
            if (tbcaruserecord == null || tbcaruserecord.Rows.Count <= 0)
            {
                //JscriptMsg("0条记录，无法导出！", "back", "Error");
                outSuccess("N", "0条记录，无法导出！");
                return;
            }
            DataTable tbWorkload = new DataTable();
            tbWorkload.Columns.Add("序号");
            tbWorkload.Columns.Add("姓名");
            tbWorkload.Columns.Add("市内出车次数");
            tbWorkload.Columns.Add("外地出车次数");
            tbWorkload.Columns.Add("累计出车次数");
            tbWorkload.Columns.Add("月初安全行车公里数");
            tbWorkload.Columns.Add("月末安全行车公里数");
            tbWorkload.Columns.Add("累计出车公里数");
            tbWorkload.Columns.Add("工作延时次数");
            tbWorkload.Columns.Add("工作延时计时");
            tbWorkload.Columns.Add("工作延时计时累计");
            tbWorkload.Columns.Add("日常维护次数");
            tbWorkload.Columns.Add("车辆维修次数");
            tbWorkload.Columns.Add("保养维修累计");
            int irownum = 0;
            #region
            for (int i = 0; i < tbdriver.Rows.Count; i++)
            {
                string code = tbdriver.Rows[i]["Driver_Code"] + "";
                string name = tbdriver.Rows[i]["Driver_Name"] + "";
                tbWorkload.Rows.Add();
                irownum++;
                tbWorkload.Rows[tbWorkload.Rows.Count - 1]["序号"] = irownum;
                tbWorkload.Rows[tbWorkload.Rows.Count - 1]["姓名"] = name + "(" + code + ")";
            }
            #endregion
            for (int i = 0; i < tbcaruserecord.Rows.Count; i++)
            {
                string drivercode = tbcaruserecord.Rows[i]["Driver_Code"] + "";
                string oncity = tbcaruserecord.Rows[i]["OnCity"] + "";
                string mileagefirst = tbcaruserecord.Rows[i]["Mileage_First"] + "";
                string mileageend = tbcaruserecord.Rows[i]["Mileage_End"] + "";
                string usetime = tbcaruserecord.Rows[i]["Use_Time"] + "";
                string returntimes = tbcaruserecord.Rows[i]["Return_Times"] + "";
                for (int j = 0; j < tbWorkload.Rows.Count; j++)
                {
                    string sdrivercode = tbWorkload.Rows[j]["姓名"] + "";
                    if (sdrivercode.Contains(drivercode))
                    {
                        string s = "";
                        if (oncity == "1")
                        {
                            s = tbWorkload.Rows[j]["市内出车次数"] + "";
                            int num = Convert.ToInt32(s == "" ? "0" : s);
                            num++;
                            tbWorkload.Rows[j]["市内出车次数"] = num;
                        }
                        else if (oncity == "0")
                        {
                            s = tbWorkload.Rows[j]["外地出车次数"] + "";
                            int num = Convert.ToInt32(s == "" ? "0" : s);
                            num++;
                            tbWorkload.Rows[j]["外地出车次数"] = num;
                        }
                        s = tbWorkload.Rows[j]["累计出车次数"] + "";
                        int num0 = Convert.ToInt32(s == "" ? "0" : s);
                        num0++;
                        tbWorkload.Rows[j]["累计出车次数"] = num0;

                        DateTime timeMon = DateTime.Parse(returntimes);
                        int mil1 = 0; int mil2 = 0;
                        try { mil1 = Convert.ToInt32(mileagefirst); }
                        catch { }
                        try { mil2 = Convert.ToInt32(mileageend); }
                        catch { }
                        if (timeMon.Day < 15)
                        {
                            s = tbWorkload.Rows[j]["月初安全行车公里数"] + "";
                            int num = Convert.ToInt32(s == "" ? "0" : s);
                            num = num + (mil2 - mil1);
                            tbWorkload.Rows[j]["月初安全行车公里数"] = num;
                        }
                        else
                        {
                            s = tbWorkload.Rows[j]["月末安全行车公里数"] + "";
                            int num = Convert.ToInt32(s == "" ? "0" : s);
                            num = num + (mil2 - mil1);
                            tbWorkload.Rows[j]["月末安全行车公里数"] = num;
                        }
                        s = tbWorkload.Rows[j]["累计出车公里数"] + "";
                        int numzgl = Convert.ToInt32(s == "" ? "0" : s);
                        numzgl = numzgl + (mil2 - mil1);
                        tbWorkload.Rows[j]["累计出车公里数"] = numzgl;

                        DateTime dtusetime = DateTime.Parse(usetime);
                        DateTime dtreturntimes = DateTime.Parse(returntimes);
                        TimeSpan midTime0 = dtreturntimes - dtusetime;
                        if (midTime0.Days > 0||dtreturntimes.Hour>18) {
                            s = tbWorkload.Rows[j]["工作延时次数"] + "";
                            int num = Convert.ToInt32(s == "" ? "0" : s);
                            num++;
                            tbWorkload.Rows[j]["工作延时次数"] = num;
                            s = tbWorkload.Rows[j]["工作延时计时"] + "";
                            int numtime = Convert.ToInt32(s == "" ? "0" : s);
                            if (midTime0.Days > 0) { numtime += dtreturntimes.Hour + ((midTime0.Days - 1) * 8); }
                            else { numtime += dtreturntimes.Hour - 18; }
                            tbWorkload.Rows[j]["工作延时计时"] = numtime;
                            tbWorkload.Rows[j]["工作延时计时累计"] = numtime;
                        }
                    }
                }
            }
            for (int i = 0; i < tbWorkload.Rows.Count; i++)
            {
                string sdrivercode = tbWorkload.Rows[i]["姓名"] + "";
                for (int j = 0; j < tbrepair.Rows.Count; j++)
                {//tbrepairitem
                    string code = tbrepair.Rows[j]["Code"] + "";
                    string dricode = tbrepair.Rows[j]["Driver_Code"] + "";
                    if (sdrivercode.Contains(dricode))
                    {
                        string s = "";
                        if (tbrepairitem == null || tbrepairitem.Rows.Count <= 0)
                        {
                            s = tbWorkload.Rows[i]["日常维护次数"] + "";
                            int num = Convert.ToInt32(s == "" ? "0" : s);
                            num++;
                            tbWorkload.Rows[i]["日常维护次数"] = num;
                        }
                        else
                        {
                            DataRow[] rows = tbrepairitem.Select("Repair_Record_Code='" + code + "'");
                            if (rows == null || rows.Length <= 0)
                            {
                                s = tbWorkload.Rows[i]["日常维护次数"] + "";
                                int num = Convert.ToInt32(s == "" ? "0" : s);
                                num++;
                                tbWorkload.Rows[i]["日常维护次数"] = num;
                            }
                            else
                            {
                                s = tbWorkload.Rows[i]["车辆维修次数"] + "";
                                int num = Convert.ToInt32(s == "" ? "0" : s);
                                num++;
                                tbWorkload.Rows[i]["车辆维修次数"] = num;
                            }
                        }
                        s = tbWorkload.Rows[i]["保养维修累计"] + "";
                        int numlj = Convert.ToInt32(s == "" ? "0" : s);
                        numlj++;
                        tbWorkload.Rows[i]["保养维修累计"] = numlj;
                    }
                }
            }

            DataTable dt = tbWorkload;
            //object itemReport = HttpContext.Current.Session["itemReport"];

            //if (itemReport == null)
            //{
            //    JscriptMsg("请先查询！", "back", "Error");
            //    return;
            //}
            //DataTable dt = itemReport as DataTable;
            List<ExportEntity> list = new List<ExportEntity>();

            //list.Add(new ExportEntity("序号", "序号", "序号", "", 15 * 256));
            //list.Add(new ExportEntity("日期", "日期", "日期", "", 15 * 256));
            //if (deptpros == "10001")
            //{
            //    list.Add(new ExportEntity("总办", "总办", "总办", "", 15 * 256));
            //    list.Add(new ExportEntity("总办小计", "总办小计", "总办小计", "", 15 * 256));
            //}
            //else if (deptpros == "10002")
            //{
            //    list.Add(new ExportEntity("行政", "行政", "行政", "", 15 * 256));
            //    list.Add(new ExportEntity("行政小计", "行政小计", "行政小计", "", 15 * 256));
            //}
            //list.Add(new ExportEntity("合计", "合计", "合计", "", 15 * 256));
            //list.Add(new ExportEntity("solution_name", "科目类别方案", "solution_name", "", 15 * 256));
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string colname = dt.Columns[j].ColumnName;
                list.Add(new ExportEntity(colname, colname, colname, "", 15 * 256));//N2
            }

            DataToExcel.DataTableToExcel(dt, list, "car_workload.xls", "车辆工作量化汇总表");

            outSuccess("Y", "car_workload.xls");
        }
    }
}