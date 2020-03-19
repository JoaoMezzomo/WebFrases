<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Categoria.aspx.cs" Inherits="WebFrases.Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de Categorias">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome da Categoria"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="205px"></asp:TextBox>
        <br />
        <asp:Button ID="btSalvar" runat="server" Text="Inserir" OnClick="btSalvar_Click" />
        <asp:Button ID="btCancelar" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btCancelar_Click" />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Registro das Categorias">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="353px" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowSelectButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="categoria" HeaderText="Nome" SortExpression="categoria" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <RowStyle BackColor="#F7F7DE" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#FBFBF2" />
            <SortedAscendingHeaderStyle BackColor="#848384" />
            <SortedDescendingCellStyle BackColor="#EAEAD3" />
            <SortedDescendingHeaderStyle BackColor="#575357" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sisfrases1ConnectionString %>" DeleteCommand="DELETE FROM [categorias] WHERE [id] = @id" InsertCommand="INSERT INTO [categorias] ([categoria]) VALUES (@categoria)" SelectCommand="SELECT * FROM [categorias]" UpdateCommand="UPDATE [categorias] SET [categoria] = @categoria WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="categoria" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="categoria" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
