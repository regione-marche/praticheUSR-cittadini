<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModuleTest.aspx.cs" Inherits="RicercaPratiche.ModuleTest" %>

<%@ Register Src="~/DesktopModules/RegioneMarche2016/RicercaPratiche/View.ascx" TagPrefix="uc1" TagName="View" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
			<uc1:View runat="server" id="View" />
        </div>
    </form>
</body>
</html>
