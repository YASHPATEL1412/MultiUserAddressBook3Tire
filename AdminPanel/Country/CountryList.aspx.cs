using MultiUserAddressBook.BAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Country_CountryList : System.Web.UI.Page
{
    #region Load Evant
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FillGridView();
            lblMessage.Text = "";
        }
    }
    #endregion Load Evant

    #region FillGridView
    private void FillGridView()
    {
        CountryBAL balCountry = new CountryBAL();
        DataTable dt = new DataTable();

        dt = balCountry.SelectAll(Convert.ToInt32(Session["UserID"]));

        gvCountry.DataSource = dt;
        gvCountry.DataBind();
    }
    #endregion FillGridView

    #region gvCountry : RowCommand
    protected void gvCountry_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCountry(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridView();
            }
        }
        #endregion Delete Record
    }
    #endregion gvCountry : RowCommand

    #region DeleteCountry Record
    private void DeleteCountry(SqlInt32 CountryID)
    {
        CountryBAL balCountry = new CountryBAL();

        if(balCountry.DeleteCountry(CountryID, Convert.ToInt32(Session["UserId"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data Delete Successfully!";
        }
        else
        {
            lblMessage.Text = balCountry.Message;
        }
    }
    #endregion DeleteCountry Record
}