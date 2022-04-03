using MultiUserAddressBook.BAL;
using System;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_City_CityList : System.Web.UI.Page
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
        CityBAL balCity = new CityBAL();
        DataTable dtCity = new DataTable();

        dtCity = balCity.SelectAll(Convert.ToInt32(Session["UserId"]));

        gvCity.DataSource = dtCity;
        gvCity.DataBind();
    }
    #endregion FillGridView

    #region gvCity : RowCommand
    protected void gvCity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteCity(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridView();
            }
        }
        #endregion Delete Record
    }
    #endregion gvCity : RowCommand

    #region DeleteCity Record
    private void DeleteCity(SqlInt32 CityID)
    {
        CityBAL balCity = new CityBAL();

        if(balCity.DeleteCity(CityID, Convert.ToInt32(Session["UserId"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data Delete Successfully!";
        }
        else
        {
            lblMessage.Text = balCity.Message;
            //Session["Error"] = balCity.Message;
        }
    }
    #endregion DeleteCity Record
}