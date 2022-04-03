using MultiUserAddressBook.BAL;
using MultiUserAddressBook.ENT;
using System;
using System.Data.SqlTypes;
using System.Web.UI;

public partial class AdminPanel_State_StateAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (RouteData.Values["StateID"] != null)
            {
                lblAddEdit.Text = "Edit State";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add State";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        //Server Side Validation
        String strErrorMessage = "";
        if (ddlCountryID.SelectedIndex == 0)
            strErrorMessage += "Select Country <br />";

        if (txtStateName.Text.Trim() == "")
            strErrorMessage += "Enter State Name <br />";

        if (txtStateCode.Text.Trim() == "")
            strErrorMessage += "Enter State Code ";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Informaction
        StateENT entState = new StateENT();

        if (ddlCountryID.SelectedIndex > 0)
            entState.CountryID = Convert.ToInt32(ddlCountryID.SelectedValue);

        if (txtStateName.Text.Trim() != "")
            entState.StateName = txtStateName.Text.Trim();

        if (txtStateCode.Text.Trim() != "")
            entState.StateCode = txtStateCode.Text.Trim();
        #endregion Gather Informaction

        StateBAL balState = new StateBAL();

        if (RouteData.Values["StateID"] != null)
        {
            #region Update Record
            entState.StateID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["StateID"].ToString()));
            if (balState.Update(entState, Convert.ToInt32(Session["UserID"])))
            {
                lblMessage.Text = "Updated Successfully";
                Response.Redirect("~/AdminPanel/State/List", true);
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
            #endregion Update Record
        }
        else
        {
            #region Insert Record
            if (balState.Insert(entState, Convert.ToInt32(Session["UserID"])))
            {
                ClearControls();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balState.Message;
            }
            #endregion Insert Record
        }

    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/State/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListCountry(ddlCountryID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownList

    #region FillControls
    private void FillControls(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        StateENT entState = new StateENT();

        entState = balState.SelectByUserID(StateID, Convert.ToInt32(Session["UserId"]));

        if (entState != null)
        {
            if (!entState.StateName.IsNull)
            {
                txtStateName.Text = entState.StateName.Value.ToString().Trim();
            }
            if (!entState.CountryID.IsNull)
            {
                ddlCountryID.SelectedValue = entState.CountryID.Value.ToString().Trim();
            }
            if (!entState.StateCode.IsNull)
            {
                txtStateCode.Text = entState.StateCode.Value.ToString().Trim();
            }
        }
    }
    #endregion FillControls

    #region ClearControls
    private void ClearControls()
    {
        txtStateName.Text = "";
        txtStateCode.Text = "";
        ddlCountryID.SelectedIndex = 0;
        ddlCountryID.Focus();
    }
    #endregion ClearControls
}