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
    public partial class oil_cost_report : Web.UI.ManagePage
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
            if (stime != "") { where += " Return_Time>'" + stime + "'"; }
            if (etime != "")
            {
                if (where == "") { where += " Return_Time<'" + etime + "'"; }
                else { where += " and Return_Time<'" + etime + "'"; }
            }
            if (deptpros != "")
            {
                if (where == "") { where += " Dept_Pros='" + deptpros + "'"; }
                else { where += " and Dept_Pros='" + deptpros + "'"; }
            }
            BLL.car_use_recordbll bll = new BLL.car_use_recordbll();
            DataTable tbcarcosted = bll.GetCarUseCost(1000, where, "Return_Time").Tables[0];
            if (tbcarcosted == null || tbcarcosted.Rows.Count <= 0)
            {
                //JscriptMsg("0条记录，无法导出！", "back", "Error");
                outSuccess("N", "0条记录，无法导出！");
                return;
            }
            DataTable tbUseCost = new DataTable();
            tbUseCost.Columns.Add("序号");
            tbUseCost.Columns.Add("日期");
            if (deptpros == "10001")
            {
                tbUseCost.Columns.Add("总办");
                tbUseCost.Columns.Add("总办小计");
                tbUseCost.Columns.Add("合计");
            }
            else if (deptpros == "10002")
            {
                tbUseCost.Columns.Add("行政");
                tbUseCost.Columns.Add("行政小计");
                tbUseCost.Columns.Add("合计");
            }
            else
            {
                tbUseCost.Columns.Add("总办");
                tbUseCost.Columns.Add("总办小计");
                tbUseCost.Columns.Add("行政");
                tbUseCost.Columns.Add("行政小计");
                tbUseCost.Columns.Add("合计");
            }
            int irow = 1;
            for (DateTime time = sdatetime; time < edatetime; time = time.AddDays(1))
            {
                tbUseCost.Rows.Add();
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["序号"] = irow;
                tbUseCost.Rows[tbUseCost.Rows.Count - 1]["日期"] = time.ToString("yyyy-MM-dd");
                irow++;
            }
            decimal dprice2 = 0; decimal dprice4 = 0; decimal dprice5 = 0;
            for (int i = 0; i < tbUseCost.Rows.Count; i++)
            {
                string time = tbUseCost.Rows[i]["日期"] + "";
                for (int j = 0; j < tbcarcosted.Rows.Count; j++)
                {
                    string utime = tbcarcosted.Rows[j]["Return_Time"] + "";
                    try { utime = DateTime.Parse(utime).ToString("yyyy-MM-dd"); }
                    catch { }
                    //string dricode = tbcarcosted.Rows[j]["Cost"] + "";
                    //string driname = tbcarcosted.Rows[j]["Driver_Name"] + "";
                    //string endaddress = tbcarcosted.Rows[j]["End_Address"] + "";
                    if (utime == time)
                    {
                        decimal num1 = 0; decimal num2 = 0; decimal num3 = 0; decimal num4 = 0; decimal num5 = 0;
                        if (deptpros == "10001")
                        {
                            if (i > 0)
                            {
                                string s1 = tbUseCost.Rows[i - 1]["总办"] + "";
                                string s2 = tbUseCost.Rows[i - 1]["总办小计"] + "";
                                string s3 = tbUseCost.Rows[i - 1]["合计"] + "";
                                num1 = decimal.Parse(s1 == "" ? "0" : s1);
                                num2 = decimal.Parse(s2 == "" ? "0" : s2);
                                num3 = decimal.Parse(s3 == "" ? "0" : s3);
                            }
                            decimal brcost = 0;
                            string sbrcost = tbcarcosted.Rows[j]["Cost"] + "";
                            brcost = decimal.Parse(sbrcost == "" ? "0" : sbrcost);
                            string st3 = tbUseCost.Rows[i]["总办"] + "";
                            decimal tnum3 = decimal.Parse(st3 == "" ? "0" : st3);
                            tbUseCost.Rows[i]["总办"] = (brcost + tnum3).ToString();
                            dprice4 = dprice4 + brcost;
                            dprice5 = dprice5 + brcost;
                            tbUseCost.Rows[i]["总办小计"] = dprice4.ToString();
                            tbUseCost.Rows[i]["合计"] = dprice5.ToString();
                        }
                        else if (deptpros == "10002")
                        {
                            if (i > 0)
                            {
                                string s1 = tbUseCost.Rows[i - 1]["行政"] + "";
                                string s2 = tbUseCost.Rows[i - 1]["行政小计"] + "";
                                string s3 = tbUseCost.Rows[i - 1]["合计"] + "";
                                num1 = decimal.Parse(s1 == "" ? "0" : s1);
                                num2 = decimal.Parse(s2 == "" ? "0" : s2);
                                num3 = decimal.Parse(s3 == "" ? "0" : s3);
                            }
                            decimal brcost = 0;
                            string sbrcost = tbcarcosted.Rows[j]["Cost"] + "";
                            brcost = decimal.Parse(sbrcost == "" ? "0" : sbrcost);
                            string st1 = tbUseCost.Rows[i]["行政"] + "";
                            decimal tnum1 = decimal.Parse(st1 == "" ? "0" : st1);
                            tbUseCost.Rows[i]["行政"] = (brcost + tnum1).ToString();
                            dprice2 = dprice2 + brcost;
                            dprice5 = dprice5 + brcost;
                            tbUseCost.Rows[i]["行政小计"] = dprice2.ToString();
                            tbUseCost.Rows[i]["合计"] = dprice5.ToString();
                        }
                        else
                        {
                            if (i > 0)
                            {
                                string s1 = tbUseCost.Rows[i - 1]["行政"] + "";
                                string s2 = tbUseCost.Rows[i - 1]["行政小计"] + "";
                                string s3 = tbUseCost.Rows[i - 1]["总办"] + "";
                                string s4 = tbUseCost.Rows[i - 1]["总办小计"] + "";
                                string s5 = tbUseCost.Rows[i - 1]["合计"] + "";
                                num1 = decimal.Parse(s1 == "" ? "0" : s1);
                                num2 = decimal.Parse(s2 == "" ? "0" : s2);
                                num3 = decimal.Parse(s3 == "" ? "0" : s3);
                                num4 = decimal.Parse(s4 == "" ? "0" : s4);
                                num5 = decimal.Parse(s5 == "" ? "0" : s5);
                            }
                            decimal brcost = 0;
                            string sbrcost = tbcarcosted.Rows[j]["Cost"] + "";
                            string _Dept_Pros = tbcarcosted.Rows[j]["Dept_Pros"] + "";
                            brcost = decimal.Parse(sbrcost == "" ? "0" : sbrcost);
                            if (_Dept_Pros == "10001")
                            {
                                dprice4 = dprice4 + brcost;
                                string st3 = tbUseCost.Rows[i]["总办"] + "";
                                decimal tnum3 = decimal.Parse(st3 == "" ? "0" : st3);
                                tbUseCost.Rows[i]["总办"] = (brcost + tnum3).ToString();
                                tbUseCost.Rows[i]["总办小计"] = dprice4.ToString();
                            }
                            if (_Dept_Pros == "10002")
                            {
                                dprice2 = dprice2 + brcost;
                                string st1 = tbUseCost.Rows[i]["行政"] + "";
                                decimal tnum1 = decimal.Parse(st1 == "" ? "0" : st1);
                                tbUseCost.Rows[i]["行政"] = (brcost + tnum1).ToString();
                                tbUseCost.Rows[i]["行政小计"] = dprice2.ToString();
                            }
                            //else
                            //{
                            //    dprice2 = dprice2 + brcost;
                            //    tbUseCost.Rows[i]["行政"] = brcost.ToString();
                            //    tbUseCost.Rows[i]["行政小计"] = dprice2.ToString();
                            //    dprice4 = dprice4 + brcost;
                            //    tbUseCost.Rows[i]["总办"] = brcost.ToString();
                            //    tbUseCost.Rows[i]["总办小计"] = dprice4.ToString();
                            //}
                            dprice5 = dprice5 + brcost;
                            tbUseCost.Rows[i]["合计"] = dprice5.ToString();
                        }
                    }
                }

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

            DataToExcel.DataTableToExcel(dt, list, "oil_cost.xls", "车辆燃油费汇总表");

            outSuccess("Y", "oil_cost.xls");
        }
    }
}