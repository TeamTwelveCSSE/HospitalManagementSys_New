<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Issue.aspx.cs" Inherits="HospitalManagementSystem.Issue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Issue</title>

    <link href="Resources/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <!-- Custom Theme files -->
	<link href="Resources/css/style.css" rel='stylesheet' type='text/css' />
   	<!-- Custom Theme files -->	
   	<!-- webfonts -->
   	<link href='http://fonts.googleapis.com/css?family=Arimo:400,700' rel='stylesheet' type='text/css'>
   	<!-- webfonts -->
    <%--<meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Resources/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
	<script src="Resources/scripts/validation.js" type="text/javascript"></script>
    <script src="Resources/scripts/DatePicker.js" type="text/javascript"></script>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css" />
    <!-- Custom Theme files -->
	<link href="Resources/css/style.css" rel='stylesheet' type='text/css' />
   	<!-- Custom Theme files -->	
   	<!-- webfonts -->
   	<link href='http://fonts.googleapis.com/css?family=Arimo:400,700' rel='stylesheet' type='text/css'>
   	<!-- webfonts -->--%>
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
                            <li  class="active"><a data-toggle="tab" href="Issue.aspx">Issue</a></li>
                            <li><a data-toggle="tab" href="Order.aspx">Order</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="Order" class="tab-pane fade in active">
                                <h3>Issue Item</h3>
                                <div class="container">

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Issue Id</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtItemIssueId" runat="server" class="form-control" Enabled="false" ></asp:TextBox>
                                                <asp:TextBox ID="hidden_txtItemIssueId" runat="server" hidden="true" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Item Name</div>
                                            <div class="col-md-8"><asp:DropDownList ID = "DropDownList1" runat="server" class="form-control"></asp:DropDownList></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Quantity Issued</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtQtyIssue" runat="server" class="form-control" TextMode="Number" min="0"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuantity" runat="server" ErrorMessage="*Quantity is Required" ControlToValidate="txtQtyIssue" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RangeValidator runat="server" id="RangeValidatorQuantity" controltovalidate="txtQtyIssue" minimumvalue="1" maximumvalue="9999999" errormessage="*Quantity must be greater than 0" ValidationGroup="Add" ForeColor="Red" />
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Location</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="location" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                                    <asp:ListItem>Add Location</asp:ListItem>
                                                    <asp:ListItem>Ward_01</asp:ListItem>
                                                    <asp:ListItem>Ward_02</asp:ListItem>
                                                    <asp:ListItem>Ward_03</asp:ListItem>
                                                    <asp:ListItem>Ward_04</asp:ListItem>
                                                    <asp:ListItem>Ward_05</asp:ListItem>
                                                    <asp:ListItem>Lab</asp:ListItem>
                                                    <asp:ListItem>Theatre</asp:ListItem>
                                                </asp:DropDownList>
                                            </div> 
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocation" runat="server" ErrorMessage="*Please Select a Location" ControlToValidate="location" ForeColor="Red" ValidationGroup="Add" InitialValue="Add Location"></asp:RequiredFieldValidator>
                                         </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Issue Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtIssueDate" runat="server" class="form-control" TextMode="Date"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="*Date is Required" ControlToValidate="txtIssueDate" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
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
                                                    <asp:ListItem Selected="True">Issue ID</asp:ListItem>
                                                    <asp:ListItem>Item Name</asp:ListItem>
                                                    <asp:ListItem>Quantity</asp:ListItem>
                                                    <asp:ListItem>Location</asp:ListItem>
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
