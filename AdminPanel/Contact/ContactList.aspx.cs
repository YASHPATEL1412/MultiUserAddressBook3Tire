using MultiUserAddressBook.BAL;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Contact_ContactList : System.Web.UI.Page
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
        ContactBAL balContact = new ContactBAL();
        DataTable dt = new DataTable();

        dt = balContact.SelectAll(Convert.ToInt32(Session["UserID"]));

        gvContact.DataSource = dt;
        gvContact.DataBind();
    }
    #endregion FillGridView

    #region gvContact : RowCommand
    protected void gvContact_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        #region Delete Record
        
            if (e.CommandName == "DeleteRecord")
            {
                if (e.CommandArgument != null)
                {
                    DeleteContact(Convert.ToInt32(e.CommandArgument.ToString()));
                    FillGridView();
                }
            }
            else if (e.CommandName == "DeleteImage")
            {
                if (e.CommandArgument != null)
                {
                    DeleteContactImage(Convert.ToInt32(e.CommandArgument.ToString()));
                    FillGridView();
                }
            }
        #endregion Delete Record    
    }
    #endregion gvContact : RowCommand

    #region Delete Image
    private void DeleteContactImage(SqlInt32 ContactID)
    {
        ContactBAL balContact = new ContactBAL();

        if(balContact.DeleteImage(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            FileInfo file = new FileInfo(Server.MapPath("~/Content/UserPhoto/" + ContactID.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
                lblMessage.ForeColor = Color.Green;
                lblMessage.Text = "Image Deleted Successfully!";
            }
            else
            {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "Image dosen't upload!";
            }
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }
    }
    #endregion Delete Image

    #region DeleteContact Record
    private void DeleteContact(SqlInt32 ContactID )  /*string FilePath*/
    {
        ContactBAL balContact = new ContactBAL();
        
        if (balContact.DeleteImage(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            DeleteContactCategory(ContactID);

            #region Delete Image
            FileInfo file = new FileInfo(Server.MapPath("~/Content/UserPhoto/" + ContactID.ToString() + ".jpg"));

            if (file.Exists)
            {
                file.Delete();
            }
            #endregion Delete Image

            DeleteContactImage(ContactID);

            lblMessage.ForeColor = Color.Green;
            lblMessage.Text = "Data Delete Successfully!";
        }
        else
        {
            lblMessage.Text = balContact.Message;
        }
    }
    #endregion DeleteContact Record

    #region DeleteContactCategory
    public void DeleteContactCategory(SqlInt32 ContactID)
    {
        ContactWiseContactCategoryBAL balContactWiseContactCategory = new ContactWiseContactCategoryBAL();
        if (!balContactWiseContactCategory.DeleteContactCategory(ContactID, Convert.ToInt32(Session["UserID"])))
        {
            lblMessage.Text = balContactWiseContactCategory.Message;
        }
    }
    #endregion DeleteContactCategory

}
