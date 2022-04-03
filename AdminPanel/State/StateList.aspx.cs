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

public partial class AdminPanel_State_StateList : System.Web.UI.Page
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
        StateBAL balState = new StateBAL();
        DataTable dt = new DataTable();

        dt = balState.SelectAll(Convert.ToInt32(Session["UserID"]));

        gvState.DataSource = dt;
        gvState.DataBind();
    }
    #endregion FillGridView

    #region gvState : RowCommand
    protected void gvState_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Which command button is clicked | e.CommandName
        //Which row is clicked | get the ID of the row | e.CommandArgument

        #region Delete Record
        if (e.CommandName == "DeleteRecord")
        {
            if (e.CommandArgument.ToString() != "")
            {
                DeleteState(Convert.ToInt32(e.CommandArgument.ToString().Trim()));
                FillGridView();
            }
        }
        #endregion Delete Record
    }
    #endregion gvState : RowCommand

    #region DeleteState Record
    private void DeleteState(SqlInt32 StateID)
    {
        StateBAL balState = new StateBAL();
        if(balState.DeleteState(StateID,Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data Delete Successfully!";
        }
        else
        {
            lblMessage.Text = balState.Message;
        }

    }
    #endregion DeleteState Record
}