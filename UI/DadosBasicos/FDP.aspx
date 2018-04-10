<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FDP.aspx.cs" Inherits="UI.DadosBasicos.FDP" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Controles/MenuTopo.ascx" tagname="MenuTopo" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<!-- **** DESIGN INFORMATION: start head **** --> 
<head id="Head1" runat="server">
    <title>SARAIVA - SEGMENTAÇÃO</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <script type="text/javascript" src="../Js/menu-for-applications.js"></script>
    <link href="../Css/Css.css" rel="stylesheet" type="text/css" />
    <link href="../Css/MenuBar.css" rel="stylesheet" media="screen" type="text/css" />
    <script type="text/javascript" src="../Js/Includes.js"></script>    
</head>
<!-- **** DESIGN INFORMATION: end /head **** --> 

<!-- **** DESIGN INFORMATION: BODY **** --> 
<body>
<form id="form1" runat="server" >
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<!-- *******************************************************************************
 DESIGN INFORMATION: start div top 
******************************************************************************** -->
<div id="framecontent">
	<div id="toplogo"><img src="../Images/topo/logo.jpg"></div>
    <div id="toplogin">
    <ul>
    	<li><b><asp:Label ID="lblLogin" runat="server" Text="Rodrigo Nobrega"></asp:Label></b></li>
        <li><asp:Label ID="lblEmpresa" runat="server" Text="W IT Solutions"></asp:Label></li>
    </ul>
    </div>   
    <div id="topmenu"><uc2:MenuTopo ID="MenuTopo1" runat="server" /></div>
</div>    
<!-- *******************************************************************************
 DESIGN INFORMATION: end div top 
******************************************************************************** -->

<div id="maincontent">
    <div class="contentform">
<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->  

    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
      <tr>
        <td>
        <asp:ImageButton ID="btnPesquisar" runat="server" />
        </td>
      </tr>
    </table>
    
<!-- *******************************************************************************
 DESIGN INFORMATION: Modal 
******************************************************************************** -->
        <cc1:ModalPopupExtender ID="mdlCadastro" runat="server" PopupControlID="pnCad" TargetControlID="btnPesquisar" CancelControlID="btnCancelar"
            BackgroundCssClass="modalBackground">
        </cc1:ModalPopupExtender>
        <asp:Panel ID="pnCad" runat="server" CssClass="modal">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td id="modalTop">
                        <img src="Images/display/ico_seta.png" align="absmiddle">Sac Serviços | Novo Serviço
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right" class="right">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" ValidationGroup="Serv"
                            CssClass="formBtnGeral" OnClick="btnConfirmar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="formBtnGeral" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="right" class="right">
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: Modal 
******************************************************************************** -->

<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->  
    </div>
</div>

</form>

<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->
    <script type="text/javascript">
        var menuModel = new DHTMLSuite.menuModel();
        DHTMLSuite.configObj.setCssPath('css/');
        menuModel.addItemsFromMarkup('menuModel');
        menuModel.setMainMenuGroupWidth(00);
        menuModel.init();
        var menuBar = new DHTMLSuite.menuBar();
        menuBar.addMenuItems(menuModel);
        menuBar.setTarget('menuDiv');
        menuBar.init();	
    </script>
<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->    
</body>
</html>
<!-- **** DESIGN INFORMATION: BODY **** -->