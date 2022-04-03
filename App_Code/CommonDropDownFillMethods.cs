using MultiUserAddressBook.BAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CommonDropDownFillMethods
/// </summary>
public static class CommonDropDownFillMethods
{
    /*public CommonDropDownFillMethods()
    {
        //
        // TODO: Add constructor logic here
        //
    }*/

    #region FillDropDownListCountry
    public static void FillDropDownListCountry(DropDownList ddlCountry, SqlInt32 userID)
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dt = balCountry.SelectForDropDownList(userID);

        if (dt.Rows.Count > 0)
        {
            ddlCountry.DataSource = dt;
            ddlCountry.DataValueField = "CountryID";
            ddlCountry.DataTextField = "CountryName";
            ddlCountry.DataBind();
        }
        ddlCountry.Items.Insert(0, new ListItem("Select Country", "-1"));
    }
    #endregion FillDropDownListCountry

    #region FillDropDownListState
    public static void FillDropDownListState(DropDownList ddlState, SqlInt32 userID)
    {
        StateBAL balState = new StateBAL();
        DataTable dt = balState.SelectForDropDownList(userID);

        if (dt.Rows.Count > 0)
        {
            ddlState.DataSource = dt;
            ddlState.DataValueField = "StateID";
            ddlState.DataTextField = "StateName";
            ddlState.DataBind();
        }

        ddlState.Items.Insert(0, new ListItem("Select State", "-1"));
    }
    #endregion FillDropDownListState

    #region FillDropDownListStateByCountryID
    public static void FillDropDownListStateByCountryID(DropDownList ddlStateID, SqlInt32 CountryID,SqlInt32 userID)
    {
        StateBAL balState = new StateBAL();
        DataTable dt = balState.SelectForDropDownListByCountryID(CountryID,userID);

        if (dt.Rows.Count > 0)
        {
            ddlStateID.DataSource = dt;
            ddlStateID.DataValueField = "StateID";
            ddlStateID.DataTextField = "StateName";
            ddlStateID.DataBind();
        }

        ddlStateID.Items.Insert(0, new ListItem("Select State", "-1"));

    }
    #endregion FillDropDownListStateByCountryID

    #region FillDropDownListCitySelectByStateID
    public static void FillDropDownListCitySelectByStateID(DropDownList ddlCityID, SqlInt32 UserID,SqlInt32 StateID)
    {
        CityBAL balCity = new CityBAL();
        DataTable dt = balCity.SelectForDropDownByStateID(UserID, StateID);

        if (dt.Rows.Count > 0)
        {
            ddlCityID.DataSource = dt;
            ddlCityID.DataValueField = "CityID";
            ddlCityID.DataTextField = "CityName";
            ddlCityID.DataBind();
        }

        ddlCityID.Items.Insert(0, new ListItem("Select City", "-1"));
    }
    #endregion FillDropDownListCitySelectByStateID

    #region Fill CBLContactCategoryList
    public static void FillCBLContactCategoryList(CheckBoxList cblContactCategoryID, SqlInt32 UserID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dt = balContactCategory.SelectForDropDownList(UserID);

        if (dt.Rows.Count > 0)
        {
            cblContactCategoryID.DataSource = dt;
            cblContactCategoryID.DataValueField = "ContactCategoryID";
            cblContactCategoryID.DataTextField = "ContactCategoryName";
            cblContactCategoryID.DataBind();
        }
    }
    #endregion Fill CBLContactCategoryList

}