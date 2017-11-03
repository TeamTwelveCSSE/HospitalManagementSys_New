<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_chanelInfo.aspx.cs" Inherits="HospitalManagementSystem.frm_chanelInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        .Gridview {
            font-family: Verdana;
            font-size: 10pt;
            font-weight: normal;
            color: black;
            width: 100%;
        }
    </style>

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

                    <h3>Channel Doctor</h3>

                    <asp:TextBox ID="txtSearch" Width="50%" runat="server" OnTextChanged="txtSearch_TextChanged" AutoPostBack="true">
                    </asp:TextBox><asp:Button ID="btn_view" BackColor="#61A6F8" runat="server" Text="Search" OnClick="btn_view_Click" />

                    <div class="container">
                        <div class="divRow">
                            <asp:GridView ID="dtg_dataGrid" runat="server" AutoGenerateColumns="false" CssClass="Gridview" HeaderStyle-BackColor="#61A6F8"
                                ShowFooter="false" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White" OnRowCommand="ActionCommand">
                                <Columns>

                                    <asp:BoundField DataField="doc_name" HeaderText="Doctor Name" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="speciality" HeaderText="Speciality" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="session_date" HeaderText="Session date" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="session_time" HeaderText="Session time" ItemStyle-Width="150" />
                                    <asp:BoundField DataField="appointment_no" HeaderText="Appointment No." ItemStyle-Width="150" />

                                    <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="150" />
                                    <asp:ButtonField Text="Report" CommandName="Report" ItemStyle-Width="150" />

                                </Columns>
                            </asp:GridView>
                        </div>

                        <div>
                            <asp:Label ID="lbl_result" runat="server"></asp:Label>
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
