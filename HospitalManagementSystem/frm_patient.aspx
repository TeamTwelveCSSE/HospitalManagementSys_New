<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_patient.aspx.cs" Inherits="HospitalManagementSystem.frm_patient" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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

    <title></title>
</head>
<body>

    <!-- header -->
    <div class="header header-border">
        <div class="container">
            <!-- logo -->
            <div class="logo">
                <a href="Main.aspx">
                    <img style="margin-left: 0" src="Resources/images/logo.png" title="medicalpluse" /></a>
            </div>
            <!-- logo -->
            <!-- top-nav -->
            <div class="top-nav">
                <span class="menu"></span>
                <!-- page heading -->
            </div>
            <!-- top-nav -->
        </div>
    </div>
    <!-- /header -->

    <form id="form1" runat="server">

        <main id="content">
            <div class="container">
                <div class="row">

                    <h3>Channel Details</h3>

                    <div class="container">
                        <div class="divRow">

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Doctor Name</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_doctorName" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Specialization</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_speciality" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Date</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_date" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Time</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_time" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Appointment No.</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_appointmentNo" ReadOnly="true" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Patient Name</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_patientName" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">NIC</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_nic" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Phone</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_phone" runat="server" class="form-control"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">Email</div>
                                    <div class="col-md-8">
                                        <asp:TextBox ID="txt_email" runat="server" class="form-control"></asp:TextBox>
                                    </div>
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

                            <div class="row top-buffer">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-3">
                                    <div class="col-md-6">
                                        <asp:Button ID="btn_add" BackColor="#61A6F8" runat="server" Text="INSERT" OnClick="btn_add_Click" />
                                    </div>
                                </div>
                            </div>

                            <div class="row top-buffer">
                                <div class="col-md-3">
                                </div>
                                <div class="col-md-6">
                                    <div class="col-md-4">
                                        <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-6">
                                <div class="col-md-4">
                                    <asp:Button ID="btn_view" BackColor="#61A6F8" runat="server" Text="View Details" OnClick="btn_view_Click" />
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
