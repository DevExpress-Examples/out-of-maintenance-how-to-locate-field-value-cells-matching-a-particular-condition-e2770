<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Default.aspx.vb"
	Inherits="ASPxPivotGrid_FindCells._Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v15.1, Version=15.1.15.0,
	Culture=neutral, PublicKeyToken=b88d1754d700e49a"
	Namespace="DevExpress.Web.ASPxPivotGrid"
	TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
	"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
	<title>Untitled Page</title>
</head>
<body>
	<form id="form1" runat="server">
		<asp:RadioButtonList ID="radioButtonList" runat="server"
			AutoPostBack="true" CellSpacing="10" >
			<asp:ListItem Selected="True">Default Layout</asp:ListItem>
			<asp:ListItem>Remove Columns with Zero Summary Values</asp:ListItem>
		</asp:RadioButtonList>
		<br />
		<div>
			<dx:ASPxPivotGrid ID="pivotGrid" runat="server" Width="500px" 
				OnFieldValueDisplayText="pivotGrid_FieldValueDisplayText"
				OnCustomFieldValueCells="pivotGrid_CustomFieldValueCells"
				OptionsCustomization-AllowFilter="false"
				OptionsCustomization-AllowDrag="false">
			</dx:ASPxPivotGrid>
		</div>
	</form>    
</body>

</html>