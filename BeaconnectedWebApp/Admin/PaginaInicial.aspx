<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaginaInicial.aspx.cs" Inherits="BeaconnectedWebApp.Admin.PaginaInicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

            <div id="ConteudosListTitle" runat="server" class="ContentHead"><h1>Conteúdos  

        <asp:Button ID="AddConteudo" runat="server" OnClick="AddConteudo_Click" Text="Novo Conteúdo" class="btn btn-primary" 
        style="margin-left:750px; width:180px; "/>
         </h1>
                <asp:GridView ID="GridViewConteudos" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" 
             CellPadding="4" CssClass="table table-striped table-bordered grid"  Width="700px">        
                <Columns>  
                <asp:HyperLinkField DataNavigateUrlFields="conteudo_id" DataTextField="titulo" HeaderText="Titulo" DataNavigateUrlFormatString="AddConteudo.aspx?ConteudoID={0}"/>     
                <asp:BoundField DataField="beacon_id" HeaderText="Beacon" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField DataField="categoria" HeaderText="Categoria" ItemStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="m_data" HeaderText="Data de Modificação" ItemStyle-HorizontalAlign="Center" /> 
                <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" />
                </Columns> 
                </asp:GridView>
        </div>

        <div id="AssBeaconsListTitle" runat="server" class="ContentHead"><h1>Beacons Associados</h1>

               <asp:GridView ID="GridBeacons" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" 
             CellPadding="4" CssClass="table table-striped table-bordered grid"  Width="400px">        
                <Columns>  
                <asp:BoundField DataField="beacon_id" HeaderText="Beacon" ItemStyle-HorizontalAlign="Center" />               
               <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" /> 
                </Columns> 
            </asp:GridView>

        </div>




</asp:Content>
