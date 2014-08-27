<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_repair_record_add.aspx.cs" Inherits="DTcms.Web.admin.cars.repair_record.car_repair_record_add" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑会员信息</title>
<link href="../../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../../images/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
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
            //            rules: {
            //                txtUserName: {
            //                    required: true,
            //                    minlength: 2,
            //                    maxlength: 8,
            //                    remote: {
            //                        type: "post",
            //                        url: "../../tools/admin_ajax.ashx?action=validate_username",
            //                        data: {
            //                            username: function () {
            //                                return $("#txtUserName").val();
            //                            },
            //                            oldusername: function () {
            //                                return $("#hidUserName").val();
            //                            }
            //                        },
            //                        dataType: "html",
            //                        dataFilter: function (data, type) {
            //                            if (data == "true")
            //                                return true;
            //                            else
            //                                return false;
            //                        }
            //                    }
            //                }
            //            },
            success: function (lable) {
                lable.ligerHideTip();
            },
            messages: {
                txtCode: {
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
    维修信息管理 &gt; 编辑维修信息信息</div>
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
                <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtInput normal required" maxlength="16"></asp:TextBox><label>*最好不要超过8位字符。</label></td>
            </tr>
            <tr>
                <th>维修时间：</th>
                <td>
                <asp:TextBox ID="txtRepare_Time" runat="server" CssClass="txtInput normal dateISO" maxlength="20" Width="160px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"></asp:TextBox><label>*</label>
                </td>
            </tr>
            <tr>
                <th>车 牌：</th>
                <td>
                    <asp:DropDownList id="ddlCar_Number" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">车牌1</asp:ListItem>
                        <asp:ListItem Value="10002">车牌2</asp:ListItem>
                        <asp:ListItem Value="10003">车牌3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>维修时公里数：</th>
                <td><asp:TextBox ID="txtMileage" runat="server" CssClass="txtInput normal required" maxlength="16"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>下次保养里数：</th>
                <td><asp:TextBox ID="txtNext_Mileage" runat="server" CssClass="txtInput normal" maxlength="16"></asp:TextBox></td>
            </tr>
            <tr>
                <th>保养项目：</th>
                <td>
                    <asp:DropDownList id="ddlMaintenance_Item" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">保养项目1</asp:ListItem>
                        <asp:ListItem Value="10002">保养项目2</asp:ListItem>
                        <asp:ListItem Value="10003">保养项目3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>修理厂：</th>
                <td>
                    <asp:DropDownList id="ddlRepair_Plant" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">修理厂1</asp:ListItem>
                        <asp:ListItem Value="10002">修理厂2</asp:ListItem>
                        <asp:ListItem Value="10003">修理厂3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>修理挂单人：</th>
                <td>
                    <asp:DropDownList id="ddlDriver_Code" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">司机1</asp:ListItem>
                        <asp:ListItem Value="10002">司机2</asp:ListItem>
                        <asp:ListItem Value="10003">司机3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>维修原因：</th>
                <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtInput normal" 
                        maxlength="16" Height="80px" TextMode="MultiLine" Width="410px"></asp:TextBox></td>
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
