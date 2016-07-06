<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveFile.aspx.cs" Inherits="Playground.SaveFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h2>Create a Hello File !!!</h2>
    <form role="form" runat="server">
        <div class="form-group">
            <label class="control-label" for="exampleInputEmail">Text to Save:</label>
            <asp:TextBox ID="textToSave" runat="server" CssClass="form-control" placeholder="write some text"></asp:TextBox>
        </div>
        <div>
            <br />
            <asp:LinkButton ID="SaveBtn" runat="server" CssClass="btn btn-primary" Text="[ SAVE to Disk ]" OnClick="SaveBtn_Click"></asp:LinkButton>
        </div>
    </form>
</body>
</html>
