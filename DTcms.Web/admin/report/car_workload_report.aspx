<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_workload_report.aspx.cs" Inherits="DTcms.Web.admin.report.car_workload_report" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>车队工作量化管理</title>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script src="../js/jquery-1.7.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript">
    $(function () {
        var date = new Date();
        //动态添加年份
        var currentYear = date.getFullYear();//获取系统当前年份
        var endYear = currentYear - 10;
        for (; currentYear > endYear; currentYear--) {
            var addoption = document.createElement("option");//动态创建元素
            addoption.text = currentYear;
            addoption.value = currentYear;
            //添加到下拉框中
            document.getElementById("year").add(addoption);
        }
        //动态添加月
        for (var i = 1; i < 13; i++) {
            var addoption = document.createElement("option");
            addoption.text = i;
            addoption.value = i;
            document.getElementById("month").add(addoption);
        }
    });
    function export_click() {
        var strstime = $("#txtStartTime").val();
        var stretime = $("#txtEndTime").val();
        var strdeptpros = $("#ddlDept_Pros").val();
        $.ajax({
            url: "car_workload_report.aspx?task=exportReport",
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
                } else if(result.IsOK == "N") {
                    //alert(result.Message);
                    alert("0条记录，无法导出！")
                }
            }
        });
    }
    
    function exportForMonth_click() {
        //获取选中的年
        var yearSelIndex = document.getElementById("year").selectedIndex;
        var year = document.getElementById("year")[yearSelIndex].value;
        //获取选中的月份
        var monthSelIndex = document.getElementById("month").selectedIndex;
        var month = document.getElementById("month")[monthSelIndex].value;
        //获取选中的驾驶员编码属性
        var proSelIndex = document.getElementById("driver").selectedIndex;
        var dricode = document.getElementById("driver")[proSelIndex].value;
        $.ajax({
            url: "car_workload_report.aspx?task=exportReportForMonDri",
            data: {
                "year": year,
                "month": month,
                "dricode": dricode
            },
            success: function (result) {
                if (result.IsOK == undefined) {
                    //{"IsOK":"Y","Message":"driver_work.xls","Data":{}}
                    var s = result.split(",");
                    if (s != undefined && s.length > 0) {
                        var file = s[1];
                        file = file.replace("\"Message\":\"", "");
                        file = file.replace("\"", "");
                        window.open("../../TEMP/" + file);
                    }
                }
                if (result.IsOK == "Y") {
                    window.open(contextPath + "/TEMP/" + result.Message);
                } else if (result.IsOK == "N") {
                    //alert(result.Message);
                    alert("0条记录，无法导出！")
                }
            }
        });
    }

    function getContextPath() {
        var pathName = document.location.pathname;
        var index = pathName.substr(1).indexOf("/");
        var result = pathName.substr(0, index + 1);
        return result;
    }
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 报表管理 &gt; 车队工作量化表</div>
    <!--begin按月份,驾驶员导出报表-->
    <div class="tools_box">
	    <div class="tools_bar">
            <div style="margin-left:10px;margin-top:10px;float:left">
                <asp:DropDownList ID="year" runat="server" Height="21px" Width="80px">
                </asp:DropDownList>
                年
                 <asp:DropDownList ID="month" runat="server" Height="21px" Width="80px">
                </asp:DropDownList>
                月
                <asp:DropDownList id="driver" CssClass="select2 required" runat="server">      
                </asp:DropDownList>
            </div>
            <div class="output_box">
                <input type="button" value="导出报表" class="btnSubmit" onclick="exportForMonth_click();" />
                <%--<asp:Button ID="btnSearch" runat="server" Text="导出报表" CssClass="btnSearch" onclick="btnSearch_Click" />--%>
		    </div>
           <%-- <a href="car_type_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加行政司机出车汇总</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>--%>
        </div>
    </div>
    <!--end-->
    <div class="tools_box">
	    <div class="tools_bar">
            <div style="margin-left:10px;margin-top:10px;float:left">时间：
                <asp:TextBox ID="txtStartTime" runat="server" CssClass="txtInput normal dateISO" maxlength="20" Width="100px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"></asp:TextBox>
			    <asp:TextBox ID="txtEndTime" runat="server" Width="100px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })" CssClass="txtInput normal dateISO"></asp:TextBox>
                <asp:DropDownList id="ddlDept_Pros" CssClass="select2 required" runat="server">
                        <asp:ListItem Value="10001">总办</asp:ListItem>
                        <asp:ListItem Value="10002">行政</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="output_box">
                <input type="button" value="导出报表" class="btnSubmit" onclick="export_click();" />
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
