<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeloManutencao.aspx.cs" Inherits="UI.DadosBasicos.ModeloManterModelo" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../Controles/MenuTopo.ascx" tagname="MenuTopo" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >


<!-- **** DESIGN INFORMATION: start head **** --> 
<head id="Head1" runat="server">
    <title></title>
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
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Dados Básicos | Modelo | Manutenção</td>
  </tr>
  <tr>
    <td>
    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td width="25%">Campanha:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
                  runat="server" ControlToValidate="ddlCampanha" ErrorMessage="*" ValidationGroup="vgSalvar"></asp:RequiredFieldValidator>
            </td>
          <td width="25%">Tipo de Segmento:<asp:RequiredFieldValidator 
                  ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTipoSegmento"
                  ErrorMessage="*" ValidationGroup="vgSalvar"></asp:RequiredFieldValidator>
            </td>
          <td width="25%">Nome:<asp:RequiredFieldValidator 
                  ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNome"
                  ErrorMessage="*" ValidationGroup="vgSalvar"></asp:RequiredFieldValidator>
            </td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlCampanha" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlCampanha_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlTipoSegmento" runat="server" CssClass="txtbox" Width="95%"></asp:DropDownList></td>
          <td><asp:TextBox ID="txtNome" runat="server" CssClass="txtbox" Width="95%" MaxLength="40"/></td>
          <td><asp:TextBox ID="txtCodigModelo" runat="server" CssClass="txtbox" Visible="false"/></td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
      </table>
    </td>
  </tr>
  <tr>
    <td id="botoes">
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" onclick="lkbSalvar_Click" ValidationGroup="vgSalvar"><asp:Image ID="btnSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" onclick="lkbCancelar_Click"><asp:Image ID="btnCancelar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->   
    </td>
  </tr>
  <tr>
    <td>
<!-- *******************************************************************************
 DESIGN INFORMATION: start grid
******************************************************************************** -->        
    <div id="gridform">
        <asp:GridView ID="grvManterModelo" runat="server" AutoGenerateColumns="False" GridLines="none"
        Width="100%" AllowPaging="false" CellPadding="4" DataKeyNames="CodigoModelo, CodigoTipoSegmento, Nome">
          <FooterStyle/>
          <RowStyle CssClass="grid_line_01" />
          <Columns>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle">
            <ItemTemplate>
              <asp:ImageButton ID="bnEditar" OnClick="btnEditar_Click" runat="server" ImageUrl="~/Images/Icones/editar.gif" ToolTip="Editar"/>
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle"></HeaderStyle>
            <ItemStyle CssClass="grid_ico" Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div">
            <ItemTemplate>
              <asp:ImageButton ID="btnExcluir" OnClick="btnExcluir_Click" runat="server" ImageUrl="~/Images/Icones/excluir.gif" ToolTip="Excluir" />
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle_div"></HeaderStyle>
            <ItemStyle CssClass="grid_ico" Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:BoundField HeaderText="Código" DataField="CodigoModelo" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Tipo Segmento" DataField="TipoSegmento" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="30%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Nome" DataField="Nome" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="30%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          </Columns>
          <HeaderStyle/>
          <AlternatingRowStyle CssClass="grid_line_02"/>
        </asp:GridView>
      </div>
<!-- *******************************************************************************
 DESIGN INFORMATION: end grid
******************************************************************************** -->          
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