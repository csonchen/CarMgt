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

    <style type="text/css">
        #code1 th {
            text-align:center;
        }
        #code0 th {
            text-align:center;
        }
    </style>
<script type="text/javascript">
    //表单验证
    $(function () {
        //绑定隐藏信息项
        setcodecost();
        setcodecost2();

        //绑定显示哪些选项卡
        //获取选项卡控件
        var choiceList = $('#choice');
        //获取选中项的值
        var choiceSelVal = choiceList.val();
        //根据选中项的值来显示相应的tab控件
        switch (choiceSelVal) {
            case "1":
                $('#maintenance_tab').css({
                    "display": "inline"
                });
                $('#repair_tab').css({
                    "display": "none"
                });
                //给指定金额项填写和消除class属性
                $('#txt_maintenance_cost').addClass("required");
                $('#txtaddcost').removeClass("required");
                break;
            case "2":
                $('#maintenance_tab').css({
                    "display": "none"
                });
                $('#repair_tab').css({
                    "display": "inline"
                });
                //给指定金额项填写和消除class属性
                $('#txt_maintenance_cost').removeClass("required");
                $('#txtaddcost').addClass("required");
                break;
            case "3":
                $('#maintenance_tab').css({
                    "display": "inline"
                });
                $('#repair_tab').css({
                    "display": "inline"
                });
                $('#txtaddcost').addClass("required");
                $('#txt_maintenance_cost').addClass("required");
                break;
            default:
                break;
        }


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

       

        ////页面加载完成，默认显示“保养项目”tab
        //$('#maintenance_tab').css({
        //    "display": "inline"
        //});
        //给“保养维修项目”绑定事件
        $('#choice').change(function () {
            //获取“保养维修项目”控件
            var choiceList = $('#choice');
            //获取选中项的值
            var choiceSelVal = choiceList.val();
            //根据选中项的值来显示相应的tab控件
            switch (choiceSelVal) {
                case "1":
                    $('#maintenance_tab').css({
                        "display": "inline"
                    });
                    $('#repair_tab').css({
                        "display": "none"
                    });
                    //给指定金额项填写和消除class属性
                    $('#txt_maintenance_cost').addClass("required");
                    $('#txtaddcost').removeClass("required");
                    break;
                case "2":
                    $('#maintenance_tab').css({
                        "display": "none"
                    });
                    $('#repair_tab').css({
                        "display": "inline"
                    });
                    //给指定金额项填写和消除class属性
                    $('#txt_maintenance_cost').removeClass("required");
                    $('#txtaddcost').addClass("required");
                    break;
                case "3":
                    $('#maintenance_tab').css({
                        "display": "inline"
                    });
                    $('#repair_tab').css({
                        "display": "inline"
                    });
                    $('#txtaddcost').addClass("required");
                    $('#txt_maintenance_cost').addClass("required");
                    break;
                default:
                    break;
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
        <!--
        <li style="display:none" id="repair_tab"><a onclick="tabs('#contentTab',1);" href="javascript:;">维修项目</a></li>
        <li style="display:none" id="maintenance_tab"><a onclick="tabs('#contentTab',2);" href="javascript:;">保养项目</a></li>   
        -->
        <%--<li><a onclick="tabs('#contentTab',1);" href="javascript:;">账户信息</a></li>--%>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>编 码：</th>
                <td>
                    <asp:TextBox ID="txtCode" runat="server" CssClass="txtInput normal required" maxlength="16"></asp:TextBox><label>*最好不要超过8位字符。</label>
                    <input type="hidden" runat="server" id="codelist" />
                    <input type="hidden" runat="server" id="costlist" />
                    <input type="hidden" runat="server" id="codelist2" />
                    <input type="hidden" runat="server" id="costlist2" />
                </td>
            </tr>
            <tr>
                <th>维修开始时间：</th>
                <td>
                <asp:TextBox ID="txtRepare_Time" runat="server" CssClass="txtInput normal dateISO" maxlength="20" Width="160px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })"></asp:TextBox><label>*</label>
                </td>
            </tr>
            <tr>
                <th>维修完毕时间：</th>
                <td>
                <asp:TextBox ID="txtRepare_Time_Finish" runat="server" CssClass="txtInput normal required" maxlength="20" Width="160px" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd HH:mm:ss' })"></asp:TextBox><label>*</label>
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
            <!--添加保养维修项目选择项-->
            <tr>
                <th>保养维修项目：</th>
                <td>
                    <asp:DropDownList ID="choice" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="1">保养</asp:ListItem>
                        <asp:ListItem Value="2">维修</asp:ListItem>
                        <asp:ListItem Value="3">保养+维修</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <!--动态显示明细项-->
            <tr>
                <th>项目明细：</th>
                <td>
                    <!--保养项选项卡-->
                    <div id="maintenance_tab" style="float:left;margin-right:10px;width:440px;height:auto;border:1px solid #eee;">
                        <div style="width:100%;float:left">
                            <ul style="list-style:none;">
                                <li style="list-style:none;float:left;">
                                    <asp:DropDownList id="ddlMaintenance_Items" CssClass="select2 required" runat="server">
                        
                                    </asp:DropDownList>
                                </li>
                                <li style="list-style:none;float:left;padding-left:10px">金额：
                                    <asp:TextBox ID="txt_maintenance_cost" runat="server" 
                                        CssClass="txtInput normal required" Width="170" maxlength="20" onblur="this.value=intChange(this)"></asp:TextBox>
                                </li>
                                <li style="list-style:none;float:left;"><input type="button" class="btnSubmit" value="添加项目" onclick="addMaintenanceItem();" /></li>
                            </ul>
                        </div>
                        <div style="width:100%;float:left">
                        <table id="maintenance_itemshtml" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                      <tr id="code1">
                        <th>保养项编码</th>
                        <th>保养项名称</th>
                        <th>金额</th>
                        <th>操作</th>
                      </tr>
                      </table>
                    </div>
                     </div>

                    <!--维修项选项卡-->
                    <div id="repair_tab" style="float:left;width:440px;height:auto;border:1px solid #eee;">
                        <div style="width:100%;float:left">
                                <ul style="list-style:none;">
                                    <li style="list-style:none;float:left;">
                                        <asp:DropDownList id="ddlRepair_Item" CssClass="select2 required" runat="server">
                        
                                        </asp:DropDownList>
                                    </li>
                                    <li style="list-style:none;float:left;padding-left:10px">金额：
                                        <asp:TextBox ID="txtaddcost" runat="server" 
                                            CssClass="txtInput normal " Width="170" maxlength="20" onblur="this.value=intChange(this)"></asp:TextBox>
                                    </li>
                                    <li style="list-style:none;float:left;"><input class="btnSubmit" type="button" value="添加项目" onclick="additem();" /></li>
                                </ul>
                            </div>
                        <div style="width:100%;float:left">
                            <table id="itemshtml" runat="server" width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
                          <tr id="code0">
                            <th>维修项编码</th>
                            <th>维修项名称</th>
                            <th>金额</th>
                            <th>操作</th>
                          </tr>
                          </table>
                          </div>
                    </div>
                </td>
            </tr>
            
            <!--暂时将保养项目一项隐藏起来-->
            <tr style="display:none;">
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
                <th>费 用：</th>
                <td>
                <asp:TextBox ID="txtCost" runat="server" 
                        CssClass="txtInput normal required" maxlength="20" onblur="this.value=floatChange(this)"></asp:TextBox>
                <label>*</label>
                </td>
            </tr>
            <tr>
                <th>维修原因：</th>
                <td><asp:TextBox ID="txtReason" runat="server" CssClass="txtInput normal" 
                        maxlength="16" Height="50px" TextMode="MultiLine" Width="410px"></asp:TextBox></td>
            </tr>
            <tr>
                <th>维修结果：</th>
                <td><asp:TextBox ID="txtReport" runat="server" CssClass="txtInput normal" 
                        maxlength="16" Height="50px" TextMode="MultiLine" Width="410px"></asp:TextBox></td>
            </tr>
            </tbody>
        </table>
    </div>
    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
</form>
    <script type="text/javascript">
        //添加保养项
        function addMaintenanceItem() {
            var itemhtmltop2 = "<tr id='code1'>";
            itemhtmltop2 += "<th>保养项编码</th>";
            itemhtmltop2 += "<th>保养项名称</th>";
            itemhtmltop2 += "<th>金额</th>";
            itemhtmltop2 += "<th>操作</th>";
            itemhtmltop2 += "</tr>";
            var additemhtml = $('#maintenance_itemshtml').html();
            additemhtml = additemhtml.replace(itemhtmltop2, "");
            var itemcode2 = $('#ddlMaintenance_Items').val();
            var itemtitle2 = $('#ddlMaintenance_Items').find("option:selected").text();
            var itemcost2 = $('#txt_maintenance_cost').val();
            var dcost2 = parseFloat(itemcost2);
            var codelist2 = $('#codelist2').val();
            var costlist2 = $('#costlist2').val();
            if (codelist2 == "") { codelist2 += itemcode2; }
            else { codelist2 += "," + itemcode2; }
            if (costlist2 == "") { costlist2 += dcost2; }
            else { costlist2 += "," + dcost2; }
            if (dcost2 > 0) {
                if (additemhtml.indexOf(itemcode2) < 0) {
                    additemhtml += "<tr id='code2" + itemcode2 + "'>";
                    additemhtml += "<td style=\"text-align:center\">" + itemcode2 + "<input type='hidden' id='itemcode2_" + itemcode2 + "' name='itemcode2" + itemcode2 + "' class=\"itemcode2\" value='" + itemcode2 + "' /></td>";
                    additemhtml += "<td style=\"text-align:center\">" + itemtitle2 + "</td>";
                    additemhtml += "<td style=\"text-align:center\">" + itemcost2 + "<input type='hidden' id='itemcose2_" + itemcode2 + "' name='itemcose2" + itemcode2 + "' class=\"itemcost2\" value='" + itemcost2 + "' /></td>";
                    additemhtml += "<td style=\"text-align:center\"><a href=\"javascript:delitem2('" + itemcode2 + "')\">删除</a></td>";
                    additemhtml += "</tr>";
                }
                $('#maintenance_itemshtml').html(additemhtml);
                setcodecost2();
            } else { alert("金额格式不正确，请重新输入"); }
        }
        function delitem2(code) {
            $('#code2' + code).remove();
            setcodecost2();
            //删除时依次判断条目是否都还存在，若都不存在，则清空金额填写框
            var itemcosts = $('td').find('input[class="itemcost2"]');
            if (itemcosts.length == 0) {
                $('#txt_maintenance_cost').val("");
            }
        }
        function setcodecost2() {
            var codes = ""; //input[name='text']
            $("input[class='itemcode2']").each(function (i) {
                var code = $(this).val();
                if (codes == "") { codes = code; }
                else { codes += "," + code; }
            });
            var costs = "";
            var totalcost = 0;
            $("input[class='itemcost2']").each(function (i) {
                var cost = $(this).val();
                if (costs == "") { costs = cost; }
                else { costs += "," + cost; }
                totalcost += parseFloat(cost);
            });
            $('#codelist2').val(codes);
            $('#codelist2').attr("value", codes);
            $('#costlist2').val(costs);
            $('#costlist2').attr("value", costs);
            //$('#txtCost').val(totalcost);
            //$('#txtCost').attr("value", totalcost);
        }

        //添加维修项
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
            } else { alert("金额格式不正确，请重新输入"); }
        }
        function delitem(code) {
            $('#code' + code).remove();
            setcodecost();
            //删除时依次判断条目是否都还存在，若都不存在，则清空金额填写框
            var itemcosts = $('td').find("input[class='itemcost']");
            if (itemcosts.length == 0) {
                $('#txtaddcost').val("");
            }
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
            //$('#txtCost').val(totalcost);
            //$('#txtCost').attr("value", totalcost);
        }
    </script>
</body>
</html>
