<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_use_record_edit.aspx.cs" Inherits="DTcms.Web.admin.cars.car_use_record.car_use_record_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑车辆登记信息</title>
<link href="../../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../../images/style.css" rel="stylesheet" type="text/css" />
<script src="../../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../../../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../../../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../../js/function.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/kindeditor-min.js"></script>
<script type="text/javascript" charset="utf-8" src="../../editor/lang/zh_CN.js"></script>

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
    function checkone(ele) {
        var che = $(ele).attr('checked');
        var unche = false;
        if (che == false) { unche = true; }
        $('#Range1').attr('checked', unche);
        $('#Range2').attr('checked', unche);
        $(ele).attr('checked', che);
    }
</script>
    <style type="text/css">
        .auto-style1
        {
            height: 35px;
            
        }
        .auto-style2
        {
            height: 35px;
            width:200px
        }
    </style>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 
    车辆使用管理 &gt; 编辑车辆登记</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <%--<li><a onclick="tabs('#contentTab',1);" href="javascript:;">账户信息</a></li>--%>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"></col>
            <col width="*"></col>
            <col width="150px"></col>
            <col width="*"></col>
            <tbody>
            <tr>
                <th class="auto-style1">编 码：</th>
                <td class="auto-style2"><asp:TextBox ID="txtCode" runat="server" CssClass="txtInput normal required" maxlength="16" Width="160px" ReadOnly="true"></asp:TextBox><label>*</label></td>
                <th class="auto-style1">出车时间：</th>
                <td class="auto-style1">
                <asp:TextBox ID="txtUse_Time" runat="server" CssClass="txtInput normal required dateISO" maxlength="20" Width="160px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>地点范围：</th>
                <td>
                <input id="Range1" runat="server" name="Range1" type="checkbox" checked="checked" onclick="checkone(this);" />市内
                <input id="Range2" runat="server" name="Range2" type="checkbox" onclick="checkone(this);" />市外<label>*</label></td>
                <th>预计还车时间：</th>
                <td>
                <asp:TextBox ID="txtReturn_Time" runat="server" CssClass="txtInput normal required dateISO" maxlength="20" Width="160px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th class="auto-style1">用车部门：</th>
                <td>
                    <asp:DropDownList ID="ddlDept_Code" CssClass="select2 required" runat="server" 
                        onselectedindexchanged="ddlDept_Code_SelectedIndexChanged" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <th class="auto-style1">用车人：</th>
                <td>
                    <asp:DropDownList id="ddlUser_Code" CssClass="select2 required" runat="server" OnSelectedIndexChanged="ddlUser_Code_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                    
                </td>
            </tr>
            <tr>
                <th>使用车车牌：</th>
                <td>
                    <asp:DropDownList id="ddlCar_Number" CssClass="select2 required" runat="server" >
                    </asp:DropDownList>
                    
                </td>
                <th>驾驶员：</th>
                <td>
                    <asp:DropDownList id="ddlDriver_Code" CssClass="select2 required" runat="server">
                    </asp:DropDownList>
                   
                </td>
            </tr>
            <tr>
                <th>起始地点：</th>
                <td colspan="3"><asp:TextBox ID="txtStart_Address" runat="server" CssClass="txtInput normal required " maxlength="16" Width="520px"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>目的地：</th>
                <td colspan="3"><asp:TextBox ID="txtEnd_Address" runat="server" CssClass="txtInput normal required " maxlength="16" Width="520px"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>

                <th>人数：</th>
                <td>
                <asp:TextBox ID="txtUser_Number" runat="server" 
                        CssClass="txtInput normal required" maxlength="20" Width="160px"></asp:TextBox><label>*</label>
                </td>
                                <th>起始里程：</th>
                <td>
<%--                <asp:TextBox ID="txtMileage_First" runat="server" 
                        CssClass="txtInput normal" maxlength="20" Width="160px" onblur="this.value=intChange(this)"></asp:TextBox>--%>
                <asp:TextBox ID="txtMileage_First" runat="server" 
                        CssClass="txtInput normal" maxlength="20" Width="160px"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <th>联系人：</th>
                <td>
                <asp:TextBox ID="txtConnecter" runat="server" 
                        CssClass="txtInput normal" maxlength="20" Width="160px"></asp:TextBox>
                </td>
                <th>电话：</th>
                <td>
                <asp:TextBox ID="txtTel" runat="server" 
                        CssClass="txtInput normal" maxlength="20" Width="160px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>备注：</th>
                <td colspan="3"><asp:TextBox ID="txtUContent" runat="server" CssClass="txtInput normal " maxlength="16" TextMode="MultiLine" Width="520px" Height="60px"></asp:TextBox></td>
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
