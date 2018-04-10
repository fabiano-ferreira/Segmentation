<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdutosAtratividade.aspx.cs" Inherits="UI.DadosBasicos.ProdutosAtratividade" %>

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
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Dados Básicos | Produtos | Aderencia</td>
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
          <td width="25%">Campanha:</td>
          <td width="25%">Modelo:</td>
          <td width="25%">Versão:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                  runat="server" ControlToValidate="ddlVersao" ErrorMessage="*" 
                  ValidationGroup="vgAderenciaProduto"></asp:RequiredFieldValidator>
            </td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td>
            <asp:DropDownList ID="ddlCampanha" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlCampanha_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
          </td>
          <td><asp:DropDownList ID="ddlModelo" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlModelo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlVersao" runat="server" CssClass="txtbox" Width="95%"
                  onselectedindexchanged="ddlVersao_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList></td>
          <td>&nbsp;</td>
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
	        <li><asp:LinkButton ID="lkAderenciaProduto" runat="server" Enabled="false" 
                    onclick="lkAderenciaProduto_Click" ValidationGroup="vgAderenciaProduto" ><asp:Image ID="btnAplicarAderencia" runat="server" ToolTip="Aplicar Aderência ao Produto Corrente" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/>Aplicar Aderência Produto Corrente</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbAderenciaProdutoFilhos" runat="server" Enabled="false"  
                    onclick="lkbAderenciaProdutoFilhos_Click" ValidationGroup="vgAderenciaProduto" ><asp:Image ID="btnAderenciaProdutoFilhos" runat="server" ToolTip="Aplicar Aderencia Produto Filhos" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Aplicar Aderência dos Produtos Filhos</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCalcularAderencia" runat="server" 
                    onclick="lkbCalcularAderencia_Click"><asp:Image ID="btnCalcularAderencia" runat="server" ToolTip="Calcular Aderência das Categorias" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/calculadora.gif"/> Calcular Aderência das Categorias</asp:LinkButton></li>	        
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
        <asp:GridView ID="grvProdutosAtratividade" runat="server" AutoGenerateColumns="False" GridLines="none"
        Width="100%" AllowPaging="false" CellPadding="4" DataKeyNames="IDVersaoProdutoFator, IDSegmento">
          <FooterStyle/>
          <RowStyle CssClass="grid_line_01" />
          <Columns>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle">
            <ItemTemplate>
              <asp:ImageButton ID="btnSelecionar" runat="server" ImageUrl="~/Images/Icones/editar.gif" ToolTip="Selecionar" OnClick="btnSelecionar_Click" /></ItemTemplate>
            <HeaderStyle CssClass="grid_tittle"></HeaderStyle>
            <ItemStyle Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div">
          </asp:TemplateField>
          <asp:BoundField HeaderText="Código" DataField="IDSegmento" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Segmento" DataField="Codigo" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle" HeaderStyle-Width="90%">
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
  <tr>
    <td><table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
      <tr>
        <td>Categoria/Produto Selecionado: 
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtCatProduto" ErrorMessage="*" 
                ValidationGroup="vgAderenciaProduto"></asp:RequiredFieldValidator>
          </td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td colspan="2"><asp:TextBox ID="txtCatProduto" runat="server" CssClass="txtbox" Width="98%" Enabled="false"/></td>
        <td>
            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
          </td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td width="25%">Aderência:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" 
                runat="server" ControlToValidate="ddlAderencia" ErrorMessage="*" 
                ValidationGroup="vgAderenciaProduto"></asp:RequiredFieldValidator>
          </td>
        <td width="25%">Aderência Calculada:</td>
        <td width="25%">&nbsp;</td>
        <td width="25%">&nbsp;</td>
      </tr>
      <tr>
        <td><asp:DropDownList ID="ddlAderencia" runat="server" CssClass="txtbox" Width="95%" AutoPostBack="true"></asp:DropDownList></td>
        <td><asp:TextBox ID="txtAderenciaCalculada" runat="server" CssClass="txtbox" Width="95%" Enabled="false"/></td>
        <td>&nbsp;</td>
        <td>&nbsp;</td>
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
    <td id="botoes">&nbsp;</td>
  </tr>
  <tr>
    <td><div id="treeview">
    <asp:TreeView ID="trvAderencia" runat="server" onselectednodechanged="trvAderencia_SelectedNodeChanged" >
            <Nodes>
            </Nodes>
        </asp:TreeView>
    </div></td>
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