<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddEntidade.aspx.cs" Inherits="BeaconnectedWebApp.Super.AddEntidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<style>
    .rbl input[type="radio"]
    {
    margin-left: 20px;
    margin-right: 1px;
    }
</style>

     <div style="text-align:center">
            <h1>Registo da Entidade</h1>
            <br />
            <br />
            <table style="margin-left:35%">
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label1" runat="server" Text="Nome: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                     <asp:TextBox ID="TextBoxNome" runat="server" Width="250px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" Text="*Nome necessário." ControlToValidate="TextBoxNome" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
             <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label3" runat="server" Text="Email: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                   <asp:TextBox ID="TextBoxEmail" runat="server" Width="250px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" Text="*Email necessário." ControlToValidate="TextBoxEmail" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
                <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label4" runat="server" Text="Morada: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                    <asp:TextBox ID="TextBoxMorada" runat="server" Width="250px"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorMorada" runat="server" Text="*Morada necessário." ControlToValidate="TextBoxMorada" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
                </td>              
            </tr>
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                    <asp:Label ID="Label6" runat="server" Text="Tema: "></asp:Label>
                 </td>
                 <td style="padding-bottom:50px">
                   <asp:DropDownList ID="listaTemas" runat="server"></asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidatorEntity" runat="server" Text="*Tema necessário." ControlToValidate="listaTemas" SetFocusOnError="true" Display="Dynamic" ForeColor="Red" ></asp:RequiredFieldValidator>
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
        
            <asp:Label ID="LabelTitle" runat="server" Text="Contéudo publicados por: " Font-Size="XX-Large"  Visible="false"></asp:Label> <asp:Label ID="LabelNome" runat="server"  Font-Size="XX-Large" Visible="false"></asp:Label> 
           <br />
         <br />
         <table style="margin-left:25%">
            <tr>
                <td style="padding-right:25px;padding-bottom:50px">
                     <asp:GridView ID="GridViewConteudos" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" 
                         CellPadding="4" CssClass="table table-striped table-bordered grid"  Width="600px" Visible="false">        
                        <Columns>                 
                        <asp:HyperLinkField DataNavigateUrlFields="conteudo_id" DataTextField="titulo" HeaderText="Titulo" DataNavigateUrlFormatString="EditConteudo.aspx?ConteudoID={0}"/>     
                        <asp:BoundField DataField="beacon_id" HeaderText="Beacon" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField DataField="categoria" HeaderText="Categoria" ItemStyle-HorizontalAlign="Center" /> 
                        <asp:BoundField DataField="m_data" HeaderText="Data de Modificação" ItemStyle-HorizontalAlign="Center" /> 
                        <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" />
                        </Columns> 
                 </asp:GridView>
                </td>
            </tr>
             </table>
         <table style="margin-left:25%">
             <tr>
                 <td>
                    <asp:Label ID="LabelConteudo" runat="server" Text="Conteudo a alterar:" Style="padding-right:20px" Visible="false"></asp:Label>
                 </td>
                <td>
                    <asp:DropDownList ID="listaTitulos" runat="server"></asp:DropDownList>
                 </td>    
                 <td>
                  <asp:RadioButtonList ID="EstadoConteudo" runat="server" RepeatDirection="Horizontal" CssClass="rbl">
                    <asp:ListItem Text="Ativo" Value="yes"  />
                    <asp:ListItem Text="Inactivo" Value="no" />
                </asp:RadioButtonList>
                 </td>
            </tr>
            </table>
         <br />

             <asp:Button ID="Cancel" runat="server" OnClick="Cancel_Click" Text="Cancelar" Width="150px" class="btn btn-primary" CausesValidation="false"/>
            <asp:Button ID="Save" runat="server" OnClick="Save_Click" Text="Guardar" Width="150px" class="btn btn-primary" 
                    style="margin-left:150px" CausesValidation="true"/>
        

     </div>



</asp:Content>
