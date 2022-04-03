using MultiUserAddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Register : System.Web.UI.Page
{
    #region Load Evant
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Evant

    #region Register Button
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        #region Server Side Validation

        String strErrorMessage = "";
        if(txtUserNameRegister.Text.Trim() == "")
        {
            strErrorMessage += "Enter User Name <br/>";
        }
        if(txtPasswordRegister.Text.Trim() =="")
        {
            strErrorMessage += "Enter PassWord <br/>";
        }
        if(txtDisplayName.Text.Trim() == "")
        {
            strErrorMessage += "Enter Display Name <br/>";
        }
        if(txtMobileNo.Text.Trim() == "")
        {
            strErrorMessage += "Enter Mobile No <br/>";
        }
        if(txtEmail.Text.Trim() == "")
        {
            strErrorMessage += "Enter Email <br/>";
        }
        if(strErrorMessage != "")
        {
            lblMessage.Text = "Kindly Solve the following Errors <br/>" + strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Assign the Value
        UserENT entuser = new UserENT();

        if (txtUserNameRegister.Text.Trim() != "")
            entuser.UserName = txtUserNameRegister.Text.Trim();

        if(txtPasswordRegister.Text.Trim() != "")
            entuser.Password = txtPasswordRegister.Text.Trim();

        if(txtDisplayName.Text.Trim() != "")
            entuser.DisplayName = txtDisplayName.Text.Trim();

        if(txtMobileNo.Text.Trim() != "")
            entuser.MobileNo = txtMobileNo.Text.Trim();

        if(txtEmail.Text.Trim() != "")
            entuser.Email = txtEmail.Text.Trim();
        #endregion Assign the Value

        #region Insert
        UserBAL balUser = new UserBAL();
        if(balUser.Insert(entuser))
        {
            lblMessage.ForeColor = System.Drawing.Color.Green;
            lblMessage.Text = entuser.UserName.ToString() + ": Register successfully";
            ClearControls();
        }
        else
        {
            lblMessage.Text = balUser.Message;
        }
        #endregion Insert
    }
    #endregion Register Button

    #region Clear Controls
    private void ClearControls()
    {
        txtUserNameRegister.Text = "";
        txtPasswordRegister.Text = "";
        txtDisplayName.Text = "";
        txtMobileNo.Text = "";
        txtEmail.Text = "";
    }
    #endregion Clear Controls
}