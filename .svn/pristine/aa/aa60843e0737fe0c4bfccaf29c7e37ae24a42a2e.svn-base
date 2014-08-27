using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.users.dept
{
    public partial class user_dept_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定编码
            BLL.user_deptbll udbll = new BLL.user_deptbll();
            string deptCode = (int.Parse(udbll.GetMaxCode()) + 1).ToString();
            this.txtDept_Code.Text = deptCode;

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
                if (!new BLL.user_deptbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                //TreeBind("is_lock=0"); //绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 绑定类别=================================
        //private void TreeBind(string strWhere)
        //{
        //    BLL.user_groups bll = new BLL.user_groups();
        //    DataTable dt = bll.GetList(0, strWhere, "grade asc,id asc").Tables[0];

        //    this.ddlGroupId.Items.Clear();
        //    this.ddlGroupId.Items.Add(new ListItem("请选择组别...", ""));
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        this.ddlGroupId.Items.Add(new ListItem(dr["title"].ToString(), dr["id"].ToString()));
        //    }
        //}
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.user_deptbll bll = new BLL.user_deptbll();
            Model.user_deptinfo model = bll.GetModel(_id);

            txtDept_Code.Text = model.Dept_Code;
            txtDept_Name.Text = model.Dept_Name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.user_deptinfo model = new Model.user_deptinfo();
            BLL.user_deptbll bll = new BLL.user_deptbll();
            model.Dept_Code = txtDept_Code.Text.Trim();
            model.Dept_Name = txtDept_Name.Text;

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
            BLL.user_deptbll bll = new BLL.user_deptbll();
            Model.user_deptinfo model = bll.GetModel(_id);

            model.Dept_Code = txtDept_Code.Text.Trim();
            model.Dept_Name = txtDept_Name.Text;

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
                JscriptMsg("修改部门成功啦！", "user_deptlist.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.user_deptbll().Exists(txtDept_Code.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加部门成功啦！", "user_deptlist.aspx", "Success");
            }
        }

    }
}