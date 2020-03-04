<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibraryManagement.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Content/bootstrap-darkly.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server" style="margin-top:200px;">
        <div class="row form-group">
            <div class="col-lg-4"></div>
            <label for="inputEmail" class="col-lg-1 control-label">Email</label>
            <div class="col-lg-3">
                <asp:TextBox ID="txtEmail" class="form-control" runat="server" placeholder="Email"></asp:TextBox>
            </div>
            <div class="col-lg-4"></div>
        </div>
        <div class="row form-group">
            <div class="col-lg-4"></div>
            <label for="inputEmail" class="col-lg-1 control-label">Password</label>
            <div class="col-lg-3">
                <asp:TextBox ID="txtPassword" class="form-control" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
            </div>
            <div class="col-lg-4"></div>
        </div>
        <div class="col-lg-4"></div>
        <div class="col-lg-2">
            <asp:Button ID="Submit" ValidationGroup="Save" runat="server" class="btn btn-success pull-right" Text="Login" OnClick="Submit_Click" />
        </div>
        <div class="col-lg-2">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>
        <div class="col-lg-4"></div>
    </form>
</body>
</html>
