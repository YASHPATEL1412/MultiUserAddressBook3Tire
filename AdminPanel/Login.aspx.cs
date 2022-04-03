using MultiUserAddressBook.BAL;
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

public partial class AdminPanel_Login : System.Web.UI.Page
{
    #region Load Evant
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #endregion Load Evant

    #region Login Button
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Valid user or not valid User
        //UserName, Password

        #region Server Side Validation
        String strErrorMessage = "";
        
        if(txtUserNameLogin.Text.Trim() == "")
        {
            strErrorMessage += "Enter UserName <br/>"; 
        }
        if(txtPasswordLogin.Text.Trim() == "")
        {
            strErrorMessage += "Enter Password <br/>";
        }
        if(strErrorMessage != "")
        {
            lblMessage.Text = "Kindly Solve the following Errors <br/>" + strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Assign the Value

        UserENT entuser = new UserENT();

        if(txtUserNameLogin.Text.Trim() != "")
            entuser.UserName = txtUserNameLogin.Text.Trim();

        if(txtPasswordLogin.Text.Trim() != "")
            entuser.Password = txtPasswordLogin.Text.Trim();
        #endregion Assign the Value

        UserBAL balUser = new UserBAL();
        UserENT entUser = balUser.ValidateUser(entuser.UserName,entuser.Password);

        if(entUser != null)
        {
            if(!entUser.UserID.IsNull)
            {
                Session["UserID"] = entUser.UserID.Value.ToString();
            }
            if(!entUser.DisplayName.IsNull)
            {
                Session["DisplayName"] = entUser.DisplayName.Value.ToString();
            }
            Response.Redirect("~/AdminPanel/Home.aspx",true);
        }
        else
        {
            lblMessage.Text = balUser.Message;
        }
    }
    #endregion Login Button
}