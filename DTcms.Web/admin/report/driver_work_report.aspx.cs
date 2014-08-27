﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.report
{
    public partial class driver_work_report : Web.UI.ManagePage
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
            else if (task == "exportReportForMonth") 
            {
                exportReportForMonth();
            }
          
        }

        //按照月份导出报表
        private void exportReportForMonth()
        {
            //接收年，月
            string year = Request.Params["year"];
            string month = Request.Params["month"];
            string proNum = Request.Params["pro"];
            //拼接查询的字符串
            string where = "";
            where = where + " YEAR(Use_Time) ='" + year + "' and MONTH(Use_Time) ='" + month +
                    "' and Dept_Pros='" + proNum + "'";

            string proName = "";
            if (proNum == "10001") {
                proName = "总办";
            }
            else if (proNum == "10002") {
                proName = "行政";
            }
            //查询出车数据
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            DataTable tbcarused = bll.GetCarUseRecord(1000, where, "Use_Time").Tables[0];
            //查询驾驶员信息
            BLL.car_driverbll dribll = new BLL.car_driverbll();
            DataTable tbdriver = dribll.GetList(1000, "", "ID").Tables[0];

            //构造导出的excel表的样式
            DataTable tbCarUse = new DataTable();
            //增加1行
            tbCarUse.Rows.Add();
            //第一行（列设置）
            tbCarUse.Columns.Add("姓名");
            //添加驾驶员姓名
            for (int i = 0; i < tbdriver.Rows.Count; i++) {
                string driverName = tbdriver.Rows[i]["Driver_Name"] + "";
                tbCarUse.Columns.Add(driverName);
                //
                tbCarUse.Rows[0][driverName] = "";
            }
            //第二行（列设置）
            tbCarUse.Rows[0]["姓名"] = "日期";

            //根据天数构造行数
            int days = DateTime.DaysInMonth(int.Parse(year), int.Parse(month));
            for (int i = 1; i < days + 1; i++) {
                tbCarUse.Rows.Add();
                tbCarUse.Rows[tbCarUse.Rows.Count - 1]["姓名"] = i;
            }

            BLL.user_deptbll deptbll = new BLL.user_deptbll();
            //添加目的地和部门（注意：这里是从第2行开始，因为第1行额外做添加“日期”属性处理）
            for (int i = 1; i < tbCarUse.Rows.Count; i++)
            {
                ////取出“日”
                string time = tbCarUse.Rows[i]["姓名"] + "";
                //拼接日期
                time = year + "-" + month + "-" + time;
                for (int j = 0; j < tbcarused.Rows.Count; j++)
                {   //取出日期             
                    string utime = tbcarused.Rows[j]["Use_Time"] + "";  
                    //格式化日期
                    //time = DateTime.Parse(time).ToString("yyyy-MM-dd");
                    try { utime = DateTime.Parse(utime).ToString("yyyy-M-d"); }
                    catch { }
                    string driname = tbcarused.Rows[j]["Driver_Name"] + "";
                    string endaddress = tbcarused.Rows[j]["End_Address"] + "";
                    string deptName = deptbll.GetTitleByCode(tbcarused.Rows[j]["Dept_Code"] + "");
                    deptName = "(" + deptName.Substring(0, 1) + ")";
                    if (utime == time)
                    {
                        string svalue = tbCarUse.Rows[i][driname ] + "";
                        svalue = svalue == "" ? endaddress + deptName: svalue + "\r\n" + endaddress + deptName;
                        tbCarUse.Rows[i][driname] = svalue;
                    }
                }
            }

            //转excel
            DataTable dt = tbCarUse;
            //object itemReport = HttpContext.Current.Session["itemReport"];

            //if (itemReport == null)
            //{
            //    JscriptMsg("请先查询！", "back", "Error");
            //    return;
            //}
            //DataTable dt = itemReport as DataTable;
            List<ExportEntity> list = new List<ExportEntity>();
            //list.Add(new ExportEntity("solution_name", "科目类别方案", "solution_name", "", 15 * 256));
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string colname = dt.Columns[j].ColumnName;
                if (j == 0)
                {
                    list.Add(new ExportEntity(colname, colname, colname, "", 15 * 180));//N2
                }
                else
                {
                    list.Add(new ExportEntity(colname, colname, colname, "", 15 * 310));//N2
                }
                
            }

            DataToExcel.DataTableToExcelForStyle(dt, list, "driver_work2.xls", proName + "司机出车汇总表（" + month + "月份）",
                 false,false,false,false,1,1,1,4);

            outSuccess("Y", "driver_work2.xls");
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
            string deptpros = ddlDept_Pros.SelectedValue;
            if (stime == null || stime == "undifine" || stime == "") { stime = Request.Params["stime"]; }
            if (etime == null || etime == "undifine" || etime == "") { etime = Request.Params["etime"]; }
            if (deptpros == null || deptpros == "undifine" || deptpros == "") { deptpros = Request.Params["deptpros"]; }
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
            if (etime != "") {
                if (where == "") { where += " Use_Time<'" + etime + "'"; }
                else { where += " and Use_Time<'" + etime + "'"; }
            }
            if (deptpros != "")
            {
                if (where == "") { where += " Dept_Pros='" + deptpros + "'"; }
                else { where += " and Dept_Pros='" + deptpros + "'"; }
            }
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            DataTable tbcarused = bll.GetCarUseRecord(1000, where, "Use_Time").Tables[0];
            BLL.car_driverbll driverbll = new BLL.car_driverbll();
            DataTable tbdriver = driverbll.GetList(1000, "", "ID").Tables[0];
            if (tbcarused == null || tbcarused.Rows.Count <= 0 || tbdriver == null || tbdriver.Rows.Count <= 0)
            {
                //JscriptMsg("0条记录，无法导出！", "back", "Error");
                outSuccess("N", "0条记录，无法导出！");
                return;
            }
            DataTable tbUseRecord = new DataTable();
            tbUseRecord.Columns.Add("序号");
            tbUseRecord.Columns.Add("日期");
            tbUseRecord.Columns.Add("c");
            for (int i = 0; i < tbdriver.Rows.Count; i++)
            {
                string dricode = tbdriver.Rows[i]["Driver_Code"] + "";
                string driname = tbdriver.Rows[i]["Driver_Name"] + "";
                tbUseRecord.Columns.Add(driname + "(" + dricode + ")");
            }
            int irow = 1;
            for (DateTime time = sdatetime; time < edatetime; time = time.AddDays(1))
            {
                tbUseRecord.Rows.Add();
                tbUseRecord.Rows[tbUseRecord.Rows.Count - 1]["序号"] = irow;
                tbUseRecord.Rows[tbUseRecord.Rows.Count - 1]["日期"] = time.ToString("yyyy-MM-dd");
                irow++;
            }
            for (int i = 0; i < tbUseRecord.Rows.Count; i++)
            {
                string time = tbUseRecord.Rows[i]["日期"] + "";
                for (int j = 0; j < tbcarused.Rows.Count; j++)
                {
                    string utime = tbcarused.Rows[j]["Use_Time"] + "";
                    try { utime = DateTime.Parse(utime).ToString("yyyy-MM-dd"); }
                    catch { }
                    string dricode = tbcarused.Rows[j]["Driver_Code"] + "";
                    string driname = tbcarused.Rows[j]["Driver_Name"] + "";
                    string endaddress = tbcarused.Rows[j]["End_Address"] + "";
                    if (utime == time) {
                        string svalue = tbUseRecord.Rows[i][driname + "(" + dricode + ")"] + "";
                        svalue = svalue == "" ? endaddress : svalue + "\r\n" + endaddress;
                        tbUseRecord.Rows[i][driname + "(" + dricode + ")"] = svalue;
                    }
                }
                
            }
            DataTable dt = tbUseRecord;
            //object itemReport = HttpContext.Current.Session["itemReport"];

            //if (itemReport == null)
            //{
            //    JscriptMsg("请先查询！", "back", "Error");
            //    return;
            //}
            //DataTable dt = itemReport as DataTable;
            List<ExportEntity> list = new List<ExportEntity>();

            list.Add(new ExportEntity("序号", "序号", "序号", "", 15 * 256));
            list.Add(new ExportEntity("日期", "日期", "日期", "", 15 * 256));
            list.Add(new ExportEntity("c", "", "c", "", 15 * 256));
            //list.Add(new ExportEntity("solution_name", "科目类别方案", "solution_name", "", 15 * 256));
            for (int j = 3; j < dt.Columns.Count; j++)
            {
                string colname = dt.Columns[j].ColumnName;
                list.Add(new ExportEntity(colname, colname, colname, "", 15 * 256));//N2
            }

            DataToExcel.DataTableToExcel(dt, list, "driver_work.xls", "司机出车汇总表");

            outSuccess("Y", "driver_work.xls");
        }
    }
}