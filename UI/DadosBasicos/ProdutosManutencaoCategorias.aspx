<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProdutosManutencaoCategorias.aspx.cs" Inherits="UI.DadosBasicos.ProdutosManutencaoCategorias" %>
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
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Dados 
        Básicos | Produtos | Manutenção de Categorias</td>
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
          <td width="25%">Nome:<asp:RequiredFieldValidator ID="rfvNome" 
                  runat="server" ErrorMessage="*" ControlToValidate="txtNome" ValidationGroup="Salvar"></asp:RequiredFieldValidator>
            </td>
          <td>Nível da Categoria Pai:</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
        <asp:UpdatePanel ID="uppCategorias" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
          <td><asp:TextBox ID="txtNome" runat="server" CssClass="txtbox" Width="86%"/></td>
          <td>
          <asp:UpdatePanel ID="uppDadosPai" runat="server" UpdateMode="Conditional">
          <ContentTemplate>
          <asp:TextBox ID="txtNivelProduto" runat="server" CssClass="txtbox" Width="86%"/>
              <asp:Label ID="lblIdCategoria" runat="server" Visible="false"></asp:Label>
              <asp:ImageButton ID="btnPesquisar" runat="server" 
                  ImageUrl="~/Images/Icones/lupa.gif" ImageAlign="Middle" 
                  onclick="btnPesquisar_Click"/>
              </ContentTemplate>
              </asp:UpdatePanel>
              </td>
          <td></td>
          <td><asp:Label ID="lblId" runat="server" Visible="false"></asp:Label></td>
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
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" onclick="lkbSalvar_Click" ><asp:Image ID="btnSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbExcluir" runat="server" onclick="lkbExcluir_Click" ><asp:Image ID="btnExcluir" runat="server" ToolTip="Excluir" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/excluir.gif"/> Excluir</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" CausesValidation="false" 
                    onclick="lkbCancelar_Click" ><asp:Image ID="btnCancelar" runat="server" ToolTip="Excluir" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->    
    </td>
  </tr>
  <tr>
    <td>
    
    <div style="height:550px; overflow:auto;">
    <asp:TreeView runat="server" ID="trvCategoria" 
            onselectednodechanged="trvCategoria_SelectedNodeChanged">
        <Nodes>
            <asp:TreeNode Value="" Text="Categorias" />
        </Nodes>
    </asp:TreeView>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </td>
  </tr>
</table>
<!-- *******************************************************************************
 DESIGN INFORMATION: end form
******************************************************************************** -->


<!-- *******************************************************************************
 DESIGN INFORMATION: start modal 
******************************************************************************** -->
<asp:Button ID="btnModal" runat="server" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlCadastro" runat="server" PopupControlID="pnCad" TargetControlID="btnModal" CancelControlID="btnFechar" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnCad" runat="server" CssClass="modal">
<div class="contentformpopup">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Categoria 
        de Produto</td>
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
    <td width="25%">Nome:</td>
    <td width="25%">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2"><asp:TextBox ID="txtNome1" runat="server" CssClass="txtbox" Width="86%"/>
    <asp:UpdatePanel ID="uppPesquisa" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:ImageButton ID="ImageButton3" runat="server" 
            ImageUrl="~/Images/Icones/lupa.gif" ImageAlign="Middle" 
            onclick="ImageButton3_Click"/>
    </ContentTemplate>
    </asp:UpdatePanel>        
    </td>
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
    <td id="botoes"><asp:ImageButton ID="btnFechar" runat="server" ImageUrl="../Images/Icones/excluir.gif" ImageAlign="AbsMiddle" CssClass="botoesgerais"/></td>
  </tr>
  <tr>
    <td>
<!-- *******************************************************************************
 DESIGN INFORMATION: start grid 
******************************************************************************** -->
    <div id="gridform">
    <div style="height:300px; overflow:auto;">
    <asp:UpdatePanel ID="uppGrid" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <asp:GridView ID="grvNivelProduto" runat="server" AutoGenerateColumns="False" GridLines="none" DataKeyNames="IDProdutoNivel"
        Width="100%" AllowPaging="false">
        <FooterStyle/>
        <RowStyle CssClass="grid_line_01" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="chkSeleciona" runat="server" AutoPostBack="true" OnCheckedChanged="chkSeleciona_CheckedChanged" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Código" HeaderStyle-HorizontalAlign="Center" DataField="IDProdutoNivel" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="20%">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
            
            <asp:BoundField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" DataField="Nome" HeaderStyle-CssClass="grid_tittle" HeaderStyle-Width="70%">
                <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
            </asp:BoundField>
            
        </Columns>
        <HeaderStyle/>
        <AlternatingRowStyle CssClass="grid_line_02"/>
    </asp:GridView>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</div> 
<!-- *******************************************************************************
 DESIGN INFORMATION: end grid 
******************************************************************************** -->
</td>
  </tr>
</table>

</div>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal 
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
 DESIGN INFORMATION: start div content 
******************************************************************************** -->    
</body>
</html>
<!-- **** DESIGN INFORMATION: BODY **** -->