<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="HospitalManagementSystem.Order" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order</title>

    <link href="Resources/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Custom Theme files -->
	<link href="Resources/css/style.css" rel='stylesheet' type='text/css' />
   	<!-- Custom Theme files -->	
   	<!-- webfonts -->
   	<link href='http://fonts.googleapis.com/css?family=Arimo:400,700' rel='stylesheet' type='text/css'>
   	<!-- webfonts -->
</head>
<body>
    <!-- container -->
        <!-- header -->
        <div class="header header-border">
            <div class="container">
                <!-- logo -->
                <div class="logo">
                    <a href="Main.aspx"><img style="margin-left:0" src="Resources/images/logo.png" title="medicalpluse" /></a>
                </div>
                <!-- logo -->
                <!-- top-nav -->
			    <div class="top-nav">
                    <span class="menu"> </span>
                    <!-- page heading -->
			    </div>
                <!-- top-nav -->
            </div>
        </div>
        <!-- /header -->
        <form id="main" runat="server" method="post">
            <main id="content">
                <div class="container">
                    <div class="row">
                         <ul class="nav nav-tabs">
                            <li><a data-toggle="tab" href="AddItem.aspx">Add Item</a></li>
                            <li><a data-toggle="tab" href="AddSuppliers.aspx">Add Supplier</a></li>
                            <li><a data-toggle="tab" href="Issue.aspx">Issue</a></li>
                            <li  class="active" id="#Order"><a data-toggle="tab" href="Order.aspx">Order</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="Order" class="tab-pane fade in active">
                                <h3>Order</h3>
                                <div class="container">

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Order Id</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtOrderId" runat="server" class="form-control" Enabled="false" ></asp:TextBox>
                                                <asp:TextBox ID="hidden_txtOrderId" runat="server" hidden="true" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Supplier Name</div>
                                            <div class="col-md-8"><asp:DropDownList ID = "DropDownList1" runat="server" class="form-control"></asp:DropDownList></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Order Name</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtOrderName" runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderName" runat="server" ErrorMessage="*Order Name is Required" ControlToValidate="txtOrderName" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Quantity Ordered</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtQtyOrder" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuantityOrdered" runat="server" ErrorMessage="*Quantity is Required" ControlToValidate="txtQtyOrder" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RangeValidator runat="server" id="RangeValidatorQuantityOrdered" controltovalidate="txtQtyOrder" minimumvalue="1" maximumvalue="9999999" errormessage="*Quantity must be greater than 0" ValidationGroup="Add" ForeColor="Red" />
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Ordered Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtOrderDate" runat="server" class="form-control" TextMode="Date"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="*Date is Required" ControlToValidate="txtOrderDate" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <%--button row--%>
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                            
                                        </div>
                                        <div class="col-md-2">
                                            
                                        </div>
                                        <div class="col-md-6">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" ValidationGroup="Add" OnClick="btnSubmit_Click"/>
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" ValidationGroup="Add"  OnClick="btnUpdate_Click"/>
                                                <asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnCancel_Click" /> 
                                                <asp:Button ID="ButtonDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" /> 
                                            </div>
                                        <div class="col-md-3">
                                            <%--<div class="col-md-6">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnCancel_Click" />                                                
                                            </div>--%>
                                           
                                        </div>
                                        </div>
                                        <br />
                                        <asp:Label ID="lblSearchId" runat="server" Text="Search By: " style="text-align: right; position: relative"></asp:Label>
                                            <asp:DropDownList ID="DropDownSearch" runat="server" Width="171px">
                                                    <asp:ListItem Selected="True">Order ID</asp:ListItem>
                                                    <asp:ListItem>Supplier ID</asp:ListItem>
                                                    <asp:ListItem>Order Name</asp:ListItem>
                                                    <asp:ListItem>Quantity</asp:ListItem>
                                                    <asp:ListItem>Date</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="tb_SearchId" runat="server" BorderStyle="Solid" ></asp:TextBox>
                                            <asp:Button ID="btnSearch" runat="server"  Text="Search"  OnClick="btnSearch_Click"></asp:Button>
                                     <br /> <br /> <br />

                                    <asp:GridView ID="GridView1" runat="server" 
                                        onselectedindexchanged="GridView1_SelectedIndexChanged" 
                                        BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                                        CellPadding="4" CellSpacing="2" ForeColor="Black"
                                        AutoGenerateSelectButton="True" OnUnload="Page_Load"  Width="1200px" 
                                        GridLines="Vertical">
                                        <FooterStyle BackColor="#CCCCCC" />
                                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                                        <RowStyle BackColor="White" />
                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#808080" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                    </asp:GridView>

                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </main>
        </form>

        <!-- footer -->
        <div style="height: 642px; width: 759px; margin-right: 540px">
            <div class="footer">

            </div>
        </div>

</body>
</html>
