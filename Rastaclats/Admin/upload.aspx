<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="upload.aspx.cs" Inherits="Rastaclats.Admin.upload" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <asp:Image ID="Image1" runat="server" />
<asp:FileUpload ID="FileUpload1" runat="server" />
<asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" style="height: 20px" OnClientClick="return confirm('Are you sure you want to upload this picture');"/>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MapPlaceHolder" runat="server">
</asp:Content>