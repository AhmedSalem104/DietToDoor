<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StationsTrxInAndOutForm.aspx.cs" Inherits="Maintanence.Reporting.Forms.StationsTrxInAndOutForm" %>
<%@Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>
            <rsweb:ReportViewer ID="ReportViewer1" ZoomPercent="150" runat="server" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="200%" BorderStyle="None" Height="581px" AsyncRendering="false" BackColor="Silver" BorderColor="Black" CssClass="auto-style2" SizeToReportContent="True" ZoomMode="PageWidth" DocumentMapWidth="100%" ExportContentDisposition="AlwaysAttachment" Font-Italic="False">
             </rsweb:ReportViewer>
        </div>
         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </form>
</body>
</html>
