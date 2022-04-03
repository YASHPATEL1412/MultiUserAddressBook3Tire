using MultiUserAddressBook.BAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_ContactCategory_ContactCategoryList : System.Web.UI.Page
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
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();
        DataTable dt = new DataTable();

        dt = balContactCategory.SelectAll(Convert.ToInt32(Session["UserID"]));

        gvContactCategory.DataSource = dt;
        gvContactCategory.DataBind();
    }
    #endregion FillGridView

    #region gvContactCategory : RowCommand
    protected void gvContactCategory_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteContactCategory(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridView();
            }
        }
        #endregion Delete Record
    }
    #endregion gvContactCategory : RowCommand

    #region DeleteContactCategory Record
    private void DeleteContactCategory(SqlInt32 ContactCategoryID)
    {
        ContactCategoryBAL balContactCategory = new ContactCategoryBAL();

        if(balContactCategory.Delete(ContactCategoryID, Convert.ToInt32(Session["UserId"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data Delete Successfully!";
        }
        else
        {
            lblMessage.Text = balContactCategory.Message;
        }
    }
    #endregion DeleteContactCategory Record
}