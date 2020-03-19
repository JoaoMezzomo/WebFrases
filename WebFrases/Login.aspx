<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFrases.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Estilos2.css" rel="stylesheet" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" GroupingText="Login de Usuário" HorizontalAlign="Center" CssClass="panel">
                <asp:Label ID="Label1" runat="server" Text="E-mail"></asp:Label>
                <br />
                <asp:TextBox ID="txbEmail" runat="server" Width="180px" class="button"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
                <br />
                <asp:TextBox ID="txbSenha" runat="server" TextMode="Password" Width="180px" class="button"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnEntrar" runat="server" Text="Entrar" OnClick="btnEntrar_Click" Width="90px" class="button"/>
                &nbsp;
                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" Width="90px" OnClick="btnCadastrar_Click" class="button"/>
                &nbsp;<br />
                <asp:Label ID="Label6" runat="server" Font-Bold="False" ForeColor="Red" Text="Email ou senha invalidos" Visible="False"></asp:Label>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:sisfrases1ConnectionString %>" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel2" runat="server" GroupingText="Cadastro de Usuário" Visible="False" HorizontalAlign="Center" CssClass="panel">
                <asp:Label ID="Label5" runat="server" Text="Nome" ></asp:Label>
                <br />
                <asp:TextBox ID="txcNome" runat="server" Width="180px" class="button"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="E-mail" ></asp:Label>
                <br />
                <asp:TextBox ID="txcEmail" runat="server" Width="180px" class="button"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Senha" ></asp:Label>
                <br />
                <asp:TextBox ID="txcSenha" runat="server" TextMode="Password" Width="180px" class="button"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="Button2" runat="server" Text="Confirmar Cadastro" Width="180px" OnClick="Button2_Click" class="button"/>
                &nbsp;<br />
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:sisfrases1ConnectionString %>" SelectCommand="SELECT * FROM [usuarios]"></asp:SqlDataSource>
            </asp:Panel>
            <br />
        </div>
    </form>
</body>
</html>
