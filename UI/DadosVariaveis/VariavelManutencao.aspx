<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VariavelManutencao.aspx.cs" Inherits="UI.DadosVariaveis.VariavelManutencao" %>
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
	<div id="toplogo"><img src="../Images/topo/logo.jpg">
    </div>
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
        Variáveis | Variável | Manutenção</td>
  </tr>
  <tr>
    <td>
    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td>Campanha:</td>
          <td>Modelo:<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlModelo" ValidationGroup="AddTreeView" SetFocusOnError="True" ErrorMessage="*" ></asp:RequiredFieldValidator><asp:RequiredFieldValidator ID="rfvModeloLista" ControlToValidate="ddlModelo" runat="server" ValidationGroup="ListaVariavel" ErrorMessage="*"></asp:RequiredFieldValidator></td>
          <td>Classe de Variável:<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlClasseVariavel" SetFocusOnError="True" ValidationGroup="AddTreeView" ErrorMessage="*" ></asp:RequiredFieldValidator></td>
          <td>Tipo de Variável:<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlTipoVariavel" SetFocusOnError="True" ValidationGroup="AddTreeView" ErrorMessage="*" ></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlCampanha" AutoPostBack="true" runat="server" CssClass="txtbox" Width="90%" 
                  onselectedindexchanged="ddlCampanha_SelectedIndexChanged"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlModelo" runat="server" CssClass="txtbox" Width="90%" AutoPostBack="true" 
                  onselectedindexchanged="ddlModelo_SelectedIndexChanged"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlClasseVariavel" runat="server" CssClass="txtbox" Width="90%"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlTipoVariavel" runat="server" CssClass="txtbox" Width="90%"></asp:DropDownList></td>
        </tr>
        <tr>
          <td>Tipo de Saída:<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlTipoSaida" ValidationGroup="AddTreeView" SetFocusOnError="True" ErrorMessage="*" ></asp:RequiredFieldValidator></td>
          <td>Tipo de Dado:<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlTipoDado" ValidationGroup="AddTreeView" SetFocusOnError="True" ErrorMessage="*" ></asp:RequiredFieldValidator></td>
          <td>Código:</td>
          <td>Coluna Importação:<asp:RequiredFieldValidator ID="rfvImportacao" runat="server" ControlToValidate="txtColunaImportacao" ValidationGroup="AddTreeView" SetFocusOnError="True" ErrorMessage="*" Enabled="false"></asp:RequiredFieldValidator>
              <asp:CompareValidator ID="cvColuna" runat="server" ErrorMessage="Apenas Números"  ControlToValidate="txtColunaImportacao" Operator="DataTypeCheck" Type="Integer" SetFocusOnError="True"></asp:CompareValidator></td>
        </tr>
        <tr>
          <td><asp:DropDownList ID="ddlTipoSaida" AutoPostBack="true" runat="server" CssClass="txtbox" 
                  Width="90%" onselectedindexchanged="ddlTipoSaida_SelectedIndexChanged"></asp:DropDownList></td>
          <td><asp:DropDownList ID="ddlTipoDado" AutoPostBack="true" runat="server" CssClass="txtbox" Width="90%" 
                  onselectedindexchanged="ddlTipoDado_SelectedIndexChanged"></asp:DropDownList></td>
          <td>
              <asp:TextBox ID="txtIdVariavel" style="display:none;" runat="server"></asp:TextBox>
              <asp:UpdatePanel ID="uppCodigo" UpdateMode="Conditional" runat="server">
              <ContentTemplate>
                    <asp:TextBox ID="txtCodigo" runat="server" MaxLength="25" CssClass="txtbox" Width="95%" Enabled="false"/>
              </ContentTemplate>
              </asp:UpdatePanel>
          </td>
          <td><asp:TextBox ID="txtColunaImportacao" MaxLength="10" Enabled="false" runat="server" CssClass="txtbox" Width="90%"/></td>
        </tr>
        <tr>
          <td>Descrição:</td>
          <td>&nbsp;</td>
          <td>Comentários:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="txtDescricao" MaxLength="60" runat="server" CssClass="txtbox" Width="95%" Height="50px" /></td>
          <td colspan="2"><asp:TextBox ID="txtDescricao2" MaxLength="500" runat="server" CssClass="txtbox" Width="95%" Height="50px" /></td>
        </tr>
        <tr>
          <td>Metodo Científico para Obtenção:</td>
          <td>&nbsp;</td>
          <td>Método Prático para Obtenção:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="txtMetodoCientifico" MaxLength="60" runat="server" CssClass="txtbox" Width="95%"/></td>
          <td colspan="2"><asp:TextBox ID="txtMetodoPratico" MaxLength="60" runat="server" CssClass="txtbox" Width="95%"/></td>
        </tr>
        <tr>
          <td>Pergunta da Pesquisa /SFA e Call Center:<asp:RequiredFieldValidator ID="rfvPergunta" runat="server" ControlToValidate="txtPerguntaPesquisa" SetFocusOnError="True" ValidationGroup="AddTreeView" ErrorMessage="*"></asp:RequiredFieldValidator></td>
          <td>&nbsp;</td>
          <td>Inteligência Sistêmica do Modelo:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="txtPerguntaPesquisa" MaxLength="60" runat="server" CssClass="txtbox" Width="95%"/></td>
          <td colspan="2"><asp:TextBox ID="txtInteligenciaSistemica" MaxLength="60" runat="server" CssClass="txtbox" Width="95%"/></td>
        </tr>
        <tr>
          <td>Variavel Pai:<asp:RequiredFieldValidator ID="rfvVarPai" runat="server" ControlToValidate="txtVariavelPai" ValidationGroup="AddTreeView" SetFocusOnError="True" ErrorMessage="*" Enabled="false"></asp:RequiredFieldValidator></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
          <td>
              <asp:UpdatePanel ID="uppVariavelPai" runat="server">
              <ContentTemplate>
              <asp:TextBox ID="txtVariavelPai" Enabled="false" runat="server"></asp:TextBox>
              <asp:TextBox ID="txtIdVariavelPai" style="display:none;"  runat="server"/>
              <asp:ImageButton ID="btnPesquisar" runat="server" ImageUrl="~/Images/Icones/lupa.gif" ImageAlign="Middle" onclick="btnPesquisar_Click" />
              </ContentTemplate>
              </asp:UpdatePanel></td>
          <td>&nbsp;</td>
          <td&nbsp;</td>
        </tr>
          <td&nbsp;</td>
          <td&nbsp;</td>
        </table>    
    </td>
  </tr>
  <tr>
    <td id="botoes">
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbPesquisarRegras" runat="server" Enabled="false" 
                    onclick="lkbPesquisarRegras_Click" ><asp:Image ID="imgPesquisarRegras" runat="server" ToolTip="Regras Lógicas" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/regras.gif"/> Regras</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbPesquisarCalculo" runat="server" Enabled="false" 
                    onclick="lkbPesquisarCalculo_Click" ><asp:Image ID="imgPesquisarCalculo" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/calculadora.gif"/> Cálculos</asp:LinkButton></li>
            <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbSalvarVariavel" runat="server" onclick="lkbSalvarVariavel_Click" 
                      ><asp:Image ID="Image3" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/Salvar.gif"/>Salvar</asp:LinkButton></li>        
            <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbListaVariavel" runat="server" 
                    ValidationGroup="ListaVariavel" onclick="lkbListaVariavel_Click"><asp:Image ID="Image1" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/calculadora.gif"/>Atualizar Lista</asp:LinkButton></li>
            <li class="separator"></li>
            <li><asp:LinkButton ID="lkbNovaVariavel" ValidationGroup="AddTreeView" 
                    runat="server" onclick="lkbNovaVariavel_Click" ><asp:Image ID="Image2" runat="server" ToolTip="Pesquisar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/adicionar_item.gif"/>Adicionar Variavel</asp:LinkButton></li>
	    </ul>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->            
    </td>
  </tr>
    <tr>
    <td id="treeview" valign="top">
        <asp:TreeView ID="trvVariavel" runat="server" onselectednodechanged="trvVariavel_SelectedNodeChanged" >
            <Nodes>
                <asp:TreeNode Text="Variáveis" Value="0"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </td>
  </tr>
</table>
<!-- *******************************************************************************
 DESIGN INFORMATION: end form
******************************************************************************** -->


<!-- *******************************************************************************
 DESIGN INFORMATION: start modal regras logicas
******************************************************************************** -->
<asp:Button ID="btnPesquisarRegrasHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlRegras" runat="server" PopupControlID="pnRegras" TargetControlID="btnPesquisarRegrasHidden" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnRegras" runat="server" CssClass="modal">
<div class="contentformpopup">
<asp:UpdatePanel ID="uppRegraLogica" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Regras 
        Lógicas</td>
  </tr>
  <tr>
    <td><table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2" valign="top"><table width="100%" border="0" cellspacing="3" cellpadding="0">
              <tr>
                <td>Variável:</td>
              </tr>
              <tr>
                <td>
                    <asp:ListBox ID="ltbVariaveis" Width="98%" Height="98%" AutoPostBack="true" 
                        runat="server" onselectedindexchanged="ltbVariaveis_SelectedIndexChanged"></asp:ListBox>
                </td>
              </tr>
            </table>
            </td>
          <td colspan="2" valign="top"><table width="100%" border="0" cellspacing="3" cellpadding="0" id="formfont">
              <tr>
                <td>Regra Lógica:</td>
                <td></td>
              </tr>
              <tr>
                <td><asp:RadioButton ID="rbtnCriterio" Checked="true" Text="Criterio" GroupName="gnRegra" AutoPostBack="true" runat="server" oncheckedchanged="rbtnCriterio_CheckedChanged" /></td>
                <td><asp:RadioButton ID="rbtnValor" Text="Valor" GroupName="gnRegra" AutoPostBack="true" runat="server" oncheckedchanged="rbtnValor_CheckedChanged" /></td>
              </tr>
              <tr>
                <td width="50%">Critério:</td>
                <td width="50%">&nbsp;</td>
              </tr>
              <tr>
                <td colspan="2"><asp:DropDownList ID="ddlCriterio" runat="server" CssClass="txtbox" Width="95%" ></asp:DropDownList></td>
              </tr>
              <tr>
                <td>Valor:</td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td colspan="2"><asp:TextBox ID="txtValor" runat="server" CssClass="txtbox" 
                        Width="95%" Enabled="false" ontextchanged="txtValor_TextChanged"/></td>
              </tr>
              <tr>
                <td>
                    <asp:RadioButton ID="ResultadoRegra" GroupName="gnRegraLogica" Checked="true" AutoPostBack="true" 
                        runat="server" Text='Resultado da Regra:' 
                        oncheckedchanged="ResultadoRegra_CheckedChanged"/>
                </td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td colspan="2"><asp:DropDownList ID="ddlResultadoRegra" runat="server" CssClass="txtbox" Width="95%"></asp:DropDownList></td>
              </tr>
              <tr>
                <td><asp:RadioButton ID="ResultadoMapeamento" AutoPostBack="true" GroupName="gnRegraLogica" runat="server" Text='Mapeamento:' oncheckedchanged="ResultadoMapeamento_CheckedChanged"/></td>
                <td>&nbsp;</td>
              </tr>
              <tr>
                <td><asp:ImageButton ID="btnPesquisarMapeamento" runat="server" Enabled="false" ImageUrl="~/Images/Icones/mapeamento.gif" ImageAlign="Middle"/></td>
                <td>&nbsp;</td>
              </tr>
            </table></td>
        </tr>
        <tr>
          <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="4">
          <div id="Div1">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="25%" align="center" class="grid_tittle_div">Regra</td>
                  <td width="25%" align="center" class="grid_tittle_div">Variável 1</td>
                  <td width="25%" align="center" class="grid_tittle_div">Variável 2</td>
                  <td width="25%" align="center" class="grid_tittle">Variável</td>
                </tr>
                <tr class="grid_line_01">
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr class="grid_line_02">
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr class="grid_line_01">
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
              </table>
            </div>
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
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" ><asp:Image ID="imgSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbFecharRegras" runat="server" 
                    onclick="lkbFecharRegras_Click" ><asp:Image ID="imgFecharRegras" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
        <!-- **** DESIGN INFORMATION: end botoes form **** -->       
 </td>
  </tr>
</table>
</ContentTemplate>
</asp:UpdatePanel>
</div>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal regras logicas
******************************************************************************** -->


<!-- *******************************************************************************
 DESIGN INFORMATION: start modal mapeamento
******************************************************************************** -->
<asp:Button ID="btnPesquisarMapeamentoHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlMapeamento" runat="server" PopupControlID="pnMapeamento" TargetControlID="btnPesquisarMapeamentoHidden" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnMapeamento" runat="server" CssClass="modal">
<div class="contentformpopup">

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Mapeamentos</td>
  </tr>
  <tr>
    <td>
    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td>Variável:</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:DropDownList ID="ddlCodigoVariavel2" runat="server" CssClass="txtbox" Width="90%"></asp:DropDownList></td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td>Critério Original:</td>
          <td>&nbsp;</td>
          <td>Critério Mapeamento:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:TextBox ID="txtCriterioOriginal" runat="server" CssClass="txtbox" Width="95%" Height="50px" TextMode="MultiLine"/></td>
          <td colspan="2"><asp:TextBox ID="txtCriterioMapeamento" runat="server" CssClass="txtbox" Width="95%" Height="50px" TextMode="MultiLine"/></td>
        </tr>
        <tr>
          <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
          <td colspan="4">
          <div id="gridform">
              <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td width="33%" align="center" class="grid_tittle_div">Mapeamento</td>
                  <td width="33%" align="center" class="grid_tittle_div">Critério Original</td>
                  <td width="33%" align="center" class="grid_tittle">Critério Mapeado</td>
                </tr>
                <tr class="grid_line_01">
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr class="grid_line_02">
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
                <tr class="grid_line_01">
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                  <td>&nbsp;</td>
                </tr>
              </table>
            </div>            
            </td>
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
	        <li><asp:LinkButton ID="lkbSalvar2" runat="server" ><asp:Image ID="imgSalvar2" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/>Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbFecharMapeamento" runat="server" ><asp:Image ID="imgFecharMapeamento" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/>Salvar</asp:LinkButton></li>
	    </ul>
	    </div>
        <!-- **** DESIGN INFORMATION: end botoes form **** -->    
    </td>
  </tr>
</table>

</div>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal mapeamento
******************************************************************************** -->


<!-- *******************************************************************************
 DESIGN INFORMATION: start modal calculo
******************************************************************************** -->
<asp:Button ID="btnPesquisarCalculoHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlCalculo" runat="server" PopupControlID="pnCalculo" TargetControlID="btnPesquisarCalculoHidden"  BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnCalculo" runat="server" CssClass="modal">
<div class="contentformpopup">

<asp:UpdatePanel ID="uppCalculo" runat="server" UpdateMode="Conditional">
<ContentTemplate>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Cálculos</td>
  </tr>
  <tr>
    <td><table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="formfont">
        <tr>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
          <td width="25%">&nbsp;</td>
        </tr>
        <tr>
          <td>Código Variável:</td>
          <td>&nbsp;</td>
          <td>Nome Variável:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2">
              <asp:TextBox ID="txtCodigoVariavel" runat="server" CssClass="txtbox" Width="90%" Enabled="false"></asp:TextBox></td>
          <td colspan="2"><asp:TextBox ID="txtNomeVariavel" runat="server" CssClass="txtbox" Width="90%" Enabled="false"></asp:TextBox></td>
        </tr>
        <tr>
          <td>Variável Selecionada:<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlVariavelSelecionada" ValidationGroup="vgCalculo" ErrorMessage="*" ></asp:RequiredFieldValidator></td>
          <td>&nbsp;</td>
          <td>Operador:</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td colspan="2"><asp:DropDownList ID="ddlVariavelSelecionada" runat="server" CssClass="txtbox" Width="90%"></asp:DropDownList></td>
          <td colspan="2"><asp:DropDownList ID="ddlOperador" runat="server" CssClass="txtbox" AutoPostBack="true" OnSelectedIndexChanged="ddlOperador_SelectedIndexChanged"
                  Width="90%" ></asp:DropDownList></td>
        </tr>
        <tr>
          <td>Abre Parentese<asp:RadioButton ID="ckbAbrePar" GroupName="vgParenteses" runat="server" /></td>
          <td>&nbsp;</td>
          <td>Fecha Parentese<asp:RadioButton ID="ckbFechaPar" GroupName="vgParenteses" runat="server" /></td>
          <td>&nbsp;</td>
        </tr>
        <tr>
          <td><asp:ImageButton ID="AdicionarItem" ValidationGroup="vgCalculo" runat="server" ImageUrl="../Images/Icones/adicionar_item.gif" OnClick="AdicionarItem_Click" ToolTip="Adicionar Fórmula" ImageAlign="AbsMiddle"/>
          <asp:ImageButton ID="btnRemoverItem" runat="server" ImageUrl="../Images/Icones/remover_item.gif" OnClick="btnRemoverItem_Click" ToolTip="Remover Fórmula" ImageAlign="AbsMiddle"/> 
              Fórmula:</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
          <td>&nbsp;</td>
        </tr>
        <tr>
              <td colspan="4">
                  <asp:TextBox ID="txtOrdem" style="display:none;" runat="server"></asp:TextBox>
              <asp:TextBox ID="txtCalculoFinal" runat="server" CssClass="txtbox" Enabled="false" Width="95%" Height="50px"/></td>
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
	        <li><asp:LinkButton ID="lkbSalvarCalculo" OnClick="lkbSalvarCalculo_Click" runat="server" ><asp:Image ID="imgSalvar3" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/>Salvar</asp:LinkButton></li>
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbFecharCalculo" runat="server" onclick="lkbFecharCalculo_Click" ><asp:Image ID="imgFecharCalculo" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/>Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->
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
 DESIGN INFORMATION: start modal 
******************************************************************************** -->
<asp:Button ID="btnPesquisarHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlVariavel" runat="server" PopupControlID="pnCad" TargetControlID="btnPesquisarHidden" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnCad" runat="server" CssClass="modal">
<div class="contentformpopup">
<asp:UpdatePanel ID="uppVariavel" runat="server" UpdateMode="Conditional">
    <ContentTemplate>    
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Consultar 
        Variável</td>
  </tr>
  <tr>
    <td>
    <table width="99%" align="right" border="0" cellspacing="3" cellpadding="0" id="Table1">
  <tr>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td width="25%">&nbsp;</td>
    <td width="25%">&nbsp;</td>
  </tr>
  <tr>
    <td width="25%">Código Variável:</td>
    <td width="25%">Nome da Variável:</td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><asp:TextBox ID="txtCodigoFiltro" MaxLength="25" runat="server" CssClass="txtbox" Width="90%"/></td>
    <td colspan="2"><asp:TextBox ID="txtNomeFiltro" MaxLength="60" runat="server" CssClass="txtbox" Width="90%"/></td>
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
	        <li><asp:LinkButton ID="lkbPesquisar1" runat="server" 
                    onclick="lkbPesquisar1_Click" ><asp:Image ID="imgPesquisar1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/pesquisar.gif"/> Pesquisar</asp:LinkButton></li>                
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelarModal" runat="server" 
                    onclick="lkbCancelarModal_Click1" ><asp:Image ID="imgFechar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/excluir.gif"/> Cancelar</asp:LinkButton></li>
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
    <asp:GridView ID="grvVariavel" 
            runat="server" AutoGenerateColumns="false" 
            GridLines="none" DataKeyNames="IdVariavel, Descricao"
        Width="100%" AllowPaging="false" CellPadding="4">
          <FooterStyle/>
          <RowStyle CssClass="grid_line_01" />
          <Columns>          
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" 
                  HeaderStyle-CssClass="grid_tittle">
            <ItemTemplate>
                <asp:RadioButton ID="rdbVariavel" runat="server" AutoPostBack="true" 
                    OnCheckedChanged="rdbVariavel_CheckedChanged"/>
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle"></HeaderStyle>
            <ItemStyle CssClass="grid_ico" Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:BoundField HeaderText="IdVariavel" Visible="false" 
                  HeaderStyle-HorizontalAlign="Center" DataField="IDVariavel" 
                  HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Código" HeaderStyle-HorizontalAlign="Center" 
                  DataField="Codigo" HeaderStyle-CssClass="grid_tittle_div" 
                  HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Nome" HeaderStyle-HorizontalAlign="Center" 
                  DataField="Descricao" HeaderStyle-CssClass="grid_tittle_div" 
                  HeaderStyle-Width="60%">
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