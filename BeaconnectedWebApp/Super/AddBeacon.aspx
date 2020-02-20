<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBeacon.aspx.cs" Inherits="BeaconnectedWebApp.Super.AddBeacon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .rbl input[type="radio"]
{
   margin-left: 20px;
   margin-right: 1px;
}
    </style>


    <div style="text-align:center">
            <h1>Registo do Beacon</h1>
            <br />
            <br />
            <table style="margin-left:35%">
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label1" runat="server" Text="Entidade: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                    <asp:DropDownList ID="listaEntidades" runat="server"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEntity" runat="server" Text="*Entidade necessária." ControlToValidate="listaEntidades" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
            <tr >
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label2" runat="server" Text="Estado: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                            <asp:RadioButtonList ID="Estado" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                                <asp:ListItem Text="Ativo" Value="yes"  />
                                <asp:ListItem Text="Inactivo" Value="no" />
                            </asp:RadioButtonList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEstado" runat="server" Text="*Estado necessário." ControlToValidate="Estado" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
         </table>
             <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancelar" Width="150px" class="btn btn-primary" CausesValidation="false" />
            <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Guardar" Width="150px" class="btn btn-primary" 
                    style="margin-left:150px" CausesValidation="true"/>
        
    </div>


</asp:Content>
