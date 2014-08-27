<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="car_edit.aspx.cs" Inherits="DTcms.Web.admin.cars.car_edit" %>
<%@ Import namespace="DTcms.Common" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑会员信息</title>
<link href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<link href="../images/style.css" rel="stylesheet" type="text/css" />
<script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
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
                txtRole_Code: {
                    required: "输入(2-8)位字符",
                    minlength: "必须大于2位字符",
                    maxlength: "必须小于8位字符",
                    remote: "抱歉，该编码不可用"
                }
            }
        });

        //处理不能输入相同的车牌号
        $('#txtCar_Number').blur(function () {
            var carNum = this.value;
            $.ajax({
                type: 'GET',
                url: 'car_edit.aspx',
                data: 'carNum=' + carNum,
                dataType:'text',
                success: function (msg) {
                    //返回结果信息出现意外，作临时处理
                    var value = msg.split('！');
                    if (value[0] == "OK") {
                        $('#carnum_lab').html('<img src="../images/icon_correct.png">');
                    } else {
                        $('#carnum_lab').html("<font style='color:red'>" + value[0] + "</font>");
                    }    
                },
                error: function (msg) {
                    alert('请求数据错误，请重试！');
                }
            });
        });
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 
    车辆管理 &gt; 编辑车辆信息</div>
<div id="contentTab">
    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <li><a onclick="tabs('#contentTab',1);" href="javascript:;">详细信息</a></li>
        <li><a onclick="tabs('#contentTab',2);" href="javascript:;">图片信息</a></li>
    </ul>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>车牌号码：</th>
                <td><asp:TextBox ID="txtCar_Number" runat="server" CssClass="txtInput normal required" maxlength="16"></asp:TextBox><label id="carnum_lab">*最好不要超过8位字符。</label></td>
            </tr>
            <tr>
                <th>车辆说明：</th>
                <td><asp:TextBox ID="txtCar_Name" runat="server" CssClass="txtInput normal required" maxlength="100"></asp:TextBox><label>*</label></td>
            </tr>
            <tr>
                <th>车辆类型：</th>
                <td>
                <asp:DropDownList id="ddlCar_Type" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">车型1</asp:ListItem>
                        <asp:ListItem Value="10002">车型2</asp:ListItem>
                        <asp:ListItem Value="10003">车型3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>属性：</th>
                <td>
                <asp:DropDownList id="ddlDept_Pros" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">总办</asp:ListItem>
                        <asp:ListItem Value="10002">行政</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>驾驶员：</th>
                <td>
                <asp:DropDownList id="ddlDriver" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="10001">驾驶员1</asp:ListItem>
                        <asp:ListItem Value="10002">驾驶员2</asp:ListItem>
                        <asp:ListItem Value="10003">驾驶员3</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            <tr>
                <th>购买日期：</th>
                <td>
                <asp:TextBox ID="txtBuy_Date" runat="server" CssClass="txtInput normal dateISO" maxlength="20" onfocus="WdatePicker({ dateFmt: 'yyyy-MM-dd' })"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>购买价格：</th>
                <td>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="txtInput normal required" 
                        maxlength="20" ontextchanged="txtPrice_TextChanged" onblur="this.value=floatChange(this)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th>起始里程：</th>
                <td>
                <asp:TextBox ID="txtMileage_First" runat="server" 
                        CssClass="txtInput normal required" maxlength="20" 
                        ontextchanged="txtMileage_First_TextChanged" onblur="this.value=intChange(this)"></asp:TextBox>
                </td>
            </tr>
            <tr style="display :none">
                <th>当前状态：</th>
                <td>
                <asp:DropDownList id="ddlStatus" CssClass="select2 required" runat="server">
                        <asp:ListItem Selected="True" Value="0">空闲中</asp:ListItem>
                        <asp:ListItem Value="1">使用中</asp:ListItem>
                        <asp:ListItem Value="2">维修中</asp:ListItem>
                    </asp:DropDownList>
                    <label>*</label>
                </td>
            </tr>
            </tbody>
        </table>
    </div>
     <div class="tab_con">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>耗油量：</th>
                <td><asp:TextBox ID="txtOil_Consumption" runat="server" CssClass="txtInput normal " maxlength="16" ontextchanged="txtOil_ConsumptionChanged" onblur="this.value=floatChange(this)"></asp:TextBox></td>
            </tr>
            <tr>
                <th>发动机号：</th>
                <td><asp:TextBox ID="txtEngine_Number" runat="server" CssClass="txtInput normal " maxlength="16"></asp:TextBox></td>
            </tr>
            <tr>
                <th>车架号：</th>
                <td><asp:TextBox ID="txtFrame_Number" runat="server" CssClass="txtInput normal " maxlength="16"></asp:TextBox></td>
            </tr>
            <tr>
                <th>载重：</th>
                <td><asp:TextBox ID="txtWeight" runat="server" CssClass="txtInput normal " maxlength="16" ontextchanged="txtWeightChanged" onblur="this.value=floatChange(this)"></asp:TextBox></td>
            </tr>
            <tr>
                <th>车位数：</th>
                <td><asp:TextBox ID="txtSeat" runat="server" CssClass="txtInput normal " maxlength="16" ontextchanged="txtSeatChanged" onblur="this.value=intChange(this)"></asp:TextBox></td>
            </tr>
            <tr>
                <th>备注：</th>
                <td><asp:TextBox ID="txtcContent" runat="server" CssClass="txtInput normal " maxlength="16" TextMode="MultiLine" Width="400px" Height="120px"></asp:TextBox></td>
            </tr>
            </tbody>
        </table>
    </div>
     <div class="tab_con">
        <table class="form_table">
            <tbody>
            <tr>
                <td>正面图片：</td>
                <td>侧面图片</td>
                
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
