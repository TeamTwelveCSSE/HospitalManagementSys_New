<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_session_details.aspx.cs" Inherits="HospitalManagementSystem.frm_session_details" %>

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
                    <h3>Appointment Sessions Details</h3>
                    <div class="container">
                        <div class="divRow">

                            <asp:GridView ID="dtg_dataGrid" DataKeyNames="session_id" runat="server" AutoGenerateColumns="false" CssClass="Gridview"
                                HeaderStyle-BackColor="#61A6F8" ShowFooter="false" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                OnRowCancelingEdit="dtg_dataGrid_RowCancelingEdit" OnRowDeleting="dtg_dataGrid_RowDeleting"
                                OnRowEditing="dtg_dataGrid_RowEditing" OnRowUpdating="dtg_dataGrid_RowUpdating">
                                <Columns>

                                    <asp:TemplateField HeaderText="Doctor ID">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_doctorID_edit" runat="server" Text='<%#Eval("doc_id") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_doctorID" runat="server" Text='<%#Eval("doc_id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Session date">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_date" runat="server" Text='<%#Eval("session_date") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("session_date") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Session time">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_time" runat="server" Text='<%#Eval("session_time") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_time" runat="server" Text='<%#Eval("session_time") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="No. of appointments">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_appointments" runat="server" Text='<%#Eval("no_of_appointments") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_appointments" runat="server" Text='<%#Eval("no_of_appointments") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="imb_update" CommandName="Update" runat="server" ImageUrl="~/Resources/images/update.png"
                                                ToolTip="Update" Height="20px" Width="20px" />
                                            <asp:ImageButton ID="imb_cancel" runat="server" CommandName="Cancel" ImageUrl="~/Resources/images/cancle.png"
                                                ToolTip="Cancel" Height="20px" Width="20px" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_edit" CommandName="Edit" runat="server" ImageUrl="~/Resources/images/edit.png" ToolTip="Edit"
                                                Height="20px" Width="20px" />
                                            <asp:ImageButton ID="imb_delete" CommandName="Delete" Text="Delete" runat="server" ImageUrl="~/Resources/images/delete.png"
                                                ToolTip="Delete" Height="20px" Width="20px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </div>
                        <div>
                            <asp:Label ID="lbl_result" runat="server"></asp:Label>
                            <br />
                            <asp:Button ID="btn_navigate" BackColor="#61A6F8" runat="server" Text="Insert Details" OnClick="btn_navigate_Click" />

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
