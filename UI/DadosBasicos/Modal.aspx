<%@ Page Language="C#" MasterPageFile="~/Principal/Principal.Master" AutoEventWireup="true" CodeBehind="Modal.aspx.cs" Inherits="UI.DadosBasicos.Modal" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<form id="form2" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table>
        <tr>
            <td>
            
                <asp:Button ID="Button1" runat="server" Text="Button" /></td>
        </tr>
    </table>
<cc1:ModalPopupExtender ID="mdlCadastro" runat="server" PopupControlID="pnCad" TargetControlID="Button1"
                BackgroundCssClass="modalBackground">
            </cc1:ModalPopupExtender>
            <asp:Panel ID="pnCad" runat="server" CssClass="modal">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td>
                           Teste
                        </td>
                    </tr>
                </table>
            </asp:Panel>
</form>
</asp:Content>
