<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_driver_list.aspx.cs" Inherits="DTcms.Web.admin.cars.driver.car_driver_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>驾驶员管理</title>
<link type="text/css" rel="stylesheet" href="../../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../../css/pagination.css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../../js/function.js"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 驾驶员管理 &gt; 驾驶员列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <a href="car_driver_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加驾驶员</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>
        <%--<div class="select_box">
            请选择：<asp:DropDownList ID="ddlGroupId" runat="server" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlGroupId_SelectedIndexChanged"></asp:DropDownList>&nbsp;
	    </div>--%>
    </div>

    <!--列表展示.开始-->
    <div style="width:100%;overflow:scroll;">
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="1050px" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th style ="width :50px;">选择</th>
        <th align="left" style="width:80px">驾驶员编码</th>
        <th align="left" style="width:80px">驾驶员名称</th>
        <th align="left" style="width:50px">性别</th>
        <th align="left" style="width:80px">生日</th>
        <th align="left" style="width:100px">身份证号</th>
        <th align="left" style="width:80px">领证日期</th>
        <th align="left" style="width:100px">地址</th>
        <th align="left" style="width:100px">驾驶证号</th>
        <th align="left" style="width:60px">准驾车型</th>
        <th align="left" style="width:100px">电话</th>
        <th align="left" style="width:80px">部门编码</th>
        <th style="width:60px;">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" /></td>
        <td><%#Eval("Driver_Code")%></td>
        <td><%#Eval("Driver_Name")%></td>
        <td><%#Eval("Sex")%></td>
        <td><%#Eval("Birthday")%></td>
        <td><%#Eval("Identity_Num")%></td>
        <td><%#Eval("CollarDate")%></td>
        <td><%#Eval("Address")%></td>
        <td><%#Eval("Driving_License_Num")%></td>
        <td><%#Eval("License_Type")%></td>
        <td><%#Eval("Telehone")%></td>
        <td><%#new DTcms.BLL.user_deptbll().GetTitleByCode((string)Eval("Dept_Code"))%></td>
        <td align="center"><a href="car_driver_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    </div>
    <!--列表展示.结束-->

   
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>
</form>
</body>
</html>
