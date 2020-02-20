<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditConteudo.aspx.cs" Inherits="BeaconnectedWebApp.Super.EditConteudo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<style>
        .rbl input[type="radio"]
{
   margin-left: 20px;
   margin-right: 1px;
}

</style>
    <div style="text-align:center">
            <h1>Novo Conteudo</h1>
            <br />
            <br />
            <table style="margin-left:35%">
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label1" runat="server" Text="Beacon: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                      <asp:DropDownList ID="BeaconsList" runat="server"></asp:DropDownList>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidatorBeacon" runat="server" Text="*Beacon necessário." ControlToValidate="BeaconsList" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
                <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label3" runat="server" Text="Título: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                   <asp:TextBox ID="TextBoxTitulo" runat="server" Width="250px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitulo" runat="server" Text="*Titulo necessário." ControlToValidate="TextBoxTitulo" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
                <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label4" runat="server" Text="Notícia: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                     <asp:TextBox ID="TextBoxNoticia" runat="server" Width="250px" Columns="40" Rows="6"  textmode="MultiLine"></asp:TextBox>
                   
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoticia" runat="server" Text="*Noticia necessária." ControlToValidate="TextBoxNoticia" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
        
            <tr>
                <td>
                    <asp:Label ID="ImagemAtual" runat="server" Text="Imagem Actual: "  Visible="false"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="Imagem" runat="server"  Visible="false"/>
                </td>
            </tr>
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label5" runat="server" Text="Imagem: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                   <asp:FileUpload ID="conteudoImage" runat="server" />
               
                </td>              
            </tr>
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label6" runat="server" Text="Categoria: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                    <asp:TextBox ID="TextBoxCategoria" runat="server" Width="250px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorCategoria" runat="server" Text="*Categoria necessário." ControlToValidate="TextBoxCategoria" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>  
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
             <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancelar" Width="150px" class="btn btn-primary" CausesValidation="false"/>
            <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Guardar" Width="150px" class="btn btn-primary" 
                    style="margin-left:150px" CausesValidation="true"/>
        
    </div>

</asp:Content>
