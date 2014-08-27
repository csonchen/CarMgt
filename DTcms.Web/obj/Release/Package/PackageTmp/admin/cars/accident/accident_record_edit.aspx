<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accident_record_edit.aspx.cs" Inherits="DTcms.Web.admin.cars.accident.accident_record_edit" %>
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
                txtType_Code: {
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
    事故管理 &gt; 编辑事故信息</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <li><a onclick="tabs('#contentTab',1);" href="javascript:;">图片信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>编 码：</th>
                <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtInput normal required" maxlength="16" Width="120px"></asp:TextBox><label>*</label></td>
                <th>车牌：</th>
                <td><asp:DropDownList id="ddlCar_Number" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">车型1</asp:ListItem>
                        <asp:ListItem Value="10002">车型2</asp:ListItem>
                        <asp:ListItem Value="10003">车型3</asp:ListItem>
                    </asp:DropDownList><label>*</label></td>
            </tr>
            <tr>
                <th>部门：</th>
                <td><asp:DropDownList id="ddlDept_Code" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">车型1</asp:ListItem>
                        <asp:ListItem Value="10002">车型2</asp:ListItem>
                        <asp:ListItem Value="10003">车型3</asp:ListItem>
                    </asp:DropDownList><label>*</label></td>
                <th>肇事人：</th>
                <td><asp:DropDownList id="ddlDriver_Code" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">车型1</asp:ListItem>
                        <asp:ListItem Value="10002">车型2</asp:ListItem>
                        <asp:ListItem Value="10003">车型3</asp:ListItem>
                    </asp:DropDownList><label>*</label></td>
            </tr>
            <tr>
                <th>肇事时间：</th>
                <td>
                <asp:TextBox ID="txtAccident_Time" runat="server" CssClass="txtInput normal" maxlength="20" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" Width="120px"></asp:TextBox>
                </td>
                <th>事故责任：</th>
                <td><asp:DropDownList id="ddlDuty" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="全部责任">全部责任</asp:ListItem>
                        <asp:ListItem Value="主要责任">主要责任</asp:ListItem>
                        <asp:ListItem Value="次要责任">次要责任</asp:ListItem>
                        <asp:ListItem Value="对等责任">对等责任</asp:ListItem>
                    </asp:DropDownList><label>*</label></td>
            </tr>
            <tr>
                <th>地址：</th>
                <td colspan="3"><asp:TextBox ID="txtAddress" runat="server" CssClass="txtInput normal required" maxlength="100" Width="500px"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>伤亡情况：</th>
                <td colspan="3"><asp:TextBox ID="txtInjured" runat="server" CssClass="txtInput normal required" maxlength="100" Width="500px"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>经济损失：</th>
                <td><asp:TextBox ID="txtLostCost" runat="server" CssClass="txtInput normal required" maxlength="100" onblur="this.value=floatChange(this)" Width="120px"></asp:TextBox><label>*</label></td>
                <th>罚款：</th>
                <td><asp:TextBox ID="txtFine" runat="server" CssClass="txtInput normal required" maxlength="100" onblur="this.value=floatChange(this)" Width="120px"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>实际赔偿：</th>
                <td><asp:TextBox ID="txtPayCost" runat="server" CssClass="txtInput normal required" maxlength="100" onblur="this.value=floatChange(this)" Width="120px"></asp:TextBox><label>*</label></td>
                <th>索赔差额：</th>
                <td><asp:TextBox ID="txtNoPayCost" runat="server" CssClass="txtInput normal required" maxlength="100" onblur="this.value=floatChange(this)" Width="120px"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>事故经过：</th>
                <td colspan="3"><asp:TextBox ID="txtAccident_Reason" runat="server" CssClass="txtInput normal " maxlength="16" TextMode="MultiLine" Width="500px" Height="120px"></asp:TextBox></td>
            </tr>
            </tbody>
        </table>
    </div>
     <div class="tab_con">
        <table class="form_table">
            <tbody>
            <tr>
                <td>图片一：</td>
                <td>图片二</td>
            </tr>
            <tr>
                <td>
                <div style="width:200px;height:200px;border:1px ridge #717171"><asp:Image ID="Image1" runat="server" Width="100%" Height="100%" /></div>
                </td>
                <td>
                <div style="width:200px;height:200px;border:1px ridge #717171"><asp:Image ID="Image2" runat="server" Width="100%" Height="100%" /></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                    <input type="button" value="清除" />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <input type="button" value="清除" />
                </td>
            </tr>
            <tr>
                <td>图片三：</td>
                <td>图片四</td>
            </tr>
            <tr>
                <td>
                <div style="width:200px;height:200px;border:1px ridge #717171"><asp:Image ID="Image3" runat="server" Width="100%" Height="100%" /></div>
                </td>
                <td>
                <div style="width:200px;height:200px;border:1px ridge #717171"><asp:Image ID="Image4" runat="server" Width="100%" Height="100%" /></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:FileUpload ID="FileUpload3" runat="server" />
                    <input type="button" value="清除" />
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload4" runat="server" />
                    <input type="button" value="清除" />
                </td>
            </tr>
            </tbody>
        </table>
    </div>

    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
</div>
</form>
</body>
</html>
