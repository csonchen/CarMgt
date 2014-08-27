<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_repair_record_edit.aspx.cs" Inherits="DTcms.Web.admin.cars.repair_record.car_repair_record_edit" %>
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
    function additem() {
        var itemhtmltop = "<tr id='code0'>";
        itemhtmltop += "<th>维修项编码</th>";
        itemhtmltop += "<th>维修项名称</th>";
        itemhtmltop += "<th>金额</th>";
        itemhtmltop += "<th>操作</th>";
        itemhtmltop += "</tr>";
        var additemhtml = $('#itemshtml').html();
        additemhtml = additemhtml.replace(itemhtmltop, "");
        var itemcode = $('#ddlRepair_Item').val();
        var itemtitle = $('#ddlRepair_Item').find("option:selected").text();
        var itemcost = $('#txtaddcost').val();
        var dcost = parseFloat(itemcost);
        var codelist = $('#codelist').val();
        var costlist = $('#costlist').val();
        if (codelist == "") { codelist += itemcode; }
        else { codelist += "," + itemcode; }
        if (costlist == "") { costlist += dcost; }
        else { costlist += "," + dcost; }
        if (dcost > 0) {
            if (additemhtml.indexOf(itemcode) < 0) {
                additemhtml += "<tr id='code" + itemcode + "'>";
                additemhtml += "<td style=\"text-align:center\">" + itemcode + "<input type='hidden' id='itemcode_" + itemcode + "' name='itemcode" + itemcode + "' class=\"itemcode\" value='" + itemcode + "' /></td>";
                additemhtml += "<td style=\"text-align:center\">" + itemtitle + "</td>";
                additemhtml += "<td style=\"text-align:center\">" + itemcost + "<input type='hidden' id='itemcose_" + itemcode + "' name='itemcose" + itemcode + "' class=\"itemcost\" value='" + itemcost + "' /></td>";
                additemhtml += "<td style=\"text-align:center\"><a href=\"javascript:delitem('" + itemcode + "')\">删除</a></td>";
                additemhtml += "</tr>";
            }
            $('#itemshtml').html(additemhtml);
            setcodecost();
        } else {alert("金额格式不正确，请重新输入");}
    }
    function delitem(code) {
        $('#code' + code).remove();
        setcodecost();
    }
    function setcodecost() {
        var codes = ""; //input[name='text']
        $("input[class='itemcode']").each(function (i) {
            var code = $(this).val();
            if (codes == "") { codes = code; }
            else { codes += "," + code; }
        });
        var costs = "";
        var totalcost = 0;
        $("input[class='itemcost']").each(function (i) {
            var cost = $(this).val();
            if (costs == "") { costs = cost; }
            else { costs += "," + cost; }
            totalcost += parseFloat(cost);
        });
        $('#codelist').val(codes);
        $('#codelist').attr("value", codes);
        $('#costlist').val(costs);
        $('#costlist').attr("value", costs);
        $('#txtCost').val(totalcost);
        $('#txtCost').attr("value", totalcost);
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 
    维修信息管理 &gt; 编辑维修信息信息</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <li><a onclick="tabs('#contentTab',1);" href="javascript:;">维修项目</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>编 码：</th>
                <td>
                    <asp:TextBox ID="txtid" runat="server" Visible="false"></asp:TextBox>
                    <input type="hidden" runat="server" id="codelist" />
                    <input type="hidden" runat="server" id="costlist" />
                    <asp:DropDownList id="ddlCode" CssClass="select2 required" runat="server" 
                        onselectedindexchanged="ddlCode_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="10001">10001</asp:ListItem>
                        <asp:ListItem Value="10002">10002</asp:ListItem>
                        <asp:ListItem Value="10003">10003</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>车 牌：</th>
                <td>
                    <asp:DropDownList id="ddlCar_Number" CssClass="select2 required" runat="server" 
                        onselectedindexchanged="ddlCar_Number_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="10001">车牌1</asp:ListItem>
                        <asp:ListItem Value="10002">车牌2</asp:ListItem>
                        <asp:ListItem Value="10003">车牌3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <th>维修完毕时间：</th>
                <td><asp:TextBox ID="txtRepare_Time_Finish" runat="server" CssClass="txtInput normal required" maxlength="100" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>费 用：</th>
                <td>
                <asp:TextBox ID="txtCost" runat="server" 
                        CssClass="txtInput normal required" maxlength="20" onblur="this.value=floatChange(this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>维修结果：</th>
                <td><asp:TextBox ID="txtReport" runat="server" CssClass="txtInput normal" 
                        maxlength="16" Height="80px" TextMode="MultiLine" Width="410px"></asp:TextBox></td>
            </tr>
            </tbody>
        </table>
    </div>

    <div class="tab_con">
        <div style="width:100%;float:left">
            <ul style="list-style:none;">
                <li style="list-style:none;float:left;">
                    <asp:DropDownList id="ddlRepair_Item" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">维修项目1</asp:ListItem>
                        <asp:ListItem Value="10002">维修项目2</asp:ListItem>
                        <asp:ListItem Value="10003">维修项目3</asp:ListItem>
                    </asp:DropDownList>
                </li>
                <li style="list-style:none;float:left;padding-left:10px">金额：
                    <asp:TextBox ID="txtaddcost" runat="server" 
                        CssClass="txtInput normal required" maxlength="20" onblur="this.value=intChange(this)"></asp:TextBox>
                </li>
                <li style="list-style:none;float:left;"><input type="button" value="添加项目" onclick="additem();" /></li>
            </ul>
        </div>
        <div style="width:100%;float:left">
        <table id="itemshtml" width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr id="code0">
        <th>维修项编码</th>
        <th>维修项名称</th>
        <th>金额</th>
        <th>操作</th>
      </tr>
      </table>
      </div>
    </div>

    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
</div>
</form>
</body>
</html>
