<%@ Page Title="List View With ODS CRUD" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListViewODSCRUD.aspx.cs" Inherits="WebApp.SamplePages.ListViewODSCRUD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Single Record CRUD using ODS: List View</h1>
    <div class="row">
        <div class="offset-2">
            <blockquote class="alert alert-info">
                This sample will use the asp:ListView control<br />
                This Sample will use ObjectDataSource for the ListView control<br />
                This samnple will use minimal code behind<br />
                This sample will use course MessageUserControl for error handling 
                This sample will use validaiton on the ListVIew control
            </blockquote>
        </div>
    </div>
    <div class="row">
        <asp:ListView ID="ListView1" runat="server">

        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">

        </asp:ObjectDataSource>
    </div>
</asp:Content>
