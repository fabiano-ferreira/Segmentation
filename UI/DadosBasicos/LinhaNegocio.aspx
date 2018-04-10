<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LinhaNegocio.aspx.cs" Inherits="UI.DadosBasicos.LinhaNegocio" %>

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
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Dados Básicos | Linha de Negócio</td>
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
          <td>Nome:<asp:RequiredFieldValidator ID="rfvNome" runat="server" 
                  ControlToValidate="txtNome" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="Salvar"></asp:RequiredFieldValidator></td>
          <td>Razão Social:<asp:RequiredFieldValidator ID="rfvRazaoSocial" runat="server" 
                  ControlToValidate="txtRazaoSocial" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="Salvar"></asp:RequiredFieldValidator></td>
          <td>CNPJ:<asp:RequiredFieldValidator ID="rfvCNPJ" runat="server" 
                  ControlToValidate="txtCNPJ" ErrorMessage="*" SetFocusOnError="True" 
                  ValidationGroup="Salvar"></asp:RequiredFieldValidator></td>
          <td></td>
        </tr>
        <tr>
          <td><asp:TextBox ID="txtNome" runat="server" CssClass="txtbox" Width="95%" MaxLength="60"/></td>
          <td><asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="txtbox" Width="95%" MaxLength="50"/></td>
          <td><asp:TextBox ID="txtCNPJ" runat="server" CssClass="txtbox" Width="95%" MaxLength="15" onBlur="VerificaCNPJ();"/>
          <cc1:MaskedEditExtender ID="MaskedEditExtender5" runat="server" AcceptNegative="Left"
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" CultureDateFormat=""
                CultureDatePlaceholder="" CultureDecimalPlaceholder="" CultureThousandsPlaceholder=""
                CultureTimePlaceholder="" DisplayMoney="Left" Enabled="True" ErrorTooltipEnabled="True"
                ClearMaskOnLostFocus="false" InputDirection="RightToLeft" Mask="99,999,999/9999-99"
                TargetControlID="txtCNPJ"> </cc1:MaskedEditExtender>
          
          </td>
          <td><asp:TextBox ID="txtCodigo" runat="server" CssClass="txtbox" Width="95%" style="display:none;"/></td>
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
    <td id="botoes"
        <!-- **** DESIGN INFORMATION: start botoes form **** -->
    	<div id="botoesform">
	    <ul>
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" ValidationGroup="Salvar" 
                    onclick="lkbSalvar_Click" ><asp:Image ID="btnSalvar" runat="server" ToolTip="Salvar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>
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
        <asp:GridView ID="grvManutencaoPerfil" runat="server" AutoGenerateColumns="False" GridLines="none" DataKeyNames="IdLinhaNegocio, Nome, RazaoSocial, CNPJ"
        Width="100%" AllowPaging="false" CellPadding="4">
          <FooterStyle/>
          <RowStyle CssClass="grid_line_01" />
          <Columns>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle">
            <ItemTemplate>
              <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="~/Images/Icones/editar.gif" OnClick="btnEdit_Click" ToolTip="Editar"/>
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle"></HeaderStyle>
            <ItemStyle CssClass="grid_ico" Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:TemplateField ItemStyle-Width="25px" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div">
            <ItemTemplate>
              <asp:ImageButton ID="btnExcluir" runat="server" ImageUrl="~/Images/Icones/excluir.gif" ToolTip="Excluir" OnClick="btnExcluir_Click" />
            </ItemTemplate>
            <HeaderStyle CssClass="grid_tittle_div"></HeaderStyle>
            <ItemStyle CssClass="grid_ico" Width="2%"></ItemStyle>
          </asp:TemplateField>
          <asp:BoundField HeaderText="Código" DataField="IDLinhaNegocio" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="10%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="Nome" DataField="Nome" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle_div" HeaderStyle-Width="70%">
            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
          </asp:BoundField>
          <asp:BoundField HeaderText="CNPJ" DataField="CNPJ" HeaderStyle-HorizontalAlign="Center" HeaderStyle-CssClass="grid_tittle" HeaderStyle-Width="20%">
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

        function VerificaCNPJ() {
            var cnpj = $get('<%= this.txtCNPJ.ClientID %>').value;
            cnpj = cnpj.replace(".", "");
            cnpj = cnpj.replace(".", "");
            cnpj = cnpj.replace("-", "");
            cnpj = cnpj.replace("/", "");
            cnpj = cnpj.replace("______________", "");
            if (cnpj != "") {
                var numeros, digitos, soma, i, resultado, pos, tamanho, digitos_iguais;
                digitos_iguais = 1;
                if (cnpj.length < 14 && cnpj.length < 15) {
                    alert("CNPJ Invalido")
                    return false;
                }
                for (i = 0; i < cnpj.length - 1; i++)
                    if (cnpj.charAt(i) != cnpj.charAt(i + 1)) {
                    digitos_iguais = 0;
                    break;
                }
                if (!digitos_iguais) {
                    tamanho = cnpj.length - 2
                    numeros = cnpj.substring(0, tamanho);
                    digitos = cnpj.substring(tamanho);
                    soma = 0;
                    pos = tamanho - 7;
                    for (i = tamanho; i >= 1; i--) {
                        soma += numeros.charAt(tamanho - i) * pos--;
                        if (pos < 2)
                            pos = 9;
                    }
                    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                    if (resultado != digitos.charAt(0)) {
                        alert("CNPJ Invalido")
                        return false;
                    }
                    tamanho = tamanho + 1;
                    numeros = cnpj.substring(0, tamanho);
                    soma = 0;
                    pos = tamanho - 7;
                    for (i = tamanho; i >= 1; i--) {
                        soma += numeros.charAt(tamanho - i) * pos--;
                        if (pos < 2)
                            pos = 9;
                    }
                    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
                    if (resultado != digitos.charAt(1)) {
                        alert("CNPJ Invalido")
                        return false;
                    }
                    return true;
                }
                else {
                    alert("CNPJ Invalido")
                    return false;
                }
            }
        }


</script>
<!-- *******************************************************************************
 DESIGN INFORMATION: start script page frames 
******************************************************************************** -->   
</body>
</html>
<!-- **** DESIGN INFORMATION: BODY **** -->