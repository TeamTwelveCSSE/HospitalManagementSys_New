<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="HospitalManagementSystem.AddItem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Item</title>

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
                            <li class="active"><a data-toggle="tab" href="AddItem.aspx" id="#AddItem">Add Item</a></li>
                            <li><a data-toggle="tab" href="AddSuppliers.aspx">Add Supplier</a></li>
                            <li><a data-toggle="tab" href="Issue.aspx">Issue</a></li>
                            <li><a data-toggle="tab" href="Order.aspx">Order</a></li>
                        </ul>
                        <div class="tab-content">
                            <div id="AddItem" class="tab-pane fade in active">
                                <h3>Add Items</h3>
                                <div class="container">
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Item Id</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="txtItemId" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                                <asp:TextBox ID="hidden_txtItemId" runat="server" hidden="true" class="form-control" Enabled="false"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    <br />

                                    <div class="row">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Category</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="category" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                                    <asp:ListItem>Select Category</asp:ListItem>
                                                    <asp:ListItem>Equipment</asp:ListItem>
                                                    <asp:ListItem>Other Materials</asp:ListItem>
                                                    <asp:ListItem>Medicine</asp:ListItem>
                                                </asp:DropDownList>
                                            </div> 
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategory" runat="server" ErrorMessage="*Please Select a Category" ControlToValidate="category" ForeColor="Red" ValidationGroup="Add" InitialValue="Select Category"></asp:RequiredFieldValidator>
                                         </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Item Code</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtItemCode" runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorItemCode" runat="server" ErrorMessage="*Item code is Required" ControlToValidate="txtItemCode" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Item Name</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtItemName" runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorItemName" runat="server" ErrorMessage="*Item Name is Required" ControlToValidate="txtItemName" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Quantity</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtQty" runat="server" class="form-control" Type="number" min="0" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-2">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorQuantity" runat="server" ErrorMessage="*Quantity is Required" ControlToValidate="txtQty" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RangeValidator runat="server" id="RangeValidatorQuantity" controltovalidate="txtQty" minimumvalue="1" maximumvalue="9999999" errormessage="*Quantity must be greater than 0" ValidationGroup="Add" ForeColor="Red" />
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Re Order Level</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtReOrder" runat="server" class="form-control" Type="number" min="0" ></asp:TextBox></div>
                                            <div class="col-md-9">
                                            <asp:RangeValidator runat="server" id="RangeValidatorReOrder" controltovalidate="txtReOrder" minimumvalue="1" maximumvalue="9999999" errormessage="*" ValidationGroup="Add" ForeColor="Red" />
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorReOrder" runat="server" ErrorMessage="*Re Order Level is Required" ControlToValidate="txtReOrder" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:CompareValidator ID="CompareValidatorReOrder" runat="server" ControlToCompare="txtQty" ControlToValidate="txtReOrder" ErrorMessage="*Order Level must less than Quantity" ForeColor="Red" Operator="LessThanEqual"  Type="Integer" ValidationGroup="Add"></asp:CompareValidator>
                                        </div>
                                        
                                        
                                        <div class="col-md-3">
                                        </div>
                                    </div>
                                    

                                    <div class="row">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Rack No</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="RackNo" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                                    <asp:ListItem>Select Rack</asp:ListItem>
                                                    <asp:ListItem>Rack 01</asp:ListItem>
                                                    <asp:ListItem>Rack 02</asp:ListItem>
                                                    <asp:ListItem>Rack 03</asp:ListItem>
                                                    <asp:ListItem>Rack 04</asp:ListItem>
                                                    <asp:ListItem>Rack 05</asp:ListItem>
                                                    <asp:ListItem>Rack 06</asp:ListItem>
                                                    <asp:ListItem>Rack 07</asp:ListItem>
                                                    <asp:ListItem>Rack 08</asp:ListItem>
                                                    <asp:ListItem>Rack 09</asp:ListItem>
                                                </asp:DropDownList>
                                            </div> 
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorRackNo" runat="server" ErrorMessage="*Please Select a Rack" ControlToValidate="RackNo" ForeColor="Red" ValidationGroup="Add" InitialValue="Select Rack"></asp:RequiredFieldValidator>
                                         </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Description</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtDescriptionItem" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtdate" runat="server" class="form-control" TextMode="Date"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDate" runat="server" ErrorMessage="*Date is Required" ControlToValidate="txtdate" ForeColor="Red" ValidationGroup="Add"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <%--<div class="row top-buffer">
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-md-3">
                                            <div class="col-md-6">
                                                <asp:Button ID="btnItemCancel" runat="server" Text="Cancel"/>                                                
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button ID="btnItemSubmit" runat="server" Text="Submit"/>
                                            </div>
                                        </div>
                                    </div>--%>

                                    <%--button row--%>
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                            
                                        </div>
                                        <div class="col-md-2">
                                            
                                        </div>
                                        <div class="col-md-6">
                                                <asp:Button ID="btnSubmitItem" runat="server" Text="Submit" ValidationGroup="Add" OnClick="btnSubmit_Click"/>
                                                <asp:Button ID="btnUpdateItem" runat="server" Text="Update" ValidationGroup="Add"  OnClick="btnUpdate_Click"/>
                                                <asp:Button ID="btnCancelItem" runat="server" Text="Clear" OnClick="btnCancel_Click" /> 
                                                <asp:Button ID="ButtonDeleteItem" runat="server" Text="Delete" OnClick="btnDelete_Click" /> 
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
                                                    <asp:ListItem Selected="True">Item ID</asp:ListItem>
                                                    <asp:ListItem>Category</asp:ListItem>
                                                    <asp:ListItem>Item Code</asp:ListItem>
                                                    <asp:ListItem>Item Name</asp:ListItem>
                                                    <asp:ListItem>Quantity</asp:ListItem>
                                                    <asp:ListItem>Re Order Level</asp:ListItem>
                                                    <asp:ListItem>Rack No</asp:ListItem>
                                                    <asp:ListItem>Description</asp:ListItem>
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