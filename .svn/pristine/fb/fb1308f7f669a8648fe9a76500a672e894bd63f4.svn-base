using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.cars.norules
{
    public partial class norules_class_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作违规类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改违规类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
                if (!new BLL.norules_classbll().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.norules_classbll bll = new BLL.norules_classbll();
            Model.norules_classinfo model = bll.GetModel(_id);

            txtNRules_Code.Text = model.NRules_Code;
            txtNRules_Name.Text = model.NRules_Name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.norules_classinfo model = new Model.norules_classinfo();
            BLL.norules_classbll bll = new BLL.norules_classbll();
            model.NRules_Code = txtNRules_Code.Text.Trim();
            model.NRules_Name = txtNRules_Name.Text;

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
            BLL.norules_classbll bll = new BLL.norules_classbll();
            Model.norules_classinfo model = bll.GetModel(_id);

            model.NRules_Code = txtNRules_Code.Text.Trim();
            model.NRules_Name = txtNRules_Name.Text;

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
                JscriptMsg("修改车型成功啦！", "norules_class_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.norules_classbll().Exists(txtNRules_Code.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加车型成功啦！", "norules_class_list.aspx", "Success");
            }
        }

    }
}