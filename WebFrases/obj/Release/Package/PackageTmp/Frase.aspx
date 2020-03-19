<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Frase.aspx.cs" Inherits="WebFrases.Frase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de Frases">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Frase"></asp:Label>
        <br />
        <asp:TextBox ID="txtFrase" runat="server" Width="205px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlAutor" runat="server" DataSourceID="SqlDataSource7" DataTextField="nome" DataValueField="id"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource7" runat="server" ConnectionString="<%$ ConnectionStrings:sisfrases1ConnectionString %>" SelectCommand="SELECT * FROM [autores]"></asp:SqlDataSource>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlCategoria" runat="server" DataSourceID="SqlDataSource8" DataTextField="categoria" DataValueField="id"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource8" runat="server" ConnectionString="<%$ ConnectionStrings:sisfrases1ConnectionString %>" SelectCommand="SELECT * FROM [categorias]"></asp:SqlDataSource>
        <br />
        <br />
        <asp:Button ID="btSalvar" runat="server" Text="Inserir" OnClick="btSalvar_Click" />
        <asp:Button ID="btCancelar" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btCancelar_Click"  />
        <br />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Registro das Categorias">
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" Width="100%" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="frase" HeaderText="Frase" SortExpression="autor" ConvertEmptyStringToNull="False" >
                <ItemStyle Wrap="True" />
                </asp:BoundField>
                <asp:BoundField DataField="autor" HeaderText="Autor" SortExpression="autor" />
                <asp:BoundField DataField="categoria" HeaderText="Categoria" SortExpression="categoria" />
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sisfrases1ConnectionString %>" SelectCommand="SELECT * FROM [frases]" DeleteCommand="DELETE FROM [frases] WHERE [id] = @id" InsertCommand="INSERT INTO [frases] ([frase], [autor], [categoria]) VALUES (@frase, @autor, @categoria)" UpdateCommand="UPDATE [frases] SET [frase] = @frase, [autor] = @autor, [categoria] = @categoria WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="frase" Type="String" />
                <asp:Parameter Name="autor" Type="Int32" />
                <asp:Parameter Name="categoria" Type="Int32" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="frase" Type="String" />
                <asp:Parameter Name="autor" Type="Int32" />
                <asp:Parameter Name="categoria" Type="Int32" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
