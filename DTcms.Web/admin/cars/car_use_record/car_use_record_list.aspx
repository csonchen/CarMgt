<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_use_record_list.aspx.cs" Inherits="DTcms.Web.admin.cars.car_use_record.car_use_record_list" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>车辆使用管理</title>
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
            url: "car_use_record_list.aspx?action=AfterStatus",
            data: { id: id, status: status },
            cache: false,
            beforeSend: function () {
                //$('#loading').show();
            },
            success: function (result) {
                if (result.IsOK == "Y") {
                    var iresult = result.Data.result;
                    if (iresult > 0) {
                        //1申请,2批准通过,3批准不通过,4出车中,5车辆使用结束
                        var s = "";
                        if (status == 0 || status == 1) {
                            s = GetStatusText(2);
                            $("#Status" + id).attr("href", "javascript:AfterStatus(" + id + ",4);");
                            $("#Status" + id).html("出车");
                        }
                        else if (status == 2) {
                            s = GetStatusText(status);
                            $("#Status" + id).attr("href", "javascript:AfterStatus(" + id + ",4);");
                            $("#Status" + id).html("出车");
                        }
                        else if (status == 4) {
                            s = GetStatusText(status);
                            $("#Status" + id).attr("href", "car_use_record_edit.aspx?action=Edit&id=" + id);
                            $("#Status" + id).html("回车");
                            //$("#Status" + id).attr("href", "");
                            //$("#Status" + id).html("");
                        }
                        else {
                            s = GetStatusText(status);
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
    } //执行回传函数
    function StatusPostBack(objId, objmsg) {
        if ($(".checkall input:checked").size() < 1) {
            $.ligerDialog.warn("对不起，请选中您要操作的记录！");
            return false;
        }
        var msg = "审核后就不能再修改，您确定吗？";
        if (arguments.length == 2) {
            msg = objmsg;
        }
        $.ligerDialog.confirm(msg, "提示信息", function (result) {
            if (result) {
                __doPostBack(objId, '');
            }
        });
        return false;
    }
    function GetStatusText(status) {
        var value = ""; //1在申请,2批准通过,3批准不通过,4出车中,5车辆使用结束
        if (status == 1) { value = "申请中"; }
        else if (status == 2) { value = "批准通过"; }
        else if (status == 3) { value = "批准不通过"; }
        else if (status == 4) { value = "出车中"; }
        else if (status == 5) { value = "已回车"; }
        return value;
    }

    //导出到excel表
    function export_click(id) {
        var id = id;
        //发送ajax请求，将id传到后台
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: '../../report/car_use_report.aspx?task=exportOneReport',
            data: {
                "id": id
            },
            success: function (result) {
                //if (result.IsOK == undefined) {
                //    //{"IsOK":"Y","Message":"driver_work.xls","Data":{}}
                //    var s = result.split(",");
                //    if (s != undefined && s.length > 0) {
                //        var file = s[1];
                //        file = file.replace("\"Message\":\"", "");
                //        file = file.replace("\"", "");
                //        window.open(getContextPath + "../../TEMP/" + file);
                //    }
                //    //alert('网络错误!');
                //}

                if (result.IsOK == "Y") {
                    window.open(getContextPath() + "../../TEMP/" + result.Message);
                } else {
                    alert(result.Message);
                    //alert("0条记录，无法导出！")
                }
            }
        });

        function getContextPath() {
            var pathName = document.location.pathname;
            var index = pathName.substr(1).indexOf("/");
            var result = pathName.substr(0, index + 1);
            return result;
        }
    }

    
</script>
    <style type="text/css">
        .export {
            cursor:pointer;
        }
    </style>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 车辆使用管理 &gt; 车辆使用列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
			    <asp:TextBox ID="txtKeywords" runat="server" CssClass="txtInput"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click" />
		    </div>
            <a href="car_use_record_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加车辆使用</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
            <asp:LinkButton ID="btnCheckIn" runat="server" CssClass="tools_btn"  
                OnClientClick="return StatusPostBack('In');" onclick="btnCheckIn_Click"><span><b class="all">审核通过</b></span></asp:LinkButton>
            <asp:LinkButton ID="btnCheckOut" runat="server" CssClass="tools_btn"  
                OnClientClick="return StatusPostBack('Out');" onclick="btnCheckOut_Click"><span><b class="all">审核不通过</b></span></asp:LinkButton>
        </div>
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th>选择</th>
        <th align="left">单据编码</th>
        <th align="left">出车时间</th>
        <th align="left">部门</th>
        <th align="left">用车人</th>
        <th align="left">车牌号</th>
        <th align="left">驾驶人</th>
        <th align="left">目的地</th>
        <th align="left">联系人</th>
        <th align="left">电话</th>
        <th align="left">状态</th>
        <th align="left">审核人</th>
        <th align="left">审核时间</th>
        <th>操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("ID")%>' runat="server" /></td>
        <td><%#Eval("Code")%></td>
        <td><%#Eval("Use_Time")%></td>
        <td><%#new DTcms.BLL.user_deptbll().GetTitleByCode((string)Eval("Dept_Code"))%></td>
        <td><%#new DTcms.BLL.manager().GetTitleByCode((string)Eval("User_Code"))%></td>
        <td><%#Eval("Car_Number")%></td>
        <td><%#new DTcms.BLL.car_driverbll().GetTitleByCode((string)Eval("Driver_Code"))%></td>
        <td><%#Eval("End_Address")%></td>
        <td><%#Eval("Connecter")%></td>
        <td><%#Eval("Tel")%></td>
        <td id="StatusText<%#Eval("ID")%>"><%#Eval("StatusText")%></td>
        <td><%#new DTcms.BLL.manager().GetTitleByCode((string)(Eval("Checker_Code")==null?"":Eval("Checker_Code")+""))%></td>
        <td><%#Eval("Check_Time")%></td> 
        <td align="center">
            <a href="car_use_record_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("ID")%>">修改</a>
            <a id="Status<%#Eval("ID")%>" href="<%#Eval("Status").ToString() != "4" ? "javascript:AfterStatus(" + Eval("ID") + "," + Eval("Status") + ")" : "../car_return_record/car_return_record_edit.aspx?action=Edit&id=" + Eval("ID") %>"><%#Eval("StatusHandleText")%></a>
            <!--添加“导出到excel表”的功能-->
            <a class="export" onclick="export_click(<%#Eval("ID")%>);" >导出</a>
            <script type="text/javascript">
                
            </script>
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
