﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_other_cost_list.aspx.cs" Inherits="DTcms.Web.admin.cars.cost.car_other_cost_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>其他费用管理</title>
<link type="text/css" rel="stylesheet" href="../../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../../images/style.css" />
<link type="text/css" rel="stylesheet" href="../../../css/pagination.css" />
<script type="text/javascript" src="../../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../../js/function.js"></script>
<script type="text/javascript">
    function AfterStatus(id,status) {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: "car_other_cost_list.aspx?action=AfterStatus",
            data: { id: id, status: status },
            cache: false,
            beforeSend: function () {
                //$('#loading').show();
            },
            success: function (result) {
                if (result.IsOK == "Y") {
                    var iresult = result.Data.result;
                    if (iresult > 0) {
                        //0在申请,1修改,2批准通过,3批准不通过,4出车中,5车辆使用结束
                        var s = "未审核";
                        if (status == 1) {
                            s = GetStatusText(1);
                            $("#Status" + id).attr("href", "");
                            $("#Status" + id).html("");
                        }
                        else {
                            s = GetStatusText(1);
                            //$("#Status" + id).attr("href", "javascript:AfterStatus(" + id + ",1);");
                            $("#Status" + id).attr("href", "");
                            $("#Status" + id).html("");
                        }
                        $("#StatusText" + id).html(s);
                    }
                }
            },
            error: function () {
                var ddd = 0;
                //alert('网络错误!');
            },
            complete: function () {
                var ddd = 0;
                IsLayerDown = 0;
                //$('#loading').hide();
            }
        });
    }
    function GetStatusText(status) {
        var value = "未审核"; //0在申请,1修改,2批准通过,3批准不通过,4出车中,5车辆使用结束
        if (status == 1) { value = "审核通过"; }
        return value;
    }
    </script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 其他费用管理 &gt; 其他费用列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <a href="car_other_cost_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加其他费用</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>选择</th>
        <th align="left">编码</th>
        <th align="left">标题</th>
        <th align="left">车牌</th>
        <th align="left">费用</th>
        <th align="left">费用类型</th>
        <th align="left">审核状态</th>
        <th align="left">审核人</th>
        <th align="left">审核时间</th>
        <th>操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" /></td>
        <td><%#Eval("Code")%></td>
        <td><%#Eval("Tittle")%></td>
        <td><%#Eval("Car_Number")%></td>
        <td><%#Eval("Cost")%></td>
        <td><%#Eval("Type_Code")+""=="10001"?"保险":"年费"%></td>
        <td id="StatusText<%#Eval("ID")%>"><%#Eval("StatusText")%></td>
        <td><%#new DTcms.BLL.manager().GetTitleByCode(Eval("Checker_Code")+"")%></td>
        <td><%#Eval("Check_Time")%></td>
        <td align="center"><a href="car_other_cost_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a>
            <a id="Status<%#Eval("ID")%>" href="javascript:AfterStatus(<%#Eval("ID")%>,<%#Eval("Status")%>);"><%#Eval("StatusHandleText")%></a>
        </td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
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
