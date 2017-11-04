<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabReport.aspx.cs" Inherits="HospitalManagementSystem.LabReport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lab Report</title>
    <meta charset="utf-8">
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
   	<!-- webfonts -->
</head>
<body>
    <!-- container -->
        <!-- header -->
        <div class="header header-border">
            <div class="container">
                <!-- logo -->
                <div class="logo col-md-6">
                    <a href="Main.aspx"><img style="margin-left:0" src="Resources/images/logo.png" title="medicalpluse" /></a>
                </div>
                <!-- logo -->
                <!-- top-nav -->
			    <div class="top-nav col-md-6">                        
                        <div class="topnav" id="TopNavBar">
                          <a href="Laboratory.aspx">Lab Test</a>
                          <a href="LabReport.aspx"><font color="96C03A">Lab Report</font></a>
                          <a href="#Lab Order">Lab Order</a>
                          <a href="#about">About</a>
                        </div>
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
                        <div class="tab-content">
                            <h3>Test Report</h3>

                            <div class="container">
                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Lab Test ID</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtLabTestId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnGenerateReport" runat="server" Text="Generate Report" Enabled="false" BackColor="Gray" OnClick="btnGenerateReport_Click"/>
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Patient Number</div>
                                            <div class="col-md-7"><asp:TextBox ID="txtPNo" runat="server" class="form-control"></asp:TextBox>
                                                <asp:Label ID="lblMsgPatient" runat="server" Text="Enter a valid Patient Number" Visible="false" ForeColor="Red"></asp:Label>
                                            </div>
                                            <div class="col-md-1"><asp:ImageButton id="btnSearchPatient" runat="server" ImageUrl="Resources/images/search.png" OnClick="btnSearchPatient_Click" /></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Patient Name</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtPatientName" runat="server" class="form-control"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">E-Mail</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtMail" runat="server" class="form-control"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Test Number</div>
                                            <div class="col-md-7"><asp:TextBox ID="txtNumber" runat="server" class="form-control"></asp:TextBox>
                                                <asp:Label ID="lblMsgTest" runat="server" Text="Enter a valid Test Number" Visible="false" ForeColor="Red"></asp:Label>
                                            </div>
                                            <div class="col-md-1"><asp:ImageButton id="btnSearchTest" runat="server" ImageUrl="Resources/images/search.png" OnClick="btnSearchTest_Click" /></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Test Name</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtTestName" runat="server" class="form-control"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Date</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtDate" runat="server" class="form-control" TextMode="Date"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Amount</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtAmount" runat="server" class="form-control"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Description</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtDesc" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                    <div class="col-md-3">
                                    </div>        
                                    <div class="col-md-6">
                                        <div class="col-md-3">
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>                                                
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Enabled="false" BackColor="Gray" OnClick="btnUpdate_Click"/>                                                
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnDelete" runat="server" Text="Delete" Enabled="false" BackColor="Gray" OnClick="btnDelete_Click"/>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidationLabReportForm()" OnClick="btnSubmit_Click"/>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                    </div>
                                </div>
                                
                                <div class="row top-buffer" style="padding-top:30px">
                                    <div class="col-md-6">
                                        View Test Report Details
                                        <a data-toggle="collapse" data-target="#emp_details"><img src="Resources/images/downarrow.png"/></a>
                                        <div id="testReport_details" class="collapse" style="padding-top:45px">
                                            <asp:GridView ID="GridReport" runat="server" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridEmp_SelectedIndexChanged" AutoGenerateSelectButton="True" OnRowDataBound="GridEmp_RowDataBound" OnUnload="Page_Load" OnRowDeleting="btnDelete_Click" OnRowEditing="GridViewTest_RowEditing" OnRowUpdating="GridViewTest_RowUpdating" AllowPaging="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">
                                                <AlternatingRowStyle BackColor="#DCDCDC"></AlternatingRowStyle>

                                                <FooterStyle BackColor="#CCCCCC" ForeColor="Black"></FooterStyle>

                                                <HeaderStyle BackColor="#3d4f17" Font-Bold="True" ForeColor="White"></HeaderStyle>

                                                <PagerStyle HorizontalAlign="Center" BackColor="#999999" ForeColor="Black"></PagerStyle>

                                                <RowStyle BackColor="#EEEEEE" ForeColor="Black"></RowStyle>

                                                <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

                                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

                                                <SortedAscendingHeaderStyle BackColor="#0000A9"></SortedAscendingHeaderStyle>

                                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

                                                <SortedDescendingHeaderStyle BackColor="#96C03A"></SortedDescendingHeaderStyle>
                                            </asp:GridView>
                                        </div>

                                        <div id="divFailed" class="alert alert-danger" style="text-align:center" runat="server" visible="False">
                                            <asp:Label ID="lblFailed" runat="server" Visible="False" Text="" Font-Size=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:DropDownList ID="lstSearch" runat="server"><asp:ListItem>Lab Test Id</asp:ListItem>
                                            <asp:ListItem>Patient Number</asp:ListItem>
                                            <asp:ListItem>Patient Name</asp:ListItem>
                                            <asp:ListItem>Test Number</asp:ListItem>
                                            <asp:ListItem>Test Name</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                        <asp:Button ID="brnSearch" runat="server" Text="Search" OnClick="brnSearch_Click"></asp:Button>
                                    </div>
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
