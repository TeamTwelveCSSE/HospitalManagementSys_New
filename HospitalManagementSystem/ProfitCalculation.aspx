<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfitCalculation.aspx.cs" Inherits="HospitalManagementSystem.ProfitCalculation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Profit Calculation</title>
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
                            <li><a data-toggle="tab" href="Account.aspx">Add Expenses</a></li>
                            <li><a data-toggle="tab" href="OutPatientCharges.aspx">Calculate Cannelling Charges</a></li>
                           <%-- <li class="active"><a data-toggle="tab" href="OutPatientCharges.aspx" id="#CalculateChannelCharges">Calculate Cannelling Charges</a></li>--%>
                            <li class="active"><a data-toggle="tab" href="ProfitCalculation.aspx" id="#CalculateProfit">Profit Calculation</a></li>
                            
                        </ul>

                        <div class="tab-content">
                            <div id="CalculateChannelCharges" class="tab-pane fade in active">
                                <h3>Calculate Profit</h3>
                                <div class="container">

                                     <div class="row top-buffer">
                                        <%--<div class="col-md-1">
                                        </div>--%>
                                        <div class="col-md-8">
                                            <div class="col-md-3">
                                            </div>
                                            <div class="col-md-4"><asp:TextBox ID="tb_from" runat="server" class="form-control" ></asp:TextBox>
                                               <%-- <asp:CustomValidator runat="server" ControlToValidate="tb_from" ErrorMessage="Date was in incorrect format" OnServerValidate="CustomValidator1_ServerValidate" />--%>
                                            </div>
                                              
                                            <div class="col-md-1">
                                                <asp:Button ID="btn_date1" width="205px" runat="server" Text="From" OnClick="btn_date1_Click"  /> 
                                            </div>
                                            <div class="col-md-10">
                                                <div class="col-md-4"></div>
                                                <asp:Calendar ID="Calendar1"  runat="server" Height="187px" Visible="false" Width="208px" OnSelectionChanged="Calendar1_SelectionChanged" > </asp:Calendar>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </div>
                                            <br /> <br />
                                         <div class="col-md-12"> 
                                             <br />
                                             <div class="col-md-6"></div>
                                             <div class="col-md-3">
                                                 
                                                <asp:Button ID="btn_view" runat="server" Text="View Details" OnClick="btn_view_Click"  /> 
                                            </div>
                                             <br />
                                         </div>
                                         <div class="col-md-8">
                                             <div class="col-md-3">
                                            </div>
                                            <div class="col-md-4"><asp:TextBox ID="tb_to" runat="server" class="form-control" ></asp:TextBox>
                                                 <%--<asp:CustomValidator runat="server" ControlToValidate="tb_from" ErrorMessage="Date was in incorrect format" OnServerValidate="CustomValidator2_ServerValidate" />--%>
                                            </div>
                                            <div class="col-md-4">
                                                <asp:Button ID="btn_date2" width="205px" runat="server" Text="To" OnClick="btn_date2_Click"  /> 
                                            </div>
                                            <div class="col-md-10">
                                                <div class="col-md-4"></div>
                                                <asp:Calendar ID="Calendar2" runat="server" Height="187px" Visible="false" Width="208px" OnSelectionChanged="Calendar2_SelectionChanged1" > </asp:Calendar>
                                            </div>
                                        </div>    
                                        
                                    </div> 

                                    <%--<div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_paymentdate" runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                           <asp:Button ID="btn_date" runat="server" Text="Payment Date" OnClick="btn_date_Click" /> 
                                        </div>
                                    </div>--%>

                                   <%-- <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4"></div>
                                            <div class="col-md-6">
                                                <asp:Calendar ID="Calendar1" OnSelectionChanged="Calendar1_SelectionChanged" runat="server" Height="187px" Visible="false" Width="208px"> </asp:Calendar>
                                            </div>
                                        </div>
                                    </div>--%>

                                    <div class="row top-buffer">
                                    </div>
                                        <br />


                                    <div class="row">
                                        <div class="col-md-2">
                                            
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-6">Total expenses for the given Duration</div>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="tb_totalExpense" runat="server" class="form-control" Enabled="true"></asp:TextBox>
                                                <asp:Label ID="lbl_errormsg_expense" runat="server" Visible="false" ForeColor="Red" Text="There are no expense details for the given time period"></asp:Label>
                                                <asp:Label ID="lbl_expense_value" runat="server" Visible="false"></asp:Label>
                                            </div> 
                                        </div>
                                        <div class="col-md-3">
                                                
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-2">
                                           
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-6">Total income for the given Duration</div>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="tb_totalIncome" runat="server" class="form-control" Enabled="true" ></asp:TextBox>
                                                <asp:Label ID="lbl_errormsg_income" runat="server" ForeColor="Red" Visible="false" Text="There are no income details for the given time period"></asp:Label>
                                                <asp:Label ID="lbl_income_value" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                     <div class="row top-buffer">
                                        <div class="col-md-2">
                                           
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-6">Profit Amount for the given Duration</div>
                                            <div class="col-md-5">
                                                <asp:TextBox ID="tb_profitAmount" runat="server" class="form-control" Enabled="true" ></asp:TextBox>
                                                <asp:Label ID="lbl_errormsg_profit" runat="server" ForeColor="Red" Visible="false" Text="There is no profit value for the given time period"></asp:Label>
                                                <asp:Label ID="lbl_profit" runat="server" Visible="false"></asp:Label>
                                            </div>
                                        </div>
                                         <br /><br /> <br /> <br /> 
                                        <div class="col-md-6">
                                            <div class="col-md-6"></div>
                                               <asp:Button ID="btn_clear" Text="Clear" runat="server" OnClick="btn_clear_Click"/>
                                            <asp:Button ID="btn_print" Text="Print Details" runat="server" OnClick="btn_print_Click"/>
                                        </div>




                                    </div>


                 <asp:GridView ID="GridView1" runat="server" 
                            
                            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                            CellPadding="4" CellSpacing="2" ForeColor="Black"
                            OnUnload="Page_Load"  Width="1200px" 
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

                  <asp:GridView ID="GridView2" runat="server" 
                            
                            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" 
                            CellPadding="4" CellSpacing="2" ForeColor="Black"
                            OnUnload="Page_Load"  Width="1200px" 
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
