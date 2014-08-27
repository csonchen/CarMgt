<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_repair_item_edit.aspx.cs" Inherits="DTcms.Web.admin.cars.repair_item.car_repair_item_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑会员信息</title>
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
    维修项管理 &gt; 编辑维修项信息</div>
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
                <td><asp:TextBox ID="txtCode" runat="server" CssClass="txtInput normal required" maxlength="16" ReadOnly="true"></asp:TextBox><label>*最好不要超过8位字符。</label></td>
            </tr>
            <tr>
                <th>名 称：</th>
                <td><asp:TextBox ID="txtRepair_Item_Name" runat="server" CssClass="txtInput normal required" maxlength="100"></asp:TextBox><label>*</label></td>
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
