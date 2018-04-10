<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FatorManutencao.aspx.cs" Inherits="UI.DadoVariavel.FatorManutencao" %>
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
	<div id="toplogo">
        <img src="../Images/topo/logo.jpg"></div>
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
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Dados Variáveis | Fator | Manutenção</td>
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
          <td width="25%">Modelo:<asp:RequiredFieldValidator ID="rfvModelo" runat="server" 
                  ControlToValidate="ddlModelo" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="ListarTreeView"></asp:RequiredFieldValidator>
                  <asp:RequiredFieldValidator ID="rfvModeloADD" runat="server" 
                  ControlToValidate="ddlModelo" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="AddTreeView"></asp:RequiredFieldValidator></td>
          <td width="25%">Tipo de Fator:<asp:RequiredFieldValidator ID="rfvTipoFator" runat="server" 
                  ControlToValidate="ddlTipoFator" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="ListarTreeView"></asp:RequiredFieldValidator>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                  ControlToValidate="ddlTipoFator" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="AddTreeView"></asp:RequiredFieldValidator></td>
          <td>Código:</td>
          <td>Nome:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                  ControlToValidate="txtNome" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="AddTreeView"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlModelo" runat="server" CssClass="txtbox" Width="95%"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlTipoFator" runat="server" CssClass="txtbox" Width="95%"></asp:DropDownList></td>
          <td><asp:TextBox ID="txtCodigoFator" runat="server" CssClass="txtbox" Enabled="false" Width="95%"/><asp:TextBox ID="txtIdFator" style="display:none;" runat="server" ></asp:TextBox></td>
          <td><asp:TextBox ID="txtNome" runat="server" CssClass="txtbox" Width="95%" MaxLength="40"/></td>
        </tr>
        <tr>
          <td>Descrição:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                  ControlToValidate="txtDescricao" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="AddTreeView"></asp:RequiredFieldValidator></td>
          <td>&nbsp;</td>
          <td>Comentário:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                  ControlToValidate="txtComentario" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="AddTreeView"></asp:RequiredFieldValidator></td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="txtDescricao" MaxLength="500" runat="server" CssClass="txtbox" Width="98%" Height="50px"/></td>
          <td colspan="2"><asp:TextBox ID="txtComentario" MaxLength="500" runat="server" CssClass="txtbox" Width="98%" Height="50px"/></td>
        </tr>
        <tr>
          <td>Peso (%):<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                  ControlToValidate="txtPeso" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="AddTreeView"></asp:RequiredFieldValidator>
                  <asp:CompareValidator ID="cvPeso" runat="server" ControlToValidate="txtPeso" ValidationGroup="AddTreeView" ErrorMessage="Apenas números" Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator></td>
          <td>Fator Principal:</td>
          <td>Campanha<asp:RequiredFieldValidator ID="rfvCampanha" runat="server" 
                  ControlToValidate="ddlCampanha" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="ListarTreeView"></asp:RequiredFieldValidator></td>
          <td>&nbsp;</td>
        </tr>
        <tr >
          <td><asp:TextBox ID="txtPeso" MaxLength="5" runat="server" CssClass="txtbox" Width="95%"/></td>
          <td >
              <asp:UpdatePanel ID="uppFatorPai" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                  <asp:TextBox ID="txtFatorPai" Enabled="false" runat="server" CssClass="txtbox" Width="85%"/>
                  <asp:TextBox ID="txtIdFatorPai" style="display:none;"  runat="server"/>
                  <asp:ImageButton ID="btnPesquisar" runat="server" ImageUrl="~/Images/Icones/lupa.gif" ImageAlign="Middle" onclick="btnPesquisar_Click"/>
                </ContentTemplate>
              </asp:UpdatePanel>
          </td>
          <td>
              <asp:DropDownList ID="ddlCampanha" runat="server" Width="95%" 
                  AutoPostBack="true" onselectedindexchanged="ddlCampanha_SelectedIndexChanged">
              </asp:DropDownList>
          </td>
          <td >
            <div id="botoesform">
	            <ul>
	                <li>
	                    <asp:LinkButton ID="btnListarFatores" ValidationGroup="ListarTreeView" runat="server" onclick="btnListarFatores_Click" ><asp:Image ID="Image2" runat="server" ToolTip="Listar Fatores" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/pesquisar.gif"/> Listar Fatores</asp:LinkButton>
	                </li>
	            </ul>
	        </div>
          </td>
        </tr>
        <tr>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td&nbsp;</td&nbsp;</td&nbsp;</td>
        </tr>
      </table>
      </td>
  </tr>
  <tr>
    <td id="botoes">
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbNovoFator" ValidationGroup="AddTreeView" runat="server" onclick="lkbNovoFator_Click" ><asp:Image ID="imgSalvar" runat="server" ToolTip="Pesquisar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/adicionar_item.gif"/>Adicionar Fator</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbSalvarFator" runat="server" onclick="lkbSalvarFator_Click" ><asp:Image ID="Image3" runat="server" ToolTip="Pesquisar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/>Salvar Fator</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" onclick="lkbCancelar_Click" ><asp:Image ID="btnCancelar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/>Cancelar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbRemover" runat="server" onclick="lkbRemover_Click" ><asp:Image ID="Image5" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/>Remover</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbModalProduto" runat="server" 
                    onclick="lkbModalProduto_Click" ><asp:Image ID="Image4" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Produto Novo</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->    
    </td>
  </tr>
  <tr>
    <td id="treeview" valign="top">
        <asp:TreeView ID="trvFator" runat="server" 
            onselectednodechanged="trvFator_SelectedNodeChanged">
            <Nodes>
                <asp:TreeNode Text="Fatores" Value="0"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </td>
  </tr>
</table>
<!-- *******************************************************************************
 DESIGN INFORMATION: end form
******************************************************************************** -->
    
<!-- *******************************************************************************
 DESIGN INFORMATION: start modal 
******************************************************************************** -->
<asp:Button ID="btnPesquisarHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlFator" runat="server" PopupControlID="pnCad" TargetControlID="btnPesquisarHidden" CancelControlID="" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnCad" runat="server" CssClass="modal">
<div class="contentformpopup">
<asp:UpdatePanel ID="uppFator" runat="server" UpdateMode="Conditional">
    <ContentTemplate>    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Consultar 
        Fator</td>
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
    <td width="25%">Código Fator</td>
    <td width="25%">Nome do Fator:</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><asp:TextBox ID="txtCodigoFiltro" MaxLength="15" runat="server" CssClass="txtbox" Width="90%"/></td>
    <td colspan="2"><asp:TextBox ID="txtNomeFiltro" MaxLength="40" runat="server" CssClass="txtbox" Width="90%"/></td>
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
    <td id="botoes">
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbPesquisar1" runat="server" onclick="lkbPesquisar1_Click" ><asp:Image ID="imgPesquisar1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/pesquisar.gif"/> Pesquisar</asp:LinkButton></li>                
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelarModal" OnClick="lkbCancelarModal_Click" runat="server" ><asp:Image ID="imgFechar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/excluir.gif"/> Cancelar</asp:LinkButton></li>
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
        <asp:GridView ID="grvFator" runat="server" AutoGenerateColumns="false" GridLines="none" DataKeyNames="IdFator, Codigo, Nome"
        Width="100%" AllowPaging="false" CellPadding="4">
          <FooterStyle/>
          <RowStyle CssClass="grid_line_01" />
          <Columns>          
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle">
            <ItemTemplate>
                <asp:RadioButton ID="rdbFator" runat="server" AutoPostBack="true" OnCheckedChanged="rdbFator_CheckedChanged" />
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle"></HeaderStyle>
            <ItemStyle CssClass="grid_ico" Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:BoundField HeaderText="IdFator" Visible="false" HeaderStyle-HorizontalAlign="Center" DataField="Codigo" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Código" HeaderStyle-HorizontalAlign="Center" DataField="Codigo" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" DataField="Nome" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="60%">
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
    </ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal 
******************************************************************************** -->








<!-- *******************************************************************************
 DESIGN INFORMATION: start modal associar
******************************************************************************** -->
<asp:Button ID="btnPesquisarProdutosHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlProdutos" runat="server" PopupControlID="pnProd" TargetControlID="btnPesquisarProdutosHidden" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnProd" runat="server" CssClass="modal">
<div class="contentformpopup">

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Associar 
        Produto ao Fator</td>
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
          <td width="25%">Código:</td>
          <td width="25%">&nbsp;</td>
          <td>Nome:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="txtCodigoProduto" Enabled="false" runat="server" CssClass="txtbox" Width="95%"/></td>
          <td colspan="2"><asp:TextBox ID="txtNomeProduto" Enabled="false" runat="server" CssClass="txtbox" Width="95%"/></td>
        </tr>
        <tr>
          <td colspan="2">&nbsp;</td>
          <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="4"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            
            <tr>
              <td width="45%" rowspan="3" valign="top">
              <div id="treeview"></div>
              </td>
              <td width="5%">
              <table border="0" align="center" cellpadding="2" cellspacing="0">
                <tr>
                  <td><asp:ImageButton ID="AdicionarCategoria" runat="server" ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar Categoria"/></td>
                </tr>
                <tr>
                  <td><asp:ImageButton ID="RemoverCategoria" runat="server" ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover Categoria"/></td>
                </tr>
              </table></td>
              <td width="45%"><table width="100%" border="0" cellspacing="2" cellpadding="0" id="formfont">
                <tr>
                  <td>Categoria:</td>
                </tr>
                <tr>
                  <td><asp:TextBox ID="txtCategoria" runat="server" CssClass="txtbox" Width="95%" Height="120px" TextMode="MultiLine"/></td>
                </tr>
              </table>
              </td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>
              <td align="center"><table border="0" cellspacing="0" cellpadding="2">
                <tr>
                  <td><asp:ImageButton ID="AdicionarProdutos" runat="server" ImageUrl="~/Images/Icones/adicionar.gif" ToolTip="Adicionar Produtos"/></td>
                </tr>
                <tr>
                  <td><asp:ImageButton ID="RemoverProdutos" runat="server" ImageUrl="~/Images/Icones/remover.gif" ToolTip="Remover Produtos"/></td>
                </tr>
              </table>
              </td>
              <td>
              <table width="100%" border="0" cellspacing="2" cellpadding="0" id="Table3">
                <tr>
                  <td>Produtos:</td>
                </tr>
                <tr>
                  <td><asp:TextBox ID="txtProdutos" runat="server" CssClass="txtbox" Width="95%" Height="120px" TextMode="MultiLine"/></td>
                </tr>
              </table>
              </td>
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
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" ><asp:Image ID="Image1" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbFecharProdutos" runat="server" ><asp:Image ID="imgFecharProdutos" runat="server" ToolTip="Excluir" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/excluir.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->      
    </td>
  </tr>
</table>


</div>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal associar
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