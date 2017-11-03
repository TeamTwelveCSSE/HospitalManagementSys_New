<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_patient_details.aspx.cs" Inherits="HospitalManagementSystem.frm_patient_details" %>

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

                    <h3>Patient Details</h3>

                    <asp:TextBox ID="txt_search" Width="50%" runat="server" OnTextChanged="txt_search_TextChanged" AutoPostBack="true"></asp:TextBox>
                    <asp:Button ID="btn_search" BackColor="#61A6F8" runat="server" Text="Search" OnClick="btn_search_Click" />

                    <div class="container">
                        <div class="divRow">
                            <asp:GridView ID="dtg_dataGrid" DataKeyNames="appointment_id" runat="server" AutoGenerateColumns="false" CssClass="Gridview"
                                HeaderStyle-BackColor="#61A6F8" ShowFooter="false" HeaderStyle-Font-Bold="true" HeaderStyle-ForeColor="White"
                                OnRowCancelingEdit="dtg_dataGrid_RowCancelingEdit" OnRowDeleting="dtg_dataGrid_RowDeleting" OnRowEditing="dtg_dataGrid_RowEditing"
                                OnRowUpdating="dtg_dataGrid_RowUpdating">
                                <Columns>

                                    <asp:TemplateField HeaderText="Doctor Name">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_doctorName_edit" runat="server" Text='<%#Eval("doc_name") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_doctorName" runat="server" Text='<%#Eval("doc_name") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Speciality">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_speciality_edit" runat="server" Text='<%#Eval("speciality") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_speciality" runat="server" Text='<%#Eval("speciality") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Chanel date">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_date_edit" runat="server" Text='<%#Eval("session_date") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_date" runat="server" Text='<%#Eval("session_date") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Chanel time">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_time_edit" runat="server" Text='<%#Eval("session_time") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_time" runat="server" Text='<%#Eval("session_time") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Appointment No.">
                                        <EditItemTemplate>
                                            <asp:Label ID="lbl_appointmentNo_edit" runat="server" Text='<%#Eval("appointment_num") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_appointmentNo" runat="server" Text='<%#Eval("appointment_num") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Patient name">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_patientName" runat="server" Text='<%#Eval("patient_name") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_patientName" runat="server" Text='<%#Eval("patient_name") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="NIC">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_nic" runat="server" Text='<%#Eval("nic") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_nic" runat="server" Text='<%#Eval("nic") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Phone">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_phone" runat="server" Text='<%#Eval("phone") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_phone" runat="server" Text='<%#Eval("phone") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Email">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txt_email" runat="server" Text='<%#Eval("email") %>' />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lbl_email" runat="server" Text='<%#Eval("email") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField>
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="imb_update" CommandName="Update" runat="server" ImageUrl="~/Resources/images/update.png" ToolTip="Update" Height="20px" Width="20px" />
                                            <asp:ImageButton ID="imb_cancel" runat="server" CommandName="Cancel" ImageUrl="~/Resources/images/cancle.png" ToolTip="Cancel" Height="20px" Width="20px" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imb_edit" CommandName="Edit" runat="server" ImageUrl="~/Resources/images/edit.png" ToolTip="Edit" Height="20px" Width="20px" />
                                            <asp:ImageButton ID="imb_delete" CommandName="Delete" Text="Edit" runat="server" ImageUrl="~/Resources/images/delete.png" ToolTip="Delete" Height="20px" Width="20px" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div>
                            <asp:Label ID="lbl_result" runat="server"></asp:Label>
                            <asp:Label ID="lbl_message" runat="server" Text=""></asp:Label>
                            <br />
                            <asp:Button ID="btn_view" BackColor="#61A6F8" runat="server" Text="Chanel Details" OnClick="btn_view_Click" />

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
