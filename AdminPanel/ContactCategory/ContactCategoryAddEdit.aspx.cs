using MultiUserAddressBook.BAL;
using MultiUserAddressBook.ENT;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI;

public partial class AdminPanel_ContactCategory_ContactCategoryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["ContactCategoryID"] != null)
            {
                lblAddEdit.Text = "Edit ContactCategory";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactCategoryID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add ContactCategory";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";
        if (txtContactCategoryName.Text.Trim() == "")
            strErrorMessage += "Enter ContactCategory Name";

        if (strErrorMessage != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Informaction
        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        if (txtContactCategoryName.Text.Trim() != "")
            entContactCategory.ContactCategoryName = txtContactCategoryName.Text.Trim();
        #endregion Gather Informaction

        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if (RouteData.Values["ContactCategoryID"] != null)
        {
            #region Update Record
            entContactCategory.ContactCategoryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["ContactCategoryID"].ToString()));
            if(balContactCategory.Update(entContactCategory, Convert.ToInt32(Session["UserID"])))
            {
                lblMessage.Text = "Updated Successfully";
                Response.Redirect("~/AdminPanel/ContactCategory/List", true);
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            if (balContactCategory.Insert(entContactCategory, Convert.ToInt32(Session["UserID"])))
            {
                ClearControls();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balContactCategory.Message;
            }
            #endregion Insert Record
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/ContactCategory/List", true);
    }
    #endregion Button : Cancel

    #region FillControls
    private void FillControls(SqlInt32 ContactCategoryID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        ContactCategoryENT entContactCategory = new ContactCategoryENT();

        entContactCategory = balContactCategory.SelectByUserID(ContactCategoryID,Convert.ToInt32(Session["UserID"]));
        if(entContactCategory != null)
        {
            if(!entContactCategory.ContactCategoryName.IsNull)
            {
                txtContactCategoryName.Text = entContactCategory.ContactCategoryName.Value.ToString();
            }
        }
    }
    #endregion FillControls

    #region ClearControls
    private void ClearControls()
    {
        txtContactCategoryName.Text = "";
        txtContactCategoryName.Focus();
    }
    #endregion ClearControls
}