<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryPage.aspx.cs" Inherits="ProductQuery.QueryPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>查询</title>
    <script src="js/bootstrap.min.js"></script>
    <link href="css/bootstrap.min.css" rel="stylesheet">
</head>
<body>
    <form class="form-horizontal" runat="server" role="form">

        <div  class="container">
            <div aria-checked="false" style=" width: 1505px; margin-bottom: 1px">
                <div>
                    <h1 class="text-center">213研究所火工品查询</h1>
                </div>
                <div>
                    <hr />
                    <hr />
                </div>
                <div class="form-group">
                    &nbsp;&nbsp;
                    <asp:Label ID="L_showquerypage" runat="server" Font-Bold="True" Font-Names="Adobe 楷体 Std R" Text="输入查询条件：" ></asp:Label>
                </div>
                <div class="form-group">
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/image/db9af6d6813de0e4ca1847e63ecddc8.png" OnClick="ImageButton1_Click" type="button" />
                    &nbsp;&nbsp;&nbsp;
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/image/6890dce2603483196b55643d610bd9c.png" OnClick="ImageButton2_Click" type ="button"/>
                    &nbsp;&nbsp;
                    <select id="Select1"  runat="server" >
                        <option value="1">请选择      </option>
                        <option value ="2">接口信息        </option>
                        <option value ="3">发火条件        </option>
                        <option value="4">燃烧压力        </option>   
                    </select>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" ></asp:TextBox>
                </div>
                <div class="form-group" id ="div2" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="Select2"> 
                        <option>请选择      </option>
                        <option>接口信息        </option>
                        <option>发火条件        </option>
                        <option>燃烧压力        </option>     
                    </select>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </div>
                <div class="form-group" id="div3" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="Select3">
                        <option>请选择       </option>
                        <option>接口信息        </option>
                        <option>发火条件        </option>
                        <option>燃烧压力        </option>     
                    </select>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </div>
                <div class="form-group" id="div4" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="Select4">
                        <option>请选择       </option>
                        <option>接口信息        </option>
                        <option>发火条件        </option>
                        <option>燃烧压力        </option>    
                    </select>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                </div>
                <div class="form-group" id="div5" runat="server">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <select id="Select5">
                        <option>请选择       </option>
                        <option>接口信息        </option>
                        <option>发火条件        </option>
                        <option>燃烧压力        </option>      
                    </select>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="查询" CssClass="btn btn-default btn-lg col-sm-offset-3 col-sm-6"/>
                </div>
            </div>
            <div aria-checked="false" style=" width: 1505px; margin-bottom: 1px" id="div6">
                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
