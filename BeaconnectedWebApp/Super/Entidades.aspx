<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Entidades.aspx.cs" Inherits="BeaconnectedWebApp.Super.Entidades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="EntidadesListTitle" runat="server" class="ContentHead"><h1>Lista de Entidades  

        <asp:Button ID="AddEntidade" runat="server" OnClick="AddEntidade_Click" Text="Nova Entidade" class="btn btn-primary" 
        style="margin-left:850px; width:180px; "/>
         </h1>
    </div>

    <asp:GridView ID="GridEntidade" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" CellPadding="4" CssClass="table table-striped table-bordered grid"  
           Width="800px">
          
             <Columns>  
             <asp:BoundField DataField="entidade_id" HeaderText="ID" ItemStyle-HorizontalAlign="Center" /> 
            <asp:HyperLinkField DataNavigateUrlFields="entidade_id" DataTextField="nome" HeaderText="Nome" DataNavigateUrlFormatString="AddEntidade.aspx?EntidadeID={0}"/> 
            <asp:BoundField DataField="email" HeaderText="Email" ItemStyle-HorizontalAlign="Center" /> 
            <asp:BoundField DataField="morada" HeaderText="Morada" ItemStyle-HorizontalAlign="Center" /> 
            <asp:BoundField DataField="tema_id" HeaderText="Tema" ItemStyle-HorizontalAlign="Center" /> 
            <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" /> 
             </Columns> 
            </asp:GridView>



</asp:Content>
