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

public partial class AdminPanel_City_CityAddEdit : System.Web.UI.Page
{
    #region Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillDropDownList();

            if (RouteData.Values["CityID"] != null)
            {
                lblAddEdit.Text = "Edit City";

                FillControls(Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString().Trim())));
            }
            else
            {
                lblAddEdit.Text = "Add City";
            }
        }
    }
    #endregion Load Event

    #region Button : Save
    protected void btnSave_Click(object sender, EventArgs e)
    {
        #region Server Side Validation
        String strErrorMessage = "";

        if (ddlStateID.SelectedIndex == 0)
            strErrorMessage += "Select State <br />";

        if (txtCityName.Text.Trim() == "")
            strErrorMessage += "Enter City Name <br />";

        if (txtSTDCode.Text.Trim() == "")
            strErrorMessage += "Enter STD Code <br />";

        if (txtPinCode.Text.Trim() == "")
            strErrorMessage += "Enter Pin Code";

        if (strErrorMessage.Trim() != "")
        {
            lblMessage.Text = strErrorMessage;
            return;
        }
        #endregion Server Side Validation

        #region Gather Informaction

        CityENT entCity = new CityENT();

        if (ddlStateID.SelectedIndex > 0)
            entCity.StateID = Convert.ToInt32(ddlStateID.SelectedValue);

        if (txtCityName.Text.Trim() != "")
            entCity.CityName = txtCityName.Text.Trim();

        if (txtSTDCode.Text.Trim() != "")
            entCity.STDCode = txtSTDCode.Text.Trim();

        if (txtPinCode.Text.Trim() != "")
            entCity.PinCode = txtPinCode.Text.Trim();

        #endregion Gather Informaction

        CityBAL balCity = new CityBAL();
        //entCity.UserID = Convert.ToInt32(Session["UserID"]);

        if (RouteData.Values["CityID"] != null)
        {
            #region Update
            entCity.CityID = Convert.ToInt32(EncryptDecrypt.Base64Decode(RouteData.Values["CityID"].ToString()));
            if (balCity.Update(entCity, Convert.ToInt32(Session["UserID"])))
            {
                lblMessage.Text = "Updated Successfully";
                Response.Redirect("~/AdminPanel/City/List", true);
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
            #endregion Update
        }
        else
        {
            #region Insert
            if (balCity.Insert(entCity, Convert.ToInt32(Session["UserID"])))
            {
                ClearControls();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Data Inserted Successfully";
            }
            else
            {
                lblMessage.Text = balCity.Message;
            }
            #endregion Insert
        }
    }
    #endregion Button : Save

    #region Button : Cancel
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/AdminPanel/City/List", true);
    }
    #endregion Button : Cancel

    #region Fill DropDownList
    private void FillDropDownList()
    {
        CommonDropDownFillMethods.FillDropDownListState(ddlStateID, Convert.ToInt32(Session["UserId"]));
    }
    #endregion Fill DropDownList

    #region FillControls
    private void FillControls(SqlInt32 CityID)
    {
        CityENT entCity = new CityENT();
        CityBAL balCity = new CityBAL();

        entCity = balCity.SelectByUserID(CityID, Convert.ToInt32(Session["UserId"]));

        if (entCity != null)
        {
            if (!entCity.CityName.IsNull)
            {
                txtCityName.Text = entCity.CityName.Value.ToString();
            }
            if (!entCity.StateID.IsNull)
            {
                ddlStateID.SelectedValue = entCity.StateID.Value.ToString();
            }
            if (!entCity.PinCode.IsNull)
            {
                txtPinCode.Text = entCity.PinCode.Value.ToString();
            }
            if (!entCity.STDCode.IsNull)
            {
                txtSTDCode.Text = entCity.STDCode.Value.ToString();
            }
        }
    }
    #endregion FillControls

    #region Clear Controls
    private void ClearControls()
    {
        txtCityName.Text = "";
        txtSTDCode.Text = "";
        txtPinCode.Text = "";
        ddlStateID.SelectedIndex = 0;
        ddlStateID.Focus();
    }
    #endregion Clear Controls
}