<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="UI._Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd"><html xmlns="http://www.w3.org/1999/xhtml" lang="en" xml:lang="en">

<!-- **** DESIGN INFORMATION: start head **** --> 
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Editora Saraiva - Segmentação</title>
<link href="Css/Css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="Js/Login.js"></script>
<script type="text/javascript" language="javascript">
<!--
    function start() {
        var winOpen = window.open('Index.aspx', '', 'resizable=no,scrooling=no');
        winOpen.moveTo(0, 0);
        winOpen.resizeTo(screen.availWidth, screen.availHeight);
        window.opener = window;
        window.close();
    }
//-->
</script>






</head>
<!-- **** DESIGN INFORMATION: end head **** --> 


<!-- **** DESIGN INFORMATION: BODY **** --> 
<body>
<form runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div id="framecontent">
	<div id="toplogo"><img src="Images/topo/logo.jpg"></div>
    <div id="toplogin"></div>
    <div id="topmenu"></div>
</div>


<!-- *******************************************************************************
 DESIGN INFORMATION: start div content 
******************************************************************************** --> 
<div id="logincontent">
<div class="logincontentform">

    <div id="wraplogin" style="width:350px; height:200px; margin: auto; background-color:#FFF; border:solid 1px #6693cf;">
      <div id="logintitulo"><img src="Images/div_titulo.gif" align="absmiddle">Login</div>
            <div id="mensagemerro"><img src="Images/login/login_erro.png" align="absmiddle" class="loginerro">Usuário 
                e Senha inválidos!</div>
	  <div id="loginimagem"><img src="Images/login/login.png"></div>
      <div id="loginusuario">
      <ul>
      	<li>Usuário</li>
        <li>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="txtbox" style="width:180px" ></asp:TextBox></li>
        <li>Senha</li>
        <li><asp:TextBox ID="txtSenha" runat="server" CssClass="txtbox" style="width:180px" 
                TextMode="Password" ></asp:TextBox></li>
        <li>
            <asp:ImageButton ID="btnLogin" runat="server" ImageUrl="~/Images/Login/btn_login.png" onclick="btnLogin_Click" CssClass="loginbtn" /></li>
      </ul>
      </div>
    </div>
    
</div>    
</div>
<!-- *******************************************************************************
 DESIGN INFORMATION: end div content 
******************************************************************************** --> 


<!-- *******************************************************************************
 DESIGN INFORMATION: start modal 
******************************************************************************** -->
<asp:Button ID="btnPesquisarHidden" runat="server" Text="Button" style="display:none;" />
<cc1:ModalPopupExtender ID="mdlCadastro"  runat="server"  PopupControlID="pnCad" TargetControlID="btnPesquisarHidden" BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
<asp:Panel ID="pnCad" runat="server" CssClass="modal">
<div class="contentformpopup">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td id="formtitulo"><img src="../Images/div_titulo.gif" align="absmiddle"/>Alterar 
        Senha</td>
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
    <td width="25%">Nova Senha: <asp:RequiredFieldValidator ID="rfvSenha" ControlToValidate="txtNovaSenha" runat="server" ErrorMessage="*" ValidationGroup="CadastroSenha"></asp:RequiredFieldValidator></td>
    <td width="25%">Confirmar Nova Senha: </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td><asp:TextBox ID="txtNovaSenha" runat="server" CssClass="txtbox" Width="90%" MaxLength="40"/></td>
    <td><asp:TextBox ID="txtConfirmarSenha" runat="server" CssClass="txtbox" Width="90%" MaxLength="40"/></td>
    <td><asp:CompareValidator ID="cvSenha" runat="server" ControlToCompare="txtConfirmarSenha" ControlToValidate="txtNovaSenha" ErrorMessage="Senhas não Conferem!" ValidationGroup="CadastroSenha"></asp:CompareValidator></td>
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
	        <li><asp:LinkButton ID="lkbSalvar" runat="server" ValidationGroup="CadastroSenha" OnClick="lkbSalvar_Click"><asp:Image ID="imgSalvar" runat="server" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/salvar.gif"/> Salvar</asp:LinkButton></li>                
	        <li class="separator"></li>
	        <li><asp:LinkButton ID="lkbCancelar" runat="server" OnClick="lkbCalcelar_Click"><asp:Image ID="imgSancelar" runat="server" ToolTip="Cancelar" ImageAlign="AbsMiddle" ImageUrl="../Images/Icones/cancelar.gif"/> Cancelar</asp:LinkButton></li>
	    </ul>
	    </div>
	    <!-- **** DESIGN INFORMATION: end botoes form **** -->      
    </td>
  </tr>
</table>
</div>
</asp:Panel>
<!-- *******************************************************************************
 DESIGN INFORMATION: end modal 
******************************************************************************** -->
</form>
</body>
</html>
<!-- **** DESIGN INFORMATION: BODY **** --> 
