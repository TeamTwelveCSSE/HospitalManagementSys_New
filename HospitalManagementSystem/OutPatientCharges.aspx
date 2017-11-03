<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutPatientCharges.aspx.cs" Inherits="HospitalManagementSystem.OutPatientCharges" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Out Patient Charges</title>
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
                            <li class="active"><a data-toggle="tab" href="OutPatientCharges.aspx" id="#CalculateChannelCharges">Calculate Cannelling Charges</a></li>
                            <li><a data-toggle="tab" href="ProfitCalculation.aspx">Profit Calculation</a></li>
                            
                        </ul>

                        <div class="tab-content">
                            <div id="CalculateChannelCharges" class="tab-pane fade in active">
                                <h3>Calculate Cannelling Charges</h3>
                                <div class="container">

                                     <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Payment ID</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_paymentid" runat="server" class="form-control" ></asp:TextBox>
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
                                        <div class="col-md-3">
                                            
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Patient ID</div>
                                            <div class="col-md-8">
                                                <asp:TextBox ID="tb_patientid" runat="server" class="form-control" Enabled="true"></asp:TextBox>
                                                <asp:Label ID="lbl_hidden_patient_id" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
                                            </div> 
                                        </div>
                                        <div class="col-md-3">
                                                <asp:Button ID="btn_searchpatientid" runat="server" Text="Get Patient Details" OnClick="btnSearch_Click" />
                                        </div>
                                    </div>

                                     <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <asp:Label ID="lbl_validate" runat="server" ForeColor="Red" Text="Invalid Patient Id" Visible="False"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                            <asp:TextBox ID="tb_mail" runat="server" class="form-control" Visible="false"></asp:TextBox>
                                            <asp:Label ID="hidden_mail" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Patient Name</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_patientname" runat="server" class="form-control" ></asp:TextBox></div>
                                             <asp:Label ID="hidden_PatientName" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
                                        </div>
                                    </div>

                                    <%--<div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Email Address</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_email" Visible="false" runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                    </div>--%>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Doctor Name</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_doctorname" runat="server" class="form-control" ></asp:TextBox></div>
                                               
                                            </div>
                                        </div>
                                    <div/>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Channeled Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_chanelleddate" runat="server" class="form-control" ></asp:TextBox></div>
                                               <asp:Label ID="hidden_channeleddate" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">

                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Doctor Charge</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_doccharge" runat="server" class="form-control"  ></asp:TextBox></div>
                                            <asp:Label ID="hidden_doctorcharge" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Hospital Charge</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_hoscharge"  runat="server" class="form-control" ></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Other</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_other"  runat="server" class="form-control" ></asp:TextBox></div>
                                            <asp:Label ID="hidden_other" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Tax</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_tax" runat="server" class="form-control" ></asp:TextBox></div>
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
                                                <asp:Button ID="btn_calculate" runat="server" Text="Calculate" OnClick="btn_calculate_Click" Enabled="false" /> 
                                        </div>
                                        <div class="col-md-3">
                                          
                                        </div>
                                   </div>
                                        <br />
                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Total Payable</div>
                                            <div class="col-md-8"><asp:TextBox ID="tb_total"  runat="server" class="form-control" ></asp:TextBox></div>
                                            <asp:Label ID="hidden_total" runat="server" hidden="true" class="form-control" Enabled="false"></asp:Label>
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
                                                <asp:Button ID="btn_add" runat="server" Text="Add" OnClick="btnAdd_Click" Enabled="false" />
                                                <asp:Button ID="btn_print" runat="server" Text="Print" Enabled="false" OnClick="btn_print_Click"/>
                                                <asp:Button ID="btn_clear" runat="server" Text="Clear" OnClick="btn_clear_Click"  />
                                                <asp:Button ID="btn_email" runat="server" Text="Email" OnClick="btn_email_Click" Enabled="false" />
                                            </div>
                                        <div class="col-md-3">
                                            <%--<div class="col-md-6">
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click"/>
                                            </div>
                                            <div class="col-md-6">
                                                <asp:Button ID="btnCancel" runat="server" Text="Clear" OnClick="btnCancel_Click" />                                                
                                            </div>--%>
                                           <asp:Label ID="lbl_emailValidation" runat="server" Enabled="false" > </asp:Label>
                                        </div>
                                        </div>
                                       
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
