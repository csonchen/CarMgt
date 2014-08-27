using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.Model;

namespace DTcms.Web.admin.report
{
    public partial class driver_subsidy_report : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int group_id;
        protected string keywords = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定显示驾驶员信息
            BindDriver();
            string task = Request.Params["task"];
            if (task == "exportReport")
            {
                exportReport();
            }
            else if (task == "exportReportForMonDri") 
            {
                exportReportForMonDri();
            }
        }

        //根据月，驾驶员导出报表
        private void exportReportForMonDri()
        {
            #region
            ////接收页面数据
            //string year = Request.Params["year"];
            //string month = Request.Params["month"];
            //string dricode = Request.Params["dricode"];
            ////拼接查询条件
            //string where = "";
            //where = " YEAR(Use_Time) = " + year + " and MONTH(Use_Time) = " + month +
            //        " and Driver_Code = " + dricode;
            ////构造正常上班时间段
            //string stime = "08:30";
            //string etime = "17:30";

            ////查询“车辆使用表”,获取相应的驾驶员信息
            //BLL.car_use_recordbll cubll = new BLL.car_use_recordbll();
            //DataTable tbdribuzhu = cubll.GetList(1000, where, "Driver_Code,Use_Time").Tables[0];

            ////取出“出车时间”，备注信息，构造补助表
            //DataTable tbSubsidy = new DataTable();
            ////构造列属性
            //tbSubsidy.Columns.Add("日期");
            //tbSubsidy.Columns.Add("出车地点");
            //tbSubsidy.Columns.Add("补助标准");
            //tbSubsidy.Columns.Add("备注");
            ////若有该驾驶员驾驶的记录，则添加默认行补助信息
            //if (tbdribuzhu != null || tbdribuzhu.Rows.Count > 0)
            //{
            //    tbSubsidy.Rows.Add();
            //    tbSubsidy.Rows[0]["日期"] = "1---31";
            //    tbSubsidy.Rows[0]["出车地点"] = "市内";
            //    tbSubsidy.Rows[0]["补助标准"] = "200";
            //    tbSubsidy.Rows[0]["备注"] = "常规补助";

            //    int i = 1;
            //    foreach (DataRow dr in tbdribuzhu.Rows)
            //    {
            //        //取出出车日期
            //        string scartime = dr["Use_Time"].ToString();
            //        //格式化日期
            //        scartime = DateTime.Parse(scartime).ToString("yyyy-MM-dd HH:mm:sss");
            //        //取出月份
            //        int scarmonth = DateTime.Parse(scartime).Month;
            //        //取出日
            //        int scarday = DateTime.Parse(scartime).Day;
            //        //取出发车的时间
            //        string ssendcar = DateTime.Parse(scartime).Hour + ":" + DateTime.Parse(scartime).Minute;
            //        //比较发车时间是否在正常时间内
            //        if (DateTime.Parse(ssendcar) < DateTime.Parse(stime))
            //        {
            //            //插入数据的导出表中
            //            tbSubsidy.Rows.Add();
            //            tbSubsidy.Rows[i]["日期"] = scarmonth + "-" + scarday;
            //            tbSubsidy.Rows[i]["出车地点"] = dr["Start_Address"].ToString();
            //            //先写死
            //            tbSubsidy.Rows[i]["补助标准"] = "200";
            //            tbSubsidy.Rows[i]["备注"] = "超时加班";
            //            i++;
            //        }
            //    }
            //}
            #endregion

            //接收页面数据
            string year = Request.Params["year"];
            string month = Request.Params["month"];
            string dricode = Request.Params["dricode"];
            //拼接查询条件（驾驶员编号和使用的月份）
            string where = "";
            //where = " Driver_Code = " + dricode + " and MONTH(Use_Time) =  '" + month + "'";
            where = " Driver_Code = " + dricode;

            //构造补助表
            DataTable tbSubsidy = new DataTable();
            //构造列属性
            tbSubsidy.Columns.Add("日期");
            tbSubsidy.Columns.Add("出车地点");
            tbSubsidy.Columns.Add("补助标准");
            tbSubsidy.Columns.Add("备注");
            //添加默认行属性值
            BLL.work_itemsbll workbll = new BLL.work_itemsbll();
            Model.work_itemsinfo uniqueItem = workbll.GetModel("10001");

            if (uniqueItem != null)
            {
                tbSubsidy.Rows.Add();
                tbSubsidy.Rows[0]["日期"] = "1---31";
                tbSubsidy.Rows[0]["出车地点"] = "市内";
                tbSubsidy.Rows[0]["补助标准"] = uniqueItem.Item_Cost;
                tbSubsidy.Rows[0]["备注"] = uniqueItem.Item_Name;
            }
            

            //根据车辆使用表查询单据编码
            BLL.car_use_recordbll cusebll = new BLL.car_use_recordbll();
            BLL.car_return_recordbll returnbll = new BLL.car_return_recordbll();
            BLL.car_driverbll driverbll = new BLL.car_driverbll();

            //根据驾驶员编码查询驾驶员姓名
            string driname = driverbll.GetTitleByCode(dricode);
            //合计金额
            float totalMoney = 0;

            DataTable dt1 = cusebll.GetList(0, where, "ID").Tables[0];

            int k = 0;
            foreach (DataRow dr in dt1.Rows)
            {
                //出车地点
                string startAddress = dr["Start_Address"].ToString();
                //获取单据编码（某驾驶员）
                string code = dr["Code"].ToString();
                //根据单据编码（某驾驶员）查询补助项编码
                string strwhere = " YEAR(Return_Time) = '" + year + "'" + " and MONTH(Return_Time) ='" + month + "'";
                //string itemCodes = returnbll.GetItemCodes(code,strwhere);
                Model.car_return_recordinfo carreturnModel = returnbll.GetItemCodes(code, strwhere);
                if (carreturnModel != null)
                {
                    string itemCodes = carreturnModel.Item_Code;
                    //获取回车时间
                    string returnTime = carreturnModel.Return_Time;
                    returnTime = DateTime.Parse(returnTime).ToString("yyyy-M-d");
                    //拼接日期输出格式
                    string[] times = returnTime.Split('-');
                    string time = times[1] + "-" + times[2];
                    //分离字符
                    string[] icodes = itemCodes.Split(',');
                    //根据补助编码查找补助项   
                    for (int i = 0; i < icodes.Length; i++)
                    {
                        //接收补助项说明
                        //string workItem = workbll.GetTitleByCode(icodes[i]);
                        Model.work_itemsinfo workItem = workbll.GetModel(icodes[i]);
                        if (workItem != null)
                        {
                            totalMoney += float.Parse(workItem.Item_Cost.ToString());
                            //增加一行
                            tbSubsidy.Rows.Add();
                            tbSubsidy.Rows[k + 1]["日期"] = time;
                            tbSubsidy.Rows[k + 1]["出车地点"] = startAddress;
                            tbSubsidy.Rows[k + 1]["补助标准"] = workItem.Item_Cost;
                            tbSubsidy.Rows[k + 1]["备注"] = workItem.Item_Name;
                            k++;
                        }
                    }
                }
                
            }
            //获取系统当前时间
            string currentTime = DateTime.Now.ToLongDateString().ToString();

            //额外加多8行空白行
            for (int i = 0; i < 8; i++) 
            {
                tbSubsidy.Rows.Add();
            }
            tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["补助标准"] = totalMoney + float.Parse(uniqueItem.Item_Cost.ToString());
            tbSubsidy.Rows.Add();
            tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["备注"] = currentTime;
            tbSubsidy.Rows.Add();
            tbSubsidy.Rows.Add();
            tbSubsidy.Rows[tbSubsidy.Rows.Count - 2]["日期"] = "出车人确认：";
            tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["日期"] = "统计：";
            tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["补助标准"] = "审核：";
            DataTable dt = tbSubsidy;

            List<ExportEntity> list = new List<ExportEntity>();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string colname = dt.Columns[j].ColumnName;
                list.Add(new ExportEntity(colname, colname, colname, "", 15 * 320));//N2
            }

            //DataToExcel.DataTableToExcelForStyle(dt, list, "subsidy_cost2.xls", month + "月份司机行车补助汇总表（" + driname + "）",
            //    false,false,1,1,1,4);
            DataToExcel.DataTableToExcelForStyle3(dt, list, "subsidy_cost2.xls", month + "月份司机行车补助汇总表（" + driname + "）");

            outSuccess("Y", "subsidy_cost2.xls");

        }

        //绑定驾驶员下拉框
        protected void BindDriver() 
        {
            BLL.car_driverbll bll = new BLL.car_driverbll();
            DataTable dt = bll.GetList(1000, "", "ID").Tables[0];
            foreach (DataRow dr in dt.Rows) 
            {
                //获取驾驶员姓名和编码
                string driverCode = dr["Driver_Code"].ToString();
                string driverName = dr["Driver_Name"].ToString();
                ListItem li = new ListItem(driverName, driverCode);
                //添加到下拉框中
                this.driver.Items.Add(li);
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
                edatetime = DateTime.Parse(etime + " 23:59:59");
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
            //if (deptpros != "")
            //{
            //    if (where == "") { where += " Dept_Pros='" + deptpros + "'"; }
            //    else { where += " and Dept_Pros='" + deptpros + "'"; }
            //}
            BLL.car_return_recordbll bll = new BLL.car_return_recordbll();
            DataTable tbcarreturned = bll.GetCarUseReturnReport(1000, where, "Driver_Code,Use_Time").Tables[0];
            BLL.work_itemsbll wbll = new BLL.work_itemsbll();
            DataTable tbwitems = wbll.GetList(1000, "", "ID").Tables[0];
            if (tbcarreturned == null || tbcarreturned.Rows.Count <= 0 || tbwitems == null || tbwitems.Rows.Count <= 0)
            {
                //JscriptMsg("0条记录，无法导出！", "back", "Error");
                outSuccess("N", "0条记录，无法导出！");
                return;
            }
            DataTable tbSubsidy = new DataTable();
            tbSubsidy.Columns.Add("序号");
            tbSubsidy.Columns.Add("姓名");
            tbSubsidy.Columns.Add("日期");
            tbSubsidy.Columns.Add("出车地点");
            tbSubsidy.Columns.Add("补助标准");
            tbSubsidy.Columns.Add("备注");
            string drivercode = "";
            int irownum = 0;
            for (int i = 0; i < tbcarreturned.Rows.Count; i++)
            {
                string sdricode = tbcarreturned.Rows[i]["Driver_Code"] + "";
                string sdriname = tbcarreturned.Rows[i]["Driver_Name"] + "";
                string susetime = tbcarreturned.Rows[i]["Use_Time"] + "";
                string sreturntime = tbcarreturned.Rows[i]["Return_Times"] + "";
                string sendaddress = tbcarreturned.Rows[i]["End_Address"] + "";
                if (sdricode != drivercode)
                {
                    tbSubsidy.Rows.Add();
                    irownum++;
                    tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["序号"] = irownum;
                    tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["姓名"] = sdriname;
                    tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["日期"] = sdatetime.ToString("yyyy-MM-dd") + "-" + edatetime.ToString("yyyy-MM-dd");
                    tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["出车地点"] = "市内";
                    work_itemsinfo witem0 = GetWorkItem(tbwitems, "正常班");
                    TimeSpan midTime0 = sdatetime - edatetime;
                    int iday0 = 1;
                    if (edatetime.Month != sdatetime.Month) { iday0 = edatetime.Month - sdatetime.Month;
                    if (iday0 < 0) { iday0 = iday0 * -1; }
                    }
                    tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["补助标准"] = witem0.Item_Cost * iday0 + (iday0 > 1 ? "(" + iday0 + ")" : "");
                    tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["备注"] = witem0.Item_Name;
                    drivercode = sdricode;
                }
                tbSubsidy.Rows.Add();
                irownum++;
                DateTime time1 = new DateTime();
                DateTime time2 = new DateTime();
                try { time1 = DateTime.Parse(susetime); }
                catch { }
                try { time2 = DateTime.Parse(sreturntime); }
                catch { }
                TimeSpan midTime = time2 - time1;
                string worktype = "正常班";
                if (midTime.Days <= 0 && time2.DayOfWeek == DayOfWeek.Sunday) { worktype = "星期日"; }
                else if(midTime.Days <= 0 && time2.DayOfWeek == DayOfWeek.Saturday) { worktype = "星期六"; }
                else if (midTime.Days > 0 || time2.Hour > 18) { worktype = "超时"; }
                tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["序号"] = irownum;
                tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["姓名"] = sdriname;
                tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["日期"] = time1.ToString("yyyy-MM-dd") + "-" + time2.ToString("yyyy-MM-dd"); ;
                tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["出车地点"] = sendaddress;
                work_itemsinfo witem = GetWorkItem(tbwitems, worktype);
                int iday = 1;
                if (midTime.Days > 0) { iday = midTime.Days + 1; }
                tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["补助标准"] = witem.Item_Cost * iday + (iday > 1 ? "(" + iday + ")" : "");
                tbSubsidy.Rows[tbSubsidy.Rows.Count - 1]["备注"] = witem.Item_Name;
            }

            DataTable dt = tbSubsidy;
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

            DataToExcel.DataTableToExcel(dt, list, "subsidy_cost.xls", "司机行车补助汇总表");

            outSuccess("Y", "subsidy_cost.xls");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tbwitems"></param>
        /// <param name="sworktime">正常班,超时,星期六,星期日,假日</param>
        /// <returns></returns>
        private work_itemsinfo GetWorkItem(DataTable tbwitems,string sworktime)
        {
            work_itemsinfo info = new work_itemsinfo();
            for (int i = 0; i < tbwitems.Rows.Count; i++)
            {
                string iid = tbwitems.Rows[i]["ID"] + "";
                string itecode = tbwitems.Rows[i]["Item_Code"] + "";
                string itename = tbwitems.Rows[i]["Item_Name"] + "";
                string itecost = tbwitems.Rows[i]["Item_Cost"] + "";
                if (itename.Contains(sworktime))
                {
                    info.ID = Convert.ToInt32(iid == "" ? "0" : iid);
                    info.Item_Code = itecode;
                    info.Item_Name = itename;
                    info.Item_Cost = decimal.Parse(itecost == "" ? "0" : itecost);
                    break;
                }
            }
            return info;
        }
    }
}