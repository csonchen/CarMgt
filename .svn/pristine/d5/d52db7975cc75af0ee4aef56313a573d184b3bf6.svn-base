using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.work.item
{
    public partial class work_items_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定编码
            BLL.work_itemsbll itembll = new BLL.work_itemsbll();
            string itemCode = (int.Parse(itembll.GetMaxCode()) + 1).ToString();
            this.txtItem_Code.Text = itemCode;

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
                if (!new BLL.work_itemsbll().Exists(this.id))
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
            BLL.work_itemsbll bll = new BLL.work_itemsbll();
            Model.work_itemsinfo model = bll.GetModel(_id);

            txtItem_Code.Text = model.Item_Code;
            txtItem_Name.Text = model.Item_Name;
            txtItem_Cost.Text = model.Item_Cost.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.work_itemsinfo model = new Model.work_itemsinfo();
            BLL.work_itemsbll bll = new BLL.work_itemsbll();
            model.Item_Code = txtItem_Code.Text.Trim();
            model.Item_Name = txtItem_Name.Text;
            string s = txtItem_Cost.Text;
            try
            {
                model.Item_Cost = decimal.Parse(s == "" ? "0" : s);
            }
            catch { }

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
            BLL.work_itemsbll bll = new BLL.work_itemsbll();
            Model.work_itemsinfo model = bll.GetModel(_id);

            model.Item_Code = txtItem_Code.Text.Trim();
            model.Item_Name = txtItem_Name.Text;
            string s = txtItem_Cost.Text;
            try
            {
                model.Item_Cost = decimal.Parse(s == "" ? "0" : s);
            }
            catch { }

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
                JscriptMsg("修改值班项成功啦！", "work_items_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.work_itemsbll().Exists(txtItem_Code.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加值班项成功啦！", "work_items_list.aspx", "Success");
            }
        }

    }
}