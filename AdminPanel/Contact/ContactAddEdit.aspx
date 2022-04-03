<%@ Page Title="" Language="C#" MasterPageFile="~/Content/MultiUserAddressBook.master" AutoEventWireup="true" CodeFile="ContactAddEdit.aspx.cs" Inherits="AdminPanel_Contact_ContactAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphHead" runat="Server">
    <style type="text/css">
        .auto-style1 {
            position: relative;
            width: 100%;
            min-height: 1px;
            -webkit-box-flex: 0;
            -ms-flex: 0 0 83.333333%;
            flex: 0 0 83.333333%;
            max-width: 83.333333%;
            left: 0px;
            top: 0px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="Server">
    <div class="row hight">
        <div class="col-md-12">
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
                <h4><span class="required">*</span>Country :</h4>           
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCountryID" OnSelectedIndexChanged="ddlCountryID_SelectedIndexChanged" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountryID" Display="Dynamic" ErrorMessage="Select Country" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>State :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlStateID" OnSelectedIndexChanged="ddlStateID_SelectedIndexChanged" AutoPostBack="True" />
                <asp:RequiredFieldValidator ID="rfvStateName" runat="server" ControlToValidate="ddlStateID" Display="Dynamic" ErrorMessage="Select State" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>City :</h4>
            </div>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlCityID" />
                <asp:RequiredFieldValidator ID="rfvCityName" runat="server" ControlToValidate="ddlCityID" Display="Dynamic" ErrorMessage="Select City" Font-Size="Medium" ForeColor="Red" InitialValue="-1" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>ContactCategory:</h4>
            </div>
            <div class="col-md-10">
                <asp:CheckBoxList runat="server" ID="cblContactCategoryID" RepeatDirection="Horizontal" Font-Size="Large" CellPadding="3" />
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Contact Name :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactName" placeholder="Enter Contact Name" />
                <asp:RequiredFieldValidator ID="rfvContactName" runat="server" ControlToValidate="txtContactName" Display="Dynamic" ErrorMessage="Enter Contact Name" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>ContactNo :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtContactNo" placeholder="Enter ContactNo" />
                <asp:RequiredFieldValidator ID="rfvContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Contact No" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revContactNo" runat="server" ControlToValidate="txtContactNo" Display="Dynamic" ErrorMessage="Enter Valid Contact No" Font-Size="Medium" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>WhatsAppNo :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtWhatsAppNo" placeholder="Enter WhatsAppNo" />
                <asp:RequiredFieldValidator ID="rfvWhatsAppNo" runat="server" ControlToValidate="txtWhatsAppNo" Display="Dynamic" ErrorMessage="Enter WhatsAppNo" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revWhatsAppNo" runat="server" ControlToValidate="txtWhatsAppNo" Display="Dynamic" ErrorMessage="Enter Valid WhatsAppNo" Font-Size="Medium" ForeColor="Red" ValidationExpression="^[7-9][0-9]{9}$" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>BirthDate :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBirthDate" TextMode="Date" />
                <asp:RequiredFieldValidator ID="rfvBirthdate" runat="server" ErrorMessage="Please Enter BirthDate" ControlToValidate="txtBirthDate" Display="Dynamic" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate" Display="Dynamic" ErrorMessage="Enter Valid Date of Birth" ForeColor="Red" Font-Size="Medium" Operator="DataTypeCheck" Type="Date" ValidationGroup="Save"></asp:CompareValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Email :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtEmail" placeholder="Enter Email" />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" Display="Dynamic" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Enter Valid Email Address" Font-Size="Medium" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="Save"></asp:RegularExpressionValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Age :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAge" placeholder="Enter Age" />
                <asp:RequiredFieldValidator ID="rfvAge" runat="server" ControlToValidate="txtAge" Display="Dynamic" ErrorMessage="Enter Age" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Address :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtAddress" placeholder="Enter Address" />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="Enter Address" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>BloodGroup :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtBloodGroup" placeholder="Enter BloodGroup" />
                <asp:RequiredFieldValidator ID="rfvBloodgroup" runat="server" ControlToValidate="txtBloodGroup" Display="Dynamic" ErrorMessage="Enter BloodGroup" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>FacebookID :</h4>
            </div>
            <div class="auto-style1">
                <asp:TextBox runat="server" ID="txtFacebookID" placeholder="Enter FacebookID" />
                <asp:RequiredFieldValidator ID="rfvFacebookID" runat="server" ControlToValidate="txtFacebookID" Display="Dynamic" ErrorMessage="Enter FacebookID" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>LinkedInID :</h4>
            </div>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="txtLinkedInID" placeholder="Enter LinkedInID" />
                <asp:RequiredFieldValidator ID="rfvLinkedInID" runat="server" ControlToValidate="txtLinkedInID" Display="Dynamic" ErrorMessage="Enter LinkedInID" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-2">
                <h4><span class="required">*</span>Contact Photo :</h4>
            </div>
            <div class="col-md-10">
                <asp:FileUpload ID="fuFile" runat="server" />
                <asp:Image runat="server" ID="imgImage" Width="100" AlternateText="Image dosen't upload!"  ImageUrl='<%# Eval("ContactPhotoPath") %>' />
                <%--<asp:LinkButton runat="server" ID="btnDeleteImg" CssClass="btn btn-outline-danger btn-sm deletebtn" CommandName="DeleteImage" CommandArgument='<%# Eval("ContactID").ToString() %>' OnClick="btnDeleteImg_Click"> <i class="fa fa-trash"></i></asp:LinkButton>--%>                            
                <br />
                <asp:RequiredFieldValidator ID="rfvImage" runat="server" ControlToValidate="fuFile" Display="Dynamic" ErrorMessage="Select Contact Photo" Font-Size="Medium" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
            </div>
        </div>
        <br />
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
