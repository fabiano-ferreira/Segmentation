<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PermissaoUsuario.aspx.cs" Inherits="UI.Seguranca.PermissaoUsuario1" %>
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
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Segurança | Usuário | Permissão</td>
  </tr>
  <tr>
    <td>
    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td width="25%">Usuários:</td>
          <td width="25%">&nbsp;</td>
          <td colspan="2">&nbsp;</td&nbsp;</td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlNomeUsuario" runat="server" CssClass="txtbox" AutoPostBack="true"
                  Width="95%" onselectedindexchanged="ddlNomeUsuario_SelectedIndexChanged"/></td>
          <td>&nbsp;</td>
          <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="4">
          <table width="100%" border="0" cellspacing="1" cellpadding="0" id="formfont">
              <tr>
                <td width="48%">Associar Permissões</td>
                <td width="4%" rowspan="2" align="center"><table border="0" cellspacing="0" cellpadding="2">
                    <tr>
                      <td><asp:ImageButton ID="btnAdicionarTodos" runat="server" 
                              ImageUrl="~/Images/Icones/adicionar_todos.gif" ToolTip="Adicionar Todos" 
                              onclick="btnAdicionarTodos_Click"/></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="Adicionar" runat="server" 
                              ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar" 
                              onclick="Adicionar_Click"/></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="Remover" runat="server" 
                              ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover" 
                              onclick="Remover_Click"/></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="btnRemoverTodos" runat="server" 
                              ImageUrl="~/Images/Icones/remover_todos.gif" ToolTip="Remover Todos" 
                              onclick="btnRemoverTodos_Click"/></td>
                    </tr>
                  </table></td>
                <td width="48%">Permissões           </tr>
              <tr>
                <td><asp:ListBox ID="ltbAssociarPermissoes" runat="server" SelectionMode="Multiple" CssClass="txtbox" Width="98%" TextMode="MultiLine" Height="120px"/></td>
                <td><asp:ListBox ID="ltbAssociarPermissoesAdd" SelectionMode="Multiple" runat="server" CssClass="txtbox" Width="98%" TextMode="MultiLine" Height="120px"/></td>
              </tr>
              <tr>
                <td>Associar PAssociar Perfil</td>
                <td rowspan="2" align="center"><table border="0" cellspacing="0" cellpadding="2">
                    <tr>
                      <td><asp:ImageButton ID="btnAdicionarTodos1" runat="server" 
                              ImageUrl="~/Images/Icones/adicionar_todos.gif" ToolTip="Adicionar Todos" 
                              onclick="btnAdicionarTodos1_Click"/></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="btnAdicionarTodos2" runat="server" 
                              ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar" 
                              onclick="btnAdicionarTodos2_Click"/></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="btnRemoverTodos3" runat="server" 
                              ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover" 
                              onclick="btnRemoverTodos3_Click" /></td>
                    </tr>
                    <tr>
                      <td><asp:ImageButton ID="btnRemoverTodos4" runat="server" 
                              ImageUrl="~/Images/Icones/remover_todos.gif" ToolTip="Remover Todos" 
                              onclick="btnRemoverTodos4_Click" /></td>
                    </tr>
                  </table>
                  </td>
                <td>Perfil           </tr>
              <tr>
                <td><asp:ListBox ID="ltbAssociarPerfil" SelectionMode="Multiple" runat="server" CssClass="txtbox" Width="98%"  Height="120px"/></td>
                <td><asp:ListBox ID="ltbAssociarPerfilAdd" SelectionMode="Multiple" runat="server" CssClass="txtbox" Width="98%" Height="120px"/></td>
              </tr>
            </table>
            </td>
        </tr>
        <tr>
          <td colspan="2">&nbsp;</td>
          <td colspan="2">&nbsp;</td&nbsp;</td>
        </tr>
      </table>
      </td>
  </tr>
  <tr>
    <td id="botoes"
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" onclick="lkbSalvar_Click" ><asp:Image ID="btnSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" onclick="lkbCancelar_Click" ><asp:Image ID="btnCancelar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->    
    </td>
  </tr>
</table>
<!-- *******************************************************************************
 DESIGN INFORMATION: end form 
******************************************************************************** -->


</div>
</div>
</form>
<!-- *******************************************************************************
 DESIGN INFORMATION: end div content 
******************************************************************************** -->  


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