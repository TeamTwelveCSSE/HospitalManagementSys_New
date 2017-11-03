<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account.aspx.cs" Inherits="HospitalManagementSystem.Account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Account Management</title>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css"/>
    <link href="Resources/css/bootstrap.css" rel='stylesheet' type='text/css' />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <!-- Custom Theme files -->
	<link href="Resources/css/style.css" rel='stylesheet' type='text/css' />
   	<!-- Custom Theme files -->	
   	<!-- webfonts -->
   	<link href='http://fonts.googleapis.com/css?family=Arimo:400,700' rel='stylesheet' type='text/css'/>
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
                            <li class="active"><a data-toggle="tab" href="Account.aspx" id="Expenses">Add Expenses</a></li>
                            <li><a data-toggle="tab" href="OutPatientCharges.aspx">Calculate Cannelling Charges</a></li>
                            <li><a data-toggle="tab" href="ProfitCalculation.aspx">Profit Calculation</a></li>
                            
                        </ul>

                        <div class="tab-content">
                            <div id="Expenses" class="tab-pane fade in active">
                                <h3>Add Expenses</h3>
                                <div class="container">

                                    <div class="row">
                                        <div class="col-md-3">
                                            
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Expense ID</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="tb_expenseid" runat="server" class="form-control" Enabled="false"></asp:TextBox>
                                                <asp:TextBox ID="hidden_expense_id" runat="server" hidden="true" class="form-control" Enabled="false"></asp:TextBox>
                                            </div> 
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_expensedate" runat="server" class="form-control" Enabled="false" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                           <asp:Button ID="btn_date" runat="server" Text="Submission Date" OnClick="btn_date_Click" /> 
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4"></div>
                                            <div class="col-md-6">
                                                <asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged" runat="server" Height="187px" Visible="false" Width="208px"> </asp:Calendar>
                                            </div>
                                        </div>
                                    <div/>

                                    <div class="row top-buffer">
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">

                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">&nbsp;&nbsp;&nbsp;Expense Type</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="list_expensetype" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                                    <%--<asp:ListItem>Select Expense Type</asp:ListItem>--%>
                                                    <asp:ListItem>Salary Payments</asp:ListItem>
                                                    <asp:ListItem>Maintenance</asp:ListItem>
                                                    <asp:ListItem>Utility Payments</asp:ListItem>
                                                    <asp:ListItem>Other</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">&nbsp;&nbsp;&nbsp;Description</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_expensedescription"  runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">&nbsp;&nbsp;&nbsp;Amount</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_expenseamount" runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>


                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                            
                                        </div>
                                        <div class="col-md-2">
                                            
                                        </div>
                                        <div class="col-md-6">
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                                                <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                                                <asp:Button ID="Button2" runat="server" Text="Clear" OnClick="btnCancel_Click" /> 
                                                <asp:Button ID="Button3" runat="server" Text="Delete" OnClick="btnDelete_Click" /> 
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
                                                    <asp:ListItem Selected="True">Expense ID</asp:ListItem>
                                                    <asp:ListItem>Date</asp:ListItem>
                                                    <asp:ListItem>Type</asp:ListItem>
                                                    <asp:ListItem>Description</asp:ListItem>
                                                    <asp:ListItem>Amount</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="tb_SearchId" runat="server" BorderStyle="Solid" ></asp:TextBox>
                                            <asp:Button ID="btnSearch" runat="server"  Text="Search" OnClick="btnSearch_Click"></asp:Button>
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

                                
                            <%--<div id="Salary" class="tab-pane fade">
                                <h3>Employee Salary</h3>
                                <div class="container">
                     
                                </div>
                            </div>

                            <div id="Attendance" class="tab-pane fade">
                                <h3>Employee Attendance</h3>
                                <div class="container">
                                    
                                </div>
                            </div>

                            <div id="Absence" class="tab-pane fade">
                                <h3>Employee Absence</h3>
                                <div class="container">
                                    
                                </div>
                            </div>--%>

                                
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
