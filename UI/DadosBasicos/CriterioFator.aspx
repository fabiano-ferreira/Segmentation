
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CriterioFator.aspx.cs" Inherits="UI.DadosBasicos.CriterioFator1" %>
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
    <style type="text/css">
        .style1
        {
            width: 27%;
        }
    </style>
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


<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->  
<div id="maincontent">
<div class="contentform">
    
    
<!-- *******************************************************************************
 DESIGN INFORMATION: start form 
******************************************************************************** -->
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Dados Básicos | Critério | Fator</td>
  </tr>
  <tr>
    <td><table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td>&nbsp;</td>
          <td class="style1">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td width="25%">Campanha:</td>
          <td class="style1">Modelo:</td>
          <td>Fator:<aspFator:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                  runat="server" ControlToValidate="ddlFator" ErrorMessage="*" 
                  ValidationGroup="vgSalvar"></asp:RequiredFieldValidator></td>
          <td>Valor:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                  runat="server" ControlToValidate="txtValor" ErrorMessage="*" 
                  ValidationGroup="vgValor" Display="Dynamic"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Apenas números" Operator="DataTypeCheck" Type="Integer" ControlToValidate="txtValor" ValidationGroup="vgValor" Display="Dynamic"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlCampanha" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlCampanha_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
          <td class="style1"><asp:DropDownList ID="ddlModelo" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlModelo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlFator" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlFator_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
          <td><asp:TextBox ID="txtValor" runat="server" CssClass="txtbox" Width="88%" MaxLength="8"/></td>
        </tr>
        <tr>
          <td colspan="2">Critérios :       <td colspan="2">Critérios Selecionados:</td>
        </tr>
        <tr>
          <td colspan="4"><table width="100%" border="0" cellspacing="1" cellpadding="0" id="formfont">
              <tr>
                <td width="48%">
                <asp:ListBox ID="lbxFatorAdd" runat="server" CssClass="txtbox" Width="98%" 
                        SelectionMode="Multiple" Height="120px" ></asp:ListBox>
                </td>
                <td width="4%" align="center"><table border="0" cellspacing="0" cellpadding="2">
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                  <tr>
                    <td><asp:ImageButton ID="Adicionar" runat="server" 
                            ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar" 
                            onclick="Adicionar_Click" ValidationGroup="vgValor"/></td>
                  </tr>
                  <tr>
                    <td><asp:ImageButton ID="Remover" runat="server" 
                            ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover" 
                            onclick="Remover_Click"/></td>
                  </tr>
                  <tr>
                    <td>&nbsp;</td>
                  </tr>
                </table></td>
                <td width="48%">
                <asp:ListBox ID="lbxValorAdd" runat="server" CssClass="txtbox" Width="98%" SelectionMode="Multiple" Height="120px"></asp:ListBox>
                </td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td class="style1">&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
      </table></td>
  </tr>
  <tr>
    <td id="botoes">
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" onclick="lkbSalvar_Click" ValidationGroup="vgSalvar" ><asp:Image ID="btnSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" onclick="lkbCancelar_Click"><asp:Image ID="btnCancelar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->    
    </td>
  </tr>
  <tr>
    <td>&nbsp;</td>
  </tr>
</table>
<!-- *******************************************************************************
 DESIGN INFORMATION: end form 
******************************************************************************** -->


<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** -->  
</div>
</div>
</form>

<!-- *******************************************************************************
 DESIGN INFORMATION: start script page frames 
******************************************************************************** -->
    <script type="text/javascript">
        $.ajax({
            type: "POST",
            url: "../Controles/Menu.asmx/Generate",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function(msg) {
                $("#menuModel").html(msg.d);

                var menuModel = new DHTMLSuite.menuModel();
                DHTMLSuite.configObj.setCssPath('css/');
                menuModel.addItemsFromMarkup('menuModel');
                menuModel.setMainMenuGroupWidth(00);
                menuModel.init();
                var menuBar = new DHTMLSuite.menuBar();
                menuBar.addMenuItems(menuModel);
                menuBar.setTarget('menuDiv');
                menuBar.init();
            },
            error: function(msg) {
                alert(msg);
            }
        });
</script>
<!-- *******************************************************************************
 DESIGN INFORMATION: start script page frames 
******************************************************************************** -->   
</body>
</html>
<!-- **** DESIGN INFORMATION: BODY **** -->