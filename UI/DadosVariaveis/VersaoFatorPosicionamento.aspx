<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VersaoFatorPosicionamento.aspx.cs" Inherits="UI.DadoVariavel.VersaoFatorPosicionamento" %>

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
        Variáveis | Fator | Versao Fator Posicionamento</td>
  </tr>
  <tr>
    <td>
    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr> 
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>
              <asp:TextBox ID="txtIdVersao" runat="server" Visible="false"></asp:TextBox>
              <asp:TextBox ID="txtNivelTreeView" runat="server" Visible="false"></asp:TextBox>
            </td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td width="25%">Campanha:</td>
          <td width="25%">Modelo:
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ValidationGroup="vgFator" Display="Dynamic" ControlToValidate="ddlModelo"></asp:RequiredFieldValidator>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ValidationGroup="vgSalvar" Display="Dynamic" ControlToValidate="ddlModelo"></asp:RequiredFieldValidator>
          </td>
          <td width="25%">Descrição:
          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="vgSalvar" Display="Dynamic" ControlToValidate="txtDescricao"></asp:RequiredFieldValidator>
          </td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlCampanha" runat="server" CssClass="txtbox" Width="95%" AutoPostBack="true" OnSelectedIndexChanged="ddlCampanha_SelectedIndexChanged"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlModelo" runat="server" CssClass="txtbox" Width="95%" 
                  onselectedindexchanged="ddlModelo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
          </td>
          <td><asp:TextBox ID="txtDescricao" runat="server" CssClass="txtbox" Width="85%" MaxLength="40" /></td>
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
	        <li><asp:LinkButton ID="lkbPesquisarFator" runat="server" 
                    onclick="lkbPesquisarFator_Click" ValidationGroup="vgFator" Enabled="false" ><asp:Image ID="imgPesquisarFator" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/lupa.gif"/> Associar Fatores e Produtos</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" OnClick="lkbSalvar_Click" ValidationGroup="vgSalvar" ><asp:Image ID="imgSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" onclick="lkbCancelar_Click" ><asp:Image ID="imgCancelar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
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
        <asp:GridView ID="grvCampanha" runat="server" AutoGenerateColumns="False" GridLines="none"
        Width="100%" AllowPaging="false" CellPadding="4" DataKeyNames="IdModelo, IdVersaoProdutoFator, Descricao">
          <FooterStyle/>
          <RowStyle CssClass="grid_line_01" />
          <Columns>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div">
            <ItemTemplate>
              <asp:ImageButton ID="btnEditarGrid" runat="server" ImageUrl="~/Images/Icones/editar.gif" ToolTip="Editar" OnClick="btnEditarGrid_Click" />
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle_div"></HeaderStyle>
            <ItemStyle Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div">
            <ItemTemplate>
              <asp:ImageButton ID="btnExcluirGrid" runat="server" ImageUrl="~/Images/Icones/excluir.gif" ToolTip="Excluir" OnClick="btnExcluirGrid_Click" />
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle_div"></HeaderStyle>
            <ItemStyle Width="2%"></ItemStyle>
          </asp:TemplateField>          
          <asp:BoundField HeaderText="Código" DataField="IdVersaoProdutoFator" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Descrição" DataField="Descricao" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle" HeaderStyle-Width="90%">
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


<!-- *******************************************************************************
 DESIGN INFORMATION: start modal 
******************************************************************************** -->
<asp:Button ID="btnPesquisarFatorHidden" runat="server" Text="Button" style="display: none;"/>
<cc1:ModalPopupExtender ID="mdlFatorPosicionamento" runat="server" PopupControlID="pnFatorPosicionamento" TargetControlID="btnPesquisarFatorHidden" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnFatorPosicionamento" runat="server" CssClass="modal">
<asp:UpdatePanel ID="uppFator" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<div class="contentformpopup">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Associar 
        Fatores e Produtos</td>
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
    <td width="25%">Descrição:</td>
    <td width="25%">&nbsp;</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td colspan="2"><asp:TextBox ID="txtDescricao2" runat="server" CssClass="txtbox" Width="95%" Enabled="false"/></td>
    <td colspan="2">&nbsp;</td>
    </tr>
  <tr>
    <td colspan="4"><table width="100%" border="0" cellspacing="1" cellpadding="0" id="formfont">
      <tr>
        <td width="48%">Fatores:</td>
        <td width="4%" rowspan="2" align="center"><table border="0" cellspacing="0" cellpadding="2">
            <tr>
              <td><asp:ImageButton ID="btnAdicionarTodos" OnClick="btnAdicionarTodos_Click" runat="server" ImageUrl="~/Images/Icones/adicionar_todos.gif" ToolTip="Adicionar Todos"/></td>
            </tr>
            <tr>
              <td><asp:ImageButton ID="Adicionar" OnClick="Adicionar_Click" runat="server" ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar"/></td>
            </tr>
            <tr>
              <td><asp:ImageButton ID="Remover" OnClick="Remover_Click" runat="server" ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover"/></td>
            </tr>
            <tr>
              <td><asp:ImageButton ID="btnRemoverTodos" OnClick="btnRemoverTodos_Click" runat="server" ImageUrl="~/Images/Icones/remover_todos.gif" ToolTip="Remover Todos"/></td>
            </tr>
        </table>
        </td>
        <td width="48%">Fatores Selecionados:</td>
      </tr>
      <tr>
        <td><asp:ListBox ID="lbxFatores" runat="server" CssClass="txtbox" Width="98%" SelectionMode="Multiple" Height="150px"></asp:ListBox></td>
        <td>
            <asp:ListBox ID="lbxFatoresSelecionados" runat="server" CssClass="txtbox" Width="98%" SelectionMode="Multiple" Height="150px"></asp:ListBox>
        </td>
      </tr>
      <tr>
        <td colspan="2"><br /><asp:TextBox ID="txtTreeView" runat="server" CssClass="txtbox" Width="92%" Enabled="false"/></td>
        <td colspan="2">&nbsp;</td>
    </tr>
        <tr>
            <td>
                Produtos:</td>
            <td align="center" rowspan="2">
                <table border="0" cellpadding="2" cellspacing="0">
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnAdicionar2" runat="server" OnClick="btnAdicionar2_Click"
                                ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:ImageButton ID="btnRemover2" runat="server" OnClick="btnRemover2_Click"
                                ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>
                Produtos Selecionados:</td>
        </tr>
      <tr>
        <td><div id="treeview" style="height:150px;">
        <asp:TreeView ID="trvVersao" runat="server" onselectednodechanged="trvVersao_SelectedNodeChanged" >
            <Nodes>
            </Nodes>
        </asp:TreeView>
        </div></td>
        <td><asp:ListBox ID="lbxProdutosSelecionados" runat="server" CssClass="txtbox" Width="98%" SelectionMode="Multiple" Height="150px"></asp:ListBox></td>
      </tr>
    </table>
    </td>
    </tr>
  <tr>
    <td colspan="4">&nbsp;</td>
  </tr>
</table>
    </td>
  </tr>
  <tr>
    <td id="botoes">
    <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbSalvarModal" runat="server" ><asp:Image ID="imgSalvarModal" runat="server" ToolTip="Pesquisar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbFecharFator" OnClick="lkbFecharFator_Click" runat="server" ><asp:Image ID="imgFecharFator" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/excluir.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->            
    </td>
  </tr>
</table>

</div>
</ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal 
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