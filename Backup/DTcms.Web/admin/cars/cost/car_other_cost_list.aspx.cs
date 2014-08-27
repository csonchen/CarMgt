﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;
using FSHH.HQ.XYJ.Web.xyj.Vendor.CertifcateCategory;

namespace DTcms.Web.admin.cars.cost
{
    public partial class car_other_cost_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int group_id;
        protected string keywords = string.Empty;
        protected Model.manager admin_info;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.group_id = DTRequest.GetQueryInt("group_id");
            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(15); //每页数量
            admin_info = GetAdminInfo();
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.View.ToString()); //检查权限
                RptBind("id>0" + CombSqlTxt(this.keywords), "id desc");
            }

            string straction = "";
            if (Request.QueryString == null || Request.QueryString.Keys.Count <= 0 || Request.QueryString["action"] == null) { }
            else
            {
                straction = Request.QueryString["action"].ToString();
            }
            if (Request.Form == null || Request.Form.Keys.Count <= 0 || Request.Form["action"] == null) { }
            else
            {
                if (straction.Trim() == "")
                {
                    straction = Request.Form["action"].ToString();
                }
            }
            if (straction == "")
            {

            }
            else if (straction == "AfterStatus") { AfterStatus(); }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            this.txtKeywords.Text = this.keywords;
            BLL.car_other_costbll bll = new BLL.car_other_costbll();
            DataTable tb = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount).Tables[0];
            tb.Columns.Add("StatusText");
            tb.Columns.Add("StatusHandleText");
            for (int i = 0; i < tb.Rows.Count; i++)
            {
                int status = Convert.ToInt32(tb.Rows[i]["Status"] + "");
                tb.Rows[i]["StatusText"] = GetStatusText(status);
                tb.Rows[i]["StatusHandleText"] = GetStatusHandleText(status);
            }
            this.rptList.DataSource = tb;
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("car_other_cost_list.aspx", "group_id={0}&keywords={1}&page={2}",
                this.group_id.ToString(), this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (Tittle like '%" + _keywords + "%' or Code like '%" + _keywords + "%')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("car_other_cost_list_page_size"), out _pagesize))
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
            Response.Redirect(Utils.CombUrlTxt("car_other_cost_list.aspx", "group_id={0}&keywords={1}",
                this.group_id.ToString(), txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("car_other_cost_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("car_other_cost_list.aspx", "group_id={0}&keywords={1}",
                this.group_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.car_other_costbll bll = new BLL.car_other_costbll();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("car_other_cost_list.aspx", "group_id={0}&keywords={1}",
                this.group_id.ToString(), this.keywords), "Success");
        }

        private void AfterStatus()
        {
            string strid = StringTrim(Request.Form["id"]);
            int id = Convert.ToInt32(strid);
            string strstatus = StringTrim(Request.Form["status"]);

            ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.car_other_costbll bll = new BLL.car_other_costbll();
            DTcms.Model.car_other_costinfo record = bll.GetModel(id);
            int iresult = 0;
            string strupdate = "Status=1,Checker_Code='" + admin_info.user_name + "',Check_Time='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss") + "'";
            iresult = bll.UpdateField(id, strupdate);
            ResultView view = new ResultView();
            view.putData("result", iresult);
            outResult(view);
        }

        private string GetStatusText(int status)
        {
            string value = "未审核";
            if (status == 1) { value = "审核通过"; }
            return value;
        }

        private string GetStatusHandleText(int status)
        {
            string value = "";
            if (status == 0) { value = "审核通过"; }
            return value;
        }
        string StringTrim(string s)
        {
            string value = s;
            if (s == "undefined" || s == "null" || s == null) { value = ""; }
            return value;
        }

    }
}