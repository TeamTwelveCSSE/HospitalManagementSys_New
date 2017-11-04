<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratory.aspx.cs" Inherits="HospitalManagementSystem.Laboratory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Laboratory</title>
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
                          <a href="Laboratory.aspx"><font color="96C03A">Lab Test</font></a>
                          <a href="LabReport.aspx">Lab Report</a>
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
                            <div id="AddTest" class="tab-pane fade in active">
                                <h3>Test Details</h3>

                                <div class="container">
                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Test Number</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtTestNo" runat="server" class="form-control" ReadOnly="true"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Test Section</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="lstSection" runat="server" class="form-control" AutoPostBack="false" Visible="True">
                                                    <asp:ListItem>Blood Tests</asp:ListItem>
                                                    <asp:ListItem>Pregnacy and Newborns Tests</asp:ListItem>
                                                    <asp:ListItem>Radiology Tests</asp:ListItem>
                                                    <asp:ListItem>Thyroid Function Tests</asp:ListItem>
                                                    <asp:ListItem>Other Tests</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
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
                                            <div class="col-md-4">Test Description</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtTestDesc" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Is Active</div>
                                            <div class="col-md-8">
                                                <asp:RadioButtonList ID="radioActive" runat="server" Font-Size="Small">
                                                    <asp:ListItem Selected="True">True</asp:ListItem>
                                                    <asp:ListItem>False</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Unit of Measure</div>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="lstUnit" runat="server" class="form-control">
                                                     <asp:ListItem>ml</asp:ListItem>
                                                     <asp:ListItem>mm</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Amount</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtTestAmount" runat="server" class="form-control"></asp:TextBox></div>
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
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidateLaboratoryForm()" OnClick="btnSubmit_Click"/>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                    </div>

                                    <div class="row top-buffer" style="padding-top:30px">
                                        <div class="col-md-6">
                                            View Test Details
                                            <a data-toggle="collapse" data-target="#test_details"><img src="Resources/images/downarrow.png"/></a>
                                            <div id="test_details" class="collapse" style="padding-top:45px">
                                                <asp:GridView ID="GridTest" runat="server" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" OnSelectedIndexChanged="GridEmp_SelectedIndexChanged" AutoGenerateSelectButton="True" OnRowDataBound="GridEmp_RowDataBound" OnUnload="Page_Load" OnRowDeleting="btnDelete_Click" OnRowEditing="GridViewTest_RowEditing" OnRowUpdating="GridViewTest_RowUpdating" AllowPaging="True" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True">

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
                                            <asp:DropDownList ID="lstSearch" runat="server"><asp:ListItem>Test Id</asp:ListItem>
                                                <asp:ListItem>Test Category</asp:ListItem>
                                                <asp:ListItem>Test Name</asp:ListItem>
                                                <asp:ListItem>Status</asp:ListItem>
                                                <asp:ListItem>Unit</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
                                            <asp:Button ID="brnSearch" runat="server" Text="Search" OnClick="brnSearch_Click"></asp:Button>
                                        </div>
                                    </div>

                                    <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-md-3">
                                        </div>
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
