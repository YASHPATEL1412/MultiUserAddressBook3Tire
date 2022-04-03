﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="CountryAddEdit.aspx.cs" Inherits="AdminPanel_Country_CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
            <%--<h3><strong>Country Add Edit Page</strong></h3>--%>
            <h3><strong><asp:Label runat="server" ID="lblAddEdit"/></strong></h3>
        </div>
    </div><hr class="hrr" />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Label runat="server" ID="lblMessage" EnableViewState="False" Font-Bold="True" Font-Size="Large" ForeColor="Red" />
        </div>
    </div>
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-2">
                <h4>Country Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCountryName" />
                <asp:RequiredFieldValidator ID="rfvCountryName" runat="server" ControlToValidate="txtCountryName" Display="Dynamic" ErrorMessage="Enter Country Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4>Country Code :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtCountryCode" />
                <asp:RequiredFieldValidator ID="rfvCountryCode" runat="server" ControlToValidate="txtCountryCode" Display="Dynamic" ErrorMessage="Enter Contact Code" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
    </div>
    <br />
    <div class="row">
        <div class="col-md-12" style="text-align: center">
            <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" ValidationGroup="Save" />
            <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn-btn-sm" Font-Bold="False" Font-Size="Large" OnClick="btnCancel_Click" />
        </div>
    </div>
    <br />
</asp:Content>
