<%@ Page Title="Artist Albums List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArtistAlbums.aspx.cs" Inherits="ChinookSystem.SamplePages.ArtistAlbums" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Artist Albums List (ODS)</h1>
    <asp:GridView ID="ArtistAlbumsList" runat="server"></asp:GridView>
    <asp:ObjectDataSource ID="ArtistAlbumsListODS" runat="server"></asp:ObjectDataSource>
</asp:Content>
