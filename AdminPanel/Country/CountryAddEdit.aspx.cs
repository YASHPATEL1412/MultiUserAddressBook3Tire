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

public partial class AdminPanel_Country_CountryAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (RouteData.Values["CountryID"] != null)
            {
                lblAddEdit.Text = "Edit Country";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add Country";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (txtCountryName.Text.Trim() == "")
            strErrorMessage += "Enter Country Name <br />";

        if (txtCountryCode.Text.Trim() == "")
            strErrorMessage += "Enter Country Code ";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Informaction
        CountryENT entCountry = new CountryENT();

        if (txtCountryName.Text.Trim() != "")
            entCountry.CountryName = txtCountryName.Text.Trim();

        if (txtCountryCode.Text.Trim() != "")
            entCountry.CountryCode = txtCountryCode.Text.Trim();
        #endregion Gather Informaction

        CountryBAL balCountry = new CountryBAL();

        if (RouteData.Values["CountryID"] != null)
        {
            #region Update
            entCountry.CountryID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CountryID"].ToString()));
            if (balCountry.Update(entCountry, Convert.ToInt32(Session["UserID"])))
            {
                lblMessage.Text = "Updated Successfully";
                Response.Redirect("~/AdminPanel/Country/List", true);
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
            #endregion Update
        }
        else
        {
            #region Insert
            if(balCountry.Insert(entCountry, Convert.ToInt32(Session["UserID"])))
            {
                ClearControls();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balCountry.Message;
            }
            #endregion Insert
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/Country/List", true);
    }
    #endregion Button : Cancel

    #region FillControls
    private void FillControls(SqlInt32 CountryID)
    {
        CountryBAL balCountry = new CountryBAL();
        CountryENT entCountry = new CountryENT();

        entCountry = balCountry.SelectByUserID(CountryID, Convert.ToInt32(Session["UserId"]));

        if(entCountry != null)
        {
            if (!entCountry.CountryName.IsNull)
            {
                txtCountryName.Text = entCountry.CountryName.Value.ToString();
            }
            if (!entCountry.CountryCode.IsNull)
            {
                txtCountryCode.Text = entCountry.CountryCode.Value.ToString();
            }
        }
    }
    #endregion FillControls

    #region ClearControls
    private void ClearControls()
    {
        txtCountryName.Text = "";
        txtCountryCode.Text = "";
        txtCountryName.Focus();
    }
    #endregion ClearControls
}