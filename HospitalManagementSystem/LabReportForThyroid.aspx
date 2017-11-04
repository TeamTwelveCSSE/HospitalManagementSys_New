<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LabReportForThyroid.aspx.cs" Inherits="HospitalManagementSystem.LabReportForThyroid" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thyroid Test Report</title>
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
                        <div class="tab-content">
                            <h3>Thyroid Function</h3>

                            <div class="container">
                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Report ID</div>
                                            <div class="col-md-8"><asp:TextBox ID="txtReportId" runat="server" class="form-control" ReadOnly="true"></asp:TextBox></div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Patient ID</div>
                                            <div class="col-md-7"><asp:TextBox ID="txtPatientId" runat="server" class="form-control"></asp:TextBox>
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
                                            <div class="col-md-4">TSH</div>
                                            <div class="col-md-4"><asp:TextBox ID="txtTSH" runat="server" class="form-control"></asp:TextBox></div>
                                            <div class="col-md-4">0.27 - 4.20</div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">T4 Total</div>
                                            <div class="col-md-4"><asp:TextBox ID="txtT4" runat="server" class="form-control"></asp:TextBox></div>
                                            <div class="col-md-4">64.5 - 142.0</div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Free T4</div>
                                            <div class="col-md-4"><asp:TextBox ID="txtFreeT4" runat="server" class="form-control"></asp:TextBox></div>
                                            <div class="col-md-4">12 - 22</div>
                                        </div>
                                        <div class="col-md-3">
                                        </div>
                                </div>

                                <div class="row top-buffer">
                                        <div class="col-md-3">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="col-md-4">Free T3</div>
                                            <div class="col-md-4"><asp:TextBox ID="txtFreeT3" runat="server" class="form-control"></asp:TextBox></div>
                                            <div class="col-md-4">3.1 - 6.8</div>
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
                                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" OnClientClick="return ValidationThyroidReportForm()"/>
                                            </div>
                                        </div>
                                        <div class="col-md-3">
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
