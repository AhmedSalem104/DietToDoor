<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormWithDate.aspx.cs" Inherits="ERPWEB.Reporting.Forms.FormWithDate" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <style>
    .container {
    height: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
}
</style>
</head>
<body >
    <form id="form1" runat="server" >
<div style="text-align:center; align-content:center" class="auto-style1" >
    <div style="text-align:center;">
      
    <rsweb:ReportViewer ID="ReportViewer7" ZoomPercent="150" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="200%" BorderStyle="None" Height="581px" BackColor="Silver" BorderColor="Black" CssClass="auto-style2" SizeToReportContent="True" ZoomMode="PageWidth" DocumentMapWidth="100%" ExportContentDisposition="AlwaysAttachment" Font-Italic="False">
     </rsweb:ReportViewer>
        </div>
     <asp:ScriptManager ID="ScriptManager7" runat="server">
            </asp:ScriptManager>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
     
    </form>
</body>
</html>