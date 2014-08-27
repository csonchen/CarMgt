<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_driver_edit.aspx.cs" Inherits="DTcms.Web.admin.cars.driver.car_driver_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑司机信息</title>
<link href="../../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../../images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../../../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../../js/function.js"></script>
<script type="text/javascript">
    //表单验证
    $(function () {
        $("#form1").validate({
            invalidHandler: function (e, validator) {
                parent.jsprint("有 " + validator.numberOfInvalids() + " 项填写有误，请检查！", "", "Warning");
            },
            errorPlacement: function (lable, element) {
                //可见元素显示错误提示
                if (element.parents(".tab_con").css('display') != 'none') {
                    element.ligerTip({ content: lable.html(), appendIdTo: lable });
                }
            },
            success: function (lable) {
                lable.ligerHideTip();
            },
            messages: {
                txtDept_Code: {
                    required: "输入(2-8)位字符",
                    minlength: "必须大于2位字符",
                    maxlength: "必须小于8位字符",
                    remote: "抱歉，该编码不可用"
                }
            }
        });
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 
    驾驶员管理 &gt; 编辑驾驶员信息</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <%--<li><a onclick="tabs('#contentTab',1);" href="javascript:;">账户信息</a></li>--%>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>编 码：</th>
                <td><asp:TextBox ID="txtDriver_Code" runat="server" CssClass="txtInput normal required" maxlength="16" ReadOnly="true"></asp:TextBox><label>*最好不要超过8位字符。</label></td>
            </tr>
            <tr>
                <th>名 称：</th>
                <td><asp:TextBox ID="txtDriver_Name" runat="server" CssClass="txtInput normal required" maxlength="100"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>性 别：</th>
                <td>
                    <asp:RadioButtonList ID="rblSex" runat="server"  RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">保密 </asp:ListItem>
                        <asp:ListItem Value="1">男 </asp:ListItem>
                        <asp:ListItem Value="2">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <th>生 日：</th>
                <td><asp:TextBox ID="txtBirthday" runat="server" CssClass="txtInput normal dateISO" maxlength="20"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>身份证：</th>
                <td><asp:TextBox ID="txtIdentity_Num" runat="server" CssClass="txtInput normal " maxlength="25"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>初领证日期：</th>
                <td><asp:TextBox ID="txtCollarDate" runat="server" CssClass="txtInput normal dateISO" maxlength="20"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>地 址：</th>
                <td><asp:TextBox ID="txtAddress" runat="server" CssClass="txtInput normal " maxlength="200"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>驾驶证号：</th>
                <td><asp:TextBox ID="txtDriving_License_Num" runat="server" CssClass="txtInput normal " maxlength="26"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>准驾车型：</th>
                <td>
                    <asp:DropDownList id="ddlLicense_Type" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="A1">A1</asp:ListItem>
                        <asp:ListItem Value="A2">A2</asp:ListItem>
                        <asp:ListItem Value="A3">A3</asp:ListItem>
                        <asp:ListItem Value="B1">B1</asp:ListItem>
                        <asp:ListItem Value="B2">B2</asp:ListItem>
                        <asp:ListItem Value="C1">C1</asp:ListItem>
                        <asp:ListItem Value="C2">C2</asp:ListItem>
                        <asp:ListItem Value="C3">C3</asp:ListItem>
                        <asp:ListItem Value="C4">C4</asp:ListItem>
                        <asp:ListItem Value="D">D</asp:ListItem>
                        <asp:ListItem Value="E">E</asp:ListItem>
                        <asp:ListItem Value="F">F</asp:ListItem>
                        <asp:ListItem Value="M">M</asp:ListItem>
                        <asp:ListItem Value="N">N</asp:ListItem>
                        <asp:ListItem Value="P">P</asp:ListItem>
                    </asp:DropDownList>
                    </asp:RadioButtonList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>电 话：</th>
                <td><asp:TextBox ID="txtTelehone" runat="server" CssClass="txtInput normal " maxlength="26"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>所属部门：</th>
                <td>
                    <asp:DropDownList id="ddlDept_Code" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">部门1</asp:ListItem>
                        <asp:ListItem Value="10002">所属部门2</asp:ListItem>
                        <asp:ListItem Value="10003">所属部门3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
     <div class="tab_con">
    </div>

    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
</div>
</form>
</body>
</html>
