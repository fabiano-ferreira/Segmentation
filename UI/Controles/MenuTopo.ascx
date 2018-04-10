<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuTopo.ascx.cs" Inherits="UI.Controles.MenuTopo" %>

<script src="../Js/jquery-1.3.2.min.js" type="text/javascript"></script>
<div id="framecontent">
    <div id="toplogo">
        <img src="../Images/topo/logo.jpg"></img></div>
    <div id="toplogin">
        <ul>
            <li>
                <asp:Label ID="lblUsuario" runat="server" Font-Bold="true"></asp:Label></li>
            <li>
                <asp:Label ID="lblEmpresa" runat="server" Text="W IT Solutions"></asp:Label></li>
        </ul>
    </div>
    <div id="mainContentainer">
    <div id="topmenu">
	        <!-- This <ul><li> list is the source of a menuModel object -->
	        <ul id="menuModel" style="display:none">
	        </ul>	
	        <!-- End data source for the menu -->
	        <div id="menuDiv"></div>
        </div>
    </div>
</div>


