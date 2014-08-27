<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="bridge_cost_report.aspx.cs" Inherits="DTcms.Web.admin.report.bridge_cost_report" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>车辆路桥费汇总管理</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript">

    function export_click() {
        var strstime = $("#txtStartTime").val();
        var stretime = $("#txtEndTime").val();
        var strdeptpros = $("#ddlDept_Pros").val();
        $.ajax({
            url: "bridge_cost_report.aspx?task=exportReport",
            data: {
                "stime": strstime,
                "etime": stretime,
                "deptpros": strdeptpros
            },
            success: function (result) {
                //if (result.IsOK == undefined) {
                //    //{"IsOK":"Y","Message":"driver_work.xls","Data":{}}
                //    var s = result.split(",");
                //    if (s != undefined && s.length > 0) {
                //        var file = s[1];
                //        file = file.replace("\"Message\":\"", "");
                //        file = file.replace("\"", "");
                //        window.open("../../TEMP/" + file);
                //    }
                //}
                if (result.IsOK == "Y") {
                    window.open(contextPath + "/TEMP/" + result.Message);
                } else {
                    //alert(result.Message);
                    alert("0条记录，无法导出！")
                }
            }
        });
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 报表管理 &gt; 车辆路桥费汇总列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div style="margin-left:10px;margin-top:10px;float:left">时间：
                <asp:TextBox ID="txtStartTime" runat="server" CssClass="txtInput normal dateISO" maxlength="20" Width="100px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"></asp:TextBox>
			    <asp:TextBox ID="txtEndTime" runat="server" Width="100px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" CssClass="txtInput normal dateISO"></asp:TextBox>
                <asp:DropDownList id="ddlDept_Pros" CssClass="select2 required" runat="server">
                        <asp:ListItem Value="10001">总办</asp:ListItem>
                        <asp:ListItem Value="10002">行政</asp:ListItem>
                        <asp:ListItem Value="10000">总办+行政</asp:ListItem>
                    </asp:DropDownList>
            </div>
            <div class="output_box">
                <input type="button" value="导出报表" class="btnSubmit" onclick="export_click();" />
                <%--<asp:Button runat="server" Text="导出报表" CssClass="btnSubmit" onclick="export_click();" />--%>
                <%--<asp:Button ID="btnSearch" runat="server" Text="导出报表" CssClass="btnSearch" onclick="btnSearch_Click" />--%>
		    </div>
           <%-- <a href="car_type_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加车辆过桥费汇总</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>--%>
        </div>
    </div>

    <!--列表展示.开始-->
    <%--<asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>选择</th>
        <th align="left">车辆过桥费汇总编码</th>
        <th align="left">车辆过桥费汇总名称</th>
        <th>操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" /></td>
        <td><%#Eval("Type_Code")%></td>
        <td><%#Eval("Type_Name")%></td>
        <td align="center"><a href="car_type_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>--%>
    <!--列表展示.结束-->

   
    <%--<div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>--%>
</form>
</body>
</html>
