<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Beacons.aspx.cs" Inherits="BeaconnectedWebApp.Super.Beacons" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div id="BeaconsListTitle" runat="server" class="ContentHead"><h1>Lista de  Beacons  

        <asp:Button ID="AddBeacon" runat="server" OnClick="AddBeacon_Click" Text="Novo Beacon" class="btn btn-primary" 
        style="margin-left:850px; width:180px; "/>
         </h1>
    </div>

    <asp:GridView ID="GridBeacons" runat="server" AutoGenerateColumns="False" ShowFooter="False" GridLines="Vertical" 
        CellPadding="4" CssClass="table table-striped table-bordered grid"  Width="800px">
          
        <Columns>  
        <asp:HyperLinkField DataNavigateUrlFields="beacon_id" DataTextField="beacon_id" HeaderText="ID" DataNavigateUrlFormatString="AddBeacon.aspx?BeaconID={0}"/> 
       <asp:BoundField DataField="Entidade.nome" HeaderText="Entidade Associada" ItemStyle-HorizontalAlign="Center" /> 
       <asp:BoundField DataField="estado" HeaderText="Estado" ItemStyle-HorizontalAlign="Center" /> 
        </Columns> 
    </asp:GridView>
    

    
</asp:Content>
