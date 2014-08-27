using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;

namespace DTcms.Web.admin.cars.maintenance_item
{
    public partial class car_maintenance_item_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            //绑定编码
            BLL.car_maintenance_itembll cmibll = new BLL.car_maintenance_itembll();
            string code = (int.Parse(cmibll.GetMaxCode()) + 1).ToString();
            this.txtCode.Text = code;

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
                if (!new BLL.car_maintenance_itembll().Exists(this.id))
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
            BLL.car_maintenance_itembll bll = new BLL.car_maintenance_itembll();
            Model.car_maintenance_iteminfo model = bll.GetModel(_id);

            txtCode.Text = model.Code;
            txtMaintenance_Item_Name.Text = model.Maintenance_Item_Name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.car_maintenance_iteminfo model = new Model.car_maintenance_iteminfo();
            BLL.car_maintenance_itembll bll = new BLL.car_maintenance_itembll();
            model.Code = txtCode.Text.Trim();
            model.Maintenance_Item_Name = txtMaintenance_Item_Name.Text;

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
            BLL.car_maintenance_itembll bll = new BLL.car_maintenance_itembll();
            Model.car_maintenance_iteminfo model = bll.GetModel(_id);

            model.Code = txtCode.Text.Trim();
            model.Maintenance_Item_Name = txtMaintenance_Item_Name.Text;

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
                JscriptMsg("修改保养项成功啦！", "car_maintenance_item_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                if (new BLL.car_maintenance_itembll().Exists(txtCode.Text.Trim()))
                {
                    JscriptMsg("编码已存在啦！", "", "Error");
                    return;
                }
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加保养项成功啦！", "car_maintenance_item_list.aspx", "Success");
            }
        }

    }
}