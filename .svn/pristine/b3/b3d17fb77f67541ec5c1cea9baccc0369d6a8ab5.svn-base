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

        //根据日期导出数据
        private void exportReportForMonDri()
        {
            //接收页面数据
            string year = Request.Params["year"];
            string month = Request.Params["month"];
            string dricode = Request.Params["dricode"];
            //string deptpro = Request.Params["deptpro"];

            //拼接查询的字符串
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" Driver_Code = " + dricode);
            strWhere.Append(" and YEAR(Use_Time) ='" + year + "' and MONTH(Use_Time) ='" + month + "'");
            //保养维修项查询字符串
            StringBuilder strWhere2 = new StringBuilder();
            strWhere2.Append(" Driver_Code = " + dricode);
            strWhere2.Append(" and YEAR(Repare_Time_Finish) = '" + year + "' and MONTH(Repare_Time_Finish) = '" + month + "'");
            //事故项查询字符串
            StringBuilder strWhere3 = new StringBuilder();
            strWhere3.Append(" Driver_Code = " + dricode);
            strWhere3.Append(" and YEAR(Accident_Time) = '" + year + "' and MONTH(Accident_Time) = '" + month + "'" );

            BLL.car_use_recordbll cubll = new BLL.car_use_recordbll();
            BLL.car_return_recordbll crbll = new BLL.car_return_recordbll();
            BLL.car_repair_recordbll crepairbll = new BLL.car_repair_recordbll();
            BLL.accident_recordbll arbll = new BLL.accident_recordbll();
            
            //根据驾驶员编码查找驾驶员姓名
            string driname = new BLL.car_driverbll().GetTitleByCode(dricode);

            //根据出车时间降序排序
            DataTable dt1 = cubll.GetList(0, strWhere.ToString(), "Use_Time desc").Tables[0];
            //查找保养维修项记录
            DataTable dt2 = crepairbll.GetList(0, strWhere2.ToString(), "ID desc").Tables[0];
            //查找事故项记录
            DataTable dt3 = arbll.GetList(0, strWhere3.ToString(), "ID desc").Tables[0];

            //构造导出表样式
            DataTable tbWorkload = new DataTable();

            tbWorkload.Columns.Add("序号");
            tbWorkload.Columns.Add("项目");
            tbWorkload.Columns.Add("统计");
            tbWorkload.Columns.Add("统计2");
            tbWorkload.Columns.Add("统计3");
            tbWorkload.Rows.Add();


            //增加一行
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows[1]["序号"] = "1";
            tbWorkload.Rows[1]["项目"] = "出车次数";
            tbWorkload.Rows[1]["统计"] = "市内";
            tbWorkload.Rows[1]["统计2"] = "外地";
            tbWorkload.Rows[1]["统计3"] = "累计（次）";

            //增加一行
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows[5]["序号"] = "2";
            tbWorkload.Rows[5]["项目"] = "安全行车公里数";
            tbWorkload.Rows[5]["统计"] = "月初";
            tbWorkload.Rows[5]["统计2"] = "月末";
            tbWorkload.Rows[5]["统计3"] = "累计（公里）";

            //增加一行
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows[9]["序号"] = "3";
            tbWorkload.Rows[9]["项目"] = "工作延时";
            tbWorkload.Rows[9]["统计"] = "次数";
            tbWorkload.Rows[9]["统计2"] = "小时";
            tbWorkload.Rows[9]["统计3"] = "累计（小时）";

            //增加一行
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows[13]["序号"] = "4";
            tbWorkload.Rows[13]["项目"] = "保养维修";
            tbWorkload.Rows[13]["统计"] = "日常维护";
            tbWorkload.Rows[13]["统计2"] = "车辆维修";
            tbWorkload.Rows[13]["统计3"] = "累计（次）";

            //增加一行
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows.Add();
            tbWorkload.Rows[17]["序号"] = "5";
            tbWorkload.Rows[17]["项目"] = "事故";
            tbWorkload.Rows[17]["统计"] = "次数";
            tbWorkload.Rows[17]["统计2"] = "责任划分";
            tbWorkload.Rows[17]["统计3"] = "累计（次）";

            //出车次数
            int oncityCount = 0;//市内
            int outcityCount = 0;//市外
            int totalCount = 0;//出车总次数(市内+市外)

            //该司机最早的出车时间下的最初里程(时间倒序排序，取最后一条)
            string mileageFirst = "";
            //回车时间集合
            List<DateTime> returnTimeList = new List<DateTime>();

            //延时次数
            int delayCount = 0;
            //公司下班时间（内嵌到代码）
            DateTime offWorkTime = DateTime.Parse("17:30");
            int standardHour = 17;
            int standardMinute = 30;
            //延时小时数
            int delayHours = 0;
            //延时分钟数
            int delayMinutes = 0;

            //日常维护项记录数
            int maintenanceCount = 0;
            //日常维修项记录数
            int repairCount = 0;

            //统计事故项记录数
            int accidentCount = dt3.Rows.Count;

            foreach (DataRow dr in dt1.Rows)
            {
                //获取出车地点范围
                string oncity = dr["OnCity"] + "";
                if (oncity.Trim() == "1")//0：市外；1：市内
                {
                    oncityCount++;
                }
                else if (oncity.Trim() == "0")
                {
                    outcityCount++;
                }
                string time = dr["Use_Time"] + "";
                //获取出车时间
                mileageFirst = dr["Mileage_First"] + "";
                //获取出车单号
                string sourceCode = dr["Code"] + "";
                //根据出车单号查找回车时间
                Model.car_return_recordinfo model = crbll.GetItemCodes(sourceCode, "");
                if (model != null)
                {
                    string returnTime = model.Return_Time;
                    returnTimeList.Add(DateTime.Parse(returnTime));
                    //时
                    int hour = DateTime.Parse(returnTime).Hour;
                    //分
                    int minute = DateTime.Parse(returnTime).Minute;
                    //实际时间
                    DateTime realOffWorkTime = DateTime.Parse(hour + ":" + minute);
                    //对比下班时间，计算延时次数
                    if (realOffWorkTime > offWorkTime)
                    {
                        delayCount++;//延时次数+1
                        int delalHour = hour - standardHour;
                        int delayMinute = minute - standardMinute;
                        delayHours = delayHours + delalHour;//延时累加(小时数)
                        delayMinutes = delayMinutes + delayMinute;//延时累计（分钟数）
                        if (delayMinutes >= 60)
                        {
                            delayHours++;//延时分钟数大于60，小时数+1
                            delayMinutes = delayMinutes - 60;
                        }
                    }

                }
            }
            //比较最后剩余的累计分钟数
            if (delayMinutes > 30)
            {
                delayHours++;//剩余分钟数大于30，小时数+1
            }
            //统计保养维修项记录数
            foreach (DataRow dr in dt2.Rows)
            { 
                //获取保养维修项记录编号(1:保养；2：维修；3：保养+维修)
                string choice = dr["Choice"] + "";
                if (choice.Trim() == "1")
                {
                    maintenanceCount++;//保养项+1
                }
                else if (choice.Trim() == "2")
                {
                    repairCount++;//维修项+1
                }
                else 
                {
                    //保养，维修项各+1；
                    maintenanceCount++;
                    repairCount++;
                }
            }

            //出车次数
            totalCount = oncityCount + outcityCount;
            tbWorkload.Rows[3]["统计"] = oncityCount;
            tbWorkload.Rows[3]["统计2"] = outcityCount;
            tbWorkload.Rows[3]["统计3"] = totalCount;

            //安全行车公里数
            tbWorkload.Rows[7]["统计"] = mileageFirst;
            if (returnTimeList.Count > 0)
            {
                //对集合中的时间排序(升序)
                returnTimeList.Sort();

                //取出日期最大的数据
                DateTime maxReturnTime = returnTimeList[returnTimeList.Count - 1];
                //根据该日期查找最终里程
                string mileageEnd = crbll.GetMileageEnd(maxReturnTime.ToString("yyyy-MM-dd HH:mm:ss"));
                tbWorkload.Rows[7]["统计2"] = mileageEnd;
                tbWorkload.Rows[7]["统计3"] = int.Parse(mileageEnd) - int.Parse(mileageFirst);
            }

            //工作延时
            tbWorkload.Rows[11]["统计"] = delayCount;
            tbWorkload.Rows[11]["统计2"] = delayHours;
            tbWorkload.Rows[11]["统计3"] = delayHours;

            //保养维修
            tbWorkload.Rows[15]["统计"] = maintenanceCount;
            tbWorkload.Rows[15]["统计2"] = repairCount;
            tbWorkload.Rows[15]["统计3"] = maintenanceCount + repairCount;

            //事故
            tbWorkload.Rows[19]["统计"] = accidentCount;
            tbWorkload.Rows[19]["统计2"] = 0;
            tbWorkload.Rows[19]["统计3"] = accidentCount;

            DataTable dt = tbWorkload;

            List<ExportEntity> list = new List<ExportEntity>();
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                string colname = dt.Columns[j].ColumnName;
                if (j == 0)
                {
                    list.Add(new ExportEntity(colname, colname, colname, "", 18 * 100));//N2
                }
                else if (j == 1)
                {
                    list.Add(new ExportEntity(colname, colname, colname, "", 18 * 300));//N2
                }
                else 
                {
                    list.Add(new ExportEntity(colname, colname, colname, "", 18 * 260));//N2
                }   
            }

            DataToExcel.DataTableToExcelForStyle(dt, list, "car_workload2.xls", month + "月份车队工作量化表（" + driname + "）",
                 false, true, false, true, 1, 1, 1, 5);

            outSuccess("Y", "car_workload2.xls");
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